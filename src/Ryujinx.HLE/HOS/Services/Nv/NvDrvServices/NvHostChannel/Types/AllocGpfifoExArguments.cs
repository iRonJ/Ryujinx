<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nv.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.Nv.Types;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct AllocGpfifoExArguments
    {
<<<<<<< HEAD
        public uint NumEntries;
        public uint NumJobs;
        public uint Flags;
        public NvFence Fence;
        public uint Reserved1;
        public uint Reserved2;
        public uint Reserved3;
=======
        public uint    NumEntries;
        public uint    NumJobs;
        public uint    Flags;
        public NvFence Fence;
        public uint    Reserved1;
        public uint    Reserved2;
        public uint    Reserved3;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
