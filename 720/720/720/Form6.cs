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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //输入id显示用户可以修改的信息
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
                label7.Text = dr["username"].ToString();
                label8.Text = dr["balance"].ToString();
               
                textBox3.Text = dr["deposit"].ToString();
              



            }
            dr.Close();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //实现用户押金，扣钱的修改操作
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn.Open();
          // int userid = int.Parse(textBox1.Text);
            string str = "update users set deposit=@deposit,balance=@balance  where uid=@uid"; //不能将表名设为user，user为关键字
            SqlCommand cmd = new SqlCommand(str, conn);

            SqlParameter sp1 = new SqlParameter("uid", textBox1.Text);
            sp1.DbType = DbType.String;
            cmd.Parameters.Add(sp1);
            SqlParameter sp2 = new SqlParameter("deposit", textBox3.Text);
            sp1.DbType = DbType.String;
            cmd.Parameters.Add(sp2);
            int i = 0;
            i = int.Parse(label8.Text) - int.Parse(textBox2.Text);
          //  MessageBox.Show(i.ToString ());//写的时候用来检验了一下i的值。
            SqlParameter sp3 = new SqlParameter("balance", i.ToString());
            sp2.DbType = DbType.String;
            cmd.Parameters.Add(sp3);

            cmd.ExecuteNonQuery();
            conn.Close();

            this.DialogResult = DialogResult.OK;
            MessageBox.Show("修改成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //实现用户的删除，注销功能
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn.Open();
            // int bid = int.Parse(textBox1.Text);
            string str = "delete from users where uid=@uid";//需要删除的地方
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlParameter sp1 = new SqlParameter("uid", textBox1.Text);
            sp1.DbType = DbType.String;
            cmd.Parameters.Add(sp1);
            int inters = -1;
            inters = cmd.ExecuteNonQuery();
            conn.Close();
            if (inters > 0)
            {
                MessageBox.Show("注销成功");
            }
            else
            {
                MessageBox.Show("注销失败");
            }
        }
    }
}
