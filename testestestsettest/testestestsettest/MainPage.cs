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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Diagnostics;

namespace testestestsettest
{
    public partial class MainPage : Form
    {
        static MainPage obj;

        //Mqtt 라즈베리파이
        MqttClient client;
        private float open_temp, close_temp;
        private bool opened;

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
            //FirstPage.Instance.Gridbinding();
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
                else
                {
                    myTabControl1.TabPages[i].Dispose();
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

            try
            {
                IPAddress hostIP;
                hostIP = IPAddress.Parse("192.168.0.6");
                client = new MqttClient(hostIP);

                client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tssProcess_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = sender as ToolStripMenuItem;
            Common.ProcessNo = int.Parse(temp.Tag.ToString());

            obj = this;

            string FormName = "ProcessDetail";

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "testestestsettest.DLL"); // firstpage 폼이 들어가야함. 
            Type typeForm = assemb.GetType("testestestsettest." + FormName.ToString(), true); // firstpage 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == FormName.ToString())
                {
                    myTabControl1.TabPages[i].Dispose();
                    myTabControl1.AddForm(ShowForm);
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
                else
                {
                    myTabControl1.TabPages[i].Dispose();
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

        #region Mqtt
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                InsertData(message);        // 메시지가 발생할 경우 DB에 저장
                SendToBroker(message);      // 알람이 발생시 디바이스로 재전송
            }
            catch (Exception ex)
            {
                MessageBox.Show("[ERROR] " + ex.Message);
            }
        }

        private void InsertData(string message)
        {
            var currentDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
            //currentDatas["dev_id"], currentDatas["time"],
        }

        private void SendToBroker(string message)
        {
            var currentDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);

            var dev_id = currentDatas["dev_id"];
            var currTemp = float.Parse(currentDatas["temp"]);
            Debug.WriteLine(currTemp);

            JObject json = new JObject();
            if (currTemp >= open_temp)
            {
                if (opened == false)
                {
                    json.Add("dev_id", dev_id);
                    json.Add("state", "ON");
                    string strJson = JsonConvert.SerializeObject(json);
                    client.Publish("", Encoding.Default.GetBytes(strJson));
                    Debug.WriteLine(json);

                    opened = true;
                }

            }
            else if (currTemp <= close_temp)
            {
                if (opened)
                {
                    json.Add("dev_id", dev_id);
                    json.Add("state", "OFF");
                    string strJson = JsonConvert.SerializeObject(json);
                    client.Publish("", Encoding.Default.GetBytes(strJson));
                    Debug.WriteLine(json);

                    opened = false;
                }

            }
        }
        #endregion Mqtt
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
