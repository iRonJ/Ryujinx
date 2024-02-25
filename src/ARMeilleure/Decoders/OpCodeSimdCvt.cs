namespace ARMeilleure.Decoders
{
    class OpCodeSimdCvt : OpCodeSimd
    {
        public int FBits { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeSimdCvt(inst, address, opCode);

        public OpCodeSimdCvt(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            int scale = (opCode >> 10) & 0x3f;
<<<<<<< HEAD
            int sf = (opCode >> 31) & 0x1;
=======
            int sf    = (opCode >> 31) & 0x1;
>>>>>>> 1ec71635b (sync with main branch)

            FBits = 64 - scale;

            RegisterSize = sf != 0
                ? RegisterSize.Int64
                : RegisterSize.Int32;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
