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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //统计用户的各列相加，来实现所需要的各值
            //统计了所有账户的余额
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "select sum(balance ) from users";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            label7.Text = Convert.ToString(sdr.GetInt32(0));
            conn.Close();
            //统计了所有用户的押金总和
            //统计了所有账户的押金
            SqlConnection conn1 = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn1.Open();
            string sql1 = "select sum(deposit ) from users";
            SqlCommand cmd1 = new SqlCommand(sql1, conn1);
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            sdr1.Read();
            label6.Text = Convert.ToString(sdr1.GetInt32(0));
            conn1.Close();

            //统计买车费用，可以用统计车辆的行数和单车的价钱的相乘来实现
            int price = 200;//定义单车单价为200元
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn2.Open();
            //查询总车辆数
            SqlCommand cmd2 = new SqlCommand("select * from bike ", conn2);


            SqlDataReader sdr2 = cmd2.ExecuteReader();

            while (sdr2.Read())
            {
                // MessageBox.Show(string.Format("数据库里共有{0}条记录", sdrr[0]));
                int a = int.Parse(string.Format(sdr2[0].ToString()));
                int a_price = price * a;
                label8.Text = a_price.ToString();
            }
            conn2.Close();

            //维修费用，可来统计损坏的车辆来实现，或者统计一下，维修的次数来实现。
            SqlConnection conn3 = new SqlConnection();
            conn3.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn3.Open();
            string sql3 = "select * from bike";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql3, conn3);
            sda.Fill(dt);
            DataView dv = dt.DefaultView;
            dv.RowFilter = "damage='损坏'";
            int uprice = 100;
            int c = dv.Count;
            int au_price = uprice * c;
            label9.Text = au_price .ToString();
            conn3.Close();
            //盈利既可用来实现，也可以删除，便民服务，要什么盈利，删除这功能。。。。
        }
    }
}
