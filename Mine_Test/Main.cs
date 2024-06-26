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
        Process[] myProc;
        ReadMemory rm = new ReadMemory();
        Process proc;
        Overlay overlay = new Overlay();

        bool attach = false;
        bool mapHack = false;

        Pointer mainMine;
        

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
                    mainMine.pProc = proc;



                    int[,] map = new int[9, 9];
                    int val = 0;
                    int bdr = proc.MainModule.BaseAddress.ToInt32() + 0x00005361;
                    int mdr = rm.ReadInt(base_addr);
                    

                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 9; j < 9; j++)
                        {
                            int m_addr = bdr + i;
                            val = rm.ReadInt(m_addr);

                            map[i, j] = val;
                            Console.WriteLine(map[i, j] + " ");
                        }
                        Console.WriteLine();
                    }



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
                    
                    lbl_time.Text = "시간 : " + mainMine.time; 
                }
                catch { }
            }
        }
    }
}
