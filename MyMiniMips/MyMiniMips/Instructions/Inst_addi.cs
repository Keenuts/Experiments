using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_addi : Instruction
    {
        public Inst_addi(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.RegWrite(rt, c.RegRead(rs) + imm);
        }
        
        public override string ToString()
        {
            return String.Format("addi {0}, {1}, {2:X}", (Sreg)rt, (Sreg)rs, imm);
        }
    }
}
