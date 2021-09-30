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
using testestestsettest.Models;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Linq.Expressions;

namespace testestestsettest
{
    public partial class ProcessDetail : Form
    {
        // 접속 정보 객체 명명
        private SqlConnection Connect = null;

        private string RtspUrl = "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov";
        // 데이터베이스 관리권한

        // 데이터베이스 명령전달

        // 접속 주소
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
                Connect = new SqlConnection(Common.DbPath);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT NO,PROCESSNO,PROCESSNAME,MAKER,PSTARTTIME,PENDTIME,STARTTIME,ENDTIME,HAZARDNO FROM TB_PROCESSWORKrec", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    return;
                }
                grid.DataSource = dtTemp;   //데이터 그리드 뷰에 데이터 테이블 등록

                //그리드뷰의 헤더 명칭 선언
                grid.Columns["NO"].HeaderText            = "no";
                grid.Columns["PROCESSNO"].HeaderText     = "프로세스 no";
                grid.Columns["PROCESSNAME"].HeaderText   = "프로세스 이름";
                grid.Columns["MAKER"].HeaderText         = "프로세스 담당자";
                grid.Columns["PSTARTTIME"].HeaderText    = "계획가동 시작시간";
                grid.Columns["PENDTIME"].HeaderText      = "계획가동 마감시간"; 
                grid.Columns["STARTTIME"].HeaderText     = "가동시작시간";
                grid.Columns["ENDTIME"].HeaderText       = "가동끝난시간";
                grid.Columns["HAZARDNO"].HeaderText      = "위험관리이력NO";

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
                grid.Columns["NO"].ReadOnly             = true;    //기본키라 수정하면 안됌, 단 신규로 추가될때는 해야함
                grid.Columns["PROCESSNO"].ReadOnly      = true;
                grid.Columns["PROCESSNAME"].ReadOnly    = true;
                grid.Columns["MAKER"].ReadOnly          = true;
                grid.Columns["PSTARTTIME"].ReadOnly     = true;
                grid.Columns["PENDTIME"].ReadOnly       = true;
                grid.Columns["STARTTIME"].ReadOnly      = true;
                grid.Columns["ENDTIME"].ReadOnly        = true;
                grid.Columns["HAZARDNO"].ReadOnly       = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();    //DB 연결 끊어주기
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

                Connect = new SqlConnection(Common.DbPath);
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

                Connect = new SqlConnection(Common.DbPath);
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
            #region 주석
            /*try
            {
                //콤보박스에서 선택된 프로세스의 조회
                // 접속 정보 커넥션에 등록 및 객체 선언
                Connect = new SqlConnection(Common.DbPath);
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
            }*/

            #endregion 

            try
            {
                Debug.WriteLine("TEST");
                vlcControl.Play(new Uri(RtspUrl));

                Debug.WriteLine(cbo_proces1.SelectedIndex);
                Debug.WriteLine((cbo_proces1.SelectedItem as Tb_Process).ProcessNo);

                var CurrProcess = (cbo_proces1.SelectedItem as Tb_Process);
                var ProcessNo = CurrProcess.ProcessNo;

                LblProcessName.Text = CurrProcess.ProcessName;

                //Sql 커넥션
                //Sql 커넥션에 등록 및 객체 선언
                Connect = new SqlConnection(Common.DbPath);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                var selQuery = @"SELECT 1 AS ID, 'NO' AS TITLE, CONVERT(VARCHAR(10), NO) AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO
                                  UNION 
                                 SELECT 2 AS ID, 'PROCESSNO' AS TITLE, CONVERT(VARCHAR(10), PROCESSNO) AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO
                                  UNION
                                 SELECT 3 AS ID, 'MAKER' AS TITLE, MAKER AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO
                                  UNION
                                 SELECT 4 AS ID, 'PSTARTTIME' AS TITLE, CONVERT(VARCHAR(10), PSTARTTIME, 120) AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO
                                  UNION
                                 SELECT 5 AS ID, 'PENDTIME' AS TITLE, CONVERT(VARCHAR(10), PENDTIME, 120) AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO
                                  UNION
                                 SELECT 6 AS ID, 'STARTTIME' AS TITLE, CONVERT(VARCHAR(10), STARTTIME, 120) AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO
                                  UNION
                                 SELECT 7 AS ID, 'ENDTIME' AS TITLE, CONVERT(VARCHAR(10), ENDTIME, 120) AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO
                                  UNION
                                 SELECT 8 AS ID, 'HAZARDNO' AS TITLE, CONVERT(VARCHAR(10), HAZARDNO, 120) AS VAL
                                   FROM TB_PROCESSWORKrec WHERE PROCESSNO = @PROCESSNO";

                SqlDataAdapter adapter = new SqlDataAdapter(selQuery, Connect);
                adapter.SelectCommand.Parameters.AddWithValue("@PROCESSNO", ProcessNo);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    return;
                }
                grid.DataSource = dtTemp;   //데이터 그리드 뷰에 데이터 테이블 등록





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();    //DB 연결 끊어주기
            }
        }

        private void btn_plan_Click(object sender, EventArgs e)
        {
            // 1. 입력 검증 - 숫자가 아닌값이 들어오면 팅겨냄
            try
            {
                var pstarttime = DateTime.Parse(txt_start.Text);
                DateTime pendtime = DateTime.Parse(txt_end.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("계획 입력시간이 틀렸습니다.");
                return;
            }            

            SetDataToDb();
        }

        private BindingList<Tb_Process> Processes;

        private void ProcessDetail_Load(object sender, EventArgs e)
        {
            InitControlsFromDb();            
        }

        #region DB처리 영역 
        private void SetDataToDb()
        {
            // 1-1. 콤보박스 값 가져오기
            Tb_Process temp = cbo_proces1.SelectedItem as Tb_Process;

            // 2. 디비 입력
            using (SqlConnection conn = new SqlConnection(Common.DbPath))
            {
                conn.Open();

                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("USP_PROCESSWORKrec_INS", conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCESSNO", temp.ProcessNo);
                cmd.Parameters.AddWithValue("@PROCESSNAME", temp.ProcessName);
                cmd.Parameters.AddWithValue("@MAKER", "SYSTEM");
                cmd.Parameters.AddWithValue("@PSTARTTIME", txt_start.Text);
                cmd.Parameters.AddWithValue("@PENDTIME", txt_end.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    // 성공
                    trans.Commit();
                    MessageBox.Show("입력성공했습니다");
                }
                else
                {
                    // 실패 
                    trans.Rollback();
                    MessageBox.Show("입력실패했습니다");
                }
            }
        }

        private void InitControlsFromDb()
        {
            Processes = new BindingList<Tb_Process>();

            // DB에서 프로세스 가져와서 콤보박스 바인딩
            using (SqlConnection conn = new SqlConnection(Common.DbPath))
            {
                conn.Open();

                var selquery = @"SELECT PROCESSNO
                                      , PROCESSNAME
                                   FROM TB_PROCESS";

                SqlCommand cmd = new SqlCommand(selquery, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Processes.Add(new Tb_Process
                    {
                        ProcessNo = (int)reader["PROCESSNO"],
                        ProcessName = reader["PROCESSNAME"].ToString()
                    });
                }
            }

            // Combobox에 바인딩
            cbo_proces1.DataSource = Processes;
            cbo_proces1.ValueMember = "PROCESSNO";
            cbo_proces1.DisplayMember = "PROCESSNAME";
            cbo_proces1.SelectedIndex = 0;
        }

        #endregion

        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;

            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
        }
    }
}
