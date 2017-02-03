using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyMiniMips
{
    enum Sreg
    {
        ze, at, v0, v1, a0, a1, a2, a3, t0, t1, t2, t3, t4, t5, t6, t7, s0,
        s1, s2, s3, s4, s5, s6, s7, t8, t9, k0, k1, gp, sp, fp, ra
    };

    class CPU
    {
        public Ram ram;
        int[] register;


        public int pc;
        public int HI;
        public int LO;

        int program_lenght;

        public CPU()
        {
            ram = new Ram();
            register = new int[32];

            pc = 0;
            HI = 0;
            LO = 0;

            program_lenght = 0;
        }

        public void LoadFile(string filename)
        {
            Console.WriteLine("Loading binary file : " + filename);
            ram = new Ram();
            FileInfo fi = new FileInfo(filename);

            if (File.Exists(filename) && fi.Length <= Ram.Lenght)
            {
                program_lenght = ram.WriteBytes(0, File.ReadAllBytes(filename));
            }

            Console.WriteLine("Program loaded : " + program_lenght + " bytes: ");
            ram.DisplayRam(program_lenght);
            Console.WriteLine("----------------------------");
        }

        public void Execute(bool jit = false)
        {
            for (pc = 0; pc < program_lenght; pc += 4)
            {
                byte[] bt = ram.ReadInstruction(pc);
                Instruction i = Instruction.Compile(bt);
                if (i != null)
                {
                    Console.Write("[MyMiniMips] Executing pc = 0x{0,8:X} : 0x{1,8:X} : ",
                        pc, Tools.Bytes2Int(bt));
                    Console.WriteLine(i.ToString());
                    i.Execute(this);
                }
            }
            Console.WriteLine("Terminated");
        }

        public void RegWrite(int add, int dt)
        {
            if (add >= 0 && add < register.Length)
                register[add] = dt;
            else
                Console.WriteLine("Trying to write at " + add);
        }

        public int RegRead(int add)
        {
            if (add >= 0 && add < register.Length)
                return register[add];
            else
            {
                Console.WriteLine("Trying to read at " + add);
                return 0;
            }
        }

        public void RegWrite(Sreg sr, int dt)
        {
            RegWrite((int)sr, dt);
        }

        public int RegRead(Sreg sr)
        {
            return RegRead((int)sr);
        }

        public void DisplayReg()
        {
            Console.WriteLine("Register");
            for (int i = 0; i < register.Length; i++)
                Console.WriteLine("{0} : {1:x}", (Sreg)i, register[i]);
        }

    }
}
