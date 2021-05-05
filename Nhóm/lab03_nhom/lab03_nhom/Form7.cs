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
    public partial class Form7 : Form
    {
        public string connectString;
        public string tenDN;
        public string pass;
        public string manv;
        public string hoten;
        SqlConnection con;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label13.Text = hoten;
            label12.Text = manv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mssv = textBox1.Text;
            string htsv = textBox3.Text;
            string nsinh = dateTimePicker1.Value.ToString();
            string diachi = textBox2.Text;
            string lop = comboBox1.Text;

            try
            {
                SqlCommand cmd = new SqlCommand("SP_MALOP_LOP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter pTENLOP = new SqlParameter("@TENLOP", SqlDbType.NVarChar, 100);
                SqlParameter pMALOP = new SqlParameter("@MALOP", SqlDbType.VarChar, 20);
                pTENLOP.Value = lop;
                pMALOP.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pTENLOP);
                cmd.Parameters.Add(pMALOP);
                cmd.ExecuteNonQuery();
                string malop = (string)pMALOP.Value;
                cmd.Parameters.Clear();

                string sqlexec2 = "EXEC SP_CHECK_LOP_NV '" + malop + "', '" + manv + "'";
                SqlCommand cmd2 = new SqlCommand(sqlexec2, con);
                cmd2.ExecuteNonQuery();

                string sqlexec1 = "EXEC SP_INS_SINHVIEN '" + mssv + "', N'" + htsv + "', '" + nsinh + "', N'" + diachi + "', '" + malop + "', '" + mssv + "', '" + mssv + "'";
                SqlCommand cmd1 = new SqlCommand(sqlexec1, con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Thêm sinh viên thành công.");
                con.Close();
                this.Close();
            }
            catch(SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString()+"\nThêm sinh viên không thành công.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Close();           
            this.Close();          
        }
    }
}
