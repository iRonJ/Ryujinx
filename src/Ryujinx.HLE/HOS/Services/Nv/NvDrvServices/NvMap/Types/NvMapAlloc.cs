using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvMap
{
    [StructLayout(LayoutKind.Sequential)]
    struct NvMapAlloc
    {
<<<<<<< HEAD
        public int Handle;
        public int HeapMask;
        public int Flags;
        public int Align;
        public long Kind;
        public ulong Address;
    }
}
=======
        public int   Handle;
        public int   HeapMask;
        public int   Flags;
        public int   Align;
        public long  Kind;
        public ulong Address;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
