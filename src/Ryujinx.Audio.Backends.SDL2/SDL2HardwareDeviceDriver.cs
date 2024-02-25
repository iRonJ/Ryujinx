<<<<<<< HEAD
using Ryujinx.Audio.Common;
=======
﻿using Ryujinx.Audio.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Audio.Integration;
using Ryujinx.Common.Logging;
using Ryujinx.Memory;
using Ryujinx.SDL2.Common;
using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Threading;
<<<<<<< HEAD
=======

>>>>>>> 1ec71635b (sync with main branch)
using static Ryujinx.Audio.Integration.IHardwareDeviceDriver;
using static SDL2.SDL;

namespace Ryujinx.Audio.Backends.SDL2
{
    public class SDL2HardwareDeviceDriver : IHardwareDeviceDriver
    {
        private readonly ManualResetEvent _updateRequiredEvent;
        private readonly ManualResetEvent _pauseEvent;
        private readonly ConcurrentDictionary<SDL2HardwareDeviceSession, byte> _sessions;

<<<<<<< HEAD
        private readonly bool _supportSurroundConfiguration;

        public float Volume { get; set; }

        // TODO: Add this to SDL2-CS
        // NOTE: We use a DllImport here because of marshaling issue for spec.
#pragma warning disable SYSLIB1054
        [DllImport("SDL2")]
        private static extern int SDL_GetDefaultAudioInfo(IntPtr name, out SDL_AudioSpec spec, int isCapture);
#pragma warning restore SYSLIB1054
=======
        private bool _supportSurroundConfiguration;

        // TODO: Add this to SDL2-CS
        // NOTE: We use a DllImport here because of marshaling issue for spec.
        [DllImport("SDL2")]
        private static extern int SDL_GetDefaultAudioInfo(IntPtr name, out SDL_AudioSpec spec, int isCapture);
>>>>>>> 1ec71635b (sync with main branch)

        public SDL2HardwareDeviceDriver()
        {
            _updateRequiredEvent = new ManualResetEvent(false);
            _pauseEvent = new ManualResetEvent(true);
            _sessions = new ConcurrentDictionary<SDL2HardwareDeviceSession, byte>();

            SDL2Driver.Instance.Initialize();

            int res = SDL_GetDefaultAudioInfo(IntPtr.Zero, out var spec, 0);

            if (res != 0)
            {
                Logger.Error?.Print(LogClass.Application,
                    $"SDL_GetDefaultAudioInfo failed with error \"{SDL_GetError()}\"");

                _supportSurroundConfiguration = true;
            }
            else
            {
<<<<<<< HEAD
                _supportSurroundConfiguration = spec.channels >= 6;
            }

            Volume = 1f;
=======
                _supportSurroundConfiguration = spec.channels == 6;
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static bool IsSupported => IsSupportedInternal();

        private static bool IsSupportedInternal()
        {
            uint device = OpenStream(SampleFormat.PcmInt16, Constants.TargetSampleRate, Constants.ChannelCountMax, Constants.TargetSampleCount, null);

            if (device != 0)
            {
                SDL_CloseAudioDevice(device);
            }

            return device != 0;
        }

        public ManualResetEvent GetUpdateRequiredEvent()
        {
            return _updateRequiredEvent;
        }

        public ManualResetEvent GetPauseEvent()
        {
            return _pauseEvent;
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

            if (direction != Direction.Output)
            {
                throw new NotImplementedException("Input direction is currently not implemented on SDL2 backend!");
            }

<<<<<<< HEAD
            SDL2HardwareDeviceSession session = new(this, memoryManager, sampleFormat, sampleRate, channelCount);
=======
            SDL2HardwareDeviceSession session = new SDL2HardwareDeviceSession(this, memoryManager, sampleFormat, sampleRate, channelCount, volume);
>>>>>>> 1ec71635b (sync with main branch)

            _sessions.TryAdd(session, 0);

            return session;
        }

        internal bool Unregister(SDL2HardwareDeviceSession session)
        {
            return _sessions.TryRemove(session, out _);
        }

        private static SDL_AudioSpec GetSDL2Spec(SampleFormat requestedSampleFormat, uint requestedSampleRate, uint requestedChannelCount, uint sampleCount)
        {
            return new SDL_AudioSpec
            {
                channels = (byte)requestedChannelCount,
                format = GetSDL2Format(requestedSampleFormat),
                freq = (int)requestedSampleRate,
<<<<<<< HEAD
                samples = (ushort)sampleCount,
=======
                samples = (ushort)sampleCount
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        internal static ushort GetSDL2Format(SampleFormat format)
        {
            return format switch
            {
                SampleFormat.PcmInt8 => AUDIO_S8,
                SampleFormat.PcmInt16 => AUDIO_S16,
                SampleFormat.PcmInt32 => AUDIO_S32,
                SampleFormat.PcmFloat => AUDIO_F32,
                _ => throw new ArgumentException($"Unsupported sample format {format}"),
            };
        }

        internal static uint OpenStream(SampleFormat requestedSampleFormat, uint requestedSampleRate, uint requestedChannelCount, uint sampleCount, SDL_AudioCallback callback)
        {
            SDL_AudioSpec desired = GetSDL2Spec(requestedSampleFormat, requestedSampleRate, requestedChannelCount, sampleCount);

            desired.callback = callback;

            uint device = SDL_OpenAudioDevice(IntPtr.Zero, 0, ref desired, out SDL_AudioSpec got, 0);

            if (device == 0)
            {
<<<<<<< HEAD
                Logger.Error?.Print(LogClass.Application, $"SDL2 open audio device initialization failed with error \"{SDL_GetError()}\"");
=======
                Logger.Error?.Print(LogClass.Application, 
                    $"SDL2 open audio device initialization failed with error \"{SDL_GetError()}\"");
>>>>>>> 1ec71635b (sync with main branch)

                return 0;
            }

            bool isValid = got.format == desired.format && got.freq == desired.freq && got.channels == desired.channels;

            if (!isValid)
            {
                Logger.Error?.Print(LogClass.Application, "SDL2 open audio device is not valid");
                SDL_CloseAudioDevice(device);

                return 0;
            }

            return device;
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
                foreach (SDL2HardwareDeviceSession session in _sessions.Keys)
                {
                    session.Dispose();
                }

                SDL2Driver.Instance.Dispose();

                _pauseEvent.Dispose();
            }
        }

        public bool SupportsSampleRate(uint sampleRate)
        {
            return true;
        }

        public bool SupportsSampleFormat(SampleFormat sampleFormat)
        {
            return sampleFormat != SampleFormat.PcmInt24;
        }

        public bool SupportsChannelCount(uint channelCount)
        {
            if (channelCount == 6)
            {
                return _supportSurroundConfiguration;
            }

            return true;
        }

        public bool SupportsDirection(Direction direction)
        {
            // TODO: add direction input when supported.
            return direction == Direction.Output;
        }
    }
}
