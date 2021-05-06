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
    public partial class Form11 : Form
    {
        public string connectString;
        public string malop;
        public string manv;
        public string hoten;
        SqlConnection con;
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label1.Text = hoten;
            label2.Text = manv;
            label4.Text = malop;

            SqlCommand cmd = new SqlCommand("SP_SEL1_LOP", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pMALOP = new SqlParameter("@MALOP", SqlDbType.VarChar, 20);
            SqlParameter pTENLOP = new SqlParameter("@TENLOP", SqlDbType.NVarChar, 100);
            pMALOP.Value = malop;
            pTENLOP.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pMALOP);
            cmd.Parameters.Add(pTENLOP);
            cmd.ExecuteNonQuery();
            textBox2.Text = (string)pTENLOP.Value;
            cmd.Parameters.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlexec1 = "EXEC SP_UPD_LOP '" + malop + "', N'" + textBox2.Text + "'";
            SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thông tin lớp thành công.");
            con.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }
    }
}
