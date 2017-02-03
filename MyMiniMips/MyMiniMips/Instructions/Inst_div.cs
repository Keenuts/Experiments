using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_div : Instruction
    {
        public Inst_div(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.LO = c.RegRead(rs) / c.RegRead(rt);
            c.HI = c.RegRead(rs) % c.RegRead(rt);
        }

        public override string ToString()
        {
            return String.Format("div {0}, {1}", (Sreg)rs, (Sreg)rt);
        }
    }
}
