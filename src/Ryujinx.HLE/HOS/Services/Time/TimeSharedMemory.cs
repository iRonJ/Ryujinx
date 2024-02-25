<<<<<<< HEAD
using Ryujinx.Cpu;
=======
﻿using Ryujinx.Cpu;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Kernel.Memory;
using Ryujinx.HLE.HOS.Services.Time.Clock;
using Ryujinx.HLE.HOS.Services.Time.Clock.Types;
using Ryujinx.HLE.HOS.Services.Time.Types;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Ryujinx.HLE.HOS.Services.Time
{
    class TimeSharedMemory
    {
<<<<<<< HEAD
        private Switch _device;
        private KSharedMemory _sharedMemory;
        private SharedMemoryStorage _timeSharedMemoryStorage;
#pragma warning disable IDE0052 // Remove unread private member
        private int _timeSharedMemorySize;
#pragma warning restore IDE0052
=======
        private Switch              _device;
        private KSharedMemory       _sharedMemory;
        private SharedMemoryStorage _timeSharedMemoryStorage;
        private int                 _timeSharedMemorySize;
>>>>>>> 1ec71635b (sync with main branch)

        private const uint SteadyClockContextOffset = 0x00;
        private const uint LocalSystemClockContextOffset = 0x38;
        private const uint NetworkSystemClockContextOffset = 0x80;
        private const uint AutomaticCorrectionEnabledOffset = 0xC8;
        private const uint ContinuousAdjustmentTimePointOffset = 0xD0;

        public void Initialize(Switch device, KSharedMemory sharedMemory, SharedMemoryStorage timeSharedMemoryStorage, int timeSharedMemorySize)
        {
<<<<<<< HEAD
            _device = device;
            _sharedMemory = sharedMemory;
            _timeSharedMemoryStorage = timeSharedMemoryStorage;
            _timeSharedMemorySize = timeSharedMemorySize;
=======
            _device                  = device;
            _sharedMemory            = sharedMemory;
            _timeSharedMemoryStorage = timeSharedMemoryStorage;
            _timeSharedMemorySize    = timeSharedMemorySize;
>>>>>>> 1ec71635b (sync with main branch)

            // Clean the shared memory
            timeSharedMemoryStorage.ZeroFill();
        }

        public KSharedMemory GetSharedMemory()
        {
            return _sharedMemory;
        }

        public void SetupStandardSteadyClock(ITickSource tickSource, UInt128 clockSourceId, TimeSpanType currentTimePoint)
        {
            UpdateSteadyClock(tickSource, clockSourceId, currentTimePoint);
        }

        public void SetAutomaticCorrectionEnabled(bool isAutomaticCorrectionEnabled)
        {
            // We convert the bool to byte here as a bool in C# takes 4 bytes...
            WriteObjectToSharedMemory(AutomaticCorrectionEnabledOffset, 0, Convert.ToByte(isAutomaticCorrectionEnabled));
        }

        public void SetSteadyClockRawTimePoint(ITickSource tickSource, TimeSpanType currentTimePoint)
        {
            SteadyClockContext context = ReadObjectFromSharedMemory<SteadyClockContext>(SteadyClockContextOffset, 4);

            UpdateSteadyClock(tickSource, context.ClockSourceId, currentTimePoint);
        }

        private void UpdateSteadyClock(ITickSource tickSource, UInt128 clockSourceId, TimeSpanType currentTimePoint)
        {
            TimeSpanType ticksTimeSpan = TimeSpanType.FromTicks(tickSource.Counter, tickSource.Frequency);

<<<<<<< HEAD
            ContinuousAdjustmentTimePoint adjustmentTimePoint = new()
=======
            ContinuousAdjustmentTimePoint adjustmentTimePoint = new ContinuousAdjustmentTimePoint
>>>>>>> 1ec71635b (sync with main branch)
            {
                ClockOffset = (ulong)ticksTimeSpan.NanoSeconds,
                Multiplier = 1,
                DivisorLog2 = 0,
                Context = new SystemClockContext
                {
                    Offset = 0,
                    SteadyTimePoint = new SteadyClockTimePoint
                    {
                        ClockSourceId = clockSourceId,
<<<<<<< HEAD
                        TimePoint = 0,
                    },
                },
=======
                        TimePoint = 0
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)
            };

            WriteObjectToSharedMemory(ContinuousAdjustmentTimePointOffset, 4, adjustmentTimePoint);

<<<<<<< HEAD
            SteadyClockContext context = new()
            {
                InternalOffset = (ulong)(currentTimePoint.NanoSeconds - ticksTimeSpan.NanoSeconds),
                ClockSourceId = clockSourceId,
=======
            SteadyClockContext context = new SteadyClockContext
            {
                InternalOffset = (ulong)(currentTimePoint.NanoSeconds - ticksTimeSpan.NanoSeconds),
                ClockSourceId = clockSourceId
>>>>>>> 1ec71635b (sync with main branch)
            };

            WriteObjectToSharedMemory(SteadyClockContextOffset, 4, context);
        }

        public void UpdateLocalSystemClockContext(SystemClockContext context)
        {
            WriteObjectToSharedMemory(LocalSystemClockContextOffset, 4, context);
        }

        public void UpdateNetworkSystemClockContext(SystemClockContext context)
        {
            WriteObjectToSharedMemory(NetworkSystemClockContextOffset, 4, context);
        }

        private T ReadObjectFromSharedMemory<T>(ulong offset, ulong padding) where T : unmanaged
        {
<<<<<<< HEAD
            T result;
=======
            T    result;
>>>>>>> 1ec71635b (sync with main branch)
            uint index;
            uint possiblyNewIndex;

            do
            {
                index = _timeSharedMemoryStorage.GetRef<uint>(offset);

                ulong objectOffset = offset + 4 + padding + (ulong)((index & 1) * Unsafe.SizeOf<T>());

                result = _timeSharedMemoryStorage.GetRef<T>(objectOffset);

                Thread.MemoryBarrier();

                possiblyNewIndex = _device.Memory.Read<uint>(offset);
            } while (index != possiblyNewIndex);

            return result;
        }

        private void WriteObjectToSharedMemory<T>(ulong offset, ulong padding, T value) where T : unmanaged
        {
            uint newIndex = _timeSharedMemoryStorage.GetRef<uint>(offset) + 1;

            ulong objectOffset = offset + 4 + padding + (ulong)((newIndex & 1) * Unsafe.SizeOf<T>());

            _timeSharedMemoryStorage.GetRef<T>(objectOffset) = value;

            Thread.MemoryBarrier();

            _timeSharedMemoryStorage.GetRef<uint>(offset) = newIndex;
        }
    }
}
