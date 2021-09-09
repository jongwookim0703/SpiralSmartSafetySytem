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
    public partial class UserResgister : Form
    {
        public UserResgister()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                byte[] recv = new byte[1];
                serialPort1.Read(recv, 0, 1);

                txtFinger.Text = recv[0].ToString();
                if (inforegister_info.ContainsKey((int)recv[0]))
                {
                    //등록된 정보가 있을경우
                    txtID.Text              = inforegister_info[recv[0]].id;
                    txtPassword.Text = inforegister_info[recv[0]].password;
                    txtName.Text       = inforegister_info[recv[0]].name;
                    cboPosition.Text  = inforegister_info[recv[0]].position;

                }
                else
                {
                    txtID.Text = "";
                    txtPassword.Text = "";
                    txtName.Text = "";
                    cboPosition.Text = "";
                }
            }
        }

        Dictionary<int, inforegister> inforegister_info = new Dictionary<int, inforegister>();
        private void button2_Click_1(object sender, EventArgs e)
        {
            inforegister input_data = new inforegister();

            if (txtFinger.Text == "")
            {
                MessageBox.Show("지문을 입력해주세요!");
                return;
            }

            input_data.fingerid = int.Parse(txtFinger.Text);
            input_data.name = txtID.Text;
            input_data.password = txtPassword.Text;
            input_data.name = txtName.Text;
            input_data.position = cboPosition.Text;

            //이미 딕셔너리에 있는 ID면 등록되면 안됨
            if (inforegister_info.ContainsKey(input_data.fingerid))
            {
                //이미등록이 된 경우
                MessageBox.Show("이미 등록된 정보입니다!");
            }
            else
            {
                inforegister_info.Add(input_data.fingerid, input_data);
                txtID.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                cboPosition.Text = "";
                txtFinger.Text = "";
                MessageBox.Show("성공적으로 등록했습니다!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txtFinger.Text == "")
            {
                MessageBox.Show("지문을 입력해주세요!");
                return;
            }

            int fingerid = int.Parse(txtFinger.Text);
            if (inforegister_info.ContainsKey(fingerid))
            {
                //지문정보가 조회된 경우
                inforegister_info[fingerid].fingerid = fingerid;
                inforegister_info[fingerid].name = txtID.Text;
                inforegister_info[fingerid].password = txtPassword.Text;
                inforegister_info[fingerid].name = txtName.Text;
                inforegister_info[fingerid].position = cboPosition.Text;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("지문을 입력해주세요!");
                return;
            }

            int fingerid = int.Parse(txtFinger.Text);
            if (inforegister_info.ContainsKey(fingerid))
            {
                inforegister_info.Remove(fingerid);
            }
        }
    }

    class inforegister
    {
        public int fingerid;
        public string id;
        public string password;
        public string position;
        public string name;
    }

}