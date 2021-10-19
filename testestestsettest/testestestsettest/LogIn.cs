using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;

namespace testestestsettest
{
    public partial class LogIn : Form
    {
        private SqlConnection Connect = null;  // 데이터 베이스 접속 정보
        private SqlTransaction Tran;           // 데이터 베이스 관리 권한 
        private SqlCommand cmd = new SqlCommand(); // 데이터 베이스 명령 전달

        public LogIn()
        {
            InitializeComponent();
            this.Tag = "FAIL";
        }

        private int PwFailCount = 0;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                // 1. 데이터 베이스 접속 경로 설정
                string strConn = "Data Source=hangaramit.iptime.org; Initial Catalog=SpiralDB;User ID=spa;Password=spiral_0904";
                Connect = new SqlConnection(strConn);


                // 2. 데이터 베이스 연결 상태 확인.
                Connect.Open();
                if (Connect.State != System.Data.ConnectionState.Open) MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                string sLogInId = txtID.Text;
                string sPassWord = txtPassword.Text;

                // 기존의 비밀 번호 찾기.
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT ID, PWD,USERNAME ,POSITION FROM TB_USER WHERE ID = '" + sLogInId + "'", Connect);
                DataTable DtTemp = new DataTable();
                Adapter.Fill(DtTemp);

                // ID 존재 여부 확인.
                if (DtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("로그인 ID 가 잘못 되었습니다.");
                    txtID.Text = "";
                    txtPassword.Focus();
                    return;
                }

                // 기존 비밀 번호 비교 
                else if (sPassWord != DtTemp.Rows[0]["PWD"].ToString())
                {

                    txtPassword.Text = "";
                    txtPassword.Focus();
                    PwFailCount += 1;
                    MessageBox.Show("비밀번호 가 잘못 되었습니다. 누적 횟수 : " + PwFailCount.ToString());
                    if (PwFailCount == 3)
                    {
                        MessageBox.Show("3회 이상 비밀번호를 잘못입력하여 프로그램을 종료 합니다.");
                        this.Close();
                    }
                    return;
                }
                else
                {
                    if (DtTemp.Rows[0]["POSITION"].ToString()=="관리자" )
                    {
                        this.Tag = DtTemp.Rows[0]["USERNAME"].ToString(); // 유저 명을 메인화면으로 보냄
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("해당사용자는 접근 권한이 없습니다. 관리자 번호 (010-9999-9999): " );
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인 작업중 오류가 발생하였습니다." + ex.ToString());
            }
            finally
            {
                Connect.Close();

            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnLogin_Click(null, null);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            UserResgister userResgister = new UserResgister();
            userResgister.ShowDialog();
        }
    }
}

