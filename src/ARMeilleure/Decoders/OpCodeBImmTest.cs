namespace ARMeilleure.Decoders
{
    class OpCodeBImmTest : OpCodeBImm
    {
<<<<<<< HEAD
        public int Rt { get; }
=======
        public int Rt  { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public int Bit { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeBImmTest(inst, address, opCode);

        public OpCodeBImmTest(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rt = opCode & 0x1f;

            Immediate = (long)address + DecoderHelper.DecodeImmS14_2(opCode);

<<<<<<< HEAD
            Bit = (opCode >> 19) & 0x1f;
            Bit |= (opCode >> 26) & 0x20;
        }
    }
}
=======
            Bit  = (opCode >> 19) & 0x1f;
            Bit |= (opCode >> 26) & 0x20;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
