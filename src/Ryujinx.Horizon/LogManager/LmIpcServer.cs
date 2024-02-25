<<<<<<< HEAD
using Ryujinx.Horizon.LogManager.Ipc;
=======
﻿using Ryujinx.Horizon.LogManager.Ipc;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Sf.Hipc;
using Ryujinx.Horizon.Sdk.Sm;

namespace Ryujinx.Horizon.LogManager
{
    class LmIpcServer
    {
<<<<<<< HEAD
        private const int MaxSessionsCount = 42;

        private const int PointerBufferSize = 0x400;
        private const int MaxDomains = 31;
        private const int MaxDomainObjects = 61;
        private const int MaxPortsCount = 1;

        private static readonly ManagerOptions _managerOptions = new(PointerBufferSize, MaxDomains, MaxDomainObjects, false);

        private SmApi _sm;
=======
        private const int LogMaxSessionsCount = 42;

        private const int PointerBufferSize = 0x400;
        private const int MaxDomains        = 31;
        private const int MaxDomainObjects  = 61;
        private const int MaxPortsCount     = 1;

        private static readonly ManagerOptions _logManagerOptions = new(PointerBufferSize, MaxDomains, MaxDomainObjects, false);

        private SmApi         _sm;
>>>>>>> 1ec71635b (sync with main branch)
        private ServerManager _serverManager;

        public void Initialize()
        {
            HeapAllocator allocator = new();

            _sm = new SmApi();
            _sm.Initialize().AbortOnFailure();

<<<<<<< HEAD
            _serverManager = new ServerManager(allocator, _sm, MaxPortsCount, _managerOptions, MaxSessionsCount);

            _serverManager.RegisterObjectForServer(new LogService(), ServiceName.Encode("lm"), MaxSessionsCount);
=======
            _serverManager = new ServerManager(allocator, _sm, MaxPortsCount, _logManagerOptions, LogMaxSessionsCount);

            _serverManager.RegisterObjectForServer(new LogService(), ServiceName.Encode("lm"), LogMaxSessionsCount);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void ServiceRequests()
        {
            _serverManager.ServiceRequests();
        }

        public void Shutdown()
        {
            _serverManager.Dispose();
<<<<<<< HEAD
            _sm.Dispose();
        }
    }
}
=======
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
