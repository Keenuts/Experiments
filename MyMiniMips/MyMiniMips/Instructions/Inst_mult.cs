using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_mult : Instruction
    {
        public Inst_mult(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.LO = ((c.RegRead(rs) * c.RegRead(rt)) << 32) >> 32;
            c.HI = (c.RegRead(rs) * c.RegRead(rt)) >> 32;
        }
        
        public override string ToString()
        {
            return String.Format("mult {0}, {1}", (Sreg)rs, (Sreg)rt);  
        }
    }
}
