using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_or : Instruction
    {
        public Inst_or(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            
        }
        
        public override string ToString()
        {
            return "2b || !2b";
        }
    }
}
