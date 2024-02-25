namespace ARMeilleure.Decoders
{
    class OpCodeSimdMemLit : OpCode, IOpCodeSimd, IOpCodeLit
    {
<<<<<<< HEAD
        public int Rt { get; }
        public long Immediate { get; }
        public int Size { get; }
        public bool Signed => false;
=======
        public int  Rt        { get; }
        public long Immediate { get; }
        public int  Size      { get; }
        public bool Signed   => false;
>>>>>>> 1ec71635b (sync with main branch)
        public bool Prefetch => false;

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeSimdMemLit(inst, address, opCode);

        public OpCodeSimdMemLit(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            int opc = (opCode >> 30) & 3;

            if (opc == 3)
            {
                Instruction = InstDescriptor.Undefined;

                return;
            }

            Rt = opCode & 0x1f;

            Immediate = (long)address + DecoderHelper.DecodeImmS19_2(opCode);

            Size = opc + 2;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
