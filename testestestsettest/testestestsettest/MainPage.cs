using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testestestsettest
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();

            /*//login form 호출
            LogIn Login = new LogIn();
            Login.ShowDialog();

            tssUserName.Text = Login.Tag.ToString();//tag는 배열처럼 사용 불가능
            if (Login.Tag.ToString() == "FAIL")
            {
                Application.ExitThread();
                Application.Exit();
                System.Environment.Exit(0);
            }*/

        }
        
        private string auth = ""; // 찾아온 타입을 입력한다. 

        private SqlConnection connect = new SqlConnection();


        private void timer1_Tick(object sender, EventArgs e)
        {
            tssTimer.Text = DateTime.Now.ToString();//breaktime 걸면 1초마다 break 발생
        }

        private void stbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stbClose_Click(object sender, EventArgs e)
        {
            //열려있는 화면이 있는지 확인
            if (myTabControl1.TabPages.Count == 0) return;

            //선택된 tab page 닫기
            myTabControl1.SelectedTab.Dispose();
        }

        private void tssFirstPage_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem TempTss = new ToolStripMenuItem();
            TempTss = (ToolStripMenuItem)sender;

            string FormName = TempTss.Tag.ToString();

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "testestestsettest.DLL"); // firstpage 폼이 들어가야함. 
            Type typeForm = assemb.GetType("testestestsettest." + FormName.ToString(), true); // firstpage 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == FormName.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }
            
            myTabControl1.AddForm(ShowForm);
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            /*this.stnDetail.Location = new Point(1575, 40);
            this.tsbClose.Location = new Point(1500, 40);*/

            string FormName = "FirstPage";

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "testestestsettest.DLL"); // 호텔 예약하기 폼이 들어가야함. 
            Type typeForm = assemb.GetType("testestestsettest." + FormName.ToString(), true); // 여기도 호텔 예약하기 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == FormName.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }

            myTabControl1.AddForm(ShowForm);
        }

        private void stnDetail_Click(object sender, EventArgs e)
        {
            string FormName = "ProcessSafety";

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "testestestsettest.DLL"); // firstpage 폼이 들어가야함. 
            Type typeForm = assemb.GetType("testestestsettest." + FormName.ToString(), true); // firstpage 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == FormName.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }

            myTabControl1.AddForm(ShowForm);
        }

        private void tssProcess1_Click(object sender, EventArgs e)
        {
            string FormName = "ProcessDetail";

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "testestestsettest.DLL"); // firstpage 폼이 들어가야함. 
            Type typeForm = assemb.GetType("testestestsettest." + FormName.ToString(), true); // firstpage 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == FormName.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }

            myTabControl1.AddForm(ShowForm);
        }
    }

    public partial class MDIForm : TabPage
    { }

    public partial class MyTabControl : TabControl
    {
        public void AddForm(Form NewForm)
        {
            if (NewForm == null) return;
            NewForm.TopLevel = false;
            MDIForm page = new MDIForm();
            page.Controls.Clear();
            page.Controls.Add(NewForm);
            page.Text = NewForm.Text;
            page.Name = NewForm.Name;
            base.TabPages.Add(page);
            NewForm.Show();
            base.SelectedTab = page;
        }
    }
}
