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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //车辆的添加
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "insert into bike(bid,area) values(@bid,@area);";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlParameter sp1 = new SqlParameter("bid", int.Parse(textBox1.Text));
            sp1.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(sp1);

            SqlParameter sp2 = new SqlParameter("area", textBox2.Text);
            sp2.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(sp2);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加成功");







        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
