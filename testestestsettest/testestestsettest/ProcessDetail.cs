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
        #region 객체사용(DB, 영상정보), mqtt 클라이언트
        // 접속 정보 객체&t상태
        private SqlConnection Connect = null;

        // 영상 정보 객체(주소)
        private string RtspUrl1 = "http://192.168.0.19:8091";
        private string RtspUrl2 = "http://192.168.0.19:8092";
        private string RtspUrl3 = "http://192.168.0.19:8093";
        private string RtspUrl4 = "http://192.168.0.19:8094";

        //mqtt 클라이언트 선언 & 충돌해결용 CallBack
        MqttClient client;
        delegate void UpdateLabelCallback(string message);
        #endregion

        #region 디자이너 Method 지원
        public ProcessDetail()
        {
            InitializeComponent();
        }
        #endregion

        #region 상세보기 Button
        private void btn_detail1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("이력관리로 이동합니다");

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
                    else
                    {
                        MainPage.Instance.tabContainer.TabPages[i].Dispose();
                    }
                }
                MainPage.Instance.tabContainer.AddForm(ShowForm);

            }
            MainPage.Instance.BTNButton.Visible = true;
        }
        #endregion

        #region Mqtt 클래스, 변수, 초기값, 초기화 설정
        public class StatusLed //LED색상 상태 클래스 선언
        {
            //색상변수 선언
            public string Green;
            public string Yellow;
            public string Red;
        }

        //LED색상 상태 클래스 초기화
        private StatusLed statusLed = new StatusLed();

        //value count 초기값 설정
        private int RedCount = 0;
        private int GreenCount = 0;
        private int YellowCount = 0;
        #endregion

        #region Mqtt 신호등 수신용(LED)
        private void UpdateLabels(string message)
        {
            var currentDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);//발행된 json 을 딕셔너리로 받아옴
            string key1 = "";
            var value1 = "1";
            if (currentDatas.ContainsKey("led1"))
            {
                key1 = $"led1_{currentDatas["led1"]}";
            }

            if (currentDatas.ContainsKey("led2"))
            {
                key1 = $"led2_{currentDatas["led2"]}";
            }

            if (currentDatas.ContainsKey("led3"))
            {
                key1 = $"led3_{currentDatas["led3"]}";
            }

            if (currentDatas.ContainsKey("led4"))
            {
                key1 = $"led4_{currentDatas["led4"]}";
            }

            //string currled1 = [currentDatas["led12"], currentDatas["led12"], currentDatas["led12"], currentDatas["led12"]];

            #region 프로세스 별 LED 자료 당 value count(value 값을 더해줌)
            switch (key1)
            {                
                //프로세스 1 LED
                case "led1_G":
                    if (value1 == "1")
                        GreenCount++;
                    break;
                case "led1_Y":
                    if (value1 == "1")
                        YellowCount++;
                    break;
                case "led1_R":
                    if (value1 == "1")
                        RedCount++;
                    break;
                //프로세스 2 LED
                case "led2_G":
                    if (value1 == "1")
                        GreenCount++;
                    break;
                case "led2_Y":
                    if (value1 == "1")
                        YellowCount++;
                    break;
                case "led2_R":
                    if (value1 == "1")
                        RedCount++;
                    break;
                //프로세스 3 LED
                case "led3_G":
                    if (value1 == "1")
                        GreenCount++;
                    break;
                case "led3_Y":
                    if (value1 == "1")
                        YellowCount++;
                    break;
                case "led3_R":
                    if (value1 == "1")
                        RedCount++;
                    break;
                //프로세스 4 LED
                case "led4_G":
                    if (value1 == "1")
                        GreenCount++;
                    break;
                case "led4_Y":
                    if (value1 == "1")
                        YellowCount++;
                    break;
                case "led4_R":
                    if (value1 == "1")
                        RedCount++;
                    break;                
            }
            #endregion

            #region 라벨 별 value count결과값 변환
            // 스레드 UI스레드 분리처리(reciever와 충돌방지)
            LblGreen.BeginInvoke(new Action(() =>
            {
                LblGreen.Text = GreenCount.ToString();
            }));

            LblYellow.BeginInvoke(new Action(() =>
            {
                LblYellow.Text = YellowCount.ToString();
            }));

            LblRed.BeginInvoke(new Action(() =>
            {
                LblRed.Text = RedCount.ToString();
            }));
            #endregion
        }
        #endregion

        #region Mqtt 퍼블리셔리씨버
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                UpdateLabels(message);        // 메세지 발생시 값 변경
            }
            catch (Exception ex)
            {
                //MessageBox.Show("[ERROR] " + ex.Message);
            }
        }        
        #endregion

        #region 정지 Button
        private void btn_stop1_Click(object sender, EventArgs e)
        {
            #region 정상적인 가동정지(Check Box Non Check)
            if (chk_re1.Checked == false)
            {
                try
                {
                    #region ComboBox 선택안한 경우에 대한 예외처리
                    if (cbo_proces1.SelectedItem == null)
                    {
                        MessageBox.Show("프로세스를 먼저 선택하세요.");
                        return;
                    }
                    #endregion

                    #region ComboBox 선택에 따른 변수선언
                    var currProc = (cbo_proces1.SelectedItem as Tb_Process);
                    var processNo = currProc.ProcessNo;
                    var processName = currProc.ProcessName;
                    var endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    #region DB 접속 
                    using (SqlConnection conn = new SqlConnection(Common.DbPath))
                    {
                        conn.Open(); // DB 오픈

                        {
                            #region DB접속&Parameter설정
                            // DB접속쿼리
                            var insQuery1 = @"UPDATE TB_PROCESSWORKrec SET ENDTIME = @endtime
                                           where CONVERT(DATE,STARTTIME) = convert(date,GETDATE()) and endtime is null and PROCESSNO = @PROCESSNO ";
                            SqlCommand cmd1 = new SqlCommand(insQuery1, conn);


                            cmd1.Parameters.AddWithValue("@PROCESSNO", processNo);
                            cmd1.Parameters.AddWithValue("@PROCESSNAME", processName);
                            cmd1.Parameters.AddWithValue("@ENDTIME", endtime);


                            var result1 = cmd1.ExecuteNonQuery();
                            #endregion


                            #region 정지 Button 클릭
                            if (result1 > 0)
                            {
                                MessageBox.Show("프로세스 정지 하였습니다.");

                                try
                                {
                                    var currtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    string pubData = "{ \n" +
                                                  $"   \"motor{processNo}\" : \"N\" \n" +
                                                  "}";

                                    Common.Client.Publish($"main/motor{processNo}", Encoding.UTF8.GetBytes(pubData), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"접속 오류 { ex.Message}");
                                }
                            }
                            else
                            {
                                MessageBox.Show("프로세스 정지 실패했습니다. 관리자에게 문의하세요.");
                            }
                            #endregion
                        }

                    }
                    #endregion


                }
                #region 예외처리
                catch (Exception ex)
                {
                    MessageBox.Show($"예외발생 : {ex.Message}");
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region 가동 Button
        private void btn_work1_Click(object sender, EventArgs e)
        {
            #region 정상적인 가동시작(Check Box Non check)
            if (chk_re1.Checked == false)
            {
                try
                {
                    #region ComboBox 선택안한 경우에 대한 예외처리
                    if (cbo_proces1.SelectedItem == null)
                    {
                        MessageBox.Show("프로세스를 먼저 선택하세요.");
                        return;
                    }
                    #endregion

                    #region ComboBox 선택에 따른 변수선언
                    var currProc = (cbo_proces1.SelectedItem as Tb_Process);
                    var processNo = currProc.ProcessNo;
                    var processName = currProc.ProcessName;
                    var startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    #region DB 접속
                    using (SqlConnection conn = new SqlConnection(Common.DbPath))
                    {                        
                        conn.Open(); // DB 오픈
                        
                        #region DB접속&Parameter설정
                        
                        // DB접속쿼리
                        var insQuery = @"INSERT INTO TB_PROCESSWORKrec (PROCESSNO,  PROCESSNAME,  STARTTIME)
                                     VALUES (@PROCESSNO, @PROCESSNAME, @STARTTIME) ";
                        SqlCommand cmd = new SqlCommand(insQuery, conn);


                        cmd.Parameters.AddWithValue("@PROCESSNO", processNo);
                        cmd.Parameters.AddWithValue("@PROCESSNAME", processName);
                        cmd.Parameters.AddWithValue("@STARTTIME", startTime);

                        // 실행 성공 1, 실패 0
                        var result = cmd.ExecuteNonQuery();
                        #endregion

                        #region 가동 Button 클릭
                        if (result > 0)
                        {
                            MessageBox.Show("프로세스 가동 시작하였습니다.");
                            try
                            {
                                var currtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string pubData = "{ \n" +
                                                  $"   \"motor{processNo}\" : \"Y\" \n" +
                                                  "}";

                                Common.Client.Publish($"main/motor{processNo}", Encoding.UTF8.GetBytes(pubData), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"접속 오류 { ex.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("프로세스 가동 실패했습니다. 관리자에게 문의하세요.");
                        }
                        #endregion

                    }
                    #endregion

                }
                #region 예외처리
                catch (Exception ex)
                {
                    MessageBox.Show($"예외발생 : {ex.Message}");
                }
                #endregion
            }
            #endregion

            #region 비정상적인 상황 종료 후 (재)가동시작(Check Box check)
            if (chk_re1.Checked == true)
            {
                try
                {
                    #region ComboBox 선택안한 경우에 대한 예외처리
                    if (cbo_proces1.SelectedItem == null)
                    {
                        MessageBox.Show("프로세스를 먼저 선택하세요.");
                        return;
                    }
                    #endregion

                    #region ComboBox 선택에 따른 변수선언
                    var currProc = (cbo_proces1.SelectedItem as Tb_Process);
                    var processNo = currProc.ProcessNo;
                    var processName = currProc.ProcessName;
                    var startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    #endregion

                    #region DB 접속
                    using (SqlConnection conn = new SqlConnection(Common.DbPath))
                    {
                        conn.Open(); // DB 오픈

                        #region DB접속&Parameter설정

                        // DB접속쿼리
                        var insQuery = @"INSERT INTO TB_PROCESSWORKrec (PROCESSNO,  PROCESSNAME,  STARTTIME)
                                     VALUES (@PROCESSNO, @PROCESSNAME, @STARTTIME) ";
                        SqlCommand cmd = new SqlCommand(insQuery, conn);


                        cmd.Parameters.AddWithValue("@PROCESSNO", processNo);
                        cmd.Parameters.AddWithValue("@PROCESSNAME", processName);
                        cmd.Parameters.AddWithValue("@STARTTIME", startTime);

                        // 실행 성공 1, 실패 0
                        var result = cmd.ExecuteNonQuery();
                        #endregion

                        #region 가동 Button 클릭
                        if (result > 0)
                        {
                            MessageBox.Show("프로세스 가동 시작하였습니다.");
                            try
                            {
                                var currtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string pubData = "{ \n" +
                                                  $"   \"motor{processNo}\" : \"Y\" \n" +
                                                  "}";

                                Common.Client.Publish($"main/motor{processNo}", Encoding.UTF8.GetBytes(pubData), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"접속 오류 { ex.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("프로세스 가동 실패했습니다. 관리자에게 문의하세요.");
                        }
                        #endregion

                    }
                    #endregion

                }
                #region 예외처리
                catch (Exception ex)
                {
                    MessageBox.Show($"예외발생 : {ex.Message}");
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region ComboBox 선택(프로세스 변경)에 대한 변수 선언
        private void ProcessDetail_Shown(object sender, EventArgs e)
        {
            cbo_proces1.SelectedIndex = cbo_proces1.FindString($"프로세스{Common.ProcessNo}");
        }
        #endregion

        #region ComboBox 선택 시(프로세스 변경 시) 연동
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
                    var selQuery2 = @"SELECT NO, STARTTIME AS 시작시간, ENDTIME AS 종료시간, HAZARDNO AS 위험번호 FROM TB_PROCESSWORKrec 
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
                    grid1.Columns[0].Width = 200;
                    grid1.Columns[1].Width = 200;

                    adapter2.SelectCommand.Parameters.AddWithValue("@PROCESSNO", ProcessNo);
                    DataTable dtTemp2 = new DataTable();
                    adapter2.Fill(dtTemp2);

                    if (dtTemp2.Rows.Count == 0)
                    {
                        grid2.DataSource = null;
                        return;
                    }
                    grid2.DataSource = dtTemp2;
                    grid2.Columns[0].Width = 45;
                    grid2.Columns[1].Width = 173;
                    grid2.Columns[2].Width = 173;
                    grid2.Columns[3].Width = 120;

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
        #endregion

        #region 계획등록 Button
        private void btn_plan_Click(object sender, EventArgs e)
        {
            // 예외처리
            // 입력 검증 - 숫자가 아닌값이 들어오면 팅겨냄
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
        #endregion

        #region DataBinding 설정(타입 지정 후 변수명 선언) <공역>
        // TB_Process에 대한 데이터바인딩
        private BindingList<Tb_Process> Processes;
        #endregion

        #region DataBinding 로드(선언된 함수에 대한 초기화 후 mqtt연결)
        private void ProcessDetail_Load(object sender, EventArgs e)
        {
            InitControlsFromDb();

            #region Mqtt 연결
            try
            {
                Common.Client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

                //서버 통신 할 라즈베리파이 ip
                // 구독할 topic명 = common
                Common.Client.Subscribe(new string[] { "main/led/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }
        #endregion

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

        #region VlcControler 함수(타입 지정, 변수선언, 함수에 대한 초기화)
        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }
        #endregion
    }

    public class moter
    {

    }
}
