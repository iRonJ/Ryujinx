using Ryujinx.Audio.Backends.Common;
using Ryujinx.Audio.Backends.Dummy;
using Ryujinx.Audio.Common;
using Ryujinx.Audio.Integration;
using Ryujinx.Common.Logging;
using Ryujinx.Memory;
using System;
using System.Threading;
<<<<<<< HEAD
=======

>>>>>>> 1ec71635b (sync with main branch)
using static Ryujinx.Audio.Integration.IHardwareDeviceDriver;

namespace Ryujinx.Audio.Backends.CompatLayer
{
    public class CompatLayerHardwareDeviceDriver : IHardwareDeviceDriver
    {
<<<<<<< HEAD
        private readonly IHardwareDeviceDriver _realDriver;

        public static bool IsSupported => true;

        public float Volume
        {
            get => _realDriver.Volume;
            set => _realDriver.Volume = value;
        }

=======
        private IHardwareDeviceDriver _realDriver;

        public static bool IsSupported => true;

>>>>>>> 1ec71635b (sync with main branch)
        public CompatLayerHardwareDeviceDriver(IHardwareDeviceDriver realDevice)
        {
            _realDriver = realDevice;
        }

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            _realDriver.Dispose();
        }

        public ManualResetEvent GetUpdateRequiredEvent()
        {
            return _realDriver.GetUpdateRequiredEvent();
        }

        public ManualResetEvent GetPauseEvent()
        {
            return _realDriver.GetPauseEvent();
        }

