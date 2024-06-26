using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mine_Test
{
    class ReadMemoryAPI
    {
        public const uint PROCESS_VM_READ = (0x0010);
        public const uint PROCESS_VM_WRITE = (0x0020);
        public const uint PROCESS_VM_OPERATION = (0x0008);
        public const uint PAGE_READWRITE = 0x0004;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_ACTIVATE = 0x6;
        public const int WM_HOTKEY = 0x0312;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UInt32 dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        public static extern int GetKeyState(int vKey);
    }

    public class ReadMemory
    {
        public ReadMemory()
        {
        }
            public Process ReadProcess
        {
            get
            {
                return m_ReadProcess;
            }
            set
            {
                m_ReadProcess = value;
            }
        }
        private Process m_ReadProcess = null;
        private IntPtr m_hProcess = IntPtr.Zero;

        public void OpenProcess()
        {
            m_hProcess = ReadMemoryAPI.OpenProcess(ReadMemoryAPI.PROCESS_VM_READ
                | ReadMemoryAPI.PROCESS_VM_WRITE | ReadMemoryAPI.PROCESS_VM_OPERATION, 1, (uint)m_ReadProcess.Id);
        }
        public void CloseHandle()
        {
            int iRetValue;
            iRetValue = ReadMemoryAPI.CloseHandle(m_hProcess);
            if (iRetValue == 0)
                throw new Exception("CloseHandle failed");
        }

        public int ReadMem(int MemoryAddress, uint bytesToRead, out byte[] buffer)
        {
            IntPtr procHandle = ReadMemoryAPI.OpenProcess(ReadMemoryAPI.PROCESS_VM_READ | ReadMemoryAPI.PROCESS_VM_WRITE | ReadMemoryAPI.PROCESS_VM_OPERATION, 1, (uint)m_ReadProcess.Id);
            if (procHandle == IntPtr.Zero)
            {
                buffer = new byte[0];
                return 0;
            }

            buffer = new byte[bytesToRead];
            IntPtr ptrBytesReaded;
            ReadMemoryAPI.ReadProcessMemory(procHandle, (IntPtr)MemoryAddress, buffer, bytesToRead, out ptrBytesReaded);
            ReadMemoryAPI.CloseHandle(procHandle);
            return ptrBytesReaded.ToInt32();
        }
        public int ReadMultiLevelPointer(int MemoryAddress, uint bytesToRead, Int32[] offsetList)
        {
            IntPtr procHandle = ReadMemoryAPI.OpenProcess(ReadMemoryAPI.PROCESS_VM_READ | ReadMemoryAPI.PROCESS_VM_WRITE | ReadMemoryAPI.PROCESS_VM_OPERATION, 1, (uint)m_ReadProcess.Id);
            IntPtr pointer = (IntPtr)0x0;
            //IF THE PROCESS isnt available we return nothing
            if (procHandle == IntPtr.Zero)
            {
                return 0;
            }

            byte[] btBuffer = new byte[bytesToRead];
            IntPtr lpOutStorage = IntPtr.Zero;

            int pointerAddy = MemoryAddress;
            //int pointerTemp = 0;
            for (int i = 0; i < (offsetList.Length); i++)
            {
                if (i == 0)
                {
                    ReadMemoryAPI.ReadProcessMemory(
                        procHandle,
                        (IntPtr)(pointerAddy),
                        btBuffer,
                        (uint)btBuffer.Length,
                        out lpOutStorage);
                }
                pointerAddy = (BitConverter.ToInt32(btBuffer, 0) + offsetList[i]);
                //string pointerAddyHEX = pointerAddy.ToString("X");

                ReadMemoryAPI.ReadProcessMemory(
                    procHandle,
                    (IntPtr)(pointerAddy),
                    btBuffer,
                    (uint)btBuffer.Length,
                    out lpOutStorage);
            }
            return pointerAddy;
        }

        public byte ReadByte(int MemoryAddress)
        {
            byte[] buffer;
            int read = ReadMem(MemoryAddress, 1, out buffer);
            if (read == 0)
                return new byte();
            else
                return buffer[0];
        }
        public int ReadInt(int MemoryAddress)
        {
            byte[] buffer;
            int read = ReadMem(MemoryAddress, 4, out buffer);
            if (read == 0)
                return 0;
            else
                return BitConverter.ToInt32(buffer, 0);
        }
        public uint ReadUInt(int MemoryAddress)
        {
            byte[] buffer;
            int read = ReadMem(MemoryAddress, 4, out buffer);
            if (read == 0)
                return 0;
            else
                return BitConverter.ToUInt32(buffer, 0);
        }

        public string ReadString(int MemoryAddress)
        {
            byte[] buffer;
            int length = 0;

            for (int i = 0; ReadByte(MemoryAddress + i) != 0; i++) length = i + 1; // We want to find the null-terminator of the string to determine length

            int read = ReadMem(MemoryAddress, (uint)length, out buffer);

            if (read == 0) return "";
            else return System.Text.Encoding.Default.GetString(buffer);
        }

        public float ReadFloat(int MemoryAddress)
        {
            byte[] buffer;
            int read = ReadMem(MemoryAddress, 4, out buffer);
            if (read == 0)
                return 0;
            else
                return BitConverter.ToSingle(buffer, 0);
        }
        public byte[] ReadAMem(IntPtr MemoryAddress, uint bytesToRead, out int bytesReaded)
        {
            byte[] buffer = new byte[bytesToRead];

            IntPtr ptrBytesReaded;
            ReadMemoryAPI.ReadProcessMemory(m_hProcess, MemoryAddress, buffer, bytesToRead, out ptrBytesReaded);
            bytesReaded = ptrBytesReaded.ToInt32();
            return buffer;
        }
        internal byte[] ReadAMem(int p, int p_2, out int bytesReadSize)
        {
            throw new NotImplementedException();
        }
    }


    
    
}
