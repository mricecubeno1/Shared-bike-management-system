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
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Web;
using  _720;
using WindowsFormsApplication1;
using xqMedia;



namespace bikesSharing
{
    public partial class USER : Form
    {
        int id = 0;//用户id
        public USER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.panel2.Visible = true;

        }



        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


        //登录
        private void button7_Click(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");

            conn.Open();
            string phn = textBox1.Text;
            string pwd = textBox2.Text;

            string sql = "select uid from dbo.users where phn='" + phn + "'and pwd='" + pwd + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            // SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandText = "select * from dbo.users where username='" + username + "'and pwd='"+pwd+"'";
            SqlDataReader sread = cmd.ExecuteReader();
            if (sread.Read())
            {
                sread.Close();
                id = (int)cmd.ExecuteScalar();
                string sql2 = "select uid from dbo.users where phn='"+phn+"'and pwd='"+pwd+"' and usertype='"+1+"'";
                SqlCommand cmd2 = new SqlCommand(sql2,conn);
                SqlDataReader sread2 = cmd2.ExecuteReader();
                if(sread2.Read())
                {
                    sread2.Close();
                    MessageBox.Show("管理员登录成功！");
                    _720.Form3 form3 =new  _720.Form3();
                    form3.Show();
                    USER u = new USER();
                    u.Hide();
                }
                else
                {
                    

                    MessageBox.Show("登录成功");
                    // cmd.ExecuteNonQuery();
                    conn.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    this.panel2.Visible = false;
                    this.panel1.Visible = true;
                }

                

            }
            else
            {
                MessageBox.Show("请输入正确的用户名和密码");

                conn.Close();
                textBox2.Text = "";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            this.panel1.Visible = true;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel11.Visible = false;
            this.panel9.Visible = false;
            this.panel12.Visible = false;
            this.panel4.Visible = false;
            this.panel10.Visible = false;
            this.panel6.Visible = false;
            this.panel7.Visible = false;
            this.panel5.Visible = false;
            this.panel8.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel3.Visible = true;

        }
        //车费充值
        private void button6_Click(object sender, EventArgs e)
        {
            int balance = int.Parse(textBox3.Text);
            string pwd = textBox4.Text;



            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();

            string sp2 = "select * from users where pwd='" + pwd + "'and uid='" + id + "'";
            SqlCommand cmd2 = new SqlCommand(sp2, conn);
            SqlDataReader pwdd = cmd2.ExecuteReader();
            if (pwdd.Read())
            {
                conn.Close();
                using (SqlConnection conn2 = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    conn2.Open();
                    /*    string spl = "update users set balance='"+balance+"'where uid='"+id+"'";
                        SqlCommand cmd = new SqlCommand(spl, conn2);
                        SqlParameter sp1 = new SqlParameter("balance", "balance"+balance);
                        sp1.DbType = System.Data.DbType.Int32;
                        cmd.Parameters.Add(sp1);
                        cmd.ExecuteNonQuery();  */
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update users set balance=balance+'" + balance + "'where uid='" + id + "'";
                    cmd.Connection = conn2;
                    cmd.ExecuteNonQuery();
                    conn2.Close();
                }

                MessageBox.Show("充值成功！");
                textBox3.Text = "";
                textBox4.Text = "";

            }
            else
            {
                MessageBox.Show("密码错误，请重新输入！");
                textBox4.Text = "";

            }



        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                this.panel1.Visible = true;
                this.panel2.Visible = true;
                this.panel9.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel11.Visible = false;
                this.panel12.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel10.Visible = false;
                this.panel5.Visible = false;
                this.panel8.Visible = false;
            }
            else
            {
                MessageBox.Show("用户已登录，重新登录请先注销或退出系统");
            }
        }

