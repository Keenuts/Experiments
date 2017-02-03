using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips
{
    class Ram
    {
        public byte[] ram;
        public const int Lenght = 64 * 1024;

        public Ram()
        {
            ram = new byte[64 * 1024];
        }

        public byte ReadByte(int pos)
        {
            if (pos < 0 || pos > ram.Length)
                return 0;
            else
                return ram[pos];
        }

        byte[] ReadN(int pos, int n)
        {
            if (pos < 0 || pos + n > ram.Length)
            {
                Console.Error.WriteLine("Out of RAM's bounds");
                return null;
            }

            byte[] r = new byte[n];

            for (int i = 0; i < n; i++)
                r[i] = ram[pos + i];

            return r;
        }

        public byte[] ReadWord(int pos)
        {
            return ReadN(pos, 2);
        }

        public byte[] ReadInt(int pos)
        {
            return ReadN(pos, 4);
        }

        public byte[] ReadLong(int pos)
        {
            return ReadN(pos, 8);
        }

        public byte[] ReadInstruction(int pos)
        {
            int n = 4;
            if (pos < 0 || pos + n > ram.Length)
            {
                Console.Error.WriteLine("Out of RAM's bounds");
                return null;
            }

            byte[] r = new byte[n];

            for (int i = 0; i < n; i++)
                r[n - i - 1] = ram[pos + i];

            return r;
        }


        public int WriteBytes(int start, byte[] b)
        {
            if (start < 0 || start + b.Length > ram.Length)
            {
                Console.Error.WriteLine("Error inserting data i ram (out of bounds)");
                return 0;
            }

            for(int i = 0 ; i < b.Length ; i++)
            {
                ram[start + i] = b[i];
            }
            return b.Length;
        }

        public void DisplayRam(int lenght)
        {
            for (int i = 0; i < ram.Length && i < lenght; i++)
            {
                if (i % 16 == 0)
                    Console.WriteLine();
                Console.Write(String.Format("{0,4:X}", ram[i]));
            }
            Console.WriteLine("\n");
        }
    }
}
