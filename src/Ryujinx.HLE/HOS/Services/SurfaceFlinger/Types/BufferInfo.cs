<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Time.Clock;
=======
﻿using Ryujinx.HLE.HOS.Services.Time.Clock;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x1C, Pack = 1)]
    struct BufferInfo
    {
<<<<<<< HEAD
        public ulong FrameNumber;
        public TimeSpanType QueueTime;
        public TimeSpanType PresentationTime;
        public BufferState State;
=======
        public ulong        FrameNumber;
        public TimeSpanType QueueTime;
        public TimeSpanType PresentationTime;
        public BufferState  State;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
