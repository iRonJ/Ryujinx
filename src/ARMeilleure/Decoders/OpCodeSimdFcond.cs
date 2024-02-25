namespace ARMeilleure.Decoders
{
    class OpCodeSimdFcond : OpCodeSimdReg, IOpCodeCond
    {
        public int Nzcv { get; }

        public Condition Cond { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeSimdFcond(inst, address, opCode);

        public OpCodeSimdFcond(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Nzcv = (opCode >> 0) & 0xf;
=======
            Nzcv =             (opCode >>  0) & 0xf;
>>>>>>> 1ec71635b (sync with main branch)
            Cond = (Condition)((opCode >> 12) & 0xf);
        }
    }
}
