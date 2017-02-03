using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_addiu : Instruction
    {
        public Inst_addiu(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            uint val, d1, d2;

            d1 = Convert.ToUInt32(c.RegRead(rs));
            d2 = Convert.ToUInt32(imm);
            val = d1 + d2;
            c.RegWrite(rt, Convert.ToInt32(val));
        }
        
        public override string ToString()
        {
            return String.Format("addiu {0}, {1}, {2:X}", (Sreg)rt, (Sreg)rs, imm);
        }
    }
}
