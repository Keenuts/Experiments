using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_addu : Instruction
    {
        public Inst_addu(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            uint val, d1, d2;

            d1 = Convert.ToUInt32(c.RegRead(rs));
            d2 = Convert.ToUInt32(c.RegRead(rt));
            val = d1 + d2;
            c.RegWrite(rd, Convert.ToInt32(val));
        }
        
        public override string ToString()
        {
            return String.Format("addu {0}, {1}, {2}", (Sreg)rd, (Sreg)rs, (Sreg)rt);
        }
    }
}
