<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Sf;

namespace Ryujinx.Horizon.Sdk.Sm
{
    interface IUserService : IServiceObject
    {
        Result Initialize(ulong clientProcessId);
        Result GetService(out int handle, ServiceName name);
        Result RegisterService(out int handle, ServiceName name, int maxSessions, bool isLight);
        Result UnregisterService(ServiceName name);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
