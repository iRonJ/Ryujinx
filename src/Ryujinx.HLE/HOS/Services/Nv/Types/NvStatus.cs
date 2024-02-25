<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x20)]
    struct NvStatus
    {
        public uint MemoryValue1;
        public uint MemoryValue2;
        public uint MemoryValue3;
        public uint MemoryValue4;
        public long Padding1;
        public long Padding2;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
