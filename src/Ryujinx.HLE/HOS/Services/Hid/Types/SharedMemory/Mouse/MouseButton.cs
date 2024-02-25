<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Mouse
{
    [Flags]
    enum MouseButton : uint
    {
        None = 0,
        Left = 1 << 0,
        Right = 1 << 1,
        Middle = 1 << 2,
        Forward = 1 << 3,
<<<<<<< HEAD
        Back = 1 << 4,
    }
}
=======
        Back = 1 << 4
    }
}
>>>>>>> 1ec71635b (sync with main branch)
