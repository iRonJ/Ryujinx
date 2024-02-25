using ARMeilleure.State;

namespace ARMeilleure.Decoders
{
    class OpCodeCcmp : OpCodeAlu, IOpCodeCond
    {
<<<<<<< HEAD
        public int Nzcv { get; }
=======
        public    int Nzcv { get; }
>>>>>>> 1ec71635b (sync with main branch)
        protected int RmImm;

        public Condition Cond { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeCcmp(inst, address, opCode);

        public OpCodeCcmp(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            int o3 = (opCode >> 4) & 1;

            if (o3 != 0)
            {
                Instruction = InstDescriptor.Undefined;

                return;
            }

<<<<<<< HEAD
            Nzcv = (opCode >> 0) & 0xf;
            Cond = (Condition)((opCode >> 12) & 0xf);
            RmImm = (opCode >> 16) & 0x1f;
=======
            Nzcv  =             (opCode >>  0) & 0xf;
            Cond  = (Condition)((opCode >> 12) & 0xf);
            RmImm =             (opCode >> 16) & 0x1f;
>>>>>>> 1ec71635b (sync with main branch)

            Rd = RegisterAlias.Zr;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
