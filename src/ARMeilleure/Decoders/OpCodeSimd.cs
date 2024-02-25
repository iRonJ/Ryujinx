namespace ARMeilleure.Decoders
{
    class OpCodeSimd : OpCode, IOpCodeSimd
    {
<<<<<<< HEAD
        public int Rd { get; }
        public int Rn { get; }
        public int Opc { get; }
=======
        public int Rd   { get; }
        public int Rn   { get; }
        public int Opc  { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public int Size { get; protected set; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeSimd(inst, address, opCode);

        public OpCodeSimd(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Rd = (opCode >> 0) & 0x1f;
            Rn = (opCode >> 5) & 0x1f;
            Opc = (opCode >> 15) & 0x3;
=======
            Rd   = (opCode >>  0) & 0x1f;
            Rn   = (opCode >>  5) & 0x1f;
            Opc  = (opCode >> 15) & 0x3;
>>>>>>> 1ec71635b (sync with main branch)
            Size = (opCode >> 22) & 0x3;

            RegisterSize = ((opCode >> 30) & 1) != 0
                ? RegisterSize.Simd128
                : RegisterSize.Simd64;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
