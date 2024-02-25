<<<<<<< HEAD
namespace Ryujinx.Horizon.LogManager
=======
﻿namespace Ryujinx.Horizon.LogManager
>>>>>>> 1ec71635b (sync with main branch)
{
    class LmMain : IService
    {
        public static void Main(ServiceTable serviceTable)
        {
            LmIpcServer ipcServer = new();

            ipcServer.Initialize();

            serviceTable.SignalServiceReady();

            ipcServer.ServiceRequests();
            ipcServer.Shutdown();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
