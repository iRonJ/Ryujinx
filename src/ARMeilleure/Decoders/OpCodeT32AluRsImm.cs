<<<<<<< HEAD
namespace ARMeilleure.Decoders
{
    class OpCodeT32AluRsImm : OpCodeT32Alu, IOpCode32AluRsImm
    {
        public int Rm { get; }
=======
﻿namespace ARMeilleure.Decoders
{
    class OpCodeT32AluRsImm : OpCodeT32Alu, IOpCode32AluRsImm
    {
        public int Rm        { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public int Immediate { get; }

        public ShiftType ShiftType { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeT32AluRsImm(inst, address, opCode);

        public OpCodeT32AluRsImm(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Rm = (opCode >> 0) & 0xf;
=======
            Rm        = (opCode >> 0) & 0xf;
>>>>>>> 1ec71635b (sync with main branch)
            Immediate = ((opCode >> 6) & 3) | ((opCode >> 10) & 0x1c);

            ShiftType = (ShiftType)((opCode >> 4) & 3);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
