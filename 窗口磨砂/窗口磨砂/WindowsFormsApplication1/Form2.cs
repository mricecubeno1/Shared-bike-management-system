using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using System.Data.SqlClient;
using xqMedia;


namespace WindowsFormsApplication1
{
    public partial class Form2 : CCSkinMain
    {
        private xqMedia.Audio ad = null;
        public static bool tag = true;
        public static Time time;
        private string a;
        private string b;
        private string c;

        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            int hour = 0;
            int minute = 0;
            int second = 0;
            time = new Time(hour, minute, second);
            this.skinLabel2.Text = "00:00:00";
            this.skinLabel1.Text = "0.0";
            skinButton2.Enabled = false;
            skinButton1.Enabled = true;

            ad = new xqMedia.Audio();
            updateToolBar();
            updateSum();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time.GetHours() > 9)
            {
                skinLabel2.Text = "" + time.GetHours() + "";
            }
            else
            {
                skinLabel2.Text = "0" + time.GetHours() + "";
            }
            if (time.GetMinutes() > 9)
            {
                skinLabel2.Text = skinLabel2.Text + ":" + time.GetMinutes() + "";
            }
            else
            {
                skinLabel2.Text = skinLabel2.Text + ":0" + time.GetMinutes() + "";
            }
            if (time.GetSeconds() > 9)
            {
                skinLabel2.Text = skinLabel2.Text + ":" + time.GetSeconds() + "";
            }
            else
            {
                skinLabel2.Text = skinLabel2.Text + ":0" + time.GetSeconds() + "";
            }
            if (time.GetMinutes() < 30 && time.GetHours() < 1)
            {
                skinLabel1.Text = "0.5";
            }
            else
            {
                double a = 0.5 * time.GetMinutes() / 30 + 1 * time.GetHours();
                String str = a.ToString("#0.0");  // 控制输出小数点后一位小数  
                skinLabel1.Text = str;
               
            }
        }



        
     
        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            skinButton1.Enabled = false;
            skinButton2.Enabled = true;
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn.Open();
            string sql = "update bike set available='" + "使用中" + "' where bid='"+WindowsFormsApplication1.Form1.bbid+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        
        public static int fa;
       
        private void skinButton2_Click(object sender, EventArgs e)
        {
            
            this.timer1.Stop();
           // int flee = int.Parse(skinLabel1.Text);
            skinButton2.Enabled = false;
            //创建骑记录
            SqlConnection conn1 = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=bikesSharing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False");
            conn1.Open();
            string sql1 = "insert into buser(uid,bid,flee) values(@uid,@bid,@flee)";
            SqlCommand cmd1 = new SqlCommand(sql1, conn1);
            SqlParameter sp1 = new SqlParameter("uid",fa);
            sp1.DbType = System.Data.DbType.Int32;
            cmd1.Parameters.Add(sp1);
            SqlParameter sp2 = new SqlParameter("bid",WindowsFormsApplication1.Form1.bbid);
            sp2.DbType = System.Data.DbType.Int32;
            cmd1.Parameters.Add(sp2);
            SqlParameter sp3 = new SqlParameter("flee",skinLabel1.Text);
            sp3.DbType = System.Data.DbType.String;
            cmd1.Parameters.Add(sp3);
            cmd1.ExecuteNonQuery();
            /*
            int flee = int.Parse(skinLabel1.Text);
            string sql2 = "update users set balance=balance-'"+flee+"'";
            SqlCommand cmd2 = new SqlCommand(sql2,conn1);
            cmd2.ExecuteNonQuery(); 
            */
            conn1.Close();

        }

        private void skinLabel4_Click(object sender, EventArgs e)
        {

        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            if (tag)
            {
                //这里是代码段一
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files|*.*";
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                ad.RenderMedia(ofd.FileName, true);
                skinTrackBar1.Maximum = ad.MediaDuration;
                updateToolBar();
                tag = false;
                skinButton3.Text = "暂停";
            }
            else
            {                //这里是代码段二
                ad.Pause();
                updateToolBar();
                tag = true;
                skinButton3.Text = "听音乐";
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ad != null)
                ad.CloseMedia();
        }
        private void updateToolBar()
        {
            skinTrackBar2.Enabled = skinTrackBar1.Enabled = true;
            switch (ad.MediaStatus)
            {
                case 0:
                    skinTrackBar2.Enabled = skinTrackBar1.Enabled = false;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            skinTrackBar2.Value = ad.MediaVol;

        }
        private void updateSum()
        {
            lbSum.Text = string.Format("{0} / {1}", ad.MediaCurPos2, ad.MediaDuration2);
            skinTrackBar1.Value = ad.MediaCurPos;
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ad.MediaStatus == 3)
            {
                updateSum();
            }
            else if (ad.MediaStatus == 1)
            {
                updateToolBar();
                updateSum();
            }

        } 

        private void skinTrackBar1_Scroll(object sender, EventArgs e)
        {
            ad.Seek(skinTrackBar1.Value);
        }

        private void skinTrackBar2_Scroll(object sender, EventArgs e)
        {
            ad.MediaVol = skinTrackBar2.Value;
        }

        public string bbid { get; set; }

        private void skinLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
