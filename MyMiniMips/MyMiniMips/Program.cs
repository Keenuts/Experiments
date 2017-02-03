using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 100;
            Console.WindowHeight = 50;
            string source_code = "fibo.bin";

            CPU cpu = new CPU();
            cpu.LoadFile(source_code);
            cpu.Execute();

            Console.ReadLine();
        }
    }
}
