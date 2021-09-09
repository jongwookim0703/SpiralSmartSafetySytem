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

            //login form 호출
            LogIn Login = new LogIn();
            Login.ShowDialog();

            tssUserName.Text = Login.Tag.ToString();//tag는 배열처럼 사용 불가능
            if (Login.Tag.ToString() == "FAIL")
            {
                Application.ExitThread();
                Application.Exit();
                System.Environment.Exit(0);
            }

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

        public partial class MDIForm : TabPage
        {
            //추가할 내용 없음
        }

        //main 안에 class선언시 main에 종속된 함수로 보게 된다.
        public partial class MyTabControl : TabControl //tabcontrol에 대한 파생class생성 //사용자 정의 control
        {
            public void AddForm(Form NewForm)
            {
                if (NewForm == null) return;    //인자로 받은 form 없는 경우 실행 중지

                NewForm.TopLevel = false;       //인자로 받은 form이 최상위 개체x 선언 == false
                MDIForm page = new MDIForm();   //tab page object 생성 
                page.Controls.Add(NewForm);     //page에 form add
                page.Text = NewForm.Text;       //form에서 지정한 명칭으로 tab page 설정
                page.Name = NewForm.Name;       //form에서 설정한 이름으로 tab page 설정
                base.TabPages.Add(page);        //tab control에 page add
                NewForm.Show();                 //인자로 받은 form show
                base.SelectedTab = page;        //현재 선택된 페이지를 호출한 폼의 페이지로 설정
            }
        }

        private void tssFirstPage_Click(object sender, EventArgs e)
        {
            Button TempBtn = new Button();
            TempBtn = (Button)sender;

            string FormName = TempBtn.Tag.ToString();

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "FirstPage.DLL"); // 호텔 예약하기 폼이 들어가야함. 
            Type typeForm = assemb.GetType("FirstPage." + FormName.ToString(), true); // 여기도 호텔 예약하기 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == FormName.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }
            if (FormName.ToString() == "FM_RESV" || FormName.ToString() == "FM_CHECK")
            {
                if (auth != "C")
                {
                    MessageBox.Show("고객만 열람할수 있습니다.");
                    return;
                }
            }
            
            //myTabControl1.AddForm(ShowForm);
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
