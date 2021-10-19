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
    public partial class Record : Form
    {
        private System.Data.SqlClient.SqlConnection Connect = null;
        string strConn = "Data Source=hangaramit.iptime.org; Initial Catalog=SpiralDB;User ID=spa;Password=spiral_0904";

        public Record()
        {
            InitializeComponent();
        }

        public void Gridbinding()
        {
            try
            {
                #region Maingrid
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                #region Main Grid


                SqlCommand cmd = new SqlCommand("USP_RECORD_Main", Connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    MessageBox.Show("조건에 일치하는 데이터가 없습니다.");
                    return;
                }

                grid.DataSource = dtTemp;

                grid.Columns["기록시간"].HeaderText = "기록시간";
                grid.Columns["프로세스"].HeaderText = "프로세스";
                grid.Columns["중단여부"].HeaderText = "중단여부";
                grid.Columns["위험"].HeaderText = "위험";
                grid.Columns["위험상태"].HeaderText = "위험상태";
                grid.Columns["계획가동시간"].HeaderText = "계획가동시간";
                grid.Columns["가동시간"].HeaderText = "가동시간";
                grid.Columns["점검시간"].HeaderText = "점검시간";
                grid.Columns["중단율"].HeaderText = "중단율";
                grid.Columns["담당자"].HeaderText = "담당자";

                grid.Columns[0].Width = 100;
                grid.Columns[1].Width = 80;
                grid.Columns[2].Width = 80;
                grid.Columns[3].Width = 60;
                grid.Columns[4].Width = 80;
                grid.Columns[5].Width = 105;
                grid.Columns[6].Width = 80;
                grid.Columns[7].Width = 80;
                grid.Columns[8].Width = 80;
                grid.Columns[9].Width = 80;

                #endregion

                #region grid1

                SqlCommand cmd1 = new SqlCommand("USP_ProcessRank_Main", Connect);
                cmd1.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                DataTable dtTemp1 = new DataTable();
                adapter1.Fill(dtTemp1);

                if (dtTemp1.Rows.Count == 0)
                {
                    grid1.DataSource = null;
                    MessageBox.Show("조건에 일치하는 데이터가 없습니다.");
                    return;
                }

                grid1.DataSource = dtTemp1;
                grid1.Columns["프로세스"].HeaderText = "프로세스";
                grid1.Columns["누적가동시간"].HeaderText = "누적가동시간";
                grid1.Columns["점검시간"].HeaderText = "점검시간";
                grid1.Columns["중단율"].HeaderText = "중단율";

                grid1.Columns[0].Width = 100;
                grid1.Columns[1].Width = 105;
                grid1.Columns[2].Width = 100;
                grid1.Columns[3].Width = 100;


                #endregion

                #region grid2

                SqlCommand cmd2 = new SqlCommand("USP_HazardRank_Main", Connect);
                cmd2.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                DataTable dtTemp2 = new DataTable();
                adapter2.Fill(dtTemp2);

                if (dtTemp2.Rows.Count == 0)
                {
                    grid2.DataSource = null;
                    MessageBox.Show("조건에 일치하는 데이터가 없습니다.");
                    return;
                }

                grid2.DataSource = dtTemp2;

                grid2.Columns["NAME"].HeaderText = "위험";
                grid2.Columns["STATE"].HeaderText = "위험상태";
                grid2.Columns["위험별점검시간"].HeaderText = "위험별점검시간";
                grid2.Columns["위험별중단율"].HeaderText = "위험별중단율";

                grid2.Columns[0].Width = 90;
                grid2.Columns[1].Width = 90;
                grid2.Columns[2].Width = 120;
                grid2.Columns[3].Width = 110;


                #endregion
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

        private void Record_Load(object sender, EventArgs e)
        {
            grid.DefaultCellStyle.ForeColor = Color.Black;
            Gridbinding();
        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            Gridbinding();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Gridbinding();

            if (cboProcess.SelectedIndex < 0 && comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("조건을 선택하세요");
                return;
            }

            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                var procesName = cboProcess.SelectedItem as string;
                var startDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                var endDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var hazard = (comboBox1.SelectedItem as string).Split(' ')[0];

                #region Main Grid

                SqlCommand cmd3 = new SqlCommand("USP_RECORD", Connect);
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.AddWithValue("@PROCESSNAME", procesName);
                cmd3.Parameters.AddWithValue("@STARTTIME", startDate);
                cmd3.Parameters.AddWithValue("@ENDTIME", endDate);
                cmd3.Parameters.AddWithValue("@HAZARAD", hazard[0]);

                SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
                DataTable dtTemp3 = new DataTable();
                adapter3.Fill(dtTemp3);

                if (dtTemp3.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    MessageBox.Show("조건에 일치하는 데이터가 없습니다.");
                    return;
                }

                grid.DataSource = dtTemp3;

                grid.Columns["기록시간"].HeaderText = "기록시간";
                grid.Columns["프로세스"].HeaderText = "프로세스";
                grid.Columns["중단여부"].HeaderText = "중단여부";
                grid.Columns["위험"].HeaderText = "위험";
                grid.Columns["위험상태"].HeaderText = "위험상태";
                grid.Columns["계획가동시간"].HeaderText = "계획가동시간";
                grid.Columns["가동시간"].HeaderText = "가동시간";
                grid.Columns["점검시간"].HeaderText = "점검시간";
                grid.Columns["중단율"].HeaderText = "중단율";
                grid.Columns["담당자"].HeaderText = "담당자";

                grid.Columns[0].Width = 100;
                grid.Columns[1].Width = 80;
                grid.Columns[2].Width = 80;
                grid.Columns[3].Width = 60;
                grid.Columns[4].Width = 80;
                grid.Columns[5].Width = 105;
                grid.Columns[6].Width = 80;
                grid.Columns[7].Width = 80;
                grid.Columns[8].Width = 80;
                grid.Columns[9].Width = 80;
                #endregion

                #region grid1

                SqlCommand cmd4 = new SqlCommand("USP_ProcessRank", Connect);
                cmd4.CommandType = CommandType.StoredProcedure;

                cmd4.Parameters.AddWithValue("@STARTTIME", startDate);
                cmd4.Parameters.AddWithValue("@ENDTIME", endDate);

                SqlDataAdapter adapter4 = new SqlDataAdapter(cmd4);
                DataTable dtTemp4 = new DataTable();
                adapter4.Fill(dtTemp4);

                if (dtTemp4.Rows.Count == 0)
                {
                    grid1.DataSource = null;
                    MessageBox.Show("조건에 일치하는 데이터가 없습니다.");
                    return;
                }

                grid1.DataSource = dtTemp4;
                grid1.Columns["프로세스"].HeaderText = "프로세스";
                grid1.Columns["누적가동시간"].HeaderText = "누적가동시간";
                grid1.Columns["점검시간"].HeaderText = "점검시간";
                grid1.Columns["중단율"].HeaderText = "중단율";


                grid1.Columns[0].Width = 100;
                grid1.Columns[1].Width = 105;
                grid1.Columns[2].Width = 100;
                grid1.Columns[3].Width = 100;


                #endregion

                #region grid2

                SqlCommand cmd2 = new SqlCommand("USP_HazardRank", Connect);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@PROCESSNAME", procesName);
                cmd2.Parameters.AddWithValue("@STARTTIME", startDate);
                cmd2.Parameters.AddWithValue("@ENDTIME", endDate);
                cmd2.Parameters.AddWithValue("@HAZARAD", hazard[0]);

                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                DataTable dtTemp2 = new DataTable();
                adapter2.Fill(dtTemp2);

                if (dtTemp2.Rows.Count == 0)
                {
                    grid2.DataSource = null;
                    MessageBox.Show("조건에 일치하는 데이터가 없습니다.");
                    return;
                }

                grid2.DataSource = dtTemp2;

                grid2.Columns["NAME"].HeaderText = "위험";
                grid2.Columns["STATE"].HeaderText = "위험상태";
                grid2.Columns["위험별점검시간"].HeaderText = "위험별점검시간";
                grid2.Columns["위험별중단율"].HeaderText = "위험별중단율";

                grid2.Columns[0].Width = 90;
                grid2.Columns[1].Width = 90;
                grid2.Columns[2].Width = 120;
                grid2.Columns[3].Width = 110;
                #endregion
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

        private void Record_Shown(object sender, EventArgs e)
        {
            cboProcess.SelectedIndex = comboBox1.SelectedIndex = 0;
        }
    }
}
#endregion