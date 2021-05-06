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
    public partial class Form1 : Form
    {
        string connectString;
        SqlConnection con;
        int num;
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                string sqlexeclogin = "EXEC SP_LOGIN_NHANVIEN N'" + username + "', '" + password + "'";
                SqlCommand cmd = new SqlCommand(sqlexeclogin, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng nhập thành công");
                Form5 f5 = new Form5();
                f5.connectString = connectString;
                f5.tenDN = username;
                f5.pass = textBox2.Text;
                this.Hide();
                f5.Show();

            }
            catch (SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString());

            }
            textBox2.Text = null;
    }
    }
}
