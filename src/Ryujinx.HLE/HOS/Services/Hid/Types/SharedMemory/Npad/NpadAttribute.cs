<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Npad
{
    [Flags]
    enum NpadAttribute : uint
    {
        None = 0,
        IsConnected = 1 << 0,
        IsWired = 1 << 1,
        IsLeftConnected = 1 << 2,
        IsLeftWired = 1 << 3,
        IsRightConnected = 1 << 4,
<<<<<<< HEAD
        IsRightWired = 1 << 5,
    }
}
=======
        IsRightWired = 1 << 5
    }
}
>>>>>>> 1ec71635b (sync with main branch)
