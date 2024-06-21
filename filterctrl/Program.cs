/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2024/6/17
 * Time: 18:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
namespace filterctrl
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			
			
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			Form MainForm = new Form();
			MainForm.Text="filterinput控制台";
			MainForm.Size = new Size(375,500);
			MainForm.Icon = Properties.Resources.ie;
			MainForm.MaximizeBox = false;
			MainForm.FormBorderStyle=FormBorderStyle.FixedSingle;
			
			
    		MainForm.BackgroundImage = Properties.Resources._1;
			MainForm.BackgroundImageLayout=ImageLayout.Stretch;
			MainForm.Opacity = 0.9;
			
			Font myfont = new Font("Segoe UI",15,FontStyle.Bold);
			Font myfont2 = new Font("Segoe UI",12,FontStyle.Italic);
			
			Button button_close=new Button();
			button_close.Text="关闭filterinput\n程序";
			button_close.Click+=new EventHandler(close);
			button_close.Size = new Size(150,150);
			button_close.Location=new Point(10,10);
			button_close.Font = myfont;
			button_close.ForeColor = Color.MediumBlue;
			button_close.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button_close.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button_close.BackColor=Color.Transparent;
			button_close.FlatStyle=FlatStyle.Flat;
			MainForm.Controls.Add(button_close);
			
			Button button_open=new Button();
			button_open.Text="打开filterinput\n程序";
			button_open.Click+=new EventHandler(open);
			button_open.Size=new Size(150,150);
			button_open.Location=new Point(200,10);
			button_open.Font = myfont;
			button_open.ForeColor = Color.IndianRed;
			button_open.BackColor=Color.Transparent;
			button_open.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button_open.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button_open.FlatStyle=FlatStyle.Flat;
			MainForm.Controls.Add(button_open);
			
			Button button_add = new Button();
			button_add.Text="将filterinput加入开机启动";
			button_add.Size = new Size(250,100);
			button_add.Location = new Point(50,190);
			button_add.Font = myfont;
			button_add.ForeColor = Color.Green;
			button_add.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button_add.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button_add.Click+=new EventHandler(add);
			button_add.BackColor=Color.Transparent;
			button_add.FlatStyle=FlatStyle.Flat;
			MainForm.Controls.Add(button_add);
			
			Button button_delete = new Button();
			button_delete.Text="关闭filterinputの开机启动";
			button_delete.Size = new Size(250,100);
			button_delete.Location = new Point(50,320);
			button_delete.Font = myfont;
			button_delete.FlatAppearance.MouseOverBackColor = Color.Transparent;
			button_delete.FlatAppearance.MouseDownBackColor = Color.Transparent;
			button_delete.ForeColor = Color.BlueViolet;
			button_delete.Click+=new EventHandler(delete);
			button_delete.BackColor=Color.Transparent;
			button_delete.FlatStyle=FlatStyle.Flat;
			MainForm.Controls.Add(button_delete);
			
			Label label1=new Label();
			label1.Text = "——by zymmiwang";
			label1.Location = new Point(210,440);
			label1.AutoSize=true;
			label1.Font = myfont2;
			label1.BackColor=Color.Transparent;
			label1.ForeColor = Color.Black;
			MainForm.Controls.Add(label1);
			
			
			
			
			
			
			Application.Run(MainForm);
		}
		
		
		private static void close(object sender, EventArgs e){
			bool a=false;
			string processName = "filterinput"; // 替换为你想关闭的程序名称
        	foreach (Process p in Process.GetProcesses())
        	{
            	if (p.ProcessName.Equals(processName))
            	{
                	try
                	{
                    	p.Kill(); // 尝试关闭进程
                    	p.WaitForExit(); // 等待进程退出
                    	MessageBox.Show("关闭成功");
                    	a=true;
                	}
                	catch (Exception ex)
                	{
                		//MessageBox.Show("无法关闭！");
                	}
            	}
        	}
        	if(a==false){
        		MessageBox.Show("关闭失败");
        	}
		}
		
		
		private static void open(object sender, EventArgs e){
			try{
			
				Process.Start("filterinput.exe");
				MessageBox.Show("打开成功");
			}
			catch(Exception ex){
				MessageBox.Show("无法打开");
			}
		
		
		}
		
		private static void add(object sender, EventArgs e){
			try{
				string exePath = AppDomain.CurrentDomain.BaseDirectory+"filterinput.exe";
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            	key.SetValue("filterinput", exePath);		
            	MessageBox.Show("添加成功");
			}
			catch{
				MessageBox.Show("添加失败");
			}
			
		}
		
		
		private static void delete(object sender, EventArgs e){
			try{
				RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
				key.DeleteValue("filterinput");
            	MessageBox.Show("删除成功");
			}
			catch{
				MessageBox.Show("删除失败");
			}
			
		
		}
		
		
	}
}
