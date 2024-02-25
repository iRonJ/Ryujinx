<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostAsGpu.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct MapBufferExArguments
    {
        public AddressSpaceFlags Flags;
<<<<<<< HEAD
        public int Kind;
        public int NvMapHandle;
        public int PageSize;
        public ulong BufferOffset;
        public ulong MappingSize;
        public ulong Offset;
=======
        public int               Kind;
        public int               NvMapHandle;
        public int               PageSize;
        public ulong             BufferOffset;
        public ulong             MappingSize;
        public ulong             Offset;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
