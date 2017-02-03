using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_sb : Instruction
    {
        public Inst_sb(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            
        }
        
        public override string ToString()
        {
            return "Should store stuff"; 
        }
    }
}
