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
    public partial class Form13 : Form
    {
        public string connectString;
        public string tenDN;
        public string pass;
        public string manv;
        public string hoten;
        string mssv;
        string mahp;
        SqlConnection con;
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label1.Text = hoten;
            label2.Text = manv;

            string sqlexec1 = "EXEC SP_SEL_DKHP N'" + manv + "', '" + pass + "'";
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["HOTEN"].Width = 200;
            dataGridView1.Columns["TENHP"].Width = 250;

            int count = dataGridView1.Rows.Count - 1;
            label5.Text = count.ToString();

            mssv = dataGridView1.Rows[0].Cells[0].Value.ToString();
            mahp = dataGridView1.Rows[0].Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label1.Text = hoten;
            label2.Text = manv;

            string sqlexec1 = "EXEC SP_SEL_DKHP N'" + manv + "', '" + pass + "'";
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["HOTEN"].Width = 200;
            dataGridView1.Columns["TENHP"].Width = 250;

            int count = dataGridView1.Rows.Count - 1;
            label5.Text = count.ToString();

            mssv = dataGridView1.Rows[0].Cells[0].Value.ToString();
            mahp = dataGridView1.Rows[0].Cells[2].Value.ToString();
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
            Form14 f14 = new Form14();
            f14.connectString = connectString;
            f14.manv = manv;
            f14.hoten = hoten;
            f14.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.connectString = connectString;
            f15.mssv = mssv;
            f15.mahp = mahp;
            f15.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                mssv = row.Cells[0].Value.ToString();              
                mahp = row.Cells[2].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.connectString = connectString;
            f16.mssv = mssv;
            f16.mahp = mahp;
            f16.manv = manv;
            f16.hoten = hoten;
            f16.pass = pass;
            f16.Show();
        }
    }
}
