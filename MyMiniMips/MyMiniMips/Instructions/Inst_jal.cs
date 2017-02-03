using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_jal : Instruction
    {
        public Inst_jal(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.RegWrite(Sreg.ra, c.pc + 4);
            c.pc = imm * 4 - 4; 
        }
        
        public override string ToString()
        {
            return String.Format("jal {0,8:x}", imm * 4);
        }
    }
}
