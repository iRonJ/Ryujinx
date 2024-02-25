namespace ARMeilleure.Decoders
{
    class OpCodeBfm : OpCodeAlu
    {
        public long WMask { get; }
        public long TMask { get; }
<<<<<<< HEAD
        public int Pos { get; }
        public int Shift { get; }
=======
        public int  Pos   { get; }
        public int  Shift { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeBfm(inst, address, opCode);

        public OpCodeBfm(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            var bm = DecoderHelper.DecodeBitMask(opCode, false);

            if (bm.IsUndefined)
            {
                Instruction = InstDescriptor.Undefined;

                return;
            }

            WMask = bm.WMask;
            TMask = bm.TMask;
<<<<<<< HEAD
            Pos = bm.Pos;
            Shift = bm.Shift;
        }
    }
}
=======
            Pos   = bm.Pos;
            Shift = bm.Shift;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
