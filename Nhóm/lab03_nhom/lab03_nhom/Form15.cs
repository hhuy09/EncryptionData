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
    public partial class Form15 : Form
    {
        public string connectString;
        public string mssv;
        public string mahp;
        SqlConnection con;
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label1.Text = mssv;
            label3.Text = mahp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlexec1 = "EXEC SP_DEL_DKHP '" + mssv + "', '" + mahp + "'";
                SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
                cmd1.ExecuteNonQuery();              
                MessageBox.Show("Xóa DKHP thành công.");
                con.Close();
                this.Close();
            }
            catch(SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString() + "\nXóa DKHP không thành công.");
            }
        }
    }
}
