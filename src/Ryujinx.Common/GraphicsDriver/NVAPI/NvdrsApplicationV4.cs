<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Common.GraphicsDriver.NVAPI
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
<<<<<<< HEAD
    struct NvdrsApplicationV4
=======
    unsafe struct NvdrsApplicationV4
>>>>>>> 1ec71635b (sync with main branch)
    {
        public uint Version;
        public uint IsPredefined;
        public NvapiUnicodeString AppName;
        public NvapiUnicodeString UserFriendlyName;
        public NvapiUnicodeString Launcher;
        public NvapiUnicodeString FileInFolder;
        public uint Flags;
        public NvapiUnicodeString CommandLine;
    }
}
