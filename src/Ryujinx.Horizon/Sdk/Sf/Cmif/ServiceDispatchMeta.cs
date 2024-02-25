<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    readonly struct ServiceDispatchMeta
=======
﻿namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    struct ServiceDispatchMeta
>>>>>>> 1ec71635b (sync with main branch)
    {
        public ServiceDispatchTableBase DispatchTable { get; }

        public ServiceDispatchMeta(ServiceDispatchTableBase dispatchTable)
        {
            DispatchTable = dispatchTable;
        }
    }
}
