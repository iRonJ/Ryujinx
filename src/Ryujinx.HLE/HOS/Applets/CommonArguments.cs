<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Applets
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    struct CommonArguments
    {
<<<<<<< HEAD
        public uint Version;
        public uint StructureSize;
        public uint AppletVersion;
        public uint ThemeColor;
        [MarshalAs(UnmanagedType.I1)]
        public bool PlayStartupSound;
=======
        public uint  Version;
        public uint  StructureSize;
        public uint  AppletVersion;
        public uint  ThemeColor;
        [MarshalAs(UnmanagedType.I1)]
        public bool  PlayStartupSound;
>>>>>>> 1ec71635b (sync with main branch)
        public ulong SystemTicks;
    }
}
