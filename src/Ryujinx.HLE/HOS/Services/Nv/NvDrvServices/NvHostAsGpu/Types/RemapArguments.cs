<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostAsGpu.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct RemapArguments
    {
        public ushort Flags;
        public ushort Kind;
<<<<<<< HEAD
        public int NvMapHandle;
        public uint MapOffset;
        public uint GpuOffset;
        public uint Pages;
=======
        public int    NvMapHandle;
        public uint   MapOffset;
        public uint   GpuOffset;
        public uint   Pages;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
