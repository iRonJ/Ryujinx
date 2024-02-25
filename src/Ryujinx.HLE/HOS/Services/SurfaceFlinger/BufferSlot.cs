<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Services.Time.Clock;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    class BufferSlot
    {
        public AndroidStrongPointer<GraphicBuffer> GraphicBuffer;
<<<<<<< HEAD
        public BufferState BufferState;
        public bool RequestBufferCalled;
        public ulong FrameNumber;
        public AndroidFence Fence;
        public bool AcquireCalled;
        public bool NeedsCleanupOnRelease;
        public bool AttachedByConsumer;
        public TimeSpanType QueueTime;
        public TimeSpanType PresentationTime;
        public bool IsPreallocated;

        public BufferSlot()
        {
            GraphicBuffer = new AndroidStrongPointer<GraphicBuffer>();
            BufferState = BufferState.Free;
            QueueTime = TimeSpanType.Zero;
            PresentationTime = TimeSpanType.Zero;
            IsPreallocated = false;
=======
        public BufferState                         BufferState;
        public bool                                RequestBufferCalled;
        public ulong                               FrameNumber;
        public AndroidFence                        Fence;
        public bool                                AcquireCalled;
        public bool                                NeedsCleanupOnRelease;
        public bool                                AttachedByConsumer;
        public TimeSpanType                        QueueTime;
        public TimeSpanType                        PresentationTime;
        public bool                                IsPreallocated;

        public BufferSlot()
        {
            GraphicBuffer    = new AndroidStrongPointer<GraphicBuffer>();
            BufferState      = BufferState.Free;
            QueueTime        = TimeSpanType.Zero;
            PresentationTime = TimeSpanType.Zero;
            IsPreallocated   = false;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
