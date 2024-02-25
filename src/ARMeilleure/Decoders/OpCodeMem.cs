namespace ARMeilleure.Decoders
{
    class OpCodeMem : OpCode
    {
<<<<<<< HEAD
        public int Rt { get; protected set; }
        public int Rn { get; protected set; }
        public int Size { get; protected set; }
=======
        public int  Rt       { get; protected set; }
        public int  Rn       { get; protected set; }
        public int  Size     { get; protected set; }
>>>>>>> 1ec71635b (sync with main branch)
        public bool Extend64 { get; protected set; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeMem(inst, address, opCode);

        public OpCodeMem(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
<<<<<<< HEAD
            Rt = (opCode >> 0) & 0x1f;
            Rn = (opCode >> 5) & 0x1f;
            Size = (opCode >> 30) & 0x3;
        }
    }
}
=======
            Rt   = (opCode >>  0) & 0x1f;
            Rn   = (opCode >>  5) & 0x1f;
            Size = (opCode >> 30) & 0x3;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
