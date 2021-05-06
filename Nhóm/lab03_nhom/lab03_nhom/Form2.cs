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
    public partial class Form2 : Form
    {
        public string connectString;
        public string tenDN;
        public string pass;
        public string manv;
        public string hoten;
        string malop;
        SqlConnection con;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label1.Text = hoten;
            label2.Text = manv;
            

            string sqlexec1 = "EXEC SP_SEL_LOP '" + label2.Text + "'";           
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1); 
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["TENLOP"].Width = 173;

            string maLop = dataGridView1.Rows[0].Cells[0].Value.ToString();
            label5.Text = dataGridView1.Rows[0].Cells[1].Value.ToString(); 

            string sqlexec2 = "EXEC SP_SEL_SINHVIEN_LOP '" + maLop + "'";            
            SqlCommand cmd2 = new SqlCommand(sqlexec2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["HOTEN"].Width = 250;

            int count = dataGridView2.Rows.Count - 1;
            label9.Text = count.ToString();
            count = dataGridView1.Rows.Count - 1;
            label11.Text = count.ToString();
     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            Form5 f5 = new Form5();
            f5.tenDN = tenDN;
            f5.pass = pass;
            this.Close();
            f5.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {     
                
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string maLop = row.Cells[0].Value.ToString();
                label5.Text = row.Cells[1].Value.ToString();
                malop = maLop;

                string sqlexec2 = "EXEC SP_SEL_SINHVIEN_LOP '" + maLop + "'";
                SqlCommand cmd2 = new SqlCommand(sqlexec2, con);
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
                dataGridView2.Columns["HOTEN"].Width = 250;

                int count = dataGridView2.Rows.Count - 1;
                label9.Text = count.ToString();
                         
            }
        }


        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                string mssv = row.Cells[0].Value.ToString();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SP_SEL_NHANVIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter ptenDN = new SqlParameter("@TENDN", SqlDbType.NVarChar, 100);
            SqlParameter phoTen = new SqlParameter("@HOTEN", SqlDbType.NVarChar, 100);
            SqlParameter pmaNV = new SqlParameter("@MANV", SqlDbType.VarChar, 20);
            ptenDN.Value = tenDN;
            phoTen.Direction = ParameterDirection.Output;
            pmaNV.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(ptenDN);
            cmd.Parameters.Add(phoTen);
            cmd.Parameters.Add(pmaNV);
            cmd.ExecuteNonQuery();
            label1.Text = (string)phoTen.Value;
            label2.Text = (string)pmaNV.Value;
            cmd.Parameters.Clear();

            string sqlexec1 = "EXEC SP_SEL_LOP '" + label2.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["TENLOP"].Width = 170;

            string maLop = dataGridView1.Rows[0].Cells[0].Value.ToString();
            label5.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();

            string sqlexec2 = "EXEC SP_SEL_SINHVIEN_LOP '" + maLop + "'";
            SqlCommand cmd2 = new SqlCommand(sqlexec2, con);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView2.Columns["HOTEN"].Width = 300;

            int count = dataGridView2.Rows.Count - 1;
            label9.Text = count.ToString();
            count = dataGridView1.Rows.Count - 1;
            label11.Text = count.ToString();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.connectString = connectString;
            f9.manv = manv;
            f9.hoten = hoten;
            f9.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.connectString = connectString;
            f10.malop = malop;
            f10.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.connectString = connectString;
            f11.malop = malop;
            f11.manv = manv;
            f11.hoten = hoten;
            f11.Show();
        }
    }
}
