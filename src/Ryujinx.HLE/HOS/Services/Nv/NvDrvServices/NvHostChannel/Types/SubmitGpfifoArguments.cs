<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nv.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.Nv.Types;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct SubmitGpfifoArguments
    {
<<<<<<< HEAD
        public long Address;
        public int NumEntries;
        public SubmitGpfifoFlags Flags;
        public NvFence Fence;
=======
        public long              Address;
        public int               NumEntries;
        public SubmitGpfifoFlags Flags;
        public NvFence           Fence;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
