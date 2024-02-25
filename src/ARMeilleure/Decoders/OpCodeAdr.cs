namespace ARMeilleure.Decoders
{
    class OpCodeAdr : OpCode
    {
        public int Rd { get; }

        public long Immediate { get; }

<<<<<<< HEAD
        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeAdr(inst, address, opCode);
=======
         public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeAdr(inst, address, opCode);
>>>>>>> 1ec71635b (sync with main branch)

        public OpCodeAdr(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rd = opCode & 0x1f;

<<<<<<< HEAD
            Immediate = DecoderHelper.DecodeImmS19_2(opCode);
            Immediate |= ((long)opCode >> 29) & 3;
        }
    }
}
=======
            Immediate  = DecoderHelper.DecodeImmS19_2(opCode);
            Immediate |= ((long)opCode >> 29) & 3;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
