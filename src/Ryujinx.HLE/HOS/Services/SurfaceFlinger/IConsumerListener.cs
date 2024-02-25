<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
=======
﻿namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
>>>>>>> 1ec71635b (sync with main branch)
{
    interface IConsumerListener
    {
        void OnFrameAvailable(ref BufferItem item);
        void OnFrameReplaced(ref BufferItem item);
        void OnBuffersReleased();
    }
}
