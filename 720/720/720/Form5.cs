using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _720
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //实现了查询的操作
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            int uid = int.Parse(textBox1.Text);
            string sql = "select * from users where uid ={0}";
            conn.Open();
            sql = string.Format(sql, uid);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            //执行查询操作
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label9.Text = dr["username"].ToString();
                label10.Text = dr["pwd"].ToString();
                label11.Text = dr["phn"].ToString();
                label12.Text = dr["deposit"].ToString();
                label13.Text = dr["balance"].ToString();



            }
            dr.Close();
            conn.Close();
        }
    }
}
