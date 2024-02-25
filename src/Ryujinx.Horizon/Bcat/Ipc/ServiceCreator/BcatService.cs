<<<<<<< HEAD
using Ryujinx.Horizon.Bcat.Types;
=======
﻿using Ryujinx.Horizon.Bcat.Types;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Common;
using Ryujinx.Horizon.Sdk.Bcat;
using Ryujinx.Horizon.Sdk.Sf;

namespace Ryujinx.Horizon.Bcat.Ipc
{
    partial class BcatService : IBcatService
    {
<<<<<<< HEAD
        public BcatService(BcatServicePermissionLevel permissionLevel) { }
=======
        private readonly BcatServicePermissionLevel _permissionLevel;

        public BcatService(BcatServicePermissionLevel permissionLevel)
        {
            _permissionLevel = permissionLevel;
        }
>>>>>>> 1ec71635b (sync with main branch)

        [CmifCommand(10100)]
        public Result RequestSyncDeliveryCache(out IDeliveryCacheProgressService deliveryCacheProgressService)
        {
            deliveryCacheProgressService = new DeliveryCacheProgressService();

            return Result.Success;
        }
    }
}
