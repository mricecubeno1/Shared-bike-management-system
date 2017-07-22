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
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //用户信息注册，添加到数据库users
        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "insert into users(username,userid,phn,pwd) values(@username,@userid,@phn,@pwd)";
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlParameter sp1 = new SqlParameter("username",textBox1.Text);
            sp1.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(sp1);
            SqlParameter sp2 = new SqlParameter("userid",textBox3.Text);
            sp2.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(sp2);
            SqlParameter sp3 = new SqlParameter("phn",textBox4.Text);
            sp3.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(sp3);
            SqlParameter sp4 = new SqlParameter("pwd",textBox2.Text);
            sp4.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(sp4);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("注册成功！");
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
        }

        Boolean textboxHasText;//判断输入框是否有文本
        private void textBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
                   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
                
       
            
      
        }
    }

