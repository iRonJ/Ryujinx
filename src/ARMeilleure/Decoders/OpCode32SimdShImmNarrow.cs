<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    class OpCode32SimdShImmNarrow : OpCode32SimdShImm
    {
        public new static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCode32SimdShImmNarrow(inst, address, opCode, false);
        public new static OpCode CreateT32(InstDescriptor inst, ulong address, int opCode) => new OpCode32SimdShImmNarrow(inst, address, opCode, true);

        public OpCode32SimdShImmNarrow(InstDescriptor inst, ulong address, int opCode, bool isThumb) : base(inst, address, opCode, isThumb) { }
    }
}