        private uint SelectHardwareChannelCount(uint targetChannelCount)
        {
            if (_realDriver.SupportsChannelCount(targetChannelCount))
            {
                return targetChannelCount;
            }

            return targetChannelCount switch
            {
                6 => SelectHardwareChannelCount(2),
                2 => SelectHardwareChannelCount(1),
                1 => throw new ArgumentException("No valid channel configuration found!"),
<<<<<<< HEAD
                _ => throw new ArgumentException($"Invalid targetChannelCount {targetChannelCount}"),
=======
                _ => throw new ArgumentException($"Invalid targetChannelCount {targetChannelCount}")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private SampleFormat SelectHardwareSampleFormat(SampleFormat targetSampleFormat)
        {
            if (_realDriver.SupportsSampleFormat(targetSampleFormat))
            {
                return targetSampleFormat;
            }

            // Attempt conversion from PCM16.
            if (targetSampleFormat == SampleFormat.PcmInt16)
            {
                // Prefer PCM32 if we need to convert.
                if (_realDriver.SupportsSampleFormat(SampleFormat.PcmInt32))
                {
                    return SampleFormat.PcmInt32;
                }

                // If not supported, PCM float provides the best quality with a cost lower than PCM24.
                if (_realDriver.SupportsSampleFormat(SampleFormat.PcmFloat))
                {
                    return SampleFormat.PcmFloat;
                }

                if (_realDriver.SupportsSampleFormat(SampleFormat.PcmInt24))
                {
                    return SampleFormat.PcmInt24;
                }

                // If nothing is truly supported, attempt PCM8 at the cost of losing quality.
                if (_realDriver.SupportsSampleFormat(SampleFormat.PcmInt8))
                {
                    return SampleFormat.PcmInt8;
                }
            }

            throw new ArgumentException("No valid sample format configuration found!");
        }

<<<<<<< HEAD
        public IHardwareDeviceSession OpenDeviceSession(Direction direction, IVirtualMemoryManager memoryManager, SampleFormat sampleFormat, uint sampleRate, uint channelCount)
=======
        public IHardwareDeviceSession OpenDeviceSession(Direction direction, IVirtualMemoryManager memoryManager, SampleFormat sampleFormat, uint sampleRate, uint channelCount, float volume)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (channelCount == 0)
            {
                channelCount = 2;
            }

            if (sampleRate == 0)
            {
                sampleRate = Constants.TargetSampleRate;
            }

<<<<<<< HEAD
=======
            volume = Math.Clamp(volume, 0, 1);

>>>>>>> 1ec71635b (sync with main branch)
            if (!_realDriver.SupportsDirection(direction))
            {
                if (direction == Direction.Input)
                {
                    Logger.Warning?.Print(LogClass.Audio, "The selected audio backend doesn't support audio input, fallback to dummy...");

<<<<<<< HEAD
                    return new DummyHardwareDeviceSessionInput(this, memoryManager);
=======
                    return new DummyHardwareDeviceSessionInput(this, memoryManager, sampleFormat, sampleRate, channelCount);
>>>>>>> 1ec71635b (sync with main branch)
                }

                throw new NotImplementedException();
            }

            SampleFormat hardwareSampleFormat = SelectHardwareSampleFormat(sampleFormat);
            uint hardwareChannelCount = SelectHardwareChannelCount(channelCount);

<<<<<<< HEAD
            IHardwareDeviceSession realSession = _realDriver.OpenDeviceSession(direction, memoryManager, hardwareSampleFormat, sampleRate, hardwareChannelCount);
=======
            IHardwareDeviceSession realSession = _realDriver.OpenDeviceSession(direction, memoryManager, hardwareSampleFormat, sampleRate, hardwareChannelCount, volume);
>>>>>>> 1ec71635b (sync with main branch)

            if (hardwareChannelCount == channelCount && hardwareSampleFormat == sampleFormat)
            {
                return realSession;
            }

            if (hardwareSampleFormat != sampleFormat)
            {
                Logger.Warning?.Print(LogClass.Audio, $"{sampleFormat} isn't supported by the audio device, conversion to {hardwareSampleFormat} will happen.");

                if (hardwareSampleFormat < sampleFormat)
                {
                    Logger.Warning?.Print(LogClass.Audio, $"{hardwareSampleFormat} has lower quality than {sampleFormat}, expect some loss in audio fidelity.");
                }
            }

            if (direction == Direction.Input)
            {
<<<<<<< HEAD
                Logger.Warning?.Print(LogClass.Audio, "The selected audio backend doesn't support the requested audio input configuration, fallback to dummy...");
=======
                Logger.Warning?.Print(LogClass.Audio, $"The selected audio backend doesn't support the requested audio input configuration, fallback to dummy...");
>>>>>>> 1ec71635b (sync with main branch)

                // TODO: We currently don't support audio input upsampling/downsampling, implement this.
                realSession.Dispose();

<<<<<<< HEAD
                return new DummyHardwareDeviceSessionInput(this, memoryManager);
=======
                return new DummyHardwareDeviceSessionInput(this, memoryManager, sampleFormat, sampleRate, channelCount);
>>>>>>> 1ec71635b (sync with main branch)
            }

            // It must be a HardwareDeviceSessionOutputBase.
            if (realSession is not HardwareDeviceSessionOutputBase realSessionOutputBase)
            {
                throw new InvalidOperationException($"Real driver session class type isn't based on {typeof(HardwareDeviceSessionOutputBase).Name}.");
            }

            // If we need to do post processing before sending to the hardware device, wrap around it.
            return new CompatLayerHardwareDeviceSession(realSessionOutputBase, sampleFormat, channelCount);
        }

        public bool SupportsChannelCount(uint channelCount)
        {
            return channelCount == 1 || channelCount == 2 || channelCount == 6;
        }

        public bool SupportsSampleFormat(SampleFormat sampleFormat)
        {
            // TODO: More formats.
            return sampleFormat == SampleFormat.PcmInt16;
        }

        public bool SupportsSampleRate(uint sampleRate)
        {
            // TODO: More sample rates.
            return sampleRate == Constants.TargetSampleRate;
        }

        public IHardwareDeviceDriver GetRealDeviceDriver()
        {
            return _realDriver;
        }

        public bool SupportsDirection(Direction direction)
        {
            return direction == Direction.Input || direction == Direction.Output;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
