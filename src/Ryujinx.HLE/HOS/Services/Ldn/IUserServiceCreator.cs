<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Ldn.UserServiceCreator;
=======
﻿using Ryujinx.HLE.HOS.Services.Ldn.UserServiceCreator;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Ldn
{
    [Service("ldn:u")]
    class IUserServiceCreator : IpcService
    {
<<<<<<< HEAD
        public IUserServiceCreator(ServiceCtx context) : base(context.Device.System.LdnServer) { }
=======
        public IUserServiceCreator(ServiceCtx context) { }
>>>>>>> 1ec71635b (sync with main branch)

        [CommandCmif(0)]
        // CreateUserLocalCommunicationService() -> object<nn::ldn::detail::IUserLocalCommunicationService>
        public ResultCode CreateUserLocalCommunicationService(ServiceCtx context)
        {
            MakeObject(context, new IUserLocalCommunicationService(context));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
