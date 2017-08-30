using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;//引用DLL申明
using CCWin;
using System.Text.RegularExpressions;
using System.Net;
using System.Data.SqlClient;
namespace  WindowsFormsApplication1
{
    public partial class Form1 : CCSkinMain
    {
        //DLL申明
        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }

        //DLL申明
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS
        margins);

        //DLL申明
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        //直接添加代码
        protected override void OnLoad(EventArgs e)
        {
            if (DwmIsCompositionEnabled())
            {
                MARGINS margins = new MARGINS();
                margins.Right = margins.Left = margins.Top = margins.Bottom =
        this.Width + this.Height;
                DwmExtendFrameIntoClientArea(this.Handle, ref margins);
            }
            base.OnLoad(e);
        }

        //直接添加代码
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (DwmIsCompositionEnabled())
            {
                e.Graphics.Clear(Color.DarkBlue);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void skinLabel1_Click(object sender, EventArgs e)
        {

        }

        private void skinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinComboBox1.SelectedItem.ToString() == "辽宁省")
            {
                skinComboBox2.Items.Clear();
                skinComboBox2.Text = "";
                skinComboBox2.Items.Add("沈阳市");
                skinComboBox2.Items.Add("鞍山市");
            }
            if (skinComboBox1.SelectedItem.ToString() == "其他")
            {
                skinComboBox2.Items.Clear();
                skinComboBox2.Text = "";
                skinComboBox2.Items.Add("海口");
                skinComboBox2.Items.Add("万宁");
            }
        }

        private void skinComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinComboBox2.SelectedItem.ToString() == "沈阳市")
            {
                skinComboBox3.Items.Clear();
                skinComboBox3.Text = "";
                skinComboBox3.Items.Add("浑南区");
                skinComboBox3.Items.Add("和平区");
                skinComboBox3.Items.Add("铁西区");
            }
            if (skinComboBox2.SelectedItem.ToString() == "鞍山市")
            {
                skinComboBox3.Items.Clear();
                skinComboBox3.Text = "";
                skinComboBox3.Items.Add("6");
                skinComboBox3.Items.Add("7");
            }
        }

        public static int bbid;
        
        private void skinButton1_Click(object sender, EventArgs e)
        {

            if (this.skinComboBox1.SelectedItem == null || this.skinComboBox3.SelectedItem == null || this.skinComboBox3.SelectedItem == null)
            {
                MessageBox.Show("请选择正确的位置");
            }
            else
            {
                string a = skinComboBox1.SelectedItem.ToString();
                string b = skinComboBox2.SelectedItem.ToString();
                string c = skinComboBox3.SelectedItem.ToString();
                //this.Hide();
                //Form2 form2 = new Form2();
                //form2.Show();
                SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
                conn.Open();
                string sql = "select bid from bike where area='"+c+"' and available='"+"可用"+"'";
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataReader sread = cmd.ExecuteReader();
                if(sread.Read())
                {
                    sread.Close();
                    panel1.Visible = true;
                    bbid = (int)cmd.ExecuteScalar();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("没车啦!");
                }

            }
        }
        public static string[] GetWeather()
        {
            Regex regex;

            string[] weather = new string[5];
            string content = "";

            Match mcTmp;
           // Match mcCity;
            int k = 1;

            HttpWebResponse theResponse;
            WebRequest theRequest;


            //ss1.htm 注意：ss1-ss303代表了不同的城市，是不连续的    ss1代表香港
            theRequest = WebRequest.Create("http://weather.news.qq.com/inc/ss115.htm");
            try
            {
                theResponse = (HttpWebResponse)theRequest.GetResponse();

                using (System.IO.Stream sm = theResponse.GetResponseStream())
                {
                    System.IO.StreamReader read = new System.IO.StreamReader(sm, Encoding.Default);
                    content = read.ReadToEnd();
                }
            }
            catch (Exception)
            {
                content = "";
            }


            string parttenTmp = "<td height=\"23\" width=\"117\" background=\"/images/r_tembg5.gif\" align=\"center\">(?<item1>[^<]+)</td>";
            k = 1;
            regex = new Regex(parttenTmp, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (mcTmp = regex.Match(content), k = 1; mcTmp.Success; mcTmp = mcTmp.NextMatch(), k++)
            {

                weather[0] = mcTmp.Groups["item1"].Value;
            }
            parttenTmp = "height=\"23\" align=\"center\">(?<item1>[^/]+)</td>";
            k = 1;
            regex = new Regex(parttenTmp, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (mcTmp = regex.Match(content), k = 1; mcTmp.Success; mcTmp = mcTmp.NextMatch(), k++)
            {
                weather[k] = mcTmp.Groups["item1"].Value;
            }
            return weather;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] str = GetWeather();
            panel1.Visible = false;
            textBox1.Text = str[1];
            textBox2.Text = str[2];
            textBox3.Text = str[3];
            if (str[3] == "优" || str[3] == "良" || str[3] == "中")
            {
                skinLabel3.Visible = true;
                skinLabel4.Visible = false;
            }
            else
            {
                skinLabel4.Visible = true;
                skinLabel3.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

     
    }
}