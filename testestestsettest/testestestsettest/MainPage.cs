using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            /*LogIn Login = new LogIn();
            Login.ShowDialog();

            //tssUserName.Text = Login.Tag.ToString();//tag는 배열처럼 사용 불가능
            if (Login.Tag.ToString() == "FAIL")
            {
                Application.ExitThread();
                Application.Exit();
                System.Environment.Exit(0);
            }*/


            //this.stbExit.Click += new System.EventHandler(this.stbExit_Click); //버튼에 이벤트 추가 //stbExit_Click이 자동 생성 안된 경우 작성

            //this.stbClose.Click += new System.EventHandler(this.stbClose_Click);//버튼 닫기 이벤트 추가

            //this.M_SYSTEM_DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.drp) 
            //drp == M_SYSTEM_DropDownItemClicked 직접만든것 //메뉴 클릭 이벤트 추가
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssTimer.Text = DateTime.Now.ToString();//breaktime 걸면 1초마다 break 발생
        }

        
    }
}
