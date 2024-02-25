namespace ARMeilleure.Decoders
{
    class OpCodeMemImm : OpCodeMem
    {
<<<<<<< HEAD
        public long Immediate { get; protected set; }
        public bool WBack { get; protected set; }
        public bool PostIdx { get; protected set; }
        protected bool Unscaled { get; }

        private enum MemOp
        {
            Unscaled = 0,
            PostIndexed = 1,
            Unprivileged = 2,
            PreIndexed = 3,
            Unsigned,
=======
        public    long Immediate { get; protected set; }
        public    bool WBack     { get; protected set; }
        public    bool PostIdx   { get; protected set; }
        protected bool Unscaled  { get; }

        private enum MemOp
        {
            Unscaled     = 0,
            PostIndexed  = 1,
            Unprivileged = 2,
            PreIndexed   = 3,
            Unsigned
>>>>>>> 1ec71635b (sync with main branch)
        }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeMemImm(inst, address, opCode);

        public OpCodeMemImm(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Extend64 = ((opCode >> 22) & 3) == 2;
<<<<<<< HEAD
            WBack = ((opCode >> 24) & 1) == 0;
=======
            WBack    = ((opCode >> 24) & 1) == 0;
>>>>>>> 1ec71635b (sync with main branch)

            // The type is not valid for the Unsigned Immediate 12-bits encoding,
            // because the bits 11:10 are used for the larger Immediate offset.
            MemOp type = WBack ? (MemOp)((opCode >> 10) & 3) : MemOp.Unsigned;

<<<<<<< HEAD
            PostIdx = type == MemOp.PostIndexed;
=======
            PostIdx  = type == MemOp.PostIndexed;
>>>>>>> 1ec71635b (sync with main branch)
            Unscaled = type == MemOp.Unscaled ||
                       type == MemOp.Unprivileged;

            // Unscaled and Unprivileged doesn't write back,
            // but they do use the 9-bits Signed Immediate.
            if (Unscaled)
            {
                WBack = false;
            }

            if (WBack || Unscaled)
            {
                // 9-bits Signed Immediate.
                Immediate = (opCode << 11) >> 23;
            }
            else
            {
                // 12-bits Unsigned Immediate.
                Immediate = ((opCode >> 10) & 0xfff) << Size;
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
