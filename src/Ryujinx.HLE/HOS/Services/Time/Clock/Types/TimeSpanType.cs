<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    [StructLayout(LayoutKind.Sequential)]
    struct TimeSpanType
    {
        private const long NanoSecondsPerSecond = 1000000000;

<<<<<<< HEAD
        public static readonly TimeSpanType Zero = new(0);
=======
        public static readonly TimeSpanType Zero = new TimeSpanType(0);
>>>>>>> 1ec71635b (sync with main branch)

        public long NanoSeconds;

        public TimeSpanType(long nanoSeconds)
        {
            NanoSeconds = nanoSeconds;
        }

<<<<<<< HEAD
        public readonly long ToSeconds()
=======
        public long ToSeconds()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return NanoSeconds / NanoSecondsPerSecond;
        }

<<<<<<< HEAD
        public readonly TimeSpanType AddSeconds(long seconds)
=======
        public TimeSpanType AddSeconds(long seconds)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return new TimeSpanType(NanoSeconds + (seconds * NanoSecondsPerSecond));
        }

<<<<<<< HEAD
        public readonly bool IsDaylightSavingTime()
=======
        public bool IsDaylightSavingTime()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return DateTime.UnixEpoch.AddSeconds(ToSeconds()).ToLocalTime().IsDaylightSavingTime();
        }

        public static TimeSpanType FromSeconds(long seconds)
        {
            return new TimeSpanType(seconds * NanoSecondsPerSecond);
        }

        public static TimeSpanType FromTimeSpan(TimeSpan timeSpan)
        {
            return new TimeSpanType((long)(timeSpan.TotalMilliseconds * 1000000));
        }

        public static TimeSpanType FromTicks(ulong ticks, ulong frequency)
        {
            return FromSeconds((long)ticks / (long)frequency);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
