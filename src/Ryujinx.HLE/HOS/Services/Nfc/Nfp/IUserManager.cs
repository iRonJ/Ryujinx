<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager;
=======
﻿using Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp
{
    [Service("nfp:user")]
    class IUserManager : IpcService
    {
        public IUserManager(ServiceCtx context) { }

        [CommandCmif(0)]
        // CreateUserInterface() -> object<nn::nfp::detail::IUser>
        public ResultCode CreateUserInterface(ServiceCtx context)
        {
            MakeObject(context, new INfp(NfpPermissionLevel.User));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
