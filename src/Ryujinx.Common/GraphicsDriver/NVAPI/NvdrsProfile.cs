<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Common.GraphicsDriver.NVAPI
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
<<<<<<< HEAD
    struct NvdrsProfile
=======
    unsafe struct NvdrsProfile
>>>>>>> 1ec71635b (sync with main branch)
    {
        public uint Version;
        public NvapiUnicodeString ProfileName;
        public uint GpuSupport;
        public uint IsPredefined;
        public uint NumOfApps;
        public uint NumOfSettings;
    }
}
