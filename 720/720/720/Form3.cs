using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _720
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new _720.Form2();
            form2.MdiParent = this;
            form2.Show();
          
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new _720.Form1();
            form1.MdiParent = this;
            form1.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 数量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new _720.Form4();
            form4.MdiParent = this;
            form4.Show();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 用户查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {//
            Form5 form5 = new Form5();
            form5.MdiParent = this;
            form5.Show();
        }
        //跳转用户管理界面
        private void 用户删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.MdiParent = this;
            form6.Show();
        }

        private void 费用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //跳转费用界面
            Form7 form7 = new Form7();
            form7.MdiParent  = this;
            form7.Show();
        }

        private void 研发团队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 form8 = new _720.Form8();
            form8.MdiParent = this;
            form8.Show();
        }

        private void 用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           

        //    SoundPlayer music = new SoundPlayer();
        //    SoundPlayer sp = new SoundPlayer("C:\\Users\\zhang\\Downloads\\720.wav");//wav格式的音频
        //   // sp.PlayLooping();//循环播放
        //    sp.Play();//播放单次
        //    //sp.Stop();//停止


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }
    }
}
