using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_syscall : Instruction
    {
        public Inst_syscall(byte[] inst)
            : base(inst)
        {

        }

        public override void Execute(CPU c)
        {
            switch (c.RegRead(Sreg.v0))
            {
                case 1:
                    Console.WriteLine("\n" + c.RegRead(Sreg.a0) + "\n");
                    break;
                case 4:
                    int addr = c.RegRead(Sreg.a0);
                    char ch = (char)c.ram.ReadByte(addr);
                    while (ch != 0)
                    {
                        Console.Write(ch);
                        addr++;
                    }
                    break;
                case 5:
                    bool ok = false;
                    int val = 0;
                    while (!ok)
                    {
                        Console.WriteLine("Please, enter a number :");
                        ok = int.TryParse(Console.ReadLine(), out val);
                        if (!ok)
                            Console.WriteLine("Error");
                    }
                    c.RegWrite(Sreg.v0, val);
                    break;
                case 10:
                    c.pc = Ram.Lenght;
                    break;
                case 11:
                    Console.Write((char)c.RegRead(Sreg.a0));
                    break;
                default:
                    Console.WriteLine("Unimplemented");
                    break;
            }

        }

        public override string ToString()
        {
            return String.Format("syscall");
        }
    }
}
