using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bikesSharing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form3 register = new Form3();
            register.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.Close();
            Form2 register = new Form2();
           
            register.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
