using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniMips
{
    enum INSTRUCTION
    {
        R, I, J
    };

    class Instruction
    {
        public int op {get; private set;}
        public int rs { get; private set; }
        public int rt { get; private set; }
        public int rd { get; private set; }
        public int shamt { get; private set; }
        public int funct { get; private set; }
        public int imm { get; private set; }
        public int addr { get; private set; }

        public int raw;

        public Instruction(byte[] inst)
        {
            raw = Tools.Bytes2Int(inst);
            op = Tools.IntTruncate(0, 6, raw);
            rs = Tools.IntTruncate(6, 5, raw);
            rt = Tools.IntTruncate(11, 5, raw);
            rd = Tools.IntTruncate(16, 5, raw);
            shamt = Tools.IntTruncate(21, 5, raw);
            funct = Tools.IntTruncate(26, 6, raw);

            imm = Tools.IntTruncate(16, 16, raw);
            addr = Tools.IntTruncate(6, 28, raw);
        }

        public override string ToString()
        {
            string r = "";
            r += "Op: " + Tools.BinaryStr(op) + "\n";

            return r;
        }

        public static Instruction Compile(byte[] inst)
        {
            //Console.WriteLine("Begin compiling an instruction");
            //Console.Write("Raw: ");
            //foreach (byte b in inst)
            //    Console.Write("{0,2:X} ", b);
            //Console.WriteLine();

            int raw = Tools.Bytes2Int(inst);
            int op = Tools.IntTruncate(0, 6, raw);

            //Console.WriteLine("OP: " + Tools.BinaryStr(op, 6)); 
            switch (op)
            {
                case 0:
                    return Compile_R(inst);
                case 0x8:
                    return new Instructions.Inst_addi(inst);
                case 0x9:
                    return new Instructions.Inst_addiu(inst);
                case 0xC:
                    return new Instructions.Inst_andi(inst);
                case 0xD:
                    return new Instructions.Inst_ori(inst);
                case 0xE:
                    return new Instructions.Inst_xori(inst);
                case 0x19:
                    return new Instructions.Inst_lhi(inst);
                case 0x18:
                    return new Instructions.Inst_llo(inst);
                case 0xA:
                    return new Instructions.Inst_slti(inst);
                case 0x4:
                    return new Instructions.Inst_beq(inst);
                case 0x7:
                    return new Instructions.Inst_bgtz(inst);
                case 0x6:
                    return new Instructions.Inst_blez(inst);
                case 0x5:
                    return new Instructions.Inst_bne(inst);
                case 0x2:
                    return new Instructions.Inst_j(inst);
                case 0x3:
                    return new Instructions.Inst_jal(inst);
                case 0x20:
                    return new Instructions.Inst_lb(inst);
                case 0x24:
                    return new Instructions.Inst_lbu(inst);
                case 0x21:
                    return new Instructions.Inst_lh(inst);
                case 0x25:
                    return new Instructions.Inst_lhu(inst);
                case 0x23:
                    return new Instructions.Inst_lw(inst);
                case 0x28:
                    return new Instructions.Inst_sb(inst);
                case 0x29:
                    return new Instructions.Inst_sh(inst);
                case 0x2B:
                    return new Instructions.Inst_sw(inst);
                case 0x1A:
                    return new Instructions.Inst_trap(inst);
                default:
                    Console.WriteLine("Unknown instruction: " + Tools.BinaryStr(op, 6));
                    return null;
            }
            
        }

        static Instruction Compile_R(byte[] inst)
        {
            int raw = Tools.Bytes2Int(inst);
            int funct = Tools.IntTruncate(26, 6, raw);

            //Console.WriteLine("Funct: " + Tools.BinaryStr(funct, 6)); 
            switch (funct)
            {
                case 0xC:
                    return new Instructions.Inst_syscall(inst);
                case 0x20:
                    return new Instructions.Inst_add(inst);
                case 0x21:
                    return new Instructions.Inst_addu(inst);
                case 0x24:
                    return new Instructions.Inst_and(inst);
                case 0x1A:
                    return new Instructions.Inst_div(inst);
                case 0x1B:
                    return new Instructions.Inst_divu(inst);
                case 0x18:
                    return new Instructions.Inst_mult(inst);
                case 0x19:
                    return new Instructions.Inst_multu(inst);
                case 0x27:
                    return new Instructions.Inst_nor(inst);
                case 0x25:
                    return new Instructions.Inst_or(inst);
                case 0x0:
                    return new Instructions.Inst_sll(inst);
                case 0x4:
                    return new Instructions.Inst_sllv(inst);
                case 0x3:
                    return new Instructions.Inst_sra(inst);
                case 0x7:
                    return new Instructions.Inst_srav(inst);
                case 0x2:
                    return new Instructions.Inst_srl(inst);
                case 0x6:
                    return new Instructions.Inst_srlv(inst);
                case 0x22:
                    return new Instructions.Inst_sub(inst);
                case 0x23:
                    return new Instructions.Inst_subu(inst);
                case 0x26:
                    return new Instructions.Inst_xor(inst);
                case 0x2A:
                    return new Instructions.Inst_slt(inst);
                case 0x29:
                    return new Instructions.Inst_sltu(inst);
                case 0x9:
                    return new Instructions.Inst_jalr(inst);
                case 0x8:
                    return new Instructions.Inst_jr(inst);
                case 0x10:
                    return new Instructions.Inst_mfhi(inst);
                case 0x12:
                    return new Instructions.Inst_mflo(inst);
                case 0x11:
                    return new Instructions.Inst_mthi(inst);
                case 0x13:
                    return new Instructions.Inst_mtlo(inst);
                default:
                    Console.WriteLine("Unknown instruction: " + Tools.BinaryStr(funct, 6));
                    return null;
            }
        }

        public virtual void Execute(CPU c)
        { }
    }
}
