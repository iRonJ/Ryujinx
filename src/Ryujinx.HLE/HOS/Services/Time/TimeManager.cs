<<<<<<< HEAD
using Ryujinx.Cpu;
=======
﻿using Ryujinx.Cpu;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.Exceptions;
using Ryujinx.HLE.HOS.Kernel.Memory;
using Ryujinx.HLE.HOS.Services.Time.Clock;
using Ryujinx.HLE.HOS.Services.Time.TimeZone;
using System;
using System.IO;

namespace Ryujinx.HLE.HOS.Services.Time
{
    class TimeManager
    {
        private static TimeManager _instance;

        public static TimeManager Instance
        {
            get
            {
<<<<<<< HEAD
                _instance ??= new TimeManager();
=======
                if (_instance == null)
                {
                    _instance = new TimeManager();
                }
>>>>>>> 1ec71635b (sync with main branch)

                return _instance;
            }
        }

<<<<<<< HEAD
        public StandardSteadyClockCore StandardSteadyClock { get; }
        public TickBasedSteadyClockCore TickBasedSteadyClock { get; }
        public StandardLocalSystemClockCore StandardLocalSystemClock { get; }
        public StandardNetworkSystemClockCore StandardNetworkSystemClock { get; }
        public StandardUserSystemClockCore StandardUserSystemClock { get; }
        public TimeZoneContentManager TimeZone { get; }
        public EphemeralNetworkSystemClockCore EphemeralNetworkSystemClock { get; }
        public TimeSharedMemory SharedMemory { get; }
        public LocalSystemClockContextWriter LocalClockContextWriter { get; }
        public NetworkSystemClockContextWriter NetworkClockContextWriter { get; }
=======
        public StandardSteadyClockCore                  StandardSteadyClock         { get; }
        public TickBasedSteadyClockCore                 TickBasedSteadyClock        { get; }
        public StandardLocalSystemClockCore             StandardLocalSystemClock    { get; }
        public StandardNetworkSystemClockCore           StandardNetworkSystemClock  { get; }
        public StandardUserSystemClockCore              StandardUserSystemClock     { get; }
        public TimeZoneContentManager                   TimeZone                    { get; }
        public EphemeralNetworkSystemClockCore          EphemeralNetworkSystemClock { get; }
        public TimeSharedMemory                         SharedMemory                { get; }
        public LocalSystemClockContextWriter            LocalClockContextWriter     { get; }
        public NetworkSystemClockContextWriter          NetworkClockContextWriter   { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public EphemeralNetworkSystemClockContextWriter EphemeralClockContextWriter { get; }

        // TODO: 9.0.0+ power states and alarms

        public TimeManager()
        {
<<<<<<< HEAD
            StandardSteadyClock = new StandardSteadyClockCore();
            TickBasedSteadyClock = new TickBasedSteadyClockCore();
            StandardLocalSystemClock = new StandardLocalSystemClockCore(StandardSteadyClock);
            StandardNetworkSystemClock = new StandardNetworkSystemClockCore(StandardSteadyClock);
            StandardUserSystemClock = new StandardUserSystemClockCore(StandardLocalSystemClock, StandardNetworkSystemClock);
            TimeZone = new TimeZoneContentManager();
            EphemeralNetworkSystemClock = new EphemeralNetworkSystemClockCore(TickBasedSteadyClock);
            SharedMemory = new TimeSharedMemory();
            LocalClockContextWriter = new LocalSystemClockContextWriter(SharedMemory);
            NetworkClockContextWriter = new NetworkSystemClockContextWriter(SharedMemory);
=======
            StandardSteadyClock         = new StandardSteadyClockCore();
            TickBasedSteadyClock        = new TickBasedSteadyClockCore();
            StandardLocalSystemClock    = new StandardLocalSystemClockCore(StandardSteadyClock);
            StandardNetworkSystemClock  = new StandardNetworkSystemClockCore(StandardSteadyClock);
            StandardUserSystemClock     = new StandardUserSystemClockCore(StandardLocalSystemClock, StandardNetworkSystemClock);
            TimeZone                    = new TimeZoneContentManager();
            EphemeralNetworkSystemClock = new EphemeralNetworkSystemClockCore(TickBasedSteadyClock);
            SharedMemory                = new TimeSharedMemory();
            LocalClockContextWriter     = new LocalSystemClockContextWriter(SharedMemory);
            NetworkClockContextWriter   = new NetworkSystemClockContextWriter(SharedMemory);
>>>>>>> 1ec71635b (sync with main branch)
            EphemeralClockContextWriter = new EphemeralNetworkSystemClockContextWriter();
        }

        public void Initialize(Switch device, Horizon system, KSharedMemory sharedMemory, SharedMemoryStorage timeSharedMemoryStorage, int timeSharedMemorySize)
        {
            SharedMemory.Initialize(device, sharedMemory, timeSharedMemoryStorage, timeSharedMemorySize);

            // Here we use system on purpose as device. System isn't initialized at this point.
            StandardUserSystemClock.CreateAutomaticCorrectionEvent(system);
        }

        public void InitializeTimeZone(Switch device)
        {
            TimeZone.Initialize(this, device);
        }

        public void SetupStandardSteadyClock(ITickSource tickSource, UInt128 clockSourceId, TimeSpanType setupValue, TimeSpanType internalOffset, TimeSpanType testOffset, bool isRtcResetDetected)
        {
            SetupInternalStandardSteadyClock(clockSourceId, setupValue, internalOffset, testOffset, isRtcResetDetected);

            TimeSpanType currentTimePoint = StandardSteadyClock.GetCurrentRawTimePoint(tickSource);

            SharedMemory.SetupStandardSteadyClock(tickSource, clockSourceId, currentTimePoint);

            // TODO: propagate IPC late binding of "time:s" and "time:p"
        }

        private void SetupInternalStandardSteadyClock(UInt128 clockSourceId, TimeSpanType setupValue, TimeSpanType internalOffset, TimeSpanType testOffset, bool isRtcResetDetected)
        {
            StandardSteadyClock.SetClockSourceId(clockSourceId);
            StandardSteadyClock.SetSetupValue(setupValue);
            StandardSteadyClock.SetInternalOffset(internalOffset);
            StandardSteadyClock.SetTestOffset(testOffset);

            if (isRtcResetDetected)
            {
                StandardSteadyClock.SetRtcReset();
            }

            StandardSteadyClock.MarkInitialized();

            // TODO: propagate IPC late binding of "time:s" and "time:p"
        }

        public void SetupStandardLocalSystemClock(ITickSource tickSource, SystemClockContext clockContext, long posixTime)
        {
            StandardLocalSystemClock.SetUpdateCallbackInstance(LocalClockContextWriter);

            SteadyClockTimePoint currentTimePoint = StandardLocalSystemClock.GetSteadyClockCore().GetCurrentTimePoint(tickSource);
            if (currentTimePoint.ClockSourceId == clockContext.SteadyTimePoint.ClockSourceId)
            {
                StandardLocalSystemClock.SetSystemClockContext(clockContext);
            }
            else
            {
                if (StandardLocalSystemClock.SetCurrentTime(tickSource, posixTime) != ResultCode.Success)
                {
                    throw new InternalServiceException("Cannot set current local time");
                }
            }

            StandardLocalSystemClock.MarkInitialized();

            // TODO: propagate IPC late binding of "time:s" and "time:p"
        }

        public void SetupStandardNetworkSystemClock(SystemClockContext clockContext, TimeSpanType sufficientAccuracy)
        {
            StandardNetworkSystemClock.SetUpdateCallbackInstance(NetworkClockContextWriter);

            if (StandardNetworkSystemClock.SetSystemClockContext(clockContext) != ResultCode.Success)
            {
                throw new InternalServiceException("Cannot set network SystemClockContext");
            }

            StandardNetworkSystemClock.SetStandardNetworkClockSufficientAccuracy(sufficientAccuracy);
            StandardNetworkSystemClock.MarkInitialized();

            // TODO: propagate IPC late binding of "time:s" and "time:p"
        }

        public void SetupTimeZoneManager(string locationName, SteadyClockTimePoint timeZoneUpdatedTimePoint, uint totalLocationNameCount, UInt128 timeZoneRuleVersion, Stream timeZoneBinaryStream)
        {
            if (TimeZone.Manager.SetDeviceLocationNameWithTimeZoneRule(locationName, timeZoneBinaryStream) != ResultCode.Success)
            {
                throw new InternalServiceException("Cannot set DeviceLocationName with a given TimeZoneBinary");
            }

            TimeZone.Manager.SetUpdatedTime(timeZoneUpdatedTimePoint, true);
            TimeZone.Manager.SetTotalLocationNameCount(totalLocationNameCount);
            TimeZone.Manager.SetTimeZoneRuleVersion(timeZoneRuleVersion);
            TimeZone.Manager.MarkInitialized();

            // TODO: propagate IPC late binding of "time:s" and "time:p"
        }

        public void SetupEphemeralNetworkSystemClock()
        {
            EphemeralNetworkSystemClock.SetUpdateCallbackInstance(EphemeralClockContextWriter);
            EphemeralNetworkSystemClock.MarkInitialized();

            // TODO: propagate IPC late binding of "time:s" and "time:p"
        }

        public void SetupStandardUserSystemClock(ITickSource tickSource, bool isAutomaticCorrectionEnabled, SteadyClockTimePoint steadyClockTimePoint)
        {
            if (StandardUserSystemClock.SetAutomaticCorrectionEnabled(tickSource, isAutomaticCorrectionEnabled) != ResultCode.Success)
            {
                throw new InternalServiceException("Cannot set automatic user time correction state");
            }

            StandardUserSystemClock.SetAutomaticCorrectionUpdatedTime(steadyClockTimePoint);
            StandardUserSystemClock.MarkInitialized();

            SharedMemory.SetAutomaticCorrectionEnabled(isAutomaticCorrectionEnabled);

            // TODO: propagate IPC late binding of "time:s" and "time:p"
        }

        public void SetStandardSteadyClockRtcOffset(ITickSource tickSource, TimeSpanType rtcOffset)
        {
            StandardSteadyClock.SetSetupValue(rtcOffset);

            TimeSpanType currentTimePoint = StandardSteadyClock.GetCurrentRawTimePoint(tickSource);

            SharedMemory.SetSteadyClockRawTimePoint(tickSource, currentTimePoint);
        }
    }
}
