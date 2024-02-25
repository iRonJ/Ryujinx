<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Sdb.Pdm.QueryService.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x18)]
    struct ApplicationPlayStatistics
    {
        public ulong TitleId;
<<<<<<< HEAD
        public long TotalPlayTime; // In nanoseconds.
        public long TotalLaunchCount;
    }
}
=======
        public long  TotalPlayTime; // In nanoseconds.
        public long  TotalLaunchCount;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
