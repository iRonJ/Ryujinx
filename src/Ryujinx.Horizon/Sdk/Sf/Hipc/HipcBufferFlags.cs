<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    [Flags]
    enum HipcBufferFlags : byte
    {
<<<<<<< HEAD
        In = 1 << 0,
        Out = 1 << 1,
        MapAlias = 1 << 2,
        Pointer = 1 << 3,
        FixedSize = 1 << 4,
        AutoSelect = 1 << 5,
        MapTransferAllowsNonSecure = 1 << 6,
        MapTransferAllowsNonDevice = 1 << 7,
=======
        In                         = 1 << 0,
        Out                        = 1 << 1,
        MapAlias                   = 1 << 2,
        Pointer                    = 1 << 3,
        FixedSize                  = 1 << 4,
        AutoSelect                 = 1 << 5,
        MapTransferAllowsNonSecure = 1 << 6,
        MapTransferAllowsNonDevice = 1 << 7
>>>>>>> 1ec71635b (sync with main branch)
    }
}
