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
    public partial class Form6 : Form
    {
        public string connectString;
        public string tenDN;
        public string pass;
        public string manv;
        public string hoten;
        string mssv;
        SqlConnection con;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label1.Text = hoten;
            label2.Text = manv;

            string sqlexec1 = "EXEC SP_SEL_SINHVIEN_NHANVIEN N'" + manv + "'";
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["TENLOP"].Width = 150;
            dataGridView1.Columns["HOTEN"].Width = 150;

            mssv = dataGridView1.Rows[0].Cells[0].Value.ToString();

            int count = dataGridView1.Rows.Count - 1;
            label5.Text = count.ToString();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Close();
            Form5 f5 = new Form5();
            f5.tenDN = tenDN;
            f5.pass = pass;
            this.Close();
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.tenDN = tenDN;
            f7.pass = pass;
            f7.hoten = hoten;
            f7.manv = manv;         
            f7.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.mssv = mssv;
            f8.connectString = connectString;
            f8.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                mssv = row.Cells[0].Value.ToString();                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sqlexec1 = "EXEC SP_SEL_SINHVIEN_NHANVIEN N'" + manv + "'";
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["TENLOP"].Width = 150;
            dataGridView1.Columns["HOTEN"].Width = 150;

            mssv = dataGridView1.Rows[0].Cells[0].Value.ToString();

            int count = dataGridView1.Rows.Count - 1;
            label5.Text = count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.mssv = mssv;
            f3.connectString = connectString;
            f3.manv = label2.Text;
            f3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.mssv = mssv;
            f4.manv = manv;
            f4.connectString = connectString;
            f4.pass = pass;
            f4.Show();
        }
    }
}
