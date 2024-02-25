<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Services.Nim.ShopServiceAccessServerInterface.ShopServiceAccessServer;

namespace Ryujinx.HLE.HOS.Services.Nim.ShopServiceAccessServerInterface
{
    class IShopServiceAccessServer : IpcService
    {
        public IShopServiceAccessServer() { }

        [CommandCmif(0)]
        // CreateAccessorInterface(u8) -> object<nn::ec::IShopServiceAccessor>
        public ResultCode CreateAccessorInterface(ServiceCtx context)
        {
            MakeObject(context, new IShopServiceAccessor(context.Device.System));

            Logger.Stub?.PrintStub(LogClass.ServiceNim);

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
