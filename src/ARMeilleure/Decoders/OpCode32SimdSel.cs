<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    class OpCode32SimdSel : OpCode32SimdRegS
    {
        public OpCode32SimdSelMode Cc { get; }

        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCode32SimdSel(inst, address, opCode, false);
        public new static OpCode CreateT32(InstDescriptor inst, ulong address, int opCode) => new OpCode32SimdSel(inst, address, opCode, true);

        public OpCode32SimdSel(InstDescriptor inst, ulong address, int opCode, bool isThumb) : base(inst, address, opCode, isThumb)
        {
            Cc = (OpCode32SimdSelMode)((opCode >> 20) & 3);
        }
    }

<<<<<<< HEAD
    enum OpCode32SimdSelMode
=======
    enum OpCode32SimdSelMode : int
>>>>>>> 1ec71635b (sync with main branch)
    {
        Eq = 0,
        Vs,
        Ge,
<<<<<<< HEAD
        Gt,
=======
        Gt
>>>>>>> 1ec71635b (sync with main branch)
    }
}
