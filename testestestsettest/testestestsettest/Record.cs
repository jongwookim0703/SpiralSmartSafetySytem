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
        string strConn = "Data Source=hangaramit.iptime.org; Initial Catalog=AppDev;User ID=spa;Password=spiral_0904";

        public Record()
        {
            InitializeComponent();
        }
        private void Record_Load(object sender, EventArgs e)
        {
            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlDataAdapter adapter = new SqlDataAdapter("", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    return;
                }

                grid.DataSource = dtTemp;

                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
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
            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패 하였습니다.");
                    return;
                }

                SqlDataAdapter adapter = new SqlDataAdapter("", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    return;
                }

                grid.DataSource = dtTemp;

                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
                grid.Columns[""].HeaderText = "";
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
    }
}
