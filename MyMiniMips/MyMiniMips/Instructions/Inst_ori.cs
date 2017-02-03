using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_ori : Instruction
    {
        public Inst_ori(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.RegWrite(rd, c.RegRead(rs) | Tools.ZeroExtend(imm, 2));
        }
        
        public override string ToString()
        {
            return String.Format("ori {0}, {1}, {2}", (Sreg)rd, (Sreg)rs, imm); 
        }
    }
}
