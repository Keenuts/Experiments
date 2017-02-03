using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_bne : Instruction
    {
        public Inst_bne(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            if (c.RegRead(rs) != c.RegRead(rt))
                c.pc += 4 * imm;
        }

        public override string ToString()
        {
            return String.Format("bne {0} == {1}, {2}", (Sreg)rs, (Sreg)rt, "pc + " + 4 * imm);
        }
    }
}
