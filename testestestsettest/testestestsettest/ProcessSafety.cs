using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using Newtonsoft.Json;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net;
using System.Diagnostics;

namespace testestestsettest
{

    public partial class ProcessSafety : Form
    {
        private System.Data.SqlClient.SqlConnection Connect = null;
        private string strConn = "Data Source=61.105.9.203; Initial Catalog=AppDev;User ID=spa;Password=spiral_0904";
        private string RtspUrl1 = "http://192.168.0.19:8091";
        private string RtspUrl2 = "http://192.168.0.19:8092";
        private string RtspUrl3 = "http://192.168.0.19:8093";
        private string RtspUrl4 = "http://192.168.0.19:8094";
        private SerialPort mySerial;

        Assembly? CurrentAssembly;
        string? CurrentDirectory;




        //MQtt 라즈베리파이
        delegate void UpdateDataCallback(string message);
        private string co_sub = "";
        private string gas_sub = "";

        public ProcessSafety()
        {
            CurrentAssembly = Assembly.GetEntryAssembly();
            CurrentDirectory = new FileInfo(CurrentAssembly.Location).DirectoryName;

            InitializeComponent();
            //serialPort1.Open();
            mySerial = new SerialPort();
        }

        private void ProcessSafety_Load(object sender, EventArgs e)
        {
            #region 아두이노 송신
            mySerial = new SerialPort();
            mySerial.PortName = "COM3";
            mySerial.BaudRate = 9600;
            mySerial.DataBits = 8;
            mySerial.DataReceived += MySerial_DataReceived;
            mySerial.Open();

            //MessageBox.Show($"{mySerial.IsOpen}");
            #endregion


            // ProcessNo, HAZARDNAME, HAZARDSTATE, MAKEDATE FROM TB_HAZARD
            try
            {
                //Sql 커넥션
                //Sql 커넥션에 등록 및 객체 선언
                Connect = new SqlConnection(Common.DbPath);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT NO,CO,GAS,MAKEDATE FROM TB_ENVIRONMENT", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid1.DataSource = null;
                    return;
                }
                grid1.DataSource = dtTemp;   //데이터 그리드 뷰에 데이터 테이블 등록

                //그리드뷰의 헤더 명칭 선언
                grid1.Columns["NO"].HeaderText = "NO";
                grid1.Columns["CO"].HeaderText = "CO";
                grid1.Columns["GAS"].HeaderText = "GAS";
                grid1.Columns["MAKEDATE"].HeaderText = "발생시간";

                // 그리드 뷰의 폭 지정
                grid1.Columns[0].Width = 40;
                grid1.Columns[1].Width = 50;
                grid1.Columns[2].Width = 50;
                grid1.Columns[3].Width = 140;


                //컬럼의 수정 여부를 지정 한다
                grid1.Columns["NO"].ReadOnly = true;    //기본키라 수정하면 안됌, 단 신규로 추가될때는 해야함
                grid1.Columns["CO"].ReadOnly = true;
                grid1.Columns["GAS"].ReadOnly = true;
                grid1.Columns["MAKEDATE"].ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();    //DB 연결 끊어주기
            }

