<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostChannel.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct SetErrorNotifierArguments
    {
        public ulong Offset;
        public ulong Size;
<<<<<<< HEAD
        public uint Mem;
        public uint Reserved;
=======
        public uint  Mem;
        public uint  Reserved;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
