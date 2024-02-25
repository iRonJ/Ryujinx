<<<<<<< HEAD
namespace Ryujinx.Horizon.Prepo
=======
﻿namespace Ryujinx.Horizon.Prepo
>>>>>>> 1ec71635b (sync with main branch)
{
    class PrepoMain : IService
    {
        public static void Main(ServiceTable serviceTable)
        {
            PrepoIpcServer ipcServer = new();

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
