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
    public partial class Form16 : Form
    {
        public string connectString;
        public string mssv;
        public string mahp;
        public string manv;
        public string hoten;
        public string pass;
        SqlConnection con;
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label12.Text = manv;
            label13.Text = hoten;
            label6.Text = mssv;
            label8.Text = mahp;

            SqlCommand cmd = new SqlCommand("SP_SEL1_DKHP ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pMASV = new SqlParameter("@MASV", SqlDbType.NVarChar, 20);
            SqlParameter pHOTEN = new SqlParameter("@HOTEN", SqlDbType.NVarChar, 100);
            SqlParameter pMAHP = new SqlParameter("@MAHP", SqlDbType.NVarChar, 20);
            SqlParameter pTENHP = new SqlParameter("@TENHP", SqlDbType.NVarChar, 200);
            pMASV.Value = mssv;
            pHOTEN.Direction = ParameterDirection.Output;
            pMAHP.Value = mahp;
            pTENHP.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pMASV);
            cmd.Parameters.Add(pHOTEN);
            cmd.Parameters.Add(pMAHP);
            cmd.Parameters.Add(pTENHP);
            cmd.ExecuteNonQuery();
            label7.Text = (string)pHOTEN.Value;
            label9.Text = (string)pTENHP.Value;
            cmd.Parameters.Clear();
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
                string sqlexec = "EXEC SP_UPDATE_BANGDIEM N'" + mssv + "', '" + mahp + "', '" + textBox1.Text + "', N'" + manv + "', '" + pass + "'";
                SqlCommand cmd = new SqlCommand(sqlexec, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật điểm thành công.");
                con.Close();
                this.Close();
            }
            catch (SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString() + "\nCập nhật điểm thi thành công.");
            }           
        }
    }
}
