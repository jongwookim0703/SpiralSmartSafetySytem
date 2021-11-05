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

        //Mqtt에서 받아올 led값 저장 할 변수 선언
        private int led1_G = 0, led2_G = 0, led3_G = 0, led4_G = 0;
        private int led1_Y = 0, led2_Y = 0, led3_Y = 0, led4_Y = 0;
        private int led1_R = 0, led2_R = 0, led3_R = 0, led4_R = 0;

        //Mqtt 라즈베리파이
        MqttClient client;
        delegate void UpdateLabelCallback(string message);

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

            //mqtt 연결
            try
            {
                IPAddress hostIP;
                //Main에서만 1회 선언
                hostIP = IPAddress.Parse("192.168.0.23");
                Common.Client = new MqttClient(hostIP);

                //Mqtt에서 publish되는 메세지 받는 함수 추가
                Common.Client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                Common.Client.MqttMsgSubscribed += Client_MqttMsgSubscribed;

                //Mian에서 1회 선언
                Common.Client.Connect("192.168.0.23");//서버 통신 할 라즈베리파이 ip

                //MQtt서버에서 읽어올 Topic선언
                Common.Client.Subscribe(new string[] { "main/#" },
                    new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE }); // 구독할 topic명 = common

                /*Common.Client.Subscribe(new string[] { "main/led/#" },
                    new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE }); // 구독할 topic명 = common*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssTimer.Text = DateTime.Now.ToString();//breaktime 걸면 1초마다 break 발생
            FirstPage.Instance.Gridbinding();
        }

        private void tssPage_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem temp = sender as ToolStripMenuItem;
            string FormName = temp.Tag.ToString();

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
                    /*if (myTabControl1.TabPages[i].Name != "FirstPage")
                    {
                        myTabControl1.TabPages[i].Dispose();

                    }*/
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

        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Debug.WriteLine(e.ToString());
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
                else
                {
                    myTabControl1.TabPages[i].Dispose();
                    /*if (myTabControl1.TabPages[i].Name != "FirstPage")
                    {
                        myTabControl1.TabPages[i].Dispose();

                    }*/
                }
            }

            myTabControl1.AddForm(ShowForm);
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Common.Client.Disconnect();
        }

        private void btnSafety_Click(object sender, EventArgs e)
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
            if (myTabControl1.SelectedTab.Name != "FirstPage")
            {
                myTabControl1.SelectedTab.Dispose();
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
                        
        }

        private void tssRecord_Click(object sender, EventArgs e)
        {


            obj = this;

            string FormName = "Record";

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


        #region Mqtt
        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {
                var message = Encoding.UTF8.GetString(e.Message);
                UpdateLabel(message);        // 메세지 받아올때 실행될 함수
            }
            catch (Exception ex)
            {
                //MessageBox.Show("[ERROR] " + ex.Message);
            }
        }

        //led 값을 받아와 lable값 을 변경하는 함수
        private void UpdateLabel(string message)
        {
            //Mqtt서버에서 전송된 Json메세지를 Dictionary형태로 받아온다.
            var currentDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);//발행된 json 을 딕셔너리로 받아옴

            #region led 값 저장
            //led1이라는 키를 가지고 있는 경우
            if (currentDatas.ContainsKey("led1"))
            {
                //led1키값에 대해 value값이 G이면
                if (currentDatas["led1"] == "G")
                {
                    led1_G = 1;
                    led1_Y = 0;
                    led1_R = 0;
                }
                else if (currentDatas["led1"] == "Y")
                {
                    led1_G = 0;
                    led1_Y = 1;
                    led1_R = 0;
                }
                else if (currentDatas["led1"] == "R")
                {
                    led1_G = 0;
                    led1_Y = 0;
                    led1_R = 1;
                }
                else
                {
                    led1_G = 0;
                    led1_Y = 0;
                    led1_R = 0;
                }
            }

            if (currentDatas.ContainsKey("led2"))
            {
                if (currentDatas["led2"] == "G")
                {
                    led2_G = 1;
                    led2_Y = 0;
                    led2_R = 0;
                }
                else if (currentDatas["led2"] == "Y")
                {
                    led2_G = 0;
                    led2_Y = 1;
                    led2_R = 0;
                }
                else if (currentDatas["led2"] == "R")
                {
                    led2_G = 0;
                    led2_Y = 0;
                    led2_R = 1;
                }
                else
                {
                    led2_G = 0;
                    led2_Y = 0;
                    led2_R = 0;
                }
            }

            if (currentDatas.ContainsKey("led3"))
            {
                if (currentDatas["led3"] == "G")
                {
                    led3_G = 1;
                    led3_Y = 0;
                    led3_R = 0;
                }
                else if (currentDatas["led3"] == "Y")
                {
                    led3_G = 0;
                    led3_Y = 1;
                    led3_R = 0;
                }
                else if (currentDatas["led3"] == "R")
                {
                    led3_G = 0;
                    led3_Y = 0;
                    led3_R = 1;
                }
                else
                {
                    led3_G = 0;
                    led3_Y = 0;
                    led3_R = 0;
                }
            }

            if (currentDatas.ContainsKey("led4"))
            {
                if (currentDatas["led4"] == "G")
                {
                    led4_G = 1;
                    led4_Y = 0;
                    led4_R = 0;
                }
                else if (currentDatas["led4"] == "Y")
                {
                    led4_G = 0;
                    led4_Y = 1;
                    led4_R = 0;
                }
                else if (currentDatas["led4"] == "R")
                {
                    led4_G = 0;
                    led4_Y = 0;
                    led4_R = 1;
                }
                else
                {
                    led4_G = 0;
                    led4_Y = 0;
                    led4_R = 0;
                }
            }
            #endregion led 값 저장
            if (panel1.InvokeRequired)
            {
                UpdateLabelCallback lb = new UpdateLabelCallback(UpdateLabel);
                this.Invoke(lb, new object[] { message });
            }
            else
            {
                //label값 변경
                this.label2.Text = Convert.ToString(led1_G + led2_G + led3_G + led4_G);
                this.label3.Text = Convert.ToString(led1_Y + led2_Y + led3_Y + led4_Y);
                this.label4.Text = Convert.ToString(led1_R + led2_R + led3_R + led4_R);
            }
            /*    label2.BeginInvoke(new Action(() =>
            {
                label2.Text = Convert.ToString(led1_G + led2_G + led3_G + led4_G);
            }));

            label3.BeginInvoke(new Action(() =>
            {
                label3.Text = Convert.ToString(led1_Y + led2_Y + led3_Y + led4_Y);
            }));

            label4.BeginInvoke(new Action(() =>
            {
                label4.Text = Convert.ToString(led1_R + led2_R + led3_R + led4_R);
            }));*/
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
