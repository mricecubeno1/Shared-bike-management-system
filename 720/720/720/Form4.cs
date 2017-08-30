using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _720
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn.Open();
            //查询总车辆数
            SqlCommand cmd = new SqlCommand("select * from bike ", conn);

            
            SqlDataReader sdrr = cmd.ExecuteReader();

            while (sdrr.Read())
            {
                // MessageBox.Show(string.Format("数据库里共有{0}条记录", sdrr[0]));
                int a = int.Parse(string.Format(sdrr[0].ToString()));
                label4.Text = a.ToString();
            }
            conn.Close();

            //DataView dv = DataSet.bike[0].defaultview;

            //dv.RowFilter = "你的条件";

            //int x = dv.Count;//就是你要的行数 


          //按条件查询
            SqlConnection conn1 = new SqlConnection();
            conn1.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn1.Open();
            string sql = "select * from bike";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(sql,conn1);
            sda.Fill(dt);
            DataView dv = dt.DefaultView;

            dv.RowFilter = "area='和平区'";
            int c = dv.Count;
            label8.Text = c.ToString();
            conn1.Close();
            //
            SqlConnection conn4 = new SqlConnection();
            conn4.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn4.Open();
            string sql4 = "select * from bike";
            DataTable dt4 = new DataTable();
            SqlDataAdapter sda4 = new SqlDataAdapter(sql4, conn4);
            sda4.Fill(dt4);
            DataView dv4 = dt4.DefaultView;

            dv4.RowFilter = "area='浑南区'";
            int c4 = dv4.Count;
            label13.Text = c4.ToString();
            conn4.Close();
            //
            SqlConnection conn5 = new SqlConnection();
            conn5.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn5.Open();
            string sql5 = "select * from bike";
            DataTable dt5 = new DataTable();
            SqlDataAdapter sda5 = new SqlDataAdapter(sql5, conn5);
            sda5.Fill(dt5);
            DataView dv5 = dt5.DefaultView;

            dv5.RowFilter = "area='铁西区'";
            int c5 = dv5.Count;
            label14.Text = c5.ToString();
            conn5.Close();
            //
            SqlConnection conn6 = new SqlConnection();
            conn6.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn6.Open();
            string sql6 = "select * from bike";
            DataTable dt6 = new DataTable();
            SqlDataAdapter sda6 = new SqlDataAdapter(sql6, conn6);
            sda6.Fill(dt6);
            DataView dv6 = dt6.DefaultView;

            dv6.RowFilter = "area='沈河区'";
            int c6 = dv6.Count;
            label15.Text = c6.ToString();
            conn6.Close();
            //
            SqlConnection conn7 = new SqlConnection();
            conn7.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn7.Open();
            string sql7 = "select * from bike";
            DataTable dt7 = new DataTable();
            SqlDataAdapter sda7 = new SqlDataAdapter(sql7, conn7);
            sda7.Fill(dt7);
            DataView dv7 = dt7.DefaultView;

            dv7.RowFilter = "area='东陵区'";
            int c7 = dv7.Count;
            label16.Text = c7.ToString();
            conn7.Close();


            //查询已损坏的数量
            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn2.Open();
            string sql1 = "select * from bike";
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(sql1, conn2);
            sda.Fill(dt1);
            DataView dv1 = dt1.DefaultView;
            dv1.RowFilter = "damage='损坏'";
            int c1 = dv1.Count;
            label5.Text = c1.ToString();
            conn2.Close();

            //查询正在使用的数量
            SqlConnection conn3 = new SqlConnection();
            conn3.ConnectionString = "Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            conn3.Open();
            string sql2 = "select * from bike";
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(sql2, conn3);
            sda.Fill(dt2);
            DataView dv2 = dt2.DefaultView;
            dv2.RowFilter = "damage='损坏'";
            int c2 = dv2.Count;
            label6.Text = c2.ToString();
            conn3.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
