<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nv.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.Nv.Types;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostCtrl.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct SyncptWaitArguments
    {
        public NvFence Fence;
<<<<<<< HEAD
        public int Timeout;
=======
        public int     Timeout;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
