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
    public partial class Form3 : Form
    {
        public string connectString;
        public string mssv;
        public string manv;
        SqlConnection con;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVNhomDataSet.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.qLSVNhomDataSet.LOP);
            connectString = "Data Source=NDHHUY;Initial Catalog=QLSVNhom;Integrated Security=True";
            con = new SqlConnection(connectString);
            con.Open();

            label2.Text = mssv;

            SqlCommand cmd = new SqlCommand("SP_SEL1_SINHVIEN", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pMASV = new SqlParameter("@MASV", SqlDbType.NVarChar, 20);
            SqlParameter pHOTEN = new SqlParameter("@HOTEN", SqlDbType.NVarChar, 100);
            SqlParameter pNS = new SqlParameter("@NGAYSINH", SqlDbType.DateTime);
            SqlParameter pDC = new SqlParameter("@DIACHI", SqlDbType.NVarChar, 200);
            SqlParameter pTENLOP = new SqlParameter("@TENLOP", SqlDbType.NVarChar, 100);
            pMASV.Value = mssv;
            pHOTEN.Direction = ParameterDirection.Output;
            pNS.Direction = ParameterDirection.Output;
            pDC.Direction = ParameterDirection.Output;
            pTENLOP.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pMASV);
            cmd.Parameters.Add(pHOTEN);
            cmd.Parameters.Add(pNS);
            cmd.Parameters.Add(pDC);
            cmd.Parameters.Add(pTENLOP);
            cmd.ExecuteNonQuery();
            textBox1.Text = (string)pHOTEN.Value;
            dateTimePicker1.Value = DateTime.Parse(pNS.Value.ToString());
            textBox2.Text = (string)pDC.Value;
            comboBox1.Text = (string)pTENLOP.Value;
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
                string sqlexec = "EXEC SP_UPDATE_SINHVIEN N'" + mssv + "', N'" + textBox1.Text + "','" + dateTimePicker1.Text + "', N'" + textBox2.Text + "', N'" + comboBox1.Text + "',N'" + manv + "'";
                SqlCommand cmd = new SqlCommand(sqlexec, con);
                cmd.ExecuteNonQuery();
            }
            catch(SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString());
            }
        }
    }
}
