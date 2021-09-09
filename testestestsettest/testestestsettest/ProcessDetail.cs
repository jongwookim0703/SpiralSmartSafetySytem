using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using System.Data.SqlClient;

namespace testestestsettest
{
    public partial class ProcessDetail : Form
    {
        // 접속 정보 객체 명명
        private System.Data.SqlClient.SqlConnection Connect = null; 
        // 데이터베이스 관리권한
        
        // 데이터베이스 명령전달

        // 접속 주소
        private string strConn = "Data Source=61.105.9.203; Initial Catalog=AppDev;User ID=spa;Password=spiral_0904";
        public ProcessDetail()
        {
            InitializeComponent();
        }

        private void btn_detail1_Click(object sender, EventArgs e)
        {
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
                    grid.DataSource = null;
                    return;
                }
                grid.DataSource = dtTemp;   //데이터 그리드 뷰에 데이터 테이블 등록

                //그리드뷰의 헤더 명칭 선언
                grid.Columns["NO"].HeaderText        = "no";
                grid.Columns["CO2"].HeaderText       = "이산화탄소";
                grid.Columns["GAS"].HeaderText       = "가스누출";
                grid.Columns["LIGHT"].HeaderText     = "조도";
                grid.Columns["FLAME"].HeaderText     = "불꽃";
                grid.Columns["MAKEDATE"].HeaderText  = "발생시간"; 
                grid.Columns["CHECKFLAG"].HeaderText = "재확인여부";
                grid.Columns["CHECKDATE"].HeaderText = "재확인시간";
                grid.Columns["MAKER"].HeaderText     = "담당자";


                // 그리드 뷰의 폭 지정
                grid.Columns[0].Width = 150;
                grid.Columns[1].Width = 150;
                grid.Columns[2].Width = 150;
                grid.Columns[3].Width = 150;
                grid.Columns[4].Width = 150;
                grid.Columns[5].Width = 150;
                grid.Columns[6].Width = 150;
                grid.Columns[7].Width = 150;
                grid.Columns[8].Width = 150;


