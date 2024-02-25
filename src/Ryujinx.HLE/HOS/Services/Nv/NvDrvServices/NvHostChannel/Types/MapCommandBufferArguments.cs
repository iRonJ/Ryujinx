<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct CommandBufferHandle
    {
        public int MapHandle;
        public int MapAddress;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MapCommandBufferArguments
    {
<<<<<<< HEAD
        public int NumEntries;
        public int DataAddress; // Ignored by the driver.
        public bool AttachHostChDas;
        public byte Padding1;
=======
        public int   NumEntries;
        public int   DataAddress; // Ignored by the driver.
        public bool  AttachHostChDas;
        public byte  Padding1;
>>>>>>> 1ec71635b (sync with main branch)
        public short Padding2;
    }
}
