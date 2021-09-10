using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testestestsettest
{
    public partial class ProcessSafety : Form
    {
        private System.Data.SqlClient.SqlConnection Connect = null;
        private string strConn = "Data Source=61.105.9.203; Initial Catalog=AppDev;User ID=spa;Password=spiral_0904";

        public ProcessSafety()
        {
            InitializeComponent();
            //serialPort1.Open();

            try
            {
                //Sql 커넥션
                //Sql 커넥션에 등록 및 객체 선언
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT NO,CO2,GAS,LIGHT,FLAME,MAKEDATE,CHECKFLAG,CHECKDATE,MAKER FROM TB_ENVIROMENTSTATE", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid1.DataSource = null;
                    return;
                }
                grid1.DataSource = dtTemp;   //데이터 그리드 뷰에 데이터 테이블 등록

                //그리드뷰의 헤더 명칭 선언
                grid1.Columns["NO"].HeaderText = "no";
                grid1.Columns["CO2"].HeaderText = "이산화탄소";
                grid1.Columns["GAS"].HeaderText = "가스누출";
                grid1.Columns["LIGHT"].HeaderText = "조도";
                grid1.Columns["FLAME"].HeaderText = "불꽃";
                grid1.Columns["MAKEDATE"].HeaderText = "발생시간";
                grid1.Columns["CHECKFLAG"].HeaderText = "재확인여부";
                grid1.Columns["CHECKDATE"].HeaderText = "재확인시간";
                grid1.Columns["MAKER"].HeaderText = "담당자";


                // 그리드 뷰의 폭 지정
                grid1.Columns[0].Width = 150;
                grid1.Columns[1].Width = 150;
                grid1.Columns[2].Width = 150;
                grid1.Columns[3].Width = 150;
                grid1.Columns[4].Width = 150;
                grid1.Columns[5].Width = 150;
                grid1.Columns[6].Width = 150;
                grid1.Columns[7].Width = 150;
                grid1.Columns[8].Width = 150;


                //컬럼의 수정 여부를 지정 한다
                grid1.Columns["NO"].ReadOnly = true;    //기본키라 수정하면 안됌, 단 신규로 추가될때는 해야함
                grid1.Columns["CO2"].ReadOnly = true;
                grid1.Columns["GAS"].ReadOnly = true;
                grid1.Columns["LIGHT"].ReadOnly = true;
                grid1.Columns["FLAME"].ReadOnly = true;
                grid1.Columns["MAKEDATE"].ReadOnly = true;
                grid1.Columns["CHECKFLAG"].ReadOnly = true;
                grid1.Columns["CHECKDATE"].ReadOnly = true;
                grid1.Columns["MAKER"].ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();    //DB 연결 끊어주기
            }
            {

            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("상세보기로 이동합니다");
            ProcessDetail processDetail = new ProcessDetail();
            processDetail.ShowDialog();
        }

// 라즈베리파이 센서연결 참고
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using Windows.Devices.Gpio;

//namespace RaspberryPi
//    {
//        class UcSensor
//        {
//            GpioController gpio = GpioController.GetDefault();

//            GpioPin TriggerPin;
//            GpioPin EchoPin;

//            //Contructor
//            public UcSensor(int TriggerPin, int EchoPin)
//            {
//                //Setting up gpio pin's
//                this.TriggerPin = gpio.OpenPin(TriggerPin);
//                this.EchoPin = gpio.OpenPin(EchoPin);

//                this.TriggerPin.SetDriveMode(GpioPinDriveMode.Output);
//                this.EchoPin.SetDriveMode(GpioPinDriveMode.Input);

//                this.TriggerPin.Write(GpioPinValue.Low);
//            }

//            public double GetDistance()
//            {
//                ManualResetEvent mre = new ManualResetEvent(false);
//                mre.WaitOne(500);

//                //Send pulse
//                this.TriggerPin.Write(GpioPinValue.High);
//                mre.WaitOne(TimeSpan.FromMilliseconds(0.01));
//                this.TriggerPin.Write(GpioPinValue.Low);

//                //Recieve pusle
//                while (this.EchoPin.Read() == GpioPinValue.Low)
//                {
//                }
//                DateTime start = DateTime.Now;

//                while (this.EchoPin.Read() == GpioPinValue.High)
//                {
//                }
//                DateTime stop = DateTime.Now;

//                //Calculating distance
//                double timeBetween = (stop - start).TotalSeconds;
//                double distance = timeBetween * 17000;

//                return distance;
//            }

//        }
//    }


}
}
