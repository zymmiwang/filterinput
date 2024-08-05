using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace flashscreen
{
    public partial class Form2 : Form
    {
        int lasttime1 = 100;
        System.Timers.Timer timer1 = new System.Timers.Timer(10000);
        string dir = "";
        public Form2(string url,int intervaltime,int lasttime)
        {
            pictureBox1 = new PictureBox();
            
            dir = url;
            

            lasttime1 = lasttime;
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(dir);
            timer1.Interval = intervaltime*1000+lasttime;
            timer1.Elapsed += waiting;
            timer1.AutoReset = true;
            timer1.Start();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        System.Timers.Timer timer2 = new System.Timers.Timer(100);
        private void waiting(Object source, ElapsedEventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            timer2.Interval = lasttime1;
            timer2.Elapsed += showing;
            timer2.AutoReset = true;
            timer2.Start();
        }


        private void showing(Object source, ElapsedEventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            this.Close();
        }
    }
}
