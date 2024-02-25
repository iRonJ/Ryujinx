<<<<<<< HEAD
using System.Diagnostics.CodeAnalysis;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    [SuppressMessage("Design", "CA1069: Enums values should not be duplicated")]
    enum Status
    {
        Success = 0,
        WouldBlock = -11,
        NoMemory = -12,
        Busy = -16,
        NoInit = -19,
        BadValue = -22,
=======
﻿namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    enum Status : int
    {
        Success          = 0,
        WouldBlock       = -11,
        NoMemory         = -12,
        Busy             = -16,
        NoInit           = -19,
        BadValue         = -22,
>>>>>>> 1ec71635b (sync with main branch)
        InvalidOperation = -37,

        // Producer flags
        BufferNeedsReallocation = 1,
<<<<<<< HEAD
        ReleaseAllBuffers = 2,

        // Consumer errors
        StaleBufferSlot = 1,
        NoBufferAvailaible = 2,
        PresentLater = 3,
=======
        ReleaseAllBuffers       = 2,

        // Consumer errors
        StaleBufferSlot    = 1,
        NoBufferAvailaible = 2,
        PresentLater       = 3,
>>>>>>> 1ec71635b (sync with main branch)
    }
}
