namespace ARMeilleure.Decoders
{
    class OpCodeMemPair : OpCodeMemImm
    {
        public int Rt2 { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeMemPair(inst, address, opCode);

        public OpCodeMemPair(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Rt2 = (opCode >> 10) & 0x1f;
            WBack = ((opCode >> 23) & 0x1) != 0;
            PostIdx = ((opCode >> 23) & 0x3) == 1;
            Extend64 = ((opCode >> 30) & 0x3) == 1;
            Size = ((opCode >> 31) & 0x1) | 2;
=======
            Rt2      =  (opCode >> 10) & 0x1f;
            WBack    = ((opCode >> 23) & 0x1) != 0;
            PostIdx  = ((opCode >> 23) & 0x3) == 1;
            Extend64 = ((opCode >> 30) & 0x3) == 1;
            Size     = ((opCode >> 31) & 0x1) | 2;
>>>>>>> 1ec71635b (sync with main branch)

            DecodeImm(opCode);
        }

        protected void DecodeImm(int opCode)
        {
            Immediate = ((long)(opCode >> 15) << 57) >> (57 - Size);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
