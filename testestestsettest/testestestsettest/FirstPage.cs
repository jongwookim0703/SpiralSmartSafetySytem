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
    public partial class FirstPage : Form
    {
        public FirstPage()
        {
            InitializeComponent();

        }

        private void btn_process1_Click(object sender, EventArgs e)
        {
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
                }
                MainPage.Instance.tabContainer.AddForm(ShowForm);


            }
        }

        private void btn_process2_Click(object sender, EventArgs e)
        {
            if (!MainPage.Instance.tabContainer.Controls.ContainsKey("ProcessDetail"))
            {
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
                }
                MainPage.Instance.tabContainer.AddForm(ShowForm);


            }
        }

        private void btn_process3_Click(object sender, EventArgs e)
        {
            if (!MainPage.Instance.tabContainer.Controls.ContainsKey("ProcessDetail"))
            {
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
                }
                MainPage.Instance.tabContainer.AddForm(ShowForm);


            }
        }

        private void btn_process4_Click(object sender, EventArgs e)
        {
            if (!MainPage.Instance.tabContainer.Controls.ContainsKey("ProcessDetail"))
            {
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
                }
                MainPage.Instance.tabContainer.AddForm(ShowForm);
            }
        }

        private SqlConnection Connect = null; // 접속 정보 객체 명명
        //접속 주소
        private string strConn = Common.DbPath;

        private void FirstPage_Load(object sender, EventArgs e)
        {
            
        }

        private void lb_process1_TextChanged(object sender, EventArgs e)
        {
            //db에서 받아오기
        }
    }
}
