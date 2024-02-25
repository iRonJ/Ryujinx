<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    ref struct CmifResponse
    {
        public ReadOnlySpan<byte> Data;
        public ReadOnlySpan<uint> Objects;
<<<<<<< HEAD
        public ReadOnlySpan<int> CopyHandles;
        public ReadOnlySpan<int> MoveHandles;
=======
        public ReadOnlySpan<int>  CopyHandles;
        public ReadOnlySpan<int>  MoveHandles;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
