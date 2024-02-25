<<<<<<< HEAD
using Ryujinx.Cpu;
=======
﻿using Ryujinx.Cpu;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    class TickBasedSteadyClockCore : SteadyClockCore
    {
<<<<<<< HEAD
        public TickBasedSteadyClockCore() { }

        public override SteadyClockTimePoint GetTimePoint(ITickSource tickSource)
        {
            SteadyClockTimePoint result = new()
            {
                TimePoint = 0,
                ClockSourceId = GetClockSourceId(),
=======
        public TickBasedSteadyClockCore() {}

        public override SteadyClockTimePoint GetTimePoint(ITickSource tickSource)
        {
            SteadyClockTimePoint result = new SteadyClockTimePoint
            {
                TimePoint     = 0,
                ClockSourceId = GetClockSourceId()
>>>>>>> 1ec71635b (sync with main branch)
            };

            TimeSpanType ticksTimeSpan = TimeSpanType.FromTicks(tickSource.Counter, tickSource.Frequency);

            result.TimePoint = ticksTimeSpan.ToSeconds();

            return result;
        }
    }
}
