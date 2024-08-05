using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flashscreen
{
    
    public partial class Form1 : Form
    {

        string dir = "";
        bool running = false;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择图片文件";
            openFileDialog.Filter = "图片文件(*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png"; // 设置文件过滤器
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dir=openFileDialog.FileName;
            }
            if (dir == "")
            {
                MessageBox.Show("请选择图片文件");
            }
            else
            {
                pictureBox1.Load(dir);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 允许输入数字、Backspace和退出键
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true; // 不允许输入其他字符
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || dir == "")
            {

                MessageBox.Show("请输入全部参数");
                return;
            }
            Form2 f2 = new Form2(dir, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            if (running == false)
            {
                MessageBox.Show("开始喽\n已隐藏到系统托盘");
                running = true;
                button2.Text = "停止";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                f2.WindowState = FormWindowState.Minimized;
                f2.Show();
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                running = false;
                
                //button2.Text = "开始";
                MessageBox.Show("停止力");
                //textBox1.Enabled = true;
                //textBox2 .Enabled = true;
                //button1.Enabled = true;
                //f2.Close();
                System.Environment.Exit(0);
            }

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
    }
}