        private void 注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = true;
                this.panel6.Visible = false;
                this.panel10.Visible = false;
                this.panel9.Visible = false;
                this.panel12.Visible = false;
                this.panel11.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = false;
                this.panel5.Visible = false;
            }
            else
            {
                MessageBox.Show("用户已登录，无法在登录时进行注册");
            }


        }

        private void 充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        //产生随机字符串函数
        string getString(int count)
        {
            int number;
            string checkCode = String.Empty;     //存放随机码的字符串   

            System.Random random = new Random();

            for (int i = 0; i < count; i++) //产生 count 位校验码   
            {
                number = random.Next();
                number = number % 36;
                if (number < 10)
                {
                    number += 48;    //数字0-9编码在48-57   
                }
                else
                {
                    number += 55;    //字母A-Z编码在65-90   
                }

                checkCode += ((char)number).ToString();
            }
            return checkCode;
        }

        string mcode = "";//连接验证码验证和注册的全局变量

        //短信验证码
        private void button8_Click(object sender, EventArgs e)
        {
            string phn = textBox6.Text;
            mcode = getString(6);
            //判断手机号是否已经被注册
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "select * from users  where phn='" + phn + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader phone = cmd.ExecuteReader();
            if (phone.Read())
            {
                MessageBox.Show("该手机号已经被注册");
                textBox6.Text = "";

            }
            else if (phn.Length != 11)
            {
                textBox6.Text = "";
                MessageBox.Show("输入的手机号码不正确，请重新输入");
            }

            else
            {
                string ret = bikesSharing.CloudInfDemo.sendSmsCode(phn, 1, mcode);
                
                MessageBox.Show("验证码已发送，请查看");
            }

        }
        //注册
        private void button2_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                if (textBox5.Text == mcode)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                    conn.Open();
                    string sql = "insert into users(username,userid,phn,pwd) values(@username,@userid,@phn,@pwd)";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlParameter sp1 = new SqlParameter("username", textBox9.Text);
                    sp1.DbType = System.Data.DbType.String;
                    cmd.Parameters.Add(sp1);

                    SqlParameter sp2 = new SqlParameter("pwd", textBox8.Text);
                    sp2.DbType = System.Data.DbType.String;
                    cmd.Parameters.Add(sp2);

                    SqlParameter sp3 = new SqlParameter("userid", textBox7.Text);
                    sp3.DbType = System.Data.DbType.String;
                    cmd.Parameters.Add(sp3);

                    SqlParameter sp4 = new SqlParameter("phn", textBox6.Text);
                    sp4.DbType = System.Data.DbType.String;
                    cmd.Parameters.Add(sp4);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("注册成功！");
                    textBox9.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    this.panel2.Visible = true;
                    this.panel4.Visible = false;
                }
                else
                {
                    MessageBox.Show("验证码输入错误，请重新输入");
                    textBox5.Text = "";
                }
            }
            else
            {
                MessageBox.Show("用户已登录，无法重复注册！");
            }

        }

        private void 押金ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void 查询余额ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //押金充值
        private void button1_Click_1(object sender, EventArgs e)
        {
            string pwd = textBox10.Text;

            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();

            string sp2 = "select * from users where pwd='" + pwd + "'and uid='" + id + "'";
            SqlCommand cmd2 = new SqlCommand(sp2, conn);
            SqlDataReader pwdd = cmd2.ExecuteReader();
            if (pwdd.Read())
            {
                conn.Close();
                using (SqlConnection conn2 = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    conn2.Open();
                    /*    string spl = "update users set balance='"+balance+"'where uid='"+id+"'";
                        SqlCommand cmd = new SqlCommand(spl, conn2);
                        SqlParameter sp1 = new SqlParameter("balance", "balance"+balance);
                        sp1.DbType = System.Data.DbType.Int32;
                        cmd.Parameters.Add(sp1);
                        cmd.ExecuteNonQuery();  */
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update users set deposit='" + 199 + "'where uid='" + id + "'";
                    cmd.Connection = conn2;
                    cmd.ExecuteNonQuery();
                    conn2.Close();
                }

                MessageBox.Show("押金充值成功！");
                textBox10.Text = "";
            }
            else if (id == 0)
            {
                MessageBox.Show("用户未登录，请先登录");
            }
            else
            {
                textBox10.Text = "";
                MessageBox.Show("密码错误，请重新输入！");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked.ToString() == "True")
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel11.Visible = false;
                this.panel4.Visible = false;
                this.panel12.Visible = false;
                this.panel9.Visible = false;
                this.panel5.Visible = true;
                this.panel10.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = false;
                this.panel6.Visible = true;
            }
            else
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel9.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel11.Visible = false;
                this.panel12.Visible = false;
                this.panel5.Visible = true;
                this.panel10.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = false;
                this.panel6.Visible = false;
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked.ToString() == "True")
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel11.Visible = false;
                this.panel12.Visible = false;
                this.panel4.Visible = false;
                this.panel9.Visible = false;
                this.panel10.Visible = false;
                this.panel5.Visible = true;
                this.panel8.Visible = false;
                this.panel7.Visible = false;
                this.panel6.Visible = true;
            }
            else
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel12.Visible = false;
                this.panel11.Visible = false;
                this.panel10.Visible = false;
                this.panel9.Visible = false;
                this.panel3.Visible = false;
                this.panel8.Visible = false;
                this.panel4.Visible = false;
                this.panel5.Visible = true;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
            }
        }

        private void 充值ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel9.Visible = false;
                this.panel12.Visible = false;
                this.panel5.Visible = true;
                this.panel10.Visible = false;
                this.panel6.Visible = false;
                this.panel11.Visible = false;
                this.panel8.Visible = false;
                this.panel7.Visible = false;
            }
            else
            {
                MessageBox.Show("用户未登录，请先登录");
            }


        }

        private void 退款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel11.Visible = false;
                this.panel9.Visible = false;
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel12.Visible = false;
                this.panel6.Visible = false;
                this.panel10.Visible = false;
                this.panel7.Visible = false;
                this.panel8.Visible = true;
            }
            else
            {
                MessageBox.Show("用户未登录，请先登录");
            }

        }

        private void 充值ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                this.panel9.Visible = false;
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel10.Visible = false;
                this.panel12.Visible = false;
                this.panel11.Visible = false;
                this.panel3.Visible = true;
                this.panel4.Visible = false;
                this.panel8.Visible = false;
                this.panel6.Visible = false;
                this.panel5.Visible = false;
                this.panel7.Visible = false;
            }
            else
            {
                MessageBox.Show("用户未登录，请先登录");
            }

        }

        private void 退款ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel8.Visible = false;
                this.panel12.Visible = false;
                this.panel4.Visible = false;
                this.panel9.Visible = false;
                this.panel6.Visible = false;
                this.panel5.Visible = false;
                this.panel11.Visible = false;
                this.panel10.Visible = false;
                this.panel7.Visible = true;
            }
            else
            {
                MessageBox.Show("用户未登录，请先登录");
            }

        }
        //车费退款
        private void button9_Click(object sender, EventArgs e)
        {
            int balance = int.Parse(textBox11.Text);
            string pwd = textBox12.Text;



            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();

            string sp2 = "select * from users where pwd='" + pwd + "'and uid='" + id + "'";
            SqlCommand cmd2 = new SqlCommand(sp2, conn);
            SqlDataReader pwdd = cmd2.ExecuteReader();
            if (pwdd.Read())
            {
                conn.Close();
                using (SqlConnection conn2 = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    conn2.Open();
                    /*    string spl = "update users set balance='"+balance+"'where uid='"+id+"'";
                        SqlCommand cmd = new SqlCommand(spl, conn2);
                        SqlParameter sp1 = new SqlParameter("balance", "balance"+balance);
                        sp1.DbType = System.Data.DbType.Int32;
                        cmd.Parameters.Add(sp1);
                        cmd.ExecuteNonQuery();  */
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update users set balance=balance-'" + balance + "'where uid='" + id + "'";
                    cmd.Connection = conn2;
                    cmd.ExecuteNonQuery();
                    conn2.Close();
                }

                MessageBox.Show("退款成功！");
                textBox11.Text = "";
                textBox12.Text = "";
            }
            else if (id == 0)
            {
                MessageBox.Show("用户未登录，请先登录");
            }
            else
            {
                textBox12.Text = "";
                MessageBox.Show("密码错误，请重新输入！");
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        //退还押金
        private void button10_Click(object sender, EventArgs e)
        {
            string pwd = textBox13.Text;
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();

            string sp2 = "select * from users where pwd='" + pwd + "'and uid='" + id + "'";
            SqlCommand cmd2 = new SqlCommand(sp2, conn);
            SqlDataReader pwdd = cmd2.ExecuteReader();
            if (pwdd.Read())
            {
                conn.Close();
                using (SqlConnection conn2 = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"))
                {
                    conn2.Open();
                    /*    string spl = "update users set balance='"+balance+"'where uid='"+id+"'";
                        SqlCommand cmd = new SqlCommand(spl, conn2);
                        SqlParameter sp1 = new SqlParameter("balance", "balance"+balance);
                        sp1.DbType = System.Data.DbType.Int32;
                        cmd.Parameters.Add(sp1);
                        cmd.ExecuteNonQuery();  */
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update users set deposit='" + 0 + "'where uid='" + id + "'";
                    cmd.Connection = conn2;
                    cmd.ExecuteNonQuery();
                    conn2.Close();
                }

                MessageBox.Show("押金退款成功！");
                textBox13.Text = "";
            }
            else if (id == 0)
            {
                MessageBox.Show("用户未登录，请先登录");
            }
            else
            {
                MessageBox.Show("密码错误，请重新输入！");
                textBox13.Text = "";

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel6.Visible = false;
            this.panel7.Visible = false;
            this.panel11.Visible = false;
            this.panel12.Visible = false;
            this.panel9.Visible = false;
            this.panel5.Visible = false;
            this.panel10.Visible = false;
            this.panel8.Visible = false;
        }

        private void 车费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                conn.Open();

                string sql = "select balance  from users where  uid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int left = (int)cmd.ExecuteScalar();

                MessageBox.Show("您当前的车费余额为" + left + "元");
                conn.Close();
            }
            else
            {

                MessageBox.Show("用户未登录，请先登录");

            }


        }

        private void 押金ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("用户未登录，请先登录");
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                conn.Open();
                string sql2 = "select deposit  from users where  uid='" + id + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                int dep = (int)cmd2.ExecuteScalar();
                MessageBox.Show("您当前的押金为" + dep + "元");
                conn.Close();
            }

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = System.DateTime.Now;
            time.Text = dt.ToString();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }



        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 注销账户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = 0;
            MessageBox.Show("注销成功！");
            this.panel1.Visible = true;
            this.panel11.Visible = false;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel6.Visible = false;
            this.panel12.Visible = false;
            this.panel7.Visible = false;
            this.panel10.Visible = false;
            this.panel5.Visible = false;
            this.panel9.Visible = false;
            this.panel8.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                this.panel9.Visible = true;
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel12.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel6.Visible = false;
                this.panel11.Visible = false;
                this.panel7.Visible = false;
                this.panel5.Visible = false;
                this.panel10.Visible = false;
                this.panel8.Visible = false;
            }
            else
            {
                MessageBox.Show("您尚未登录，无法修改");

            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string pwd2 = textBox14.Text;
            string pwd3 = textBox15.Text;

            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();

            string sql = "select * from users where pwd='" + pwd2 + "' and uid='" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader pwdd = cmd.ExecuteReader();
            if (!pwdd.Read())
            {
                pwdd.Close();
                MessageBox.Show("原密码输入错误，请重新输入");
                conn.Close();
                textBox14.Text = "";

            }
            else
            {
                pwdd.Close();
                string sql2 = "update users set pwd='" + pwd3 + "' where uid='" + id + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("密码修改成功，请重新登录");
                textBox14.Text = "";
                textBox15.Text = "";
                id = 0;
                this.panel1.Visible = true;
                this.panel2.Visible = true;
                this.panel11.Visible = false;
                this.panel3.Visible = false;
                this.panel9.Visible = false;
                this.panel12.Visible = false;
                this.panel4.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel5.Visible = false;
                this.panel10.Visible = false;
                this.panel8.Visible = false;


                /*      SqlCommand cmd = new SqlCommand();
                      cmd.CommandType = CommandType.Text;
                      cmd.CommandText = "update users set deposit='" + 0 + "'where uid='" + id + "'";
                      cmd.Connection = conn2;
                      cmd.ExecuteNonQuery();
                      conn2.Close();  */
            }

        }

        //修改手机号
        string mcode2 = "";
        private void 修改手机号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel9.Visible = false;
                this.panel4.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel5.Visible = false;
                this.panel12.Visible = false;
                this.panel8.Visible = false;
                this.panel11.Visible = false;
                this.panel10.Visible = true;

                mcode2 = getString(6);

                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                conn.Open();
                string sql = "select phn from users where uid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                string phn1 = (string)cmd.ExecuteScalar();
                string ret = bikesSharing.CloudInfDemo.sendSmsCode(phn1, 1, mcode2);
                MessageBox.Show("验证码已发送，请查看");
            }
            else
            {
                MessageBox.Show("用户尚未登录，请先登录再修改");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (mcode2 == textBox17.Text)
            {
                this.panel11.Visible = true;
                this.panel1.Visible = true;
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel9.Visible = false;
                this.panel4.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel5.Visible = false;
                this.panel12.Visible = false;
                this.panel8.Visible = false;
                this.panel10.Visible = false;
                textBox17.Text = "";

            }
            else
            {
                MessageBox.Show("验证码输入错误，请重新输入");
                textBox17.Text = "";
            }
        }

        string mcode3 = "";
        private void button4_Click_1(object sender, EventArgs e)
        {
            string phn3 = textBox16.Text;
            mcode3 = getString(6);
            //判断手机号是否已经被注册
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "select * from users  where phn='" + phn3 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader phone = cmd.ExecuteReader();
            if (phone.Read())
            {
                MessageBox.Show("该手机号已经被注册");
                textBox16.Text = "";
            }
            else if (phn3.Length != 11)
            {
                MessageBox.Show("输入的手机号码不正确，请重新输入");
                textBox16.Text = "";

            }

            else
            {
                string ret = bikesSharing.CloudInfDemo.sendSmsCode(phn3, 1, mcode3);
                MessageBox.Show("验证码已发送，请查看");
              

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == mcode3)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                conn.Open();
                string sql = "update users set phn='" + textBox16.Text + "' where uid='" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("手机号已成功修改，请重新登录");
                textBox18.Text = "";

                this.panel1.Visible = true;
                this.panel11.Visible = false;
                this.panel2.Visible = true;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel6.Visible = false;
                this.panel7.Visible = false;
                this.panel10.Visible = false;
                this.panel5.Visible = false;
                this.panel9.Visible = false;
                this.panel8.Visible = false;
                this.panel12.Visible = false;

            }
            else
            {
                textBox18.Text = "";
                MessageBox.Show("验证码输入错误，请重新输入");
            }


        }
        string mcode6 = "";
        private void 找回密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel11.Visible = false;
            this.panel2.Visible = true;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel6.Visible = false;
            this.panel7.Visible = false;
            this.panel10.Visible = false;
            this.panel5.Visible = false;
            this.panel9.Visible = false;
            this.panel8.Visible = false;
            this.panel12.Visible = true;


            
        }

        private void 开始骑行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(id==0)
            {
                MessageBox.Show("用户尚未登录，无法骑行");
            }
            else
            {
                WindowsFormsApplication1.Form1 ff1 = new WindowsFormsApplication1.Form1();
              //  ff1.uuid = id;
               // WindowsFormsApplication1.Form2 ff2 = new WindowsFormsApplication1.Form2();
                WindowsFormsApplication1.Form2.fa = id;

                ff1.Show();
            }
            
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string phn = textBox19.Text;
            mcode6 = getString(6);
            //判断手机号是否已经被注册
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "select * from users  where phn='" + phn + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader phone = cmd.ExecuteReader();
            if (!phone.Read())
            {
                MessageBox.Show("不存在该用户");
                textBox19.Text = "";

            }
            else if (phn.Length != 11)
            {
                textBox19.Text = "";
                MessageBox.Show("输入的手机号码不正确，请重新输入");
            }

            else
            {
                string ret = bikesSharing.CloudInfDemo.sendSmsCode(phn, 1, mcode6);

                MessageBox.Show("验证码已发送，请查看");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if(textBox20.Text==mcode6)
            {
                SqlConnection conn = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                conn.Open();
                string sql2 = "select pwd  from users where  phn='" + textBox19.Text + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                string dep = (string)cmd2.ExecuteScalar();
                textBox21.Text = dep;
                conn.Close();
                
            }
            else
            {
                MessageBox.Show("验证码输入错误请重新输入");
                textBox21.Text = "";
            }
        }
    }
}

