using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Mine_Test
{
    public partial class Overlay : Form
    {
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        Graphics g;
        Pen pen = new Pen(Color.Red, 4);
        
        RECT rect;
        IntPtr handle;
        public const string winName = "지뢰 찾기";

        ReadMemory rm = new ReadMemory();
        public string[,] str = new string[9, 9];

        private string[,] _data;
        public string[,] Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private int h;
        public int H
        {
            get { return h; }
            set { h = value; }
        }
        private int w;
        public int W
        {
            get { return w; }
            set { w = value; }
        }


        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;

            int formStyle = GetWindowLongPtr(this.Handle, -20);
            SetWindowLong(this.Handle, -20, formStyle | 0x80000 | 0x20);
            handle = FindWindow(null, winName);
            GetWindowRect(handle, out rect);
            int h = rect.Bottom - rect.Top;
            int w = rect.Right - rect.Left;
            this.Size = new Size(w, h);
            this.Top = rect.Top;
            this.Left = rect.Left;

            tmr_setting.Enabled = true;
        }

        public void arrayData(string[,] data)
        {
            /*for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    
                    md.map[i, j] = data[i, j];
                }
            }*/

            str = data.Clone() as string[,];
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (Data[i, j] == "8F")
                    {
                        rect.Left = (j * 16) + 15;
                        rect.Top = (i * 16) + 100;
                        g.DrawRectangle(pen, rect.Left, rect.Top, 15, 15);
                    }
                        
                }
            }

        }

        private void tmr_setting_Tick(object sender, EventArgs e)
        {
            GetWindowRect(handle, out rect);
            this.Top = rect.Top;
            this.Left = rect.Left;
        }

        private static int GetProcessId(string procName)
        {
            Process[] process = Process.GetProcessesByName(procName);
            if (process.Length > 0)
            {
                return process[0].Id; 
            }
            else
            {
                return -1;
            }
        }

       
        
    }
}
