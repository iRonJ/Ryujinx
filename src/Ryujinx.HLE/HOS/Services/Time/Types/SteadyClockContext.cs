<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Time.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct SteadyClockContext
    {
<<<<<<< HEAD
        public ulong InternalOffset;
=======
        public ulong   InternalOffset;
>>>>>>> 1ec71635b (sync with main branch)
        public UInt128 ClockSourceId;
    }
}
