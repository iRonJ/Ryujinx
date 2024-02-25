<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostAsGpu.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct InitializeExArguments
    {
<<<<<<< HEAD
        public uint Flags;
        public int AsFd;
        public uint BigPageSize;
        public uint Reserved;
=======
        public uint  Flags;
        public int   AsFd;
        public uint  BigPageSize;
        public uint  Reserved;
>>>>>>> 1ec71635b (sync with main branch)
        public ulong Unknown0;
        public ulong Unknown1;
        public ulong Unknown2;
    }
}
