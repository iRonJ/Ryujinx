<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
=======
﻿namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
>>>>>>> 1ec71635b (sync with main branch)
{
    static class BufferQueue
    {
        public static BufferQueueCore CreateBufferQueue(Switch device, ulong pid, out BufferQueueProducer producer, out BufferQueueConsumer consumer)
        {
<<<<<<< HEAD
            BufferQueueCore core = new(device, pid);
=======
            BufferQueueCore core = new BufferQueueCore(device, pid);
>>>>>>> 1ec71635b (sync with main branch)

            producer = new BufferQueueProducer(core, device.System.TickSource);
            consumer = new BufferQueueConsumer(core);

            return core;
        }
    }
}
