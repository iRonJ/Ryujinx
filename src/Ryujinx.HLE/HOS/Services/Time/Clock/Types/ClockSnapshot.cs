<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Time.TimeZone;
=======
﻿using Ryujinx.HLE.HOS.Services.Time.TimeZone;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    [StructLayout(LayoutKind.Sequential, Size = 0xD0)]
    struct ClockSnapshot
    {
<<<<<<< HEAD
        public SystemClockContext UserContext;
        public SystemClockContext NetworkContext;
        public long UserTime;
        public long NetworkTime;
        public CalendarTime UserCalendarTime;
        public CalendarTime NetworkCalendarTime;
        public CalendarAdditionalInfo UserCalendarAdditionalTime;
        public CalendarAdditionalInfo NetworkCalendarAdditionalTime;
        public SteadyClockTimePoint SteadyClockTimePoint;
=======
        public SystemClockContext     UserContext;
        public SystemClockContext     NetworkContext;
        public long                   UserTime;
        public long                   NetworkTime;
        public CalendarTime           UserCalendarTime;
        public CalendarTime           NetworkCalendarTime;
        public CalendarAdditionalInfo UserCalendarAdditionalTime;
        public CalendarAdditionalInfo NetworkCalendarAdditionalTime;
        public SteadyClockTimePoint   SteadyClockTimePoint;
>>>>>>> 1ec71635b (sync with main branch)

        private LocationNameStorageHolder _locationName;

        public Span<byte> LocationName => MemoryMarshal.Cast<LocationNameStorageHolder, byte>(MemoryMarshal.CreateSpan(ref _locationName, LocationNameStorageHolder.Size));

        [MarshalAs(UnmanagedType.I1)]
<<<<<<< HEAD
        public bool IsAutomaticCorrectionEnabled;
        public byte Type;
=======
        public bool   IsAutomaticCorrectionEnabled;
        public byte   Type;
>>>>>>> 1ec71635b (sync with main branch)
        public ushort Unknown;


        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = Size)]
        private struct LocationNameStorageHolder
        {
            public const int Size = 0x24;
        }

        public static ResultCode GetCurrentTime(out long currentTime, SteadyClockTimePoint steadyClockTimePoint, SystemClockContext context)
        {
            currentTime = 0;

            if (steadyClockTimePoint.ClockSourceId == context.SteadyTimePoint.ClockSourceId)
            {
                currentTime = steadyClockTimePoint.TimePoint + context.Offset;

                return ResultCode.Success;
            }

            return ResultCode.TimeMismatch;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
