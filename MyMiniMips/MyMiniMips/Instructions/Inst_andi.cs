using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_andi : Instruction
    {
        public Inst_andi(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.RegWrite(rt, c.RegRead(rs) & imm);

        }

        public override string ToString()
        {
            return String.Format("andi {0}, {1}, {2,8:x}", (Sreg)rt, (Sreg)rs, imm);
        }
    }
}
