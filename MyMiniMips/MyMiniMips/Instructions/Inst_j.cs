using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_j : Instruction
    {
        public Inst_j(byte[] inst)
            : base(inst)
        {
        }

        public override void Execute(CPU c)
        {
            int p = imm * 4 - 4;
            c.pc = p;
        }
        
        public override string ToString()
        {
            return String.Format("j {0,8:x}", imm * 4);
        }
    }
}
