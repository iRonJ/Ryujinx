<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Sf;
using Ryujinx.Horizon.Sdk.Sm;
using Ryujinx.Horizon.Sm.Impl;

namespace Ryujinx.Horizon.Sm.Ipc
{
    partial class UserService : IUserService
    {
        private readonly ServiceManager _serviceManager;

        private ulong _clientProcessId;
<<<<<<< HEAD
        private bool _initialized;
=======
        private bool  _initialized;
>>>>>>> 1ec71635b (sync with main branch)

        public UserService(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [CmifCommand(0)]
        public Result Initialize([ClientProcessId] ulong clientProcessId)
        {
            _clientProcessId = clientProcessId;
<<<<<<< HEAD
            _initialized = true;
=======
            _initialized     = true;
>>>>>>> 1ec71635b (sync with main branch)

            return Result.Success;
        }

        [CmifCommand(1)]
        public Result GetService([MoveHandle] out int handle, ServiceName name)
        {
            if (!_initialized)
            {
                handle = 0;

                return SmResult.InvalidClient;
            }

            return _serviceManager.GetService(out handle, _clientProcessId, name);
        }

        [CmifCommand(2)]
        public Result RegisterService([MoveHandle] out int handle, ServiceName name, int maxSessions, bool isLight)
        {
            if (!_initialized)
            {
                handle = 0;

                return SmResult.InvalidClient;
            }

            return _serviceManager.RegisterService(out handle, _clientProcessId, name, maxSessions, isLight);
        }

        [CmifCommand(3)]
        public Result UnregisterService(ServiceName name)
        {
            if (!_initialized)
            {
                return SmResult.InvalidClient;
            }

            return _serviceManager.UnregisterService(_clientProcessId, name);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
