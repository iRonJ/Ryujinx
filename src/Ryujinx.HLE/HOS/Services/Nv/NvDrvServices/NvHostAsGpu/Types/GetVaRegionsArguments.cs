<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostAsGpu.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct VaRegion
    {
        public ulong Offset;
        public uint PageSize;
        public uint Padding;
        public ulong Pages;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct GetVaRegionsArguments
    {
        public ulong Unused;
        public uint BufferSize;
        public uint Padding;
        public Array2<VaRegion> Regions;
    }
}
