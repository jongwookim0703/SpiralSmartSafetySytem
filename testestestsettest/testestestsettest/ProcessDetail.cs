using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using System.Data.SqlClient;
using testestestsettest.Models;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Linq.Expressions;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;


namespace testestestsettest
{
    public partial class ProcessDetail : Form
    {
        // 접속 정보 객체 명명
        private SqlConnection Connect = null;

        private string RtspUrl1 = "http://archive.org/download/SampleMpeg4_201307/sample_mpeg4.mp4";
        private string RtspUrl2 = "http://assets.appcelerator.com.s3.amazonaws.com/video/media.m4v";
        private string RtspUrl3 = "http://archive.org/download/SampleMpeg4_201307/sample_mpeg4.mp4";
        private string RtspUrl4 = "http://assets.appcelerator.com.s3.amazonaws.com/video/media.m4v";
        // 데이터베이스 관리권한
        
        // 데이터베이스 명령전달

        // 접속 주소
        //mqtt참고
        MqttClient client;
        delegate void UpdateLabelCallback(string message);

        public ProcessDetail()
        {
            InitializeComponent();
        }

        private void btn_detail1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("상세보기로 이동합니다");

            if (!MainPage.Instance.tabContainer.Controls.ContainsKey("Record"))
            {
                //MainPage.Instance
                string FormName = "Record";

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
                }
                MainPage.Instance.tabContainer.AddForm(ShowForm);

            }
            MainPage.Instance.BTNButton.Visible = true;
        }
        private void UpdateLabel(string message)
        {
            var currentDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);//발행된 json 을 딕셔너리로 받아옴
            var currled1 = currentDatas["led12"];

            //string currled1 = [currentDatas["led12"], currentDatas["led12"], currentDatas["led12"], currentDatas["led12"]];
            if (panel1.InvokeRequired)
            {
                UpdateLabelCallback lb = new UpdateLabelCallback(UpdateLabel);
                this.Invoke(lb, new object[] { message });
            }
            else
            {
                this.label2.Text = currled1.ToString();
                //this.label2.Text = currled1[0].ToString();
            }
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                UpdateLabel(message);        // 메세지 발생시 값 변경
            }
            catch (Exception ex)
            {
                MessageBox.Show("[ERROR] " + ex.Message);
            }
        }

        private void btn_stop1_Click(object sender, EventArgs e)
        {
            if (chk_re1.Checked == false)
            {
                try
                {
                    #region Flag 처리
                    //Flag(가동 중인 경우 가동이 다시 눌리지 않도록 작성하기 위함)
                    //if (grid1.Rows.Count == 0) return;
                    //string nores = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                    //if (MessageBox.Show("설비를 가동 하시겠습니까?", "가동", MessageBoxButtons.YesNo)
                    //    == DialogResult.Yes) return;
                    //string Num = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                    //if (nores == "가동")
                    //{
                    //    Tran.Commit();
                    //    MessageBox.Show("설비가 가동 되었습니다.");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("설비를 가동할 수 없습니다.");
                    //}
                    #endregion

                    if (cbo_proces1.SelectedItem == null)
                    {
                        MessageBox.Show("프로세스를 먼저 선택하세요.");
                        return;
                    }

                    var currProc = (cbo_proces1.SelectedItem as Tb_Process);
                    var processNo = currProc.ProcessNo;
                    var processName = currProc.ProcessName;
                    var endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                    using (SqlConnection conn = new SqlConnection(Common.DbPath))
                    {
                        conn.Open(); // DB 오픈

                        {
                            var insQuery1 = @"UPDATE TB_PROCESSWORKrec SET ENDTIME = @endtime
                                           where CONVERT(DATE,STARTTIME) = convert(date,GETDATE()) and endtime is null";
                            SqlCommand cmd1 = new SqlCommand(insQuery1, conn);


                            cmd1.Parameters.AddWithValue("@PROCESSNO", processNo);
                            cmd1.Parameters.AddWithValue("@PROCESSNAME", processName);
                            cmd1.Parameters.AddWithValue("@ENDTIME", endtime);

                            var result1 = cmd1.ExecuteNonQuery(); // 실행 성공 1, 실패 0

                            if (result1 > 0)
                            {
                                MessageBox.Show("프로세스 정지 하였습니다.");
                            }
                            else
                            {
                                MessageBox.Show("프로세스 정지 실패했습니다. 관리자에게 문의하세요.");
                            }
                        }

                    }
                    //mqtt 연결
                    try
                    {
                        IPAddress hostIP;

                        hostIP = IPAddress.Parse("127.0.0.1");
                        client = new MqttClient(hostIP);
                        client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

                        client.Connect("192.168.0.10");//서버 통신 할 라즈베리파이 ip
                        client.Subscribe(new string[] { "common" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE }); // 구독할 topic명 = common
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"예외발생 : {ex.Message}");
                }
            }
        }

        private void btn_work1_Click(object sender, EventArgs e)
        {
            if (chk_re1.Checked == false)
            {
                try
                {
                    #region Flag 처리
                    //Flag(가동 중인 경우 가동이 다시 눌리지 않도록 작성하기 위함)
                    //if (grid1.Rows.Count == 0) return;
                    //string nores = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                    //if (MessageBox.Show("설비를 가동 하시겠습니까?", "가동", MessageBoxButtons.YesNo)
                    //    == DialogResult.Yes) return;
                    //string Num = grid1.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                    //if (nores == "가동")
                    //{
                    //    Tran.Commit();
                    //    MessageBox.Show("설비가 가동 되었습니다.");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("설비를 가동할 수 없습니다.");
                    //}
                    #endregion

                    if (cbo_proces1.SelectedItem == null)
                    {
                        MessageBox.Show("프로세스를 먼저 선택하세요.");
                        return;
                    }

                    var currProc = (cbo_proces1.SelectedItem as Tb_Process);
                    var processNo = currProc.ProcessNo;
                    var processName = currProc.ProcessName;
                    var startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    using (SqlConnection conn = new SqlConnection(Common.DbPath))
                    {
                        conn.Open(); // DB 오픈

                        var insQuery = @"INSERT INTO TB_PROCESSWORKrec (PROCESSNO,  PROCESSNAME,  STARTTIME)
                                     VALUES (@PROCESSNO, @PROCESSNAME, @STARTTIME) ";
                        SqlCommand cmd = new SqlCommand(insQuery, conn);


                        cmd.Parameters.AddWithValue("@PROCESSNO", processNo);
                        cmd.Parameters.AddWithValue("@PROCESSNAME", processName);
                        cmd.Parameters.AddWithValue("@STARTTIME", startTime);

                        var result = cmd.ExecuteNonQuery(); // 실행 성공 1, 실패 0

                        if (result > 0)
                        {
                            MessageBox.Show("프로세스 가동 시작하였습니다.");
                        }
                        else
                        {
                            MessageBox.Show("프로세스 가동 실패했습니다. 관리자에게 문의하세요.");
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"예외발생 : {ex.Message}");
                }
            }
        }

        private void cbo_proces1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 주석
            /*try
            {
                //콤보박스에서 선택된 프로세스의 조회
                // 접속 정보 커넥션에 등록 및 객체 선언
                Connect = new SqlConnection(Common.DbPath);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT NO, PROCESSNO, PROCESSNAME, ONOFFFLAG, APPROACHWARN, FIREWARN, MAKEDATE, CHECKFLAG,CHECKDATE,MAKER FROM TB_WARNINGMANAGE", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                cbo_proces1.DataSource = dtTemp;
                cbo_proces1.DisplayMember = "NO";                 // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "PROCESSNO";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "PROCESSNAME";        // 눈으로 보여줄 항목

                cbo_proces1.DisplayMember = "ONOFFFLAG";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "APPROACHWARN";       // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "FIREWARN";           // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "MAKEDATE";           // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "CHECKFLAG";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "CHECKDATE";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "MAKER";              // 눈으로 보여줄 항목


                cbo_proces1.ValueMember = "TB_WARNINGMANAGE";     // 실제 데이터를 처리할 코드 항목
                cbo_proces1.Text = "";

                // 이미지 그룹박스 사이즈 조절
                groupBox2.Size = new System.Drawing.Size(Convert.ToInt32(this.Size.Width / 2), 563);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();              //DB 연결 끊어주기
            }*/

            #endregion 

            try
            {
                Debug.WriteLine("TEST");
                //TEST FAIL

                Debug.WriteLine(cbo_proces1.SelectedIndex);
                if (cbo_proces1.SelectedItem != null)
                {
                    Debug.WriteLine((cbo_proces1.SelectedItem as Tb_Process).ProcessNo);

                    var CurrProcess = (cbo_proces1.SelectedItem as Tb_Process);
                    var ProcessNo = CurrProcess.ProcessNo;

                    var RtspUrl = string.Empty;

                    switch (ProcessNo)
                    {
                        case 1:
                            RtspUrl = RtspUrl1;
                            break;
                        case 2:
                            RtspUrl = RtspUrl2;
                            break;
                        case 3:
                            RtspUrl = RtspUrl3;
                            break;
                        case 4:
                            RtspUrl = RtspUrl4;
                            break;
                        default:
                            RtspUrl = RtspUrl1;
                            break;
                    }

                    vlcControl.Play(new Uri(RtspUrl));
                    LblProcessName.Text = CurrProcess.ProcessName;

                    //Sql 커넥션
                    //Sql 커넥션에 등록 및 객체 선언
                    Connect = new SqlConnection(Common.DbPath);
                    Connect.Open();//DB열었음

                    if (Connect.State != System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                        return;
                    }
                    //SELECT QUARRY로 GRID에 띄울 쿼리문을 작성한다.(2개)
                    var selQuery1 = @"SELECT PSTARTTIME AS 계획시작시간, PENDTIME AS 계획종료시간 FROM TB_PLANrec 
	                                          WHERE PROCESSNO = @PROCESSNO 
		                                      ORDER BY PROCESSNAME";
                    var selQuery2 = @"SELECT NO, STARTTIME AS 시작시간, ENDTIME AS 죵료시간, HAZARDNO AS 위험번호 FROM TB_PROCESSWORKrec 
	                                          WHERE PROCESSNO = @PROCESSNO 
		                                      ORDER BY PROCESSNAME";

                    SqlDataAdapter adapter1 = new SqlDataAdapter(selQuery1, Connect);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(selQuery2, Connect);

                    adapter1.SelectCommand.Parameters.AddWithValue("@PROCESSNO", ProcessNo);
                    DataTable dtTemp1 = new DataTable();
                    adapter1.Fill(dtTemp1);

                    if (dtTemp1.Rows.Count == 0)
                    {
                        grid1.DataSource = null;
                        return;
                    }
                    grid1.DataSource = dtTemp1;   //데이터 그리드 뷰에 데이터 테이블 등록


                    adapter2.SelectCommand.Parameters.AddWithValue("@PROCESSNO", ProcessNo);
                    DataTable dtTemp2 = new DataTable();
                    adapter2.Fill(dtTemp2);

                    if (dtTemp2.Rows.Count == 0)
                    {
                        grid2.DataSource = null;
                        return;
                    }
                    grid2.DataSource = dtTemp2;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();    //DB 연결 끊어주기
            }
        }

        private void btn_plan_Click(object sender, EventArgs e)
        {
            // 1. 입력 검증 - 숫자가 아닌값이 들어오면 팅겨냄
            try
            {
                var pstarttime = DateTime.Parse(txt_start.Text);
                DateTime pendtime = DateTime.Parse(txt_end.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("계획 입력시간이 틀렸습니다.");
                return;
            }

            SetDataToDb();
        }

        private BindingList<Tb_Process> Processes;

        private void ProcessDetail_Load(object sender, EventArgs e)
        {
            InitControlsFromDb();
        }

        #region DB처리 영역 
        private void SetDataToDb()
        {
            // 1-1. 콤보박스 값 가져오기
            Tb_Process temp = cbo_proces1.SelectedItem as Tb_Process;

            // 2. 디비 입력
            using (SqlConnection conn = new SqlConnection(Common.DbPath))
            {
                conn.Open();

                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("USP_PLANrec_INS", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCESSNO", temp.ProcessNo);
                cmd.Parameters.AddWithValue("@PROCESSNAME", temp.ProcessName);
                cmd.Parameters.AddWithValue("@MAKER", "SYSTEM");
                cmd.Parameters.AddWithValue("@PSTARTTIME", txt_start.Text);
                cmd.Parameters.AddWithValue("@PENDTIME", txt_end.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    // 성공
                    trans.Commit();
                    MessageBox.Show("입력성공했습니다");
                }
                else
                {
                    // 실패 
                    trans.Rollback();
                    MessageBox.Show("입력실패했습니다");
                }
            }
        }

        private void InitControlsFromDb()
        {
            Processes = new BindingList<Tb_Process>();

            // DB에서 프로세스 가져와서 콤보박스 바인딩
            using (SqlConnection conn = new SqlConnection(Common.DbPath))
            {
                conn.Open();

                var selquery = @"SELECT PROCESSNO
                                      , PROCESSNAME
                                   FROM TB_PROCESS";

                SqlCommand cmd = new SqlCommand(selquery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Processes.Add(new Tb_Process
                    {
                        ProcessNo = (int)reader["PROCESSNO"],
                        ProcessName = reader["PROCESSNAME"].ToString()
                    });
                }
            }

            // Combobox에 바인딩
            cbo_proces1.DataSource = Processes;
            cbo_proces1.ValueMember = "PROCESSNO";
            cbo_proces1.DisplayMember = "PROCESSNAME";
            cbo_proces1.SelectedIndex = 0;
        }

        #endregion

        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void ProcessDetail_Shown(object sender, EventArgs e)
        {
            cbo_proces1.SelectedIndex = cbo_proces1.FindString($"프로세스{Common.ProcessNo}");
        }
    }
}