                //컬럼의 수정 여부를 지정 한다
                grid.Columns["NO"].ReadOnly        = true;    //기본키라 수정하면 안됌, 단 신규로 추가될때는 해야함
                grid.Columns["CO2"].ReadOnly       = true;
                grid.Columns["GAS"].ReadOnly       = true;
                grid.Columns["LIGHT"].ReadOnly     = true;
                grid.Columns["FLAME"].ReadOnly     = true;
                grid.Columns["MAKEDATE"].ReadOnly  = true;
                grid.Columns["CHECKFLAG"].ReadOnly = true;
                grid.Columns["CHECKDATE"].ReadOnly = true;
                grid.Columns["MAKER"].ReadOnly     = true;

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
        private void btn_stop1_Click(object sender, EventArgs e) //추후 DB.Helper 사용하게 되는 경우 해당하는 형태로 코드변경을 검토하여야함.
        {
            //<생각정리>
            //C#의 프로그램상에서 정지버튼을 클릭함 => DB에서 신호를 보냄(sql로 요청함)              => DB의 설비이력에 정지시간 및 이력이 등록됨(Stored procedure에서 update 구문을 작성함)

            try
            {
                if (grid.Rows.Count == 0) return;
                string nores = grid.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                if (MessageBox.Show("설비를 정지 하시겠습니까?", "정지", MessageBoxButtons.YesNo)
                    == DialogResult.No) return;

                string Num = grid.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();


                SqlCommand cmd = new SqlCommand();
                SqlTransaction Tran;   //승인을 할지 거절을 할지 권한을 가지겟다

                Connect = new SqlConnection(strConn);
                Connect.Open();

                Tran = Connect.BeginTransaction("TestTran");
                cmd.Transaction = Tran;
                cmd.Connection = Connect;

                //주석 사유 : TRANSACTION으로 걸려야 할 값 및 삽입되어야 할 값에 대해서 DB.Helper 안쓴버전으로 입력하였으나, 추가검토가 필요함.  
                //cmd.CommandText = "INSERT INTO TB_WARNINGMANAGE(custID, resDate,  resState,  roomNum ,NoShow) " +
                //                          "VALUES('" + Common.LogInId + "','" + Date + "','" + "Y" + "','" + Num + "','" + "N" + "')" +
                //                  "INSERT INTO TB_ENVIROMENTSTATE(MAKEDATE,CHECKFLAG,CHECKDATE) " +
                //                          "VALUES('" + Num + "','" + Date + "')";
                cmd.ExecuteNonQuery();

                // 성공 시 DB COMMIT

                if (nores == "정지가능")
                {
                    Tran.Commit();
                    MessageBox.Show("정지되었습니다.");
                }
                else
                {
                    MessageBox.Show("정지할 수 없습니다..");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        private void btn_work1_Click(object sender, EventArgs e)
        {
            //<생각정리>
            //C#의 프로그램상에서 가동버튼을 클릭함 => DB에서 신호를 보냄(sql로 요청함)              => DB의 설비이력에 정지시간 및 이력이 등록됨(Stored procedure에서 update 구문을 작성함) (테이블 설계상 이게 맞을거 같은데?)
            try
            {
                if (grid.Rows.Count == 0) return;
                string nores = grid.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();
                if (MessageBox.Show("설비를 가동 하시겠습니까?", "가동", MessageBoxButtons.YesNo)
                    == DialogResult.Yes) return;

                string Num = grid.CurrentRow.Cells["ONOFFFLAG"].Value.ToString();


                SqlCommand cmd = new SqlCommand();
                SqlTransaction Tran;   //승인을 할지 거절을 할지 권한을 가지겟다

                Connect = new SqlConnection(strConn);
                Connect.Open();

                Tran = Connect.BeginTransaction("TestTran");
                cmd.Transaction = Tran;
                cmd.Connection = Connect;

                //주석 사유 : 정지버튼과 동일한 사유
                //cmd.CommandText = "INSERT INTO TB_WARNINGMANAGE(custID, resDate,  resState,  roomNum ,NoShow) " +
                //                          "VALUES('" + Common.LogInId + "','" + Date + "','" + "Y" + "','" + Num + "','" + "N" + "')" +
                //                  "INSERT INTO TB_ENVIROMENTSTATE(MAKEDATE,CHECKFLAG,CHECKDATE) " +
                //                          "VALUES('" + Num + "','" + Date + "')";
                cmd.ExecuteNonQuery();

                // 성공 시 DB COMMIT

                if (nores == "가동")
                {
                    Tran.Commit();
                    MessageBox.Show("설비가 가동 되었습니다.");
                }
                else
                {
                    MessageBox.Show("설비를 가동할 수 없습니다.");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        private void cbo_proces1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //콤보박스 품목 상세 데이터 조회 및 추가
                // 접속 정보 커넥션에 등록 및 객체 선언
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT NO, PROCESSNO, PROCESSNAME, ONOFFFLAG, APPROACHWARN, FIREWARN, MAKEDATE, CHECKFLAG,CHECKDATE,MAKER FROM TB_WARNINGMANAGE", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                cbo_proces1.DataSource = dtTemp;
                cbo_proces1.DisplayMember = "NO";                 // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "PROCESSNO";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "PROCESSNAME";        // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "ONOFFFLAG";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "APPROACHWARN";       // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "FIREWARN";           // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "MAKEDATE";           // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "CHECKFLAG";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "CHECKDATE";          // 눈으로 보여줄 항목
                cbo_proces1.DisplayMember = "MAKER";              // 눈으로 보여줄 항목


                cbo_proces1.ValueMember = "TB_WARNINGMANAGE";     // 실제 데이터를 처리할 코드 항목
                cbo_proces1.Text = "";

                // 이미지 그룹박스 사이즈 조절
                groupBox2.Size = new System.Drawing.Size(Convert.ToInt32(this.Size.Width / 2), 563);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();              //DB 연결 끊어주기
            }
        }
    }
}
