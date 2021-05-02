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


namespace lab03_canhan
{
    public partial class Form1 : Form
    {
        string connectString;
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSV;Integrated Security=True";
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
                string sqlexeclogin = "EXEC SP_LOGIN N'" + username + "', '" + password + "'";
                SqlCommand cmd = new SqlCommand(sqlexeclogin, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng nhập thành công");
            }
            catch(SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr = errorStr.Split('\n');
                MessageBox.Show(arrStr[0].ToString());
            }
        }
    }
}
