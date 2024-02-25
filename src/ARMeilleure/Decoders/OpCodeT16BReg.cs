<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    class OpCodeT16BReg : OpCodeT16, IOpCode32BReg
    {
        public int Rm { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeT16BReg(inst, address, opCode);

        public OpCodeT16BReg(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rm = (opCode >> 3) & 0xf;
        }
    }
}
