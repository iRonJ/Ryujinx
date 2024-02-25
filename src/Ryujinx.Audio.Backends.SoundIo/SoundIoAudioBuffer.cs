<<<<<<< HEAD
namespace Ryujinx.Audio.Backends.SoundIo
=======
﻿namespace Ryujinx.Audio.Backends.SoundIo
>>>>>>> 1ec71635b (sync with main branch)
{
    class SoundIoAudioBuffer
    {
        public readonly ulong DriverIdentifier;
        public readonly ulong SampleCount;
        public ulong SamplePlayed;

        public SoundIoAudioBuffer(ulong driverIdentifier, ulong sampleCount)
        {
            DriverIdentifier = driverIdentifier;
            SampleCount = sampleCount;
            SamplePlayed = 0;
        }
    }
}
