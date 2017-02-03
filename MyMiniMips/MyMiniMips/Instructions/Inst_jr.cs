using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_jr : Instruction
    {
        public Inst_jr(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            c.pc = addr - 4;
        }
        
        public override string ToString()
        {
            return String.Format("jr {0,8:x}", addr);
        }
    }
}
