<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Time.TimeZone
{
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack = 4)]
    public struct TimeTypeInfo
    {
        public const int Size = 0x10;

        public int GmtOffset;

        [MarshalAs(UnmanagedType.I1)]
        public bool IsDaySavingTime;

        public Array3<byte> Padding1;

        public int AbbreviationListIndex;

        [MarshalAs(UnmanagedType.I1)]
        public bool IsStandardTimeDaylight;

        [MarshalAs(UnmanagedType.I1)]
        public bool IsGMT;

        public ushort Padding2;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
