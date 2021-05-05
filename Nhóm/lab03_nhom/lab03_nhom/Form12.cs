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
    public partial class Form12 : Form
    {
        public string connectString;
        public string tenDN;
        public string pass;
        public string manv;
        public string hoten;
        SqlConnection con;
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label1.Text = manv;
            label2.Text = hoten;

            string sqlexec1 = "EXEC SP_SEL_PUBLIC_NHANVIEN '" + tenDN + "','" + pass + "'";
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);       
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["HOTEN"].Width = 170;

            int count = dataGridView1.Rows.Count - 1;
            label5.Text = count.ToString();
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

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
