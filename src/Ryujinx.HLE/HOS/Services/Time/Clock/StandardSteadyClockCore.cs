<<<<<<< HEAD
using Ryujinx.Cpu;
=======
﻿using Ryujinx.Cpu;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    class StandardSteadyClockCore : SteadyClockCore
    {
        private TimeSpanType _setupValue;
        private TimeSpanType _testOffset;
        private TimeSpanType _internalOffset;
        private TimeSpanType _cachedRawTimePoint;

        public StandardSteadyClockCore()
        {
<<<<<<< HEAD
            _setupValue = TimeSpanType.Zero;
            _testOffset = TimeSpanType.Zero;
            _internalOffset = TimeSpanType.Zero;
=======
            _setupValue         = TimeSpanType.Zero;
            _testOffset         = TimeSpanType.Zero;
            _internalOffset     = TimeSpanType.Zero;
>>>>>>> 1ec71635b (sync with main branch)
            _cachedRawTimePoint = TimeSpanType.Zero;
        }

        public override SteadyClockTimePoint GetTimePoint(ITickSource tickSource)
        {
<<<<<<< HEAD
            SteadyClockTimePoint result = new()
            {
                TimePoint = GetCurrentRawTimePoint(tickSource).ToSeconds(),
                ClockSourceId = GetClockSourceId(),
=======
            SteadyClockTimePoint result = new SteadyClockTimePoint
            {
                TimePoint     = GetCurrentRawTimePoint(tickSource).ToSeconds(),
                ClockSourceId = GetClockSourceId()
>>>>>>> 1ec71635b (sync with main branch)
            };

            return result;
        }

        public override TimeSpanType GetTestOffset()
        {
            return _testOffset;
        }

        public override void SetTestOffset(TimeSpanType testOffset)
        {
            _testOffset = testOffset;
        }

        public override TimeSpanType GetInternalOffset()
        {
            return _internalOffset;
        }

        public override void SetInternalOffset(TimeSpanType internalOffset)
        {
            _internalOffset = internalOffset;
        }

        public override TimeSpanType GetCurrentRawTimePoint(ITickSource tickSource)
        {
            TimeSpanType ticksTimeSpan = TimeSpanType.FromTicks(tickSource.Counter, tickSource.Frequency);

<<<<<<< HEAD
            TimeSpanType rawTimePoint = new(_setupValue.NanoSeconds + ticksTimeSpan.NanoSeconds);
=======
            TimeSpanType rawTimePoint = new TimeSpanType(_setupValue.NanoSeconds + ticksTimeSpan.NanoSeconds);
>>>>>>> 1ec71635b (sync with main branch)

            if (rawTimePoint.NanoSeconds < _cachedRawTimePoint.NanoSeconds)
            {
                rawTimePoint.NanoSeconds = _cachedRawTimePoint.NanoSeconds;
            }

            _cachedRawTimePoint = rawTimePoint;

            return rawTimePoint;
        }

        public void SetSetupValue(TimeSpanType setupValue)
        {
            _setupValue = setupValue;
        }
    }
}
