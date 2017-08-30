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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //实现了查询的操作
            int bidSearch=0;
            int uidSearch=0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
           int bid = int.Parse(textBox1.Text); 
            string sql = "select * from bike where bid ={0}";
           
            conn.Open();
            sql = string.Format(sql, bid);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            bidSearch = bid;
            //执行查询操作
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2 .Text = dr["area"].ToString();
                textBox3 .Text = dr["available"].ToString();
                textBox4.Text = dr["damage"].ToString();
               

            }

            dr.Close();
            
            //实现了查询该车号使用人的功能
            string sql1 = "select * from buser where bid={0}";
            sql1 = string.Format(sql1,bidSearch);
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = sql1;
            cmd2.Connection = conn;
            SqlDataReader dr1 = cmd2.ExecuteReader();

            if (dr1.Read())
            {
                uidSearch = int.Parse(dr1["uid"].ToString());


            }
           
            dr1.Close();
            string sql2 = "select username from users where uid={0}";
            sql2 = string.Format(sql2, uidSearch);
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = sql2;
            cmd3.Connection = conn;
            SqlDataReader dr2 = cmd3.ExecuteReader();
            if (dr2.Read())
            {
                textBox5.Text = dr2["username"].ToString();
            }
            dr2.Close();

           conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //实现了修改的操作，只修改投放地区
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn.Open();
            string str = "update bike set area=@area  where bid=@bid";
            SqlCommand cmd = new SqlCommand(str, conn);

            SqlParameter sp1 = new SqlParameter("bid", textBox1.Text);
            sp1.DbType = DbType.String;
            cmd.Parameters.Add(sp1);

            SqlParameter sp2 = new SqlParameter("area", textBox2.Text);
            sp2.DbType = DbType.String;
            cmd.Parameters.Add(sp2);

            cmd.ExecuteNonQuery();
            conn.Close();

            this.DialogResult = DialogResult.OK;
            MessageBox.Show("修改成功");

        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //实现了损坏车辆的删除操作
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn.Open();
           // int bid = int.Parse(textBox1.Text);
            string str = "delete from bike where bid=@bid";//需要删除的地方
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlParameter sp1 = new SqlParameter("bid", textBox1.Text);
            sp1.DbType = DbType.String;
            cmd.Parameters.Add(sp1);
            int inters = -1;
            inters = cmd.ExecuteNonQuery();
            conn.Close();
            if (inters > 0)
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //维修车辆
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn.Open();
            string str = "update bike set damage=@damage  where bid=@bid";
            SqlCommand cmd = new SqlCommand(str, conn);

            SqlParameter sp1 = new SqlParameter("bid", textBox1.Text);
            sp1.DbType = DbType.String;
            cmd.Parameters.Add(sp1);

            SqlParameter sp2 = new SqlParameter("damage", @"良好");
            sp2.DbType = DbType.String;
            cmd.Parameters.Add(sp2);

            cmd.ExecuteNonQuery();
            conn.Close();

            this.DialogResult = DialogResult.OK;
            MessageBox.Show("维修成功");

        }
    }
}
