﻿using System;
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
        //접속 주소
        private string strConn = Common.DbPath;

        private void FirstPage_Load(object sender, EventArgs e)
        {
            //Gridbinding();
        }

        private void lb_process1_TextChanged(object sender, EventArgs e)
        {
            //db에서 받아오기
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
                var selQuery = @"";

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
                grid.Columns["PROCESSNAME"].HeaderText = "프로세스 명";
                grid.Columns["MAKER      "].HeaderText = "담당자";
                grid.Columns["PROCESSTIME"].HeaderText = "계획가동시간";
                grid.Columns["SUMTIME    "].HeaderText = "누적가동시간";
                grid.Columns["STOPRATE   "].HeaderText = "중단율";
                grid.Columns["CHECKTIME  "].HeaderText = "최근 점검시간";
                grid.Columns["CHECKER    "].HeaderText = "점검자";
                grid.Columns["HAZARDNO   "].HeaderText = "위험이력번호";

                // 그리드 뷰의 폭 지정
                grid.Columns[0].Width = 70;
                grid.Columns[1].Width = 70;
                grid.Columns[2].Width = 70;
                grid.Columns[3].Width = 100;
                grid.Columns[4].Width = 100;
                grid.Columns[5].Width = 100;
                grid.Columns[6].Width = 100;
                grid.Columns[7].Width = 100;


                //컬럼의 수정 여부를 지정 한다
                grid.Columns["PROCESSNAME"].ReadOnly = true;
                grid.Columns["MAKER      "].ReadOnly = true;
                grid.Columns["PROCESSTIME"].ReadOnly = true;
                grid.Columns["SUMTIME    "].ReadOnly = true;
                grid.Columns["STOPRATE   "].ReadOnly = true;
                grid.Columns["CHECKTIME  "].ReadOnly = true;
                grid.Columns["CHECKER    "].ReadOnly = true;
                grid.Columns["HAZARDNO   "].ReadOnly = true;
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
    }
}
