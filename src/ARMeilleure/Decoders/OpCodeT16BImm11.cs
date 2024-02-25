<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    class OpCodeT16BImm11 : OpCodeT16, IOpCode32BImm
    {
        public long Immediate { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeT16BImm11(inst, address, opCode);

        public OpCodeT16BImm11(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            int imm = (opCode << 21) >> 20;
=======
            int imm = (opCode << 21) >> 20; 
>>>>>>> 1ec71635b (sync with main branch)
            Immediate = GetPc() + imm;
        }
    }
}
