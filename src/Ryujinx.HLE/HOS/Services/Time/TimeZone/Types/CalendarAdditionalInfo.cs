<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Time.TimeZone
{
    [StructLayout(LayoutKind.Sequential, Pack = 0x4, Size = 0x18, CharSet = CharSet.Ansi)]
    struct CalendarAdditionalInfo
    {
        public uint DayOfWeek;
        public uint DayOfYear;

        public Array8<byte> TimezoneName;

        [MarshalAs(UnmanagedType.I1)]
        public bool IsDaySavingTime;

        public Array3<byte> Padding;

        public int GmtOffset;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
