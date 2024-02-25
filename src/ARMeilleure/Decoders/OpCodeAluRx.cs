namespace ARMeilleure.Decoders
{
    class OpCodeAluRx : OpCodeAlu, IOpCodeAluRx
    {
        public int Shift { get; }
<<<<<<< HEAD
        public int Rm { get; }
=======
        public int Rm    { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public IntType IntType { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeAluRx(inst, address, opCode);

        public OpCodeAluRx(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Shift = (opCode >> 10) & 0x7;
            IntType = (IntType)((opCode >> 13) & 0x7);
            Rm = (opCode >> 16) & 0x1f;
        }
    }
}
=======
            Shift   =           (opCode >> 10) & 0x7;
            IntType = (IntType)((opCode >> 13) & 0x7);
            Rm      =           (opCode >> 16) & 0x1f;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
