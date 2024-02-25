using System;

namespace Ryujinx.HLE.HOS.Kernel.Memory
{
    [Flags]
<<<<<<< HEAD
    enum MemoryAttribute : byte
=======
    enum MemoryAttribute  : byte
>>>>>>> 1ec71635b (sync with main branch)
    {
        None = 0,
        Mask = 0xff,

<<<<<<< HEAD
        Borrowed = 1 << 0,
        IpcMapped = 1 << 1,
        DeviceMapped = 1 << 2,
        Uncached = 1 << 3,
        PermissionLocked = 1 << 4,

        IpcAndDeviceMapped = IpcMapped | DeviceMapped,
        BorrowedAndIpcMapped = Borrowed | IpcMapped,
        DeviceMappedAndUncached = DeviceMapped | Uncached,
    }
}
=======
        Borrowed     = 1 << 0,
        IpcMapped    = 1 << 1,
        DeviceMapped = 1 << 2,
        Uncached     = 1 << 3,

        IpcAndDeviceMapped = IpcMapped | DeviceMapped,

        BorrowedAndIpcMapped = Borrowed | IpcMapped,

        DeviceMappedAndUncached = DeviceMapped | Uncached
    }
}
>>>>>>> 1ec71635b (sync with main branch)
