<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostCtrlGpu.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct GpuCharacteristics
    {
<<<<<<< HEAD
        public int Arch;
        public int Impl;
        public int Rev;
        public int NumGpc;
        public long L2CacheSize;
        public long OnBoardVideoMemorySize;
        public int NumTpcPerGpc;
        public int BusType;
        public int BigPageSize;
        public int CompressionPageSize;
        public int PdeCoverageBitCount;
        public int AvailableBigPageSizes;
        public int GpcMask;
        public int SmArchSmVersion;
        public int SmArchSpaVersion;
        public int SmArchWarpCount;
        public int GpuVaBitCount;
        public int Reserved;
        public long Flags;
        public int TwodClass;
        public int ThreedClass;
        public int ComputeClass;
        public int GpfifoClass;
        public int InlineToMemoryClass;
        public int DmaCopyClass;
        public int MaxFbpsCount;
        public int FbpEnMask;
        public int MaxLtcPerFbp;
        public int MaxLtsPerLtc;
        public int MaxTexPerTpc;
        public int MaxGpcCount;
        public int RopL2EnMask0;
        public int RopL2EnMask1;
=======
        public int  Arch;
        public int  Impl;
        public int  Rev;
        public int  NumGpc;
        public long L2CacheSize;
        public long OnBoardVideoMemorySize;
        public int  NumTpcPerGpc;
        public int  BusType;
        public int  BigPageSize;
        public int  CompressionPageSize;
        public int  PdeCoverageBitCount;
        public int  AvailableBigPageSizes;
        public int  GpcMask;
        public int  SmArchSmVersion;
        public int  SmArchSpaVersion;
        public int  SmArchWarpCount;
        public int  GpuVaBitCount;
        public int  Reserved;
        public long Flags;
        public int  TwodClass;
        public int  ThreedClass;
        public int  ComputeClass;
        public int  GpfifoClass;
        public int  InlineToMemoryClass;
        public int  DmaCopyClass;
        public int  MaxFbpsCount;
        public int  FbpEnMask;
        public int  MaxLtcPerFbp;
        public int  MaxLtsPerLtc;
        public int  MaxTexPerTpc;
        public int  MaxGpcCount;
        public int  RopL2EnMask0;
        public int  RopL2EnMask1;
>>>>>>> 1ec71635b (sync with main branch)
        public long ChipName;
        public long GrCompbitStoreBaseHw;
    }

    struct CharacteristicsHeader
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public long BufferSize;
        public long BufferAddress;
#pragma warning restore CS0649
    }

    [StructLayout(LayoutKind.Sequential)]
    struct GetCharacteristicsArguments
    {
        public CharacteristicsHeader Header;
<<<<<<< HEAD
        public GpuCharacteristics Characteristics;
=======
        public GpuCharacteristics    Characteristics;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
