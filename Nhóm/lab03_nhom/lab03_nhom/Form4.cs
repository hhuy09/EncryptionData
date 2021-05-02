using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace lab03_nhom
{
    public partial class Form4 : Form
    {
        public string connectString;
        public string mssv;
        public string manv;
        string mahp;
        public string pass;
        SqlConnection con;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            SqlCommand cmd = new SqlCommand("SP_SEL1_SINHVIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pMASV = new SqlParameter("@MASV", SqlDbType.NVarChar, 20);
            SqlParameter pHOTEN = new SqlParameter("@HOTEN", SqlDbType.NVarChar, 100);
            SqlParameter pNS = new SqlParameter("@NGAYSINH", SqlDbType.DateTime);
            SqlParameter pDC = new SqlParameter("@DIACHI", SqlDbType.NVarChar, 200);
            SqlParameter pTENLOP = new SqlParameter("@TENLOP", SqlDbType.NVarChar, 100);
            pMASV.Value = mssv;
            pHOTEN.Direction = ParameterDirection.Output;
            pNS.Direction = ParameterDirection.Output;
            pDC.Direction = ParameterDirection.Output;
            pTENLOP.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pMASV);
            cmd.Parameters.Add(pHOTEN);
            cmd.Parameters.Add(pNS);
            cmd.Parameters.Add(pDC);
            cmd.Parameters.Add(pTENLOP);
            cmd.ExecuteNonQuery();
            label2.Text = (string)pHOTEN.Value;           
            cmd.Parameters.Clear();

            try
            {
                string sqlexec1 = "EXEC SP_SEL_BANGDIEM '" + mssv + "'" + ", N'" + manv + "', '" + pass + "'";
                SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["SOTC"].Width = 50;
                dataGridView1.Columns["TENHP"].Width = 275;
            }
            catch(SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString());
            }

            int count = dataGridView1.Rows.Count - 1;
            label7.Text = count.ToString();

            if (count != 0)
            {
                label3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string tenhp = row.Cells[1].Value.ToString();
                label3.Text = tenhp;
                mahp = row.Cells[0].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlexec = "EXEC SP_UPDATE_BANGDIEM N'" + mssv + "', '" + mahp + "', '" + textBox1.Text + "', N'" + manv + "', '" + pass + "'";
                SqlCommand cmd = new SqlCommand(sqlexec, con);
                cmd.ExecuteNonQuery();

                string sqlexec1 = "EXEC SP_SEL_BANGDIEM '" + mssv + "'" + ", N'" + manv + "', '" + pass + "'";
                SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["SOTC"].Width = 50;
                dataGridView1.Columns["TENHP"].Width = 275;
            }
            catch(SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString());
            }
        }
    }
}
