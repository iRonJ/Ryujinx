<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nfc.NfcManager;
=======
﻿using Ryujinx.HLE.HOS.Services.Nfc.NfcManager;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nfc
{
    [Service("nfc:user")]
    class IUserManager : IpcService
    {
        public IUserManager(ServiceCtx context) { }

        [CommandCmif(0)]
        // CreateUserInterface() -> object<nn::nfc::detail::IUser>
        public ResultCode CreateUserInterface(ServiceCtx context)
        {
            MakeObject(context, new INfc(NfcPermissionLevel.User));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
