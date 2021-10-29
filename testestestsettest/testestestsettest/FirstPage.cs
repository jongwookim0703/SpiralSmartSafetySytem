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

        private string RtspUrl1 = "https://www.youtube.com/watch?v=Nh27WsNdymo&list=PLotqbLTnmf4L8knQeE4Ylw92jJc0Md2AR&index=36&t=713s";
        private string RtspUrl2 = "https://www.youtube.com/watch?v=Nh27WsNdymo&list=PLotqbLTnmf4L8knQeE4Ylw92jJc0Md2AR&index=36&t=713s";
        private string RtspUrl3 = "https://www.youtube.com/watch?v=Nh27WsNdymo&list=PLotqbLTnmf4L8knQeE4Ylw92jJc0Md2AR&index=36&t=713s";
        private string RtspUrl4 = "https://www.youtube.com/watch?v=Nh27WsNdymo&list=PLotqbLTnmf4L8knQeE4Ylw92jJc0Md2AR&index=36&t=713s";

        delegate void UpdateLabelCallback(string message);

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
                    
                }
                MainPage.Instance.tabContainer.AddForm(ShowForm);


            }
            MainPage.Instance.BTNButton.Visible = true;
        }

        private SqlConnection Connect = null; // 접속 정보 객체 명명

        private void FirstPage_Load(object sender, EventArgs e)
        {
            Gridbinding();
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
                                 	   ,C.HAZARDNO														AS HAZARDNO
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
                                 	 		 SUM(DATEDIFF(MI,P.STARTTIME,P.ENDTIME)) AS SUMTIME,
                                 	 		 Q.HAZARDNO
                                 	  FROM   TB_PROCESSWORKrec AS P 
                                 	 		 LEFT JOIN 
                                 	 	    (SELECT PROCESSNO, MAX(ENDTIME) AS ENDTIME,HAZARDNO
                                 	 	     FROM TB_PROCESSWORKrec
                                 	 	     WHERE HAZARDNO IS NOT NULL AND CONVERT(DATE,STARTTIME) = CONVERT(DATE,GETDATE())
                                 	 	     GROUP BY PROCESSNO,HAZARDNO) AS Q
                                 	 		 ON P.PROCESSNO = Q.PROCESSNO
                                 	  WHERE  CONVERT(DATE,STARTTIME) = CONVERT(DATE,GETDATE())		
                                 	  GROUP BY P.PROCESSNO,Q.HAZARDNO) AS C
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
                grid.Columns[6].HeaderText = "위험이력번호";

                // 그리드 뷰의 폭 지정
                grid.Columns[0].Width = 120;
                grid.Columns[1].Width = 90;
                grid.Columns[2].Width = 130;
                grid.Columns[3].Width = 130;
                grid.Columns[4].Width = 90;
                grid.Columns[5].Width = 140;
                grid.Columns[6].Width = 130;


                //컬럼의 수정 여부를 지정 한다
                grid.Columns[0].ReadOnly = true;
                grid.Columns[1].ReadOnly = true;
                grid.Columns[2].ReadOnly = true;
                grid.Columns[3].ReadOnly = true;
                grid.Columns[4].ReadOnly = true;
                grid.Columns[5].ReadOnly = true;
                grid.Columns[6].ReadOnly = true;

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
    }
}
