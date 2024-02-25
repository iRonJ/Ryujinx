<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    class OpCodeT32MemImm8 : OpCodeT32, IOpCode32Mem
    {
        public int Rt { get; }
        public int Rn { get; }
        public bool WBack { get; }
        public bool IsLoad { get; }
        public bool Index { get; }
        public bool Add { get; }
        public int Immediate { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCodeT32MemImm8(inst, address, opCode);

        public OpCodeT32MemImm8(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            Rt = (opCode >> 12) & 0xf;
            Rn = (opCode >> 16) & 0xf;

            Index = ((opCode >> 10) & 1) != 0;
<<<<<<< HEAD
            Add = ((opCode >> 9) & 1) != 0;
=======
            Add   = ((opCode >> 9) & 1) != 0;
>>>>>>> 1ec71635b (sync with main branch)
            WBack = ((opCode >> 8) & 1) != 0;

            Immediate = opCode & 0xff;

            IsLoad = ((opCode >> 20) & 1) != 0;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
