namespace ARMeilleure.Decoders
{
    class OpCodeMemEx : OpCodeMem
    {
        public int Rt2 { get; }
<<<<<<< HEAD
        public int Rs { get; }
=======
        public int Rs  { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeMemEx(inst, address, opCode);

        public OpCodeMemEx(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rt2 = (opCode >> 10) & 0x1f;
<<<<<<< HEAD
            Rs = (opCode >> 16) & 0x1f;
        }
    }
}
=======
            Rs  = (opCode >> 16) & 0x1f;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
