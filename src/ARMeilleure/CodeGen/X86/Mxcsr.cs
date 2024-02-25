<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace ARMeilleure.CodeGen.X86
{
    [Flags]
    enum Mxcsr
    {
        Ftz = 1 << 15, // Flush To Zero.
        Rhi = 1 << 14, // Round Mode high bit.
        Rlo = 1 << 13, // Round Mode low bit.
        Um = 1 << 11,  // Underflow Mask.
        Dm = 1 << 8,   // Denormal Mask.
<<<<<<< HEAD
        Daz = 1 << 6, // Denormals Are Zero.
=======
        Daz = 1 << 6   // Denormals Are Zero.
>>>>>>> 1ec71635b (sync with main branch)
    }
}
