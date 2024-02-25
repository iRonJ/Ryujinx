<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel.Types
{
    [Flags]
    enum SubmitGpfifoFlags : uint
    {
        None,
<<<<<<< HEAD
        FenceWait = 1 << 0,
        FenceIncrement = 1 << 1,
        HwFormat = 1 << 2,
        SuppressWfi = 1 << 4,
=======
        FenceWait          = 1 << 0,
        FenceIncrement     = 1 << 1,
        HwFormat           = 1 << 2,
        SuppressWfi        = 1 << 4,
>>>>>>> 1ec71635b (sync with main branch)
        IncrementWithValue = 1 << 8,
    }
}
