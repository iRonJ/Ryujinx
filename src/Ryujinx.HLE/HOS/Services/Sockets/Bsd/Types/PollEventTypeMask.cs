<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
{
    [Flags]
    enum PollEventTypeMask : ushort
    {
        Input = 1,
        UrgentInput = 2,
        Output = 4,
        Error = 8,
        Disconnected = 0x10,
<<<<<<< HEAD
        Invalid = 0x20,
=======
        Invalid = 0x20
>>>>>>> 1ec71635b (sync with main branch)
    }
}
