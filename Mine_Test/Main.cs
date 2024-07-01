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
using static System.Windows.Forms.DataFormats;

namespace Mine_Test
{
    public partial class Main : Form
    {
        Process[] myProc;
        ReadMemory rm = new ReadMemory();
        Process proc;
        Overlay overlay = new Overlay();

        bool attach = false;
        bool mapHack = false;

        Pointer mainMine;
        int base_m = 0x00005361;
        int base_w = 0x00005334;
        int base_h = 0x00005338;
        int main_addr;
        int h_addr;
        int w_addr;
        int h;
        int w;

        public Main()
        {
            InitializeComponent();
        }



        private void wallHack_CheckedChanged_1(object sender, EventArgs e)
        {
            if (wallHack.Checked == true)
            {
                //timer2.Enabled = true;
                string specifier = "X";
                string str;
                string[,] data = new string[h,w];
                int addr, val;
                
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        //map_addr = map_addr + j;
                        //addr = main_addr;
                        //addr += j;
                        addr = main_addr + j + i * 32;
                        val = rm.ReadInt(addr);
                        str = val.ToString(specifier);
                        data[i, j] = str.Substring(str.Length - 2);

                    }

                }
                overlay.Data = data;
                overlay.H = h;
                overlay.W = w;
                overlay.Show();
            }
            else
            {
                overlay.Hide();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            wallHack.Enabled = false;
            
        }

        protected void btn_catchProc_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    string str = comboBox1.SelectedItem.ToString();
                    int pid = int.Parse(str.Split(':')[str.Split(':').Length - 1]);
                    proc = Process.GetProcessById(pid);

                    rm.ReadProcess = proc;
                    rm.OpenProcess();
                    

                    /*int base_w = proc.MainModule.BaseAddress.ToInt32() + 0x00005334;
                    int base_h = proc.MainModule.BaseAddress.ToInt32() + 0x00005338;
                    int base_m = proc.MainModule.BaseAddress.ToInt32() + 0x00005361;
                    int base_t = proc.MainModule.BaseAddress.ToInt32() + 0x0000579C;
                    int w_base = rm.ReadInt(base_w);
                    int h_base = rm.ReadInt(base_h);
                    int m_base = rm.ReadInt(base_m);
                    int t_base = rm.ReadInt(base_t);*/
                    
                    //lbl_base.Text = "베이스 : " + base_addr;
                    lbl_catchProc.ForeColor = Color.LimeGreen;
                    lbl_catchProc.Text = proc.ProcessName + "을 열었습니다 :D";
                    int base_addr = proc.MainModule.BaseAddress.ToInt32();
                    int mine_base = rm.ReadInt(base_addr);
                    mainMine = new Pointer(base_addr);

                    main_addr = base_addr + base_m;
                    w_addr = base_addr + base_w;
                    h_addr = base_addr + base_h;
                    timer2.Enabled = true;



                    wallHack.Enabled = true;
                    
                    attach = true;
                }
            }
            catch (Exception except)
            {
                attach = false;
            }
        }

        protected void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            myProc = Process.GetProcesses();

            foreach (Process proc in myProc)
            {
                string str = proc.ProcessName + ":" + proc.Id;
                comboBox1.Items.Add(str);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (attach)
            {
                try
                {
                    mainMine.SetMineData(rm);

                    string specifier = "X";
                    lbl_base.Text = "베이스 : " + mainMine.base_addr.ToString(specifier);
                    lbl_time.Text = "시간 : " + mainMine.time;
                    lbl_arAddr.Text = "지뢰주소 : " + mainMine.main_addr.ToString(specifier);
                    
                }
                catch { }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            w = rm.ReadInt(w_addr);
            h = rm.ReadInt(h_addr);
            lbl_h.Text = "높이 : " + w;
            lbl_w.Text = "너비 : " + h;
        }
    }
}
