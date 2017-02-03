using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips.Instructions
{
    class Inst_srl : Instruction
    {
        public Inst_srl(byte[] inst)
            : base(inst)
        {
            
        }

        public override void Execute(CPU c)
        {
            
        }
        
        public override string ToString()
        {
            string r = "";
            r += "Op: undefined " + 
                    String.Format("{0:X}", rd) + "=" +
                    String.Format("{0:X}", rs) + "+" +
                    String.Format("{0:X}", rt) + "\n";

            return r;  
        }
    }
}
