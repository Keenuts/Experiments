using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_multu : Instruction
    {
        public Inst_multu(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            uint v1 = Convert.ToUInt32(c.RegRead(rs));
            uint v2 = Convert.ToUInt32(c.RegRead(rt));

            c.LO = Convert.ToInt32(((v1 * v2) << 32) >> 32);
            c.HI = Convert.ToInt32((v1 * v2) >> 32);
        }
        
        public override string ToString()
        {
            return String.Format("multu {0}, {1}", (Sreg)rs, (Sreg)rt);  
        }
    }
}
