<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Irs.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x20)]
    struct PackedMomentProcessorConfig
    {
<<<<<<< HEAD
        public long ExposureTime;
        public byte LightTarget;
        public byte Gain;
        public byte IsNegativeImageUsed;
        public byte Reserved1;
        public uint Reserved2;
=======
        public long   ExposureTime;
        public byte   LightTarget;
        public byte   Gain;
        public byte   IsNegativeImageUsed;
        public byte   Reserved1;
        public uint   Reserved2;
>>>>>>> 1ec71635b (sync with main branch)
        public ushort WindowOfInterestX;
        public ushort WindowOfInterestY;
        public ushort WindowOfInterestWidth;
        public ushort WindowOfInterestHeight;
<<<<<<< HEAD
        public uint RequiredMcuVersion;
        public byte Preprocess;
        public byte PreprocessIntensityThreshold;
        public ushort Reserved3;
    }
}
=======
        public uint   RequiredMcuVersion;
        public byte   Preprocess;
        public byte   PreprocessIntensityThreshold;
        public ushort Reserved3;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
