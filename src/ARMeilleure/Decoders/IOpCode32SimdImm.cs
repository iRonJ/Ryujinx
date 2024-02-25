<<<<<<< HEAD
namespace ARMeilleure.Decoders
=======
﻿namespace ARMeilleure.Decoders
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IOpCode32SimdImm : IOpCode32Simd
    {
        int Vd { get; }
        long Immediate { get; }
        int Elems { get; }
    }
}