            //mqtt 연결
            try
            {
                //Common.Client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived3;

                /*Common.Client.Subscribe(new string[] { "main/env/#" },
                    new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE }); // 구독할 topic명 = common*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void MySerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 시리얼통신 하나 스레드 / UI스레드 
            string in_data = mySerial.ReadLine();
            Debug.WriteLine(in_data);
            Thread.Sleep(1000); // 1초동안 딜레이
            var split_val = in_data.Replace("\r", "").Split(':');

            if (txtCO.InvokeRequired)
            {
                // 작업쓰레드인 경우
                txtCO.BeginInvoke(new Action(() => txtCO.Text = split_val[0]));
            }
            else
            {
                // UI 쓰레드인 경우
                txtCO.Text = split_val[0];
            }

            if (txtGas.InvokeRequired)
            {
                // 작업쓰레드인 경우
                txtGas.BeginInvoke(new Action(() => txtGas.Text = split_val[1]));
            }
            else
            {
                // UI 쓰레드인 경우
                txtGas.Text = split_val[1];
            }
        }

        #region Mqtt
        private void Client_MqttMsgPublishReceived3(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                UpdateText(message);        // 메세지 발생시 값 변경
            }
            catch (Exception ex)
            {
                MessageBox.Show("[ERROR] " + ex.Message);
            }
        }

        private void UpdateText(string message)
        {
            var currentDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);//발행된 json 을 딕셔너리로 받아옴

            if (currentDatas.ContainsKey("co"))
            {
                co_sub = currentDatas["co"];
            }

            if (currentDatas.ContainsKey("gas"))
            {
                gas_sub = currentDatas["gas"];
            }

            if (panel1.InvokeRequired)
            {
                UpdateDataCallback lb = new UpdateDataCallback(UpdateText);
                this.Invoke(lb, new object[] { message });
            }
            else
            {
                txtCO.Text = co_sub;
                txtGas.Text = gas_sub;
            }
        }

        #endregion Mqtt

        private void button1_Click(object sender, EventArgs e)
        {
            vlc1.Stop();
            vlc2.Stop();
            vlc3.Stop();
            vlc4.Stop();

            Button temp = sender as Button;
            Common.ProcessNo = int.Parse(temp.Tag.ToString()); //프로세스 넘버 결정

            MessageBox.Show("프로세스 관리로 이동합니다");
            //ProcessDetail processDetail = new ProcessDetail();
            //processDetail.ShowDialog();
            if (!MainPage.Instance.tabContainer.Controls.ContainsKey("ProcessDetail"))
            {
                //MainPage.Instance
                string FormName = "ProcessDetail";

                Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "testestestsettest.DLL");
                Type typeForm = assemb.GetType("testestestsettest." + FormName.ToString(), true);
                Form ShowForm = (Form)Activator.CreateInstance(typeForm);

                for (int i = 0; i < MainPage.Instance.tabContainer.TabPages.Count; i++)
                {
                    if (MainPage.Instance.tabContainer.TabPages[i].Name == FormName.ToString())
                    {
                        MainPage.Instance.tabContainer.SelectedTab = MainPage.Instance.tabContainer.TabPages[i];
                        return;
                    }
                    else
                    {
                        MainPage.Instance.tabContainer.TabPages[i].Dispose();
                    }
                }

                MainPage.Instance.tabContainer.AddForm(ShowForm);
            }
        }

        // btn 가동 버튼은 visible false로 수정하기 
        private void btnRun_Click(object sender, EventArgs e)
        {
            //<생각정리>
            //C#의 프로그램상에서 가동버튼을 클릭함 => DB에서 신호를 보냄(sql로 요청함)              => DB의 설비이력에 정지시간 및 이력이 등록됨(Stored procedure에서 update 구문을 작성함) (테이블 설계상 이게 맞을거 같은데?)
            try
            {
                if (grid1.Rows.Count == 0) return;
                string nores = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                if (MessageBox.Show("설비를 가동 하시겠습니까?", "가동", MessageBoxButtons.YesNo)
                    == DialogResult.Yes) return;

                string Num = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();

                SqlCommand cmd = new SqlCommand();
                SqlTransaction Tran;   //승인을 할지 거절을 할지 권한을 가지겟다

                Connect = new SqlConnection(Common.DbPath);
                Connect.Open();

                Tran = Connect.BeginTransaction("TestTran");
                cmd.Transaction = Tran;
                cmd.Connection = Connect;

                //주석 사유 : 정지버튼과 동일한 사유
                //cmd.CommandText = "INSERT INTO TB_WARNINGMANAGE(custID, resDate,  resState,  roomNum ,NoShow) " +
                //                          "VALUES('" + Common.LogInId + "','" + Date + "','" + "Y" + "','" + Num + "','" + "N" + "')" +
                //                  "INSERT INTO TB_ENVIROMENTSTATE(MAKEDATE,CHECKFLAG,CHECKDATE) " +
                //                          "VALUES('" + Num + "','" + Date + "')";
                cmd.ExecuteNonQuery();

                // 성공 시 DB COMMIT

                if (nores == "가동")
                {
                    Tran.Commit();
                    MessageBox.Show("설비가 가동 되었습니다.");
                }
                else
                {
                    MessageBox.Show("설비를 가동할 수 없습니다.");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid1.Rows.Count == 0) return;
                string nores = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                if (MessageBox.Show("설비를 정지 하시겠습니까?", "정지", MessageBoxButtons.YesNo)
                    == DialogResult.No) return;

                string Num = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();

                SqlCommand cmd = new SqlCommand();
                SqlTransaction Tran;   //승인을 할지 거절을 할지 권한을 가지겟다

                Connect = new SqlConnection(Common.DbPath);
                Connect.Open();

                Tran = Connect.BeginTransaction("TestTran");
                cmd.Transaction = Tran;
                cmd.Connection = Connect;

                //주석 사유 : TRANSACTION으로 걸려야 할 값 및 삽입되어야 할 값에 대해서 DB.Helper 안쓴버전으로 입력하였으나, 추가검토가 필요함.  
                //cmd.CommandText = "INSERT INTO TB_WARNINGMANAGE(custID, resDate,  resState,  roomNum ,NoShow) " +
                //                          "VALUES('" + Common.LogInId + "','" + Date + "','" + "Y" + "','" + Num + "','" + "N" + "')" +
                //                  "INSERT INTO TB_ENVIROMENTSTATE(MAKEDATE,CHECKFLAG,CHECKDATE) " +
                //                          "VALUES('" + Num + "','" + Date + "')";
                cmd.ExecuteNonQuery();

                // 성공 시 DB COMMIT

                if (nores == "정지가능")
                {
                    Tran.Commit();
                    MessageBox.Show("정지되었습니다.");
                }
                else
                {
                    MessageBox.Show("정지할 수 없습니다..");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        

        private void vlc1_VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(CurrentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void vlc2_VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(CurrentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void vlc3_VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(CurrentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void vlc4_VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(CurrentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void ProcessSafety_VisibleChanged(object sender, EventArgs e)
        {
            vlc1.Play(new Uri(RtspUrl1));
            vlc2.Play(new Uri(RtspUrl2));
            vlc3.Play(new Uri(RtspUrl3));
            vlc4.Play(new Uri(RtspUrl4));
        }



    }
}
