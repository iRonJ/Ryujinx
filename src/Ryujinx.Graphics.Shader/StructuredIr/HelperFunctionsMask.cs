using System;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    [Flags]
    enum HelperFunctionsMask
    {
<<<<<<< HEAD
        MultiplyHighS32 = 1 << 2,
        MultiplyHighU32 = 1 << 3,
        SwizzleAdd = 1 << 10,
        FSI = 1 << 11,
    }
}
=======
        AtomicMinMaxS32Shared  = 1 << 0,
        AtomicMinMaxS32Storage = 1 << 1,
        MultiplyHighS32        = 1 << 2,
        MultiplyHighU32        = 1 << 3,
        Shuffle                = 1 << 4,
        ShuffleDown            = 1 << 5,
        ShuffleUp              = 1 << 6,
        ShuffleXor             = 1 << 7,
        StoreSharedSmallInt    = 1 << 8,
        StoreStorageSmallInt   = 1 << 9,
        SwizzleAdd             = 1 << 10,
        FSI                    = 1 << 11
    }
}
>>>>>>> 1ec71635b (sync with main branch)
