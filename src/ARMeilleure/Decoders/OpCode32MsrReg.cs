<<<<<<< HEAD
using ARMeilleure.State;
=======
﻿using ARMeilleure.State;
>>>>>>> 1ec71635b (sync with main branch)

namespace ARMeilleure.Decoders
{
    class OpCode32MsrReg : OpCode32
    {
<<<<<<< HEAD
        public bool R { get; }
        public int Mask { get; }
        public int Rd { get; }
        public bool Banked { get; }
        public int Rn { get; }
=======
        public bool R      { get; }
        public int  Mask   { get; }
        public int  Rd     { get; }
        public bool Banked { get; }
        public int  Rn     { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCode32MsrReg(inst, address, opCode);

        public OpCode32MsrReg(InstDescriptor inst, ulong address, int opCode) : base(inst, address, opCode)
        {
            R = ((opCode >> 22) & 1) != 0;
            Mask = (opCode >> 16) & 0xf;
            Rd = (opCode >> 12) & 0xf;
            Banked = ((opCode >> 9) & 1) != 0;
            Rn = (opCode >> 0) & 0xf;

            if (Rn == RegisterAlias.Aarch32Pc || Mask == 0)
            {
                Instruction = InstDescriptor.Undefined;
            }
        }
    }
}
