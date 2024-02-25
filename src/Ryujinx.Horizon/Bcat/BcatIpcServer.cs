<<<<<<< HEAD
=======
﻿using Ryujinx.Horizon.Bcat.Ipc;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Bcat.Types;
using Ryujinx.Horizon.Sdk.Sf.Hipc;
using Ryujinx.Horizon.Sdk.Sm;

namespace Ryujinx.Horizon.Bcat
{
    internal class BcatIpcServer
    {
<<<<<<< HEAD
        private const int MaxSessionsCount = 8;
        private const int TotalMaxSessionsCount = MaxSessionsCount * 4;
=======
        private const int BcatMaxSessionsCount = 8;
        private const int BcatTotalMaxSessionsCount = BcatMaxSessionsCount * 4; 
>>>>>>> 1ec71635b (sync with main branch)

        private const int PointerBufferSize = 0x400;
        private const int MaxDomains = 64;
        private const int MaxDomainObjects = 64;
        private const int MaxPortsCount = 4;

        private SmApi _sm;
        private BcatServerManager _serverManager;

<<<<<<< HEAD
        private static readonly ManagerOptions _managerOptions = new(PointerBufferSize, MaxDomains, MaxDomainObjects, false);
=======
        private static readonly ManagerOptions _bcatManagerOptions = new(PointerBufferSize, MaxDomains, MaxDomainObjects, false);
>>>>>>> 1ec71635b (sync with main branch)

        internal void Initialize()
        {
            HeapAllocator allocator = new();

            _sm = new SmApi();
            _sm.Initialize().AbortOnFailure();

<<<<<<< HEAD
            _serverManager = new BcatServerManager(allocator, _sm, MaxPortsCount, _managerOptions, TotalMaxSessionsCount);

#pragma warning disable IDE0055 // Disable formatting
            _serverManager.RegisterServer((int)BcatPortIndex.Admin,   ServiceName.Encode("bcat:a"), MaxSessionsCount);
            _serverManager.RegisterServer((int)BcatPortIndex.Manager, ServiceName.Encode("bcat:m"), MaxSessionsCount);
            _serverManager.RegisterServer((int)BcatPortIndex.User,    ServiceName.Encode("bcat:u"), MaxSessionsCount);
            _serverManager.RegisterServer((int)BcatPortIndex.System,  ServiceName.Encode("bcat:s"), MaxSessionsCount);
#pragma warning restore IDE0055
=======
            _serverManager = new BcatServerManager(allocator, _sm, MaxPortsCount, _bcatManagerOptions, BcatTotalMaxSessionsCount);

            _serverManager.RegisterServer((int)BcatPortIndex.Admin,   ServiceName.Encode("bcat:a"), BcatMaxSessionsCount);
            _serverManager.RegisterServer((int)BcatPortIndex.Manager, ServiceName.Encode("bcat:m"), BcatMaxSessionsCount);
            _serverManager.RegisterServer((int)BcatPortIndex.User,    ServiceName.Encode("bcat:u"), BcatMaxSessionsCount);
            _serverManager.RegisterServer((int)BcatPortIndex.System,  ServiceName.Encode("bcat:s"), BcatMaxSessionsCount);
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
=======
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
