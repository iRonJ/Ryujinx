<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
{
    interface IPollManager
    {
        bool IsCompatible(PollEvent evnt);

        LinuxError Poll(List<PollEvent> events, int timeoutMilliseconds, out int updatedCount);

        LinuxError Select(List<PollEvent> events, int timeout, out int updatedCount);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
