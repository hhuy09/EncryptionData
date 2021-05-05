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
    public partial class Form5 : Form
    {
        public string connectString;
        public string tenDN;
        public string pass;
        SqlConnection con;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.connectString = connectString;
            f2.tenDN = tenDN;
            f2.pass = pass;
            f2.manv = label2.Text;
            f2.hoten = label1.Text;
            this.Hide();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.connectString = connectString;
            f6.tenDN = tenDN;
            f6.pass = pass;
            f6.manv = label2.Text;
            f6.hoten = label1.Text;
            this.Hide();
            f6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Close();
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.connectString = connectString;
            f12.tenDN = tenDN;
            f12.pass = pass;
            f12.manv = label2.Text;
            f12.hoten = label1.Text;
            this.Hide();
            f12.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.connectString = connectString;
            f13.tenDN = tenDN;
            f13.pass = pass;
            f13.manv = label2.Text;
            f13.hoten = label1.Text;
            this.Hide();
            f13.Show();
        }
    }
}
