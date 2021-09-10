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
            /*MyTabControl myTabControl1 = new MyTabControl();
            string FormName = "ProcessDetail";

            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "ProcessDetail.DLL"); // 호텔 예약하기 폼이 들어가야함. 
            Type typeForm = assemb.GetType("ProcessDetail." + FormName.ToString(), true); // 여기도 호텔 예약하기 폼의 네임스페이스가 들어가야함. 
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);*/

            Form ShowForm = new ProcessDetail();
            ShowForm.Show();
            /*for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == FormName.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }
            myTabControl1.AddForm(ShowForm);*/

            
        }

        private void btn_process2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_process3_Click(object sender, EventArgs e)
        {

        }

        private void btn_process4_Click(object sender, EventArgs e)
        {

        }

        private SqlConnection Connect = null; // 접속 정보 객체 명명
        //접속 주소
        private string strConn = Common.DbPath;

        private void FirstPage_Load(object sender, EventArgs e)
        {
            /*try
            {
                //콤보박스 품목 상세 데이터 조회 및 추가
                Connect = new SqlConnection(strConn); // 접속 정보 커넥션에 등록 및 객체 선언
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }
                
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT roomType FROM TB_2_ROOM", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                

                SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT DISTINCT peoNum FROM TB_2_ROOM", Connect);

                DataTable dtTemp1 = new DataTable();
                adapter1.Fill(dtTemp1);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null; // 데이터가 없을 경우 초기화
                    return; // return이 있어서 else 구문 필요 없음
                }

                grid.DataSource = dtTemp; // 데이터 그리드 뷰에 데이터 테이블 등록
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }*/
        }

        private void lb_process1_TextChanged(object sender, EventArgs e)
        {
            //db에서 받아오기
        }
    }
}
