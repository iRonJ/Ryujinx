using Ryujinx.Audio.Common;
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.Audio.Integration
{
    public class HardwareDeviceImpl : IHardwareDevice
    {
<<<<<<< HEAD
        private readonly IHardwareDeviceSession _session;
        private readonly uint _channelCount;
        private readonly uint _sampleRate;
        private uint _currentBufferTag;

        private readonly byte[] _buffer;

        public HardwareDeviceImpl(IHardwareDeviceDriver deviceDriver, uint channelCount, uint sampleRate)
        {
            _session = deviceDriver.OpenDeviceSession(IHardwareDeviceDriver.Direction.Output, null, SampleFormat.PcmInt16, sampleRate, channelCount);
=======
        private IHardwareDeviceSession _session;
        private uint _channelCount;
        private uint _sampleRate;
        private uint _currentBufferTag;

        private byte[] _buffer;

        public HardwareDeviceImpl(IHardwareDeviceDriver deviceDriver, uint channelCount, uint sampleRate, float volume)
        {
            _session = deviceDriver.OpenDeviceSession(IHardwareDeviceDriver.Direction.Output, null, SampleFormat.PcmInt16, sampleRate, channelCount, volume);
>>>>>>> 1ec71635b (sync with main branch)
            _channelCount = channelCount;
            _sampleRate = sampleRate;
            _currentBufferTag = 0;

            _buffer = new byte[Constants.TargetSampleCount * channelCount * sizeof(ushort)];

            _session.Start();
        }

        public void AppendBuffer(ReadOnlySpan<short> data, uint channelCount)
        {
            data.CopyTo(MemoryMarshal.Cast<byte, short>(_buffer));

            _session.QueueBuffer(new AudioBuffer
            {
                DataPointer = _currentBufferTag++,
                Data = _buffer,
                DataSize = (ulong)_buffer.Length,
            });

<<<<<<< HEAD
            _currentBufferTag %= 4;
=======
            _currentBufferTag = _currentBufferTag % 4;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void SetVolume(float volume)
        {
            _session.SetVolume(volume);
        }

        public float GetVolume()
        {
            return _session.GetVolume();
        }

        public uint GetChannelCount()
        {
            return _channelCount;
        }

        public uint GetSampleRate()
        {
            return _sampleRate;
        }

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _session.Dispose();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
