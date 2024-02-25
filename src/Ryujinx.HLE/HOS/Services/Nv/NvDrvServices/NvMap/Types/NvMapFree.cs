using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvMap
{
    [StructLayout(LayoutKind.Sequential)]
    struct NvMapFree
    {
<<<<<<< HEAD
        public int Handle;
        public int Padding;
        public ulong Address;
        public uint Size;
        public int Flags;
    }
}
=======
        public int   Handle;
        public int   Padding;
        public ulong Address;
        public int   Size;
        public int   Flags;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
