<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
{
    [Flags]
    enum BsdSocketCreationFlags
    {
        None = 0,
        CloseOnExecution = 1,
        NonBlocking = 2,

<<<<<<< HEAD
        FlagsShift = 28,
=======
        FlagsShift = 28
>>>>>>> 1ec71635b (sync with main branch)
    }
}
