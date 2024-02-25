namespace ARMeilleure.Decoders
{
    class OpCodeSimdFmov : OpCode, IOpCodeSimd
    {
<<<<<<< HEAD
        public int Rd { get; }
        public long Immediate { get; }
        public int Size { get; }
=======
        public int  Rd        { get; }
        public long Immediate { get; }
        public int  Size      { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeSimdFmov(inst, address, opCode);

        public OpCodeSimdFmov(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            int type = (opCode >> 22) & 0x3;

            Size = type;

            long imm;

<<<<<<< HEAD
            Rd = (opCode >> 0) & 0x1f;
=======
            Rd  = (opCode >>  0) & 0x1f;
>>>>>>> 1ec71635b (sync with main branch)
            imm = (opCode >> 13) & 0xff;

            if (type == 0)
            {
                Immediate = (long)DecoderHelper.Imm8ToFP32Table[(int)imm];
            }
            else /* if (type == 1) */
            {
                Immediate = (long)DecoderHelper.Imm8ToFP64Table[(int)imm];
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
