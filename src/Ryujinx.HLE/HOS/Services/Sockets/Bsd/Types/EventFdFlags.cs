<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
{
    [Flags]
    enum EventFdFlags : uint
    {
        None = 0,
        Semaphore = 1 << 0,
<<<<<<< HEAD
        NonBlocking = 1 << 2,
=======
        NonBlocking = 1 << 2
>>>>>>> 1ec71635b (sync with main branch)
    }
}
