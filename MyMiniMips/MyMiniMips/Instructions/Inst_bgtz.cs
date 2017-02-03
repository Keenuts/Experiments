using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_bgtz : Instruction
    {
        public Inst_bgtz(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            
        }
        
        public override string ToString()
        {
            return "Pseudo instruction : NOT IMPLEMENTED";
        }
    }
}
