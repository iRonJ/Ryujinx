<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    class OpCode32AluRsReg : OpCode32Alu, IOpCode32AluRsReg
    {
        public int Rm { get; }
        public int Rs { get; }

        public ShiftType ShiftType { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCode32AluRsReg(inst, address, opCode);

        public OpCode32AluRsReg(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rm = (opCode >> 0) & 0xf;
            Rs = (opCode >> 8) & 0xf;

            ShiftType = (ShiftType)((opCode >> 5) & 3);
        }
    }
}
