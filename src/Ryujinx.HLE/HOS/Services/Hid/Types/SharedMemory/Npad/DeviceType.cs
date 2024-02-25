<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Npad
{
    [Flags]
<<<<<<< HEAD
    enum DeviceType
=======
    enum DeviceType : int
>>>>>>> 1ec71635b (sync with main branch)
    {
        None = 0,

        FullKey = 1 << 0,
        DebugPad = 1 << 1,
        HandheldLeft = 1 << 2,
        HandheldRight = 1 << 3,
        JoyLeft = 1 << 4,
        JoyRight = 1 << 5,
        Palma = 1 << 6,
        LarkHvcLeft = 1 << 7,
        LarkHvcRight = 1 << 8,
        LarkNesLeft = 1 << 9,
        LarkNesRight = 1 << 10,
        HandheldLarkHvcLeft = 1 << 11,
        HandheldLarkHvcRight = 1 << 12,
        HandheldLarkNesLeft = 1 << 13,
        HandheldLarkNesRight = 1 << 14,
        Lucia = 1 << 15,

<<<<<<< HEAD
        System = 1 << 31,
=======
        System = 1 << 31
>>>>>>> 1ec71635b (sync with main branch)
    }
}
