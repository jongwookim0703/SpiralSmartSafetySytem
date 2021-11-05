using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt.Messages;
using Vlc.DotNet.Forms;

namespace testestestsettest
{
    public partial class FirstPage : Form
    {
        static FirstPage obj;
        
        public static FirstPage Instance
        {
            get
            {
                if (obj == null)
                {
                    obj = new FirstPage();
                }

                return obj;
            }
        }

        public VlcControl Video1
        {
            get { return vlc1; }
            set { vlc1 = value; }
        }

        public VlcControl Video2
        {
            get { return vlc2; }
            set { vlc2 = value; }
        }

        public VlcControl Video3
        {
            get { return vlc3; }
            set { vlc3 = value; }
        }

        public VlcControl Video4
        {
            get { return vlc4; }
            set { vlc4 = value; }
        }
        
        
        private string RtspUrl1 = "http://192.168.0.19:8091";
        private string RtspUrl2 = "http://192.168.0.19:8092";
        private string RtspUrl3 = "http://192.168.0.19:8093";
        private string RtspUrl4 = "http://192.168.0.19:8094";

        delegate void UpdateLabelCallback(string message);
        private int warn1 = 0, warn2 = 0, warn3 = 0, warn4 = 0;
        private string warnstate1 = "", warnstate2 = "", warnstate3 = "", warnstate4 = "";
        private string disttxt1 = "", disttxt2 = "", disttxt3 = "", disttxt4 = "";
        private string firetxt1 = "", firetxt2 = "", firetxt3 = "", firetxt4 = "";
        private Color color1 = System.Drawing.Color.Transparent, color2 = System.Drawing.Color.Transparent, color3 = System.Drawing.Color.Transparent, color4 = System.Drawing.Color.Transparent;

