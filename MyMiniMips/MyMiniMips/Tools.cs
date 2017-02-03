using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips
{
    class Tools
    {
        public static int Bytes2Int(byte[] b)
        {
            if (b == null)
            {
                Console.Error.WriteLine("Unable to convert byte[] to int");
                return 0;
            }

            int n = 0;
            for (int i = 0; i < b.Length; i++)
            {
                n <<= 8;
                n += b[i];
            }
            return n;
        }

        public static byte[] Int2Bytes(int n)
        {
            byte[] b = new byte[4] { 0, 0, 0, 0 };

            for (int i = 3; i >= 0; i--)
            {
                b[i] = (byte)n;
                n >>= 8;
            }

            return b;
        }

        public static int IntTruncate(int start, int lenght, int val)
        {
            int mask = 0;

            for (int i = start; i < 32; i++)
            {
                mask <<= 1;
                if (i < start + lenght)
                    mask += 1;
            }

            val &= mask;
            val >>= 32 - start - lenght;
            return val;
        }

        public static string BinaryStr(int val, int padding = -1)
        {
            if (padding == -1)
                return Convert.ToString(val, 2);
            else
            {
                string ret = "";
                padding -= 1;
                while (padding >= 0)
                {
                    ret += (val & (1 << padding)) != 0 ? "1" : "0";
                    padding--;
                }

                return ret;
            }
        }

        public static string BinaryStr(uint val, int padding = -1)
        {
            if (padding == -1)
                return Convert.ToString(val, 2);
            else
            {
                string ret = "";
                padding -= 1;
                while (padding >= 0)
                {
                    ret += (val & (1 << padding)) != 0 ? "1" : "0";
                    padding--;
                }

                return ret;
            }
        }

        public static string BinaryStr(byte b)
        {
            return  Convert.ToString(b, 2);
        }

        public static string BinaryStr(byte[] b)
        {
            string s = "";
            for (int i = 0; i < b.Length; i++)
                s += Convert.ToString(b[i], 2).PadLeft(8, '0') + "-";
            return s;
        }

        public static int ZeroExtend(int n, int size)
        {

            Console.WriteLine(Tools.BinaryStr(n, 32));

            int res = 0 | n;

            Console.WriteLine(Tools.BinaryStr(res, 32));
            Console.ReadLine();
            return res;
        }
    }
}
