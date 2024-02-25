<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager;
=======
﻿using Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp
{
    [Service("nfp:sys")]
    class ISystemManager : IpcService
    {
        public ISystemManager(ServiceCtx context) { }

        [CommandCmif(0)]
        // CreateSystemInterface() -> object<nn::nfp::detail::ISystem>
        public ResultCode CreateSystemInterface(ServiceCtx context)
        {
            MakeObject(context, new INfp(NfpPermissionLevel.System));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
