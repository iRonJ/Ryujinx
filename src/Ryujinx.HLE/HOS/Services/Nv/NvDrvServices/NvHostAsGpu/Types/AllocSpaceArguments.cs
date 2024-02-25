<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostAsGpu.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct AllocSpaceArguments
    {
<<<<<<< HEAD
        public uint Pages;
        public uint PageSize;
        public AddressSpaceFlags Flags;
        public uint Padding;
        public ulong Offset;
=======
        public uint              Pages;
        public uint              PageSize;
        public AddressSpaceFlags Flags;
        public uint              Padding;
        public ulong             Offset;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
