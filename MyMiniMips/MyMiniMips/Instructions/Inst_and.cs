using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_and : Instruction
    {
        public Inst_and(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.RegWrite(rd, c.RegRead(rs) & c.RegRead(rt));

        }

        public override string ToString()
        {
            return String.Format("and {0}, {1}, {2}", (Sreg)rd, (Sreg)rs, (Sreg)rt);
        }
    }
}
