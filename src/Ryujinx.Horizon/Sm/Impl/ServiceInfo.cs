<<<<<<< HEAD
using Ryujinx.Horizon.Sdk.Sm;
=======
﻿using Ryujinx.Horizon.Sdk.Sm;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sm.Impl
{
    struct ServiceInfo
    {
        public ServiceName Name;
<<<<<<< HEAD
        public ulong OwnerProcessId;
        public int PortHandle;
=======
        public ulong       OwnerProcessId;
        public int         PortHandle;
>>>>>>> 1ec71635b (sync with main branch)

        public void Free()
        {
            HorizonStatic.Syscall.CloseHandle(PortHandle);

<<<<<<< HEAD
            Name = ServiceName.Invalid;
            OwnerProcessId = 0L;
            PortHandle = 0;
        }
    }
}
=======
            Name           = ServiceName.Invalid;
            OwnerProcessId = 0L;
            PortHandle     = 0;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
