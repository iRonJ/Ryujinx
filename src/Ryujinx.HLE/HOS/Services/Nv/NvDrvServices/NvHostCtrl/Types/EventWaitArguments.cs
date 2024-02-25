<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nv.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.Nv.Types;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostCtrl.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct EventWaitArguments
    {
        public NvFence Fence;
<<<<<<< HEAD
        public int Timeout;
        public uint Value;
=======
        public int     Timeout;
        public uint    Value;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
