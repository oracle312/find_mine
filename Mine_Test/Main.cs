using System;
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
    public partial class Main : Form
    {
        Overlay overlay = new Overlay();
        const int PROCESS_WM_READ = 0x0010;
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public Main()
        {
            InitializeComponent();
        }



        private void wallHack_CheckedChanged_1(object sender, EventArgs e)
        {
            if (wallHack.Checked == true)
            {
                overlay.Show();
            }
            else
            {
                overlay.Hide();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            

        }
    }
}