        public FirstPage()
        {
            InitializeComponent();

        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            vlc1.Stop();
            vlc2.Stop();
            vlc3.Stop();
            vlc4.Stop();

            Button temp = sender as Button;
            Common.ProcessNo = int.Parse(temp.Tag.ToString());

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
                        MainPage.Instance.tabContainer.TabPages[i].Dispose();
                        MainPage.Instance.tabContainer.AddForm(ShowForm);
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

        private SqlConnection Connect = null; // 접속 정보 객체 명명

        private void FirstPage_Load(object sender, EventArgs e)
        {
            Gridbinding();
            #region Mqtt 연결
            
            try
            {
                Common.Client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

                //서버 통신 할 라즈베리파이 ip
                // 구독할 topic명 = common
                Common.Client.Subscribe(new string[] { "main/state/#" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }

        private void vlc1_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void vlc2_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void FirstPage_VisibleChanged(object sender, EventArgs e)
        {
            vlc1.Play(new Uri(RtspUrl1));
            vlc2.Play(new Uri(RtspUrl2));
            vlc3.Play(new Uri(RtspUrl3));
            vlc4.Play(new Uri(RtspUrl4));
            Gridbinding();

            
        }

        private void vlc3_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        private void vlc4_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }

        #region Gridbind
        public void Gridbinding()
        {
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
                //select querry 변경예정
                var selQuery = @"SELECT A.PROCESSNAME													AS PROCESSNAME
                                 	   ,A.MAKER															AS MAKER
                                 	   ,CONCAT(B.PROCESSTIME,'분')										AS PROCESSTIME
                                 	   ,CONCAT(C.SUMTIME,'분')											AS SUMTIME
                                 	   ,CONCAT(100-(100 * C.SUMTIME / B.PROCESSTIME),'%')           	AS STOPRATE
                                 	   ,C.CHECKTIME														AS CHECKTIME
                                 FROM TB_PROCESS AS A 
                                 	  LEFT JOIN
                                 	 (SELECT PROCESSNO,PROCESSNAME,DATEDIFF(MI,PSTARTTIME, PENDTIME) AS PROCESSTIME
                                 	  FROM   TB_PLANrec
                                 	  WHERE  CONVERT(DATE,PSTARTTIME) = CONVERT(DATE,GETDATE())) AS B 			
                                 	  ON A.PROCESSNO = B.PROCESSNO
                                 	  LEFT JOIN
                                 	 (SELECT P.PROCESSNO,
                                 	 		 CASE WHEN MAX(Q.ENDTIME) IS NULL THEN NULL 
                                 	 		 	 WHEN MAX(STARTTIME) < MAX(Q.ENDTIME) THEN CONCAT(CONVERT(CHAR(8),MAX(Q.ENDTIME),8),' - ')
                                 	 		 	 ELSE CONCAT(CONVERT(CHAR(8),MAX(Q.ENDTIME),8),' - ',CONVERT(CHAR(8),MAX(STARTTIME),8)) 
                                 	 		 END AS CHECKTIME,
                                 	 		 SUM(DATEDIFF(MI,P.STARTTIME,P.ENDTIME)) AS SUMTIME
                                 	  FROM   TB_PROCESSWORKrec AS P 
                                 	 		 LEFT JOIN 
                                 	 	    (SELECT PROCESSNO, MAX(ENDTIME) AS ENDTIME
                                 	 	     FROM TB_PROCESSWORKrec
                                 	 	     WHERE HAZARDNO IS NOT NULL AND CONVERT(DATE,STARTTIME) = CONVERT(DATE,GETDATE())
                                 	 	     GROUP BY PROCESSNO) AS Q
                                 	 		 ON P.PROCESSNO = Q.PROCESSNO
                                 	  WHERE  CONVERT(DATE,STARTTIME) = CONVERT(DATE,GETDATE())		
                                 	  GROUP BY P.PROCESSNO) AS C
                                 	  ON B.PROCESSNO = C.PROCESSNO";

                SqlDataAdapter adapter = new SqlDataAdapter(selQuery, Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    return;
                }
                grid.DataSource = dtTemp;   //데이터 그리드 뷰에 데이터 테이블 등록

                //그리드뷰의 헤더 명칭 선언
                grid.Columns[0].HeaderText = "프로세스 명";
                grid.Columns[1].HeaderText = "담당자";
                grid.Columns[2].HeaderText = "계획가동시간";
                grid.Columns[3].HeaderText = "누적가동시간";
                grid.Columns[4].HeaderText = "중단율";
                grid.Columns[5].HeaderText = "최근 점검시간";

                // 그리드 뷰의 폭 지정
                grid.Columns[0].Width = 120;
                grid.Columns[1].Width = 90;
                grid.Columns[2].Width = 130;
                grid.Columns[3].Width = 130;
                grid.Columns[4].Width = 90;
                grid.Columns[5].Width = 140;


                //컬럼의 수정 여부를 지정 한다
                grid.Columns[0].ReadOnly = true;
                grid.Columns[1].ReadOnly = true;
                grid.Columns[2].ReadOnly = true;
                grid.Columns[3].ReadOnly = true;
                grid.Columns[4].ReadOnly = true;
                grid.Columns[5].ReadOnly = true;

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
        #endregion Gridbind

        #region mqtt
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                UpdateWarn(message);        // 메세지 받아올때 실행될 함수
            }
            catch (Exception ex)
            {
                //MessageBox.Show("[ERROR] " + ex.Message);
            }
        }

        //led 값을 받아와 lable값 을 변경하는 함수
        private void UpdateWarn(string message)
        {
            //Mqtt서버에서 전송된 Json메세지를 Dictionary형태로 받아온다.
            var currentDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);//발행된 json 을 딕셔너리로 받아옴

            #region process1
            if (currentDatas.ContainsKey("dist1"))
            {
                warnstate1 = currentDatas["dist1"];
                if (disttxt1 != "")
                {
                    if (warnstate1 == "D")
                    {
                        disttxt1 = " 접근 위험 ";
                    }
                    else if (warnstate1 == "W")
                    {
                        disttxt1 = " 접근 경고 ";
                    }
                    else
                    {
                        if (warn1 > 0)
                        {
                            warn1 -= 1;
                        }
                        disttxt1 = "";
                    }
                }
                else
                {
                    if (warnstate1 == "D")
                    {
                        warn1 += 1;
                        disttxt1 = " 접근 위험 ";
                    }
                    else if (warnstate1 == "W")
                    {
                        warn1 += 1;
                        disttxt1 = " 접근 경고 ";
                    }
                }

                color1 = WarnColor(warnstate1);
                
            }

            if (currentDatas.ContainsKey("flame1"))
            {
                if (warnstate1 != "D")
                {
                    if (warnstate1 != "W" )
                    {
                        warnstate1 = currentDatas["flame1"];
                    }
                }

                if (firetxt1 != "")
                {
                    if (currentDatas["flame1"] == "D")
                    {
                        firetxt1 = " 화재 위험 ";
                    }
                    else
                    {
                        if (warn1 > 0)
                        {
                            warn1 -= 1;
                        }
                        firetxt1 = "";
                    }
                }
                else
                {
                    if (currentDatas["flame1"] == "D")
                    {
                        warn1 += 1;
                        firetxt1 = " 화재 위험 ";
                    }
                }

                color1 = WarnColor(warnstate1);
            }
            #endregion process1

            #region process2
            if (currentDatas.ContainsKey("dist2"))
            {
                warnstate2 = currentDatas["dist2"];
                if (disttxt2 != "")
                {
                    if (warnstate2 == "D")
                    {
                        disttxt2 = " 접근 위험 ";
                    }
                    else if (warnstate2 == "W")
                    {
                        disttxt2 = " 접근 경고 ";
                    }
                    else
                    {
                        if (warn2 > 0)
                        {
                            warn2 -= 1;
                        }
                        disttxt2 = "";
                    }
                }
                else
                {
                    if (warnstate2 == "D")
                    {
                        warn2 += 1;
                        disttxt2 = " 접근 위험 ";
                    }
                    else if (warnstate2 == "W")
                    {
                        warn2 += 1;
                        disttxt2 = " 접근 경고 ";
                    }
                }

                color2 = WarnColor(warnstate2);

            }

            if (currentDatas.ContainsKey("flame2"))
            {
                if (warnstate2 != "D")
                {
                    if (warnstate2 != "W")
                    {
                        warnstate2 = currentDatas["flame2"];
                    }
                }

                if (firetxt2 != "")
                {
                    if (currentDatas["flame2"] == "D")
                    {
                        firetxt2 = " 화재 위험 ";
                    }
                    else
                    {
                        if (warn2 > 0)
                        {
                            warn2 -= 1;
                        }
                        firetxt2 = "";
                    }
                }
                else
                {
                    if (currentDatas["flame2"] == "D")
                    {
                        warn2 += 1;
                        firetxt2 = " 화재 위험 ";
                    }
                }

                color2 = WarnColor(warnstate2);
            }

            #endregion process2

            #region process3
            if (currentDatas.ContainsKey("dist3"))
            {
                warnstate3 = currentDatas["dist3"];
                if (disttxt3 != "")
                {
                    if (warnstate3 == "D")
                    {
                        disttxt3 = " 접근 위험 ";
                    }
                    else if (warnstate3 == "W")
                    {
                        disttxt3 = " 접근 경고 ";
                    }
                    else
                    {
                        if (warn3 > 0)
                        {
                            warn3 -= 1;
                        }
                        disttxt3 = "";
                    }
                }
                else
                {
                    if (warnstate3 == "D")
                    {
                        warn3 += 1;
                        disttxt3 = " 접근 위험 ";
                    }
                    else if (warnstate3 == "W")
                    {
                        warn3 += 1;
                        disttxt3 = " 접근 경고 ";
                    }
                }

                color3 = WarnColor(warnstate3);

            }
            if (currentDatas.ContainsKey("flame3"))
            {
                if (warnstate3 != "D")
                {
                    if (warnstate3 != "W")
                    {
                        warnstate3 = currentDatas["flame3"];
                    }
                }

                if (firetxt3 != "")
                {
                    if (currentDatas["flame3"] == "D")
                    {
                        firetxt3 = " 화재 위험 ";
                    }
                    else
                    {
                        if (warn3 > 0)
                        {
                            warn3 -= 1;
                        }
                        firetxt3 = "";
                    }
                }
                else
                {
                    if (currentDatas["flame3"] == "D")
                    {
                        warn3 += 1;
                        firetxt3 = " 화재 위험 ";
                    }
                }

                color3 = WarnColor(warnstate3);
            }
            #endregion process3

            #region process4
            if (currentDatas.ContainsKey("dist4"))
            {
                warnstate4 = currentDatas["dist4"];
                if (disttxt4 != "")
                {
                    if (warnstate4 == "D")
                    {
                        disttxt4 = " 접근 위험 ";
                    }
                    else if (warnstate4 == "W")
                    {
                        disttxt4 = " 접근 경고 ";
                    }
                    else
                    {
                        if (warn4 > 0)
                        {
                            warn4 -= 1;
                        }
                        disttxt4 = "";
                    }
                }
                else
                {
                    if (warnstate4 == "D")
                    {
                        warn4 += 1;
                        disttxt4 = " 접근 위험 ";
                    }
                    else if (warnstate4 == "W")
                    {
                        warn4 += 1;
                        disttxt4 = " 접근 경고 ";
                    }
                }

                color4 = WarnColor(warnstate4);

            }

            if (currentDatas.ContainsKey("flame4"))
            {
                if (warnstate4 != "D")
                {
                    if (warnstate4 != "W")
                    {
                        warnstate4 = currentDatas["flame4"];
                    }

                }

                if (firetxt4 != "")
                {
                    if (currentDatas["flame4"] == "D")
                    {
                        firetxt4 = " 화재 위험 ";
                    }
                    else
                    {
                        if (warn4 > 0)
                        {
                            warn4 -= 1;
                        }
                        firetxt4 = "";
                    }
                }
                else
                {
                    if (currentDatas["flame4"] == "D")
                    {
                        warn4 += 1;
                        firetxt4 = " 화재 위험 ";
                    }
                }

                color4 = WarnColor(warnstate4);
            }
            #endregion process4

            #region label change
            if (groupBox3.InvokeRequired)
            {
                UpdateLabelCallback lb = new UpdateLabelCallback(UpdateWarn);
                this.Invoke(lb, new object[] { message });
            }
            else
            {
                //label값
                label6.Text = Convert.ToString(warn1);
                label8.Text = Convert.ToString(warn2);
                label10.Text = Convert.ToString(warn3);
                label12.Text = Convert.ToString(warn4);
                lb_process1.Text = disttxt1;
                lb_process2.Text = disttxt2;
                lb_process3.Text = disttxt3;
                lb_process4.Text = disttxt4;
                lb_process5.Text = firetxt1;
                lb_process6.Text = firetxt2;
                lb_process7.Text = firetxt3;
                lb_process8.Text = firetxt4;
                groupBox6.BackColor = color1;
                groupBox4.BackColor = color2;
                groupBox5.BackColor = color3;
                groupBox7.BackColor = color4;

            }
            #endregion label change
        }

        private Color WarnColor(string warnstate)
        {
            if (warnstate == "D")
            {
                return System.Drawing.Color.Red;
            }
            else if (warnstate == "W")
            {
                return System.Drawing.Color.Yellow;
            }
            else
            {
                return System.Drawing.Color.Transparent;
            }
        }

        private void WarnDist(string warnstate,string disttxt,int warn)
        {
            if (disttxt != "")
            {
                if (warnstate == "D")
                {
                    disttxt = " 접근 위험 ";
                }
                else if (warnstate == "W")
                {
                    disttxt = " 접근 경고 ";
                }
                else
                {
                    if (warn > 0)
                    {
                        warn -= 1;
                    }
                    disttxt = "";
                }
            }
            else
            {
                if (warnstate == "D")
                {
                    warn += 1;
                    disttxt = " 접근 위험 ";
                }
                else if (warnstate == "W")
                {
                    warn += 1;
                    disttxt = " 접근 경고 ";
                }
            }
        }
        #endregion mqtt
    }
}
