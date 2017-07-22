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

namespace bikesSharing
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string username = textBox1.Text;
            string pwd = textBox2.Text;

           // string sql = "select * from dbo.users where username='"+username+"'and pwd='"+pwd+"'";
            //SqlCommand cmd = new SqlCommand(sql,conn);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from dbo.users where username='" + username+"'";

            SqlDataReader sread = cmd.ExecuteReader();
            if(sread.Read())
            {
                MessageBox.Show("登录成功");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("请输入正确的用户名和密码");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
