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
    public partial class Form14 : Form
    {
        public string connectString;
        public string tenDN;
        public string pass;
        public string manv;
        public string hoten;
        string mssv;
        SqlConnection con;
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label13.Text = hoten;
            label12.Text = manv;
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
                SqlCommand cmd = new SqlCommand("SP_SEL1_MAHP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pTENHP = new SqlParameter("@TENHP", SqlDbType.NVarChar, 100);
                SqlParameter pMAHP = new SqlParameter("@MAHP", SqlDbType.VarChar, 20);
                pTENHP.Value = comboBox1.Text;
                pMAHP.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pTENHP);
                cmd.Parameters.Add(pMAHP);
                cmd.ExecuteNonQuery();
                string mahp = (string)pMAHP.Value;
                cmd.Parameters.Clear();

                string sqlexec1 = "EXEC SP_INS_DKHP '" + textBox1.Text + "', '" + mahp + "'";
                SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Thêm DKHP thành công.");

                con.Close();
                this.Close();
            }
            catch(SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString() + "\nThêm DKHP không thành công.");
            }
        }
    }
}
