<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    class OpCode32AluReg : OpCode32Alu, IOpCode32AluReg
    {
        public int Rm { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCode32AluReg(inst, address, opCode);

        public OpCode32AluReg(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rm = (opCode >> 0) & 0xf;
        }
    }
}
