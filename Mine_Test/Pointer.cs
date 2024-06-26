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
        int base_addr;
        public int main_addr;
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
        }

        public void SetMineData(ReadMemory rm)
        {
            time = rm.ReadInt(base_addr + base_t);
            mem = rm;
        }
    }
}
