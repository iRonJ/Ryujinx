<<<<<<< HEAD
using Ryujinx.Common.Utilities;
=======
﻿using Ryujinx.Common.Utilities;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct SteadyClockTimePoint
    {
<<<<<<< HEAD
        public long TimePoint;
        public UInt128 ClockSourceId;

        public readonly ResultCode GetSpanBetween(SteadyClockTimePoint other, out long outSpan)
=======
        public long    TimePoint;
        public UInt128 ClockSourceId;

        public ResultCode GetSpanBetween(SteadyClockTimePoint other, out long outSpan)
>>>>>>> 1ec71635b (sync with main branch)
        {
            outSpan = 0;

            if (ClockSourceId == other.ClockSourceId)
            {
                try
                {
                    outSpan = checked(other.TimePoint - TimePoint);

                    return ResultCode.Success;
                }
                catch (OverflowException)
                {
                    return ResultCode.Overflow;
                }
            }

            return ResultCode.Overflow;
        }

        public static SteadyClockTimePoint GetRandom()
        {
            return new SteadyClockTimePoint
            {
<<<<<<< HEAD
                TimePoint = 0,
                ClockSourceId = UInt128Utils.CreateRandom(),
            };
        }
    }
}
=======
                TimePoint     = 0,
                ClockSourceId = UInt128Utils.CreateRandom()
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
