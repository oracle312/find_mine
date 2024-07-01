using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Mine_Test
{
    internal class Pointer
    {
        public int base_addr;
        public int main_addr;
        public int map_addr;
        public string[,] data;
        public int val;
        /*int base_w = proc.MainModule.BaseAddress.ToInt32() + 0x00005334;
                    int base_h = proc.MainModule.BaseAddress.ToInt32() + 0x00005338;
                    int base_m = proc.MainModule.BaseAddress.ToInt32() + 0x00005361;
                    int base_t = proc.MainModule.BaseAddress.ToInt32() + 0x0000579C;
                    int w_base = rm.ReadInt(base_w);
                    int h_base = rm.ReadInt(base_h);
                    int m_base = rm.ReadInt(base_m);
                    int t_base = rm.ReadInt(base_t);*/
        int base_w = 0x00005334;
        int base_h = 0x00005338;
        int base_m = 0x00005361;
        int base_t = 0x0000579C;

        public int time;

        public ReadMemory mem = new ReadMemory();
        public Process pProc;
        public Overlay overlay = new Overlay();

        /*public Pointer(int mine_addr)
        {
            base_addr = mine_addr;
            time = 0;
        }*/

        public Pointer(int mine_base)
        {
            base_addr = mine_base;
            main_addr = base_addr + base_m;

            time = 0;
            val = 0;
            data = new string[9, 9];

        }

        public void SetMineData(ReadMemory rm)
        {
            time = rm.ReadInt(base_addr + base_t);
            mem = rm;
            /* string specifier = "X";
             string str;
             int addr;
             for (int i = 0; i < 9; i++)
             {
                 for (int j = 0; j < 9; j++)
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

             overlay.arrayData(data);

             overlay.Data = data;
         }*/
        }
    }
}
