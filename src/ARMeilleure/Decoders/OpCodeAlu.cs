namespace ARMeilleure.Decoders
{
    class OpCodeAlu : OpCode, IOpCodeAlu
    {
        public int Rd { get; protected set; }
        public int Rn { get; }

        public DataOp DataOp { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeAlu(inst, address, opCode);

        public OpCodeAlu(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Rd = (opCode >> 0) & 0x1f;
            Rn = (opCode >> 5) & 0x1f;
=======
            Rd     =          (opCode >>  0) & 0x1f;
            Rn     =          (opCode >>  5) & 0x1f;
>>>>>>> 1ec71635b (sync with main branch)
            DataOp = (DataOp)((opCode >> 24) & 0x3);

            RegisterSize = (opCode >> 31) != 0
                ? RegisterSize.Int64
                : RegisterSize.Int32;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
