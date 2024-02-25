<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Irs.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x18)]
    struct PackedImageTransferProcessorConfig
    {
<<<<<<< HEAD
        public long ExposureTime;
        public byte LightTarget;
        public byte Gain;
        public byte IsNegativeImageUsed;
        public byte Reserved1;
        public uint Reserved2;
        public uint RequiredMcuVersion;
        public byte Format;
        public byte Reserved3;
        public ushort Reserved4;
    }
}
=======
        public long   ExposureTime;
        public byte   LightTarget;
        public byte   Gain;
        public byte   IsNegativeImageUsed;
        public byte   Reserved1;
        public uint   Reserved2;
        public uint   RequiredMcuVersion;
        public byte   Format;
        public byte   Reserved3;
        public ushort Reserved4;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
