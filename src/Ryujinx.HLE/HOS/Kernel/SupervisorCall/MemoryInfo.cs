<<<<<<< HEAD
using Ryujinx.HLE.HOS.Kernel.Memory;
=======
﻿using Ryujinx.HLE.HOS.Kernel.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Kernel.SupervisorCall
{
    struct MemoryInfo
    {
        public ulong Address;
        public ulong Size;
        public MemoryState State;
        public MemoryAttribute Attribute;
        public KMemoryPermission Permission;
        public int IpcRefCount;
        public int DeviceRefCount;
<<<<<<< HEAD
#pragma warning disable CS0414, IDE0052 // Remove unread private member
        private readonly int _padding;
#pragma warning restore CS0414, IDE0052
=======
#pragma warning disable CS0414
        private int _padding;
#pragma warning restore CS0414
>>>>>>> 1ec71635b (sync with main branch)

        public MemoryInfo(
            ulong address,
            ulong size,
            MemoryState state,
            MemoryAttribute attribute,
            KMemoryPermission permission,
            int ipcRefCount,
            int deviceRefCount)
        {
            Address = address;
            Size = size;
            State = state;
            Attribute = attribute;
            Permission = permission;
            IpcRefCount = ipcRefCount;
            DeviceRefCount = deviceRefCount;
            _padding = 0;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
