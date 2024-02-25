namespace ARMeilleure.Decoders
{
    class OpCodeSimdReg : OpCodeSimd
    {
        public bool Bit3 { get; }
<<<<<<< HEAD
        public int Ra { get; }
        public int Rm { get; protected set; }
=======
        public int  Ra   { get; }
        public int  Rm   { get; protected set; }
>>>>>>> 1ec71635b (sync with main branch)

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeSimdReg(inst, address, opCode);

        public OpCodeSimdReg(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Bit3 = ((opCode >> 3) & 0x1) != 0;
            Ra = (opCode >> 10) & 0x1f;
            Rm = (opCode >> 16) & 0x1f;
        }
    }
}
=======
            Bit3 = ((opCode >>  3) & 0x1) != 0;
            Ra   =  (opCode >> 10) & 0x1f;
            Rm   =  (opCode >> 16) & 0x1f;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
