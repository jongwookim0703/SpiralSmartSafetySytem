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

        private void Record_Load(object sender, EventArgs e)
        {
            grid.DefaultCellStyle.ForeColor = Color.Black;

            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("USP_RECORD_MAIN", Connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PROCESSNAME", "");
                cmd.Parameters.AddWithValue("@STARTTIME", "");
                cmd.Parameters.AddWithValue("@ENDTIME", "");
                cmd.Parameters.AddWithValue("@HAZARAD", "");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    return;
                }

                else
                {
                    grid.DataSource = dtTemp;

                    grid.Columns["기록시간"].HeaderText = "기록시간";
                    grid.Columns["프로세스"].HeaderText = "프로세스";
                    grid.Columns["NO"].HeaderText = "NO";
                    grid.Columns["프로세스 NO"].HeaderText = "프로세스 NO";
                    grid.Columns["중단여부"].HeaderText = "중단여부";
                    grid.Columns["위험"].HeaderText = "위험";
                    grid.Columns["위험상태"].HeaderText = "위험상태";
                    grid.Columns["계획가동시간"].HeaderText = "계획가동시간";
                    grid.Columns["가동시간"].HeaderText = "가동시간";
                    grid.Columns["중단율"].HeaderText = "중단율";
                    grid.Columns["점검시간"].HeaderText = "점검시간";
                    grid.Columns["담당자"].HeaderText = "담당자";
                }

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboProcess.SelectedIndex < 0 || comboBox1.SelectedIndex < 0)
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

                SqlCommand cmd = new SqlCommand("USP_RECORD", Connect);
                cmd.CommandType = CommandType.StoredProcedure;

                var procesName = cboProcess.SelectedItem as string;
                var startDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                var endDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                var hazard = (comboBox1.SelectedItem as string).Split(' ')[0];

                cmd.Parameters.AddWithValue("@PROCESSNAME", procesName);
                cmd.Parameters.AddWithValue("@STARTTIME", startDate);
                cmd.Parameters.AddWithValue("@ENDTIME", endDate);
                cmd.Parameters.AddWithValue("@HAZARAD", hazard);

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
                grid.Columns["NO"].HeaderText = "NO";
                grid.Columns["프로세스 NO"].HeaderText = "프로세스 NO";
                grid.Columns["중단여부"].HeaderText = "중단여부";
                grid.Columns["위험"].HeaderText = "위험";
                grid.Columns["위험상태"].HeaderText = "위험상태";
                grid.Columns["계획가동시간"].HeaderText = "계획가동시간";
                grid.Columns["가동시간"].HeaderText = "가동시간";
                grid.Columns["중단율"].HeaderText = "중단율";
                grid.Columns["점검시간"].HeaderText = "점검시간";
                grid.Columns["담당자"].HeaderText = "담당자";
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

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Record_Shown(object sender, EventArgs e)
        {
            cboProcess.SelectedIndex = comboBox1.SelectedIndex = 0;
        }
    }
}
