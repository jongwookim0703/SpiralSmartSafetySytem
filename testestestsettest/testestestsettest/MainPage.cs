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
//using Windows.Devices.Gpio;

namespace testestestsettest
{
    public partial class MainPage : Form
    {
        static MainPage obj;

        #region raspberry
        /*GpioController gpio = GpioController.GetDefault();
        GpioPin pin = gpio.OpenPin(18);*/

        #endregion raspberry

        public static MainPage Instance
        {
            get
            {
                if (obj == null)
                {
                    obj = new MainPage();
                }

                return obj;
            }
        }

        public MyTabControl tabContainer
        {
            get { return myTabControl1; }
            set { myTabControl1 = value; }
        }

        public Button BTNButton
        {
            get { return btnClose; }
            set { btnClose = value; }
        }

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
            obj = this;

            string FormName = "FirstPage";

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "testestestsettest.DLL");
            Type typeForm = assemb.GetType("testestestsettest." + FormName.ToString(), true);
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
            FirstPage.Instance.Video1.Stop();
            FirstPage.Instance.Video2.Stop();
            FirstPage.Instance.Video3.Stop();
            FirstPage.Instance.Video4.Stop();

            obj = this;

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

        private void tssProcess2_Click(object sender, EventArgs e)
        {
            FirstPage.Instance.Video1.Stop();
            FirstPage.Instance.Video2.Stop();
            FirstPage.Instance.Video3.Stop();
            FirstPage.Instance.Video4.Stop();

            obj = this;

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

        private void tssProcess3_Click(object sender, EventArgs e)
        {
            FirstPage.Instance.Video1.Stop();
            FirstPage.Instance.Video2.Stop();
            FirstPage.Instance.Video3.Stop();
            FirstPage.Instance.Video4.Stop();

            obj = this;

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

        private void tssProcess4_Click(object sender, EventArgs e)
        {
            FirstPage.Instance.Video1.Stop();
            FirstPage.Instance.Video2.Stop();
            FirstPage.Instance.Video3.Stop();
            FirstPage.Instance.Video4.Stop();

            obj = this;

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            obj = this;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            //열려있는 화면이 있는지 확인
            if (myTabControl1.TabPages.Count == 0) return;
            //선택된 tab page 닫기
            myTabControl1.SelectedTab.Dispose();
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            /*Boolean led = pin.Read();

            if (led = true)
            {
                label2.Text = "1";
            }
            else
            {
                label2.Text = "0";
            }*/
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
            NewForm.Dock = DockStyle.Fill;
            NewForm.FormBorderStyle = FormBorderStyle.None;
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
