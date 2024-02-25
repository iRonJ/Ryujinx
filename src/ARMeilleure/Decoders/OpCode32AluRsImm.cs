namespace ARMeilleure.Decoders
{
    class OpCode32AluRsImm : OpCode32Alu, IOpCode32AluRsImm
    {
<<<<<<< HEAD
        public int Rm { get; }
=======
        public int Rm        { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public int Immediate { get; }

        public ShiftType ShiftType { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCode32AluRsImm(inst, address, opCode);

        public OpCode32AluRsImm(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Rm = (opCode >> 0) & 0xf;
=======
            Rm        = (opCode >> 0) & 0xf;
>>>>>>> 1ec71635b (sync with main branch)
            Immediate = (opCode >> 7) & 0x1f;

            ShiftType = (ShiftType)((opCode >> 5) & 3);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
