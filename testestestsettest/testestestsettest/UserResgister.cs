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
    public partial class UserResgister : Form
    {
        public UserResgister()
        {
            InitializeComponent();
            //    serialPort1.Open();
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

        private void button2_Click(object sender, EventArgs e) //등록
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("필수값을 입력하세요");
                return;
            }

            var id = txtID.Text;
            var pass = txtPassword.Text;
            var name = txtName.Text;
            var position = cboPosition.SelectedItem == null ? "" : cboPosition.SelectedItem.ToString();
            var finger = txtFinger.Text;

            try
            {
                using (var conn = new SqlConnection(Common.DbPath))
                {
                    conn.Open();

                    var chkquery = @"SELECT ID FROM TB_USER WHERE ID = @ID";

                    var chkcmd = new SqlCommand(chkquery, conn);
                    chkcmd.Parameters.AddWithValue("@ID", id);

                    var chkid = chkcmd.ExecuteScalar();

                    if (chkid != null) {
                        MessageBox.Show("아이디가 중복되었습니다.");
                        txtID.Text = "";
                        return;
                    }                    

                    var query = @"INSERT INTO [dbo].[TB_USER]
                                       ([ID]
                                       ,[PWD]
                                       ,[USERNAME]
                                       ,[ENTRYDATE]
                                       ,[FINGERIN]
                                       ,[POSITION])
                                 VALUES
                                       (@ID
                                       ,@PWD
                                       ,@USERNAME
                                       ,@ENTRYDATE
                                       ,@FINGERIN
                                       ,@POSITION)";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@PWD", pass);
                    cmd.Parameters.AddWithValue("@USERNAME", name);
                    cmd.Parameters.AddWithValue("@ENTRYDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@FINGERIN", finger);
                    cmd.Parameters.AddWithValue("@POSITION", position);

                    var result = cmd.ExecuteNonQuery();



                    if (result > 0)
                    {
                        MessageBox.Show("사용자가 등록되었습니다.");
                        txtID.Text = "";
                        txtPassword.Text = "";
                        txtName.Text = "";
                        cboPosition.SelectedItem = "";
                        txtFinger.Text = "";


                    }
                    else
                    {
                        MessageBox.Show("사용자 등록에 실패했습니다.");
                        txtID.Text = "";
                        txtPassword.Text = "";
                        txtName.Text = "";
                        cboPosition.SelectedItem = "";
                        txtFinger.Text = "";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB처리 오류 : {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e) //삭제
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("필수값을 입력하세요");
                return;
            }

            var id = txtID.Text;
            var pass = txtPassword.Text;
            var name = txtName.Text;
            var finger = txtFinger.Text;

            try
            {
                using (var conn = new SqlConnection(Common.DbPath))
                {
                    conn.Open();

                    var chkquery = @"SELECT ID FROM TB_USER WHERE ID = @ID";

                    var chkcmd = new SqlCommand(chkquery, conn);
                    chkcmd.Parameters.AddWithValue("@ID", id);

                    var chkid = chkcmd.ExecuteScalar();

                    if (chkid != null)
                    {
                        var delquery1 = @"DELETE FROM [dbo].[TB_USER]
                                           WHERE [ID]=@ID
                                             AND [PWD]=@PWD
                                             AND [USERNAME]=@USERNAME
                                             AND [FINGERIN]=@FINGERIN";

                        var cmd1 = new SqlCommand(delquery1, conn);
                        cmd1.Parameters.AddWithValue("@ID", id);
                        cmd1.Parameters.AddWithValue("@PWD", pass);
                        cmd1.Parameters.AddWithValue("@USERNAME", name);
                        cmd1.Parameters.AddWithValue("@FINGERIN", finger);


                        var result = cmd1.ExecuteNonQuery();

                        if (result < 1 )
                        {
                            MessageBox.Show("사용자가 삭제되었습니다.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB처리 오류 : {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e) //지문 센서 확인버튼
        {

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