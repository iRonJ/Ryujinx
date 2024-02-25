using Ryujinx.Audio.Integration;
using System;

namespace Ryujinx.Audio.Renderer.Utils
{
    public class SplitterHardwareDevice : IHardwareDevice
    {
<<<<<<< HEAD
        private readonly IHardwareDevice _baseDevice;
        private readonly IHardwareDevice _secondaryDevice;
=======
        private IHardwareDevice _baseDevice;
        private IHardwareDevice _secondaryDevice;
>>>>>>> 1ec71635b (sync with main branch)

        public SplitterHardwareDevice(IHardwareDevice baseDevice, IHardwareDevice secondaryDevice)
        {
            _baseDevice = baseDevice;
            _secondaryDevice = secondaryDevice;
        }

        public void AppendBuffer(ReadOnlySpan<short> data, uint channelCount)
        {
            _baseDevice.AppendBuffer(data, channelCount);
            _secondaryDevice?.AppendBuffer(data, channelCount);
        }

        public void SetVolume(float volume)
        {
            _baseDevice.SetVolume(volume);
            _secondaryDevice.SetVolume(volume);
        }

        public float GetVolume()
        {
            return _baseDevice.GetVolume();
        }

        public uint GetChannelCount()
        {
            return _baseDevice.GetChannelCount();
        }

        public uint GetSampleRate()
        {
            return _baseDevice.GetSampleRate();
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
                _baseDevice.Dispose();
                _secondaryDevice?.Dispose();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
