<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager;
=======
﻿using Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp
{
    [Service("nfp:dbg")]
    class IAmManager : IpcService
    {
        public IAmManager(ServiceCtx context) { }

        [CommandCmif(0)]
        // CreateDebugInterface() -> object<nn::nfp::detail::IDebug>
        public ResultCode CreateDebugInterface(ServiceCtx context)
        {
            MakeObject(context, new INfp(NfpPermissionLevel.Debug));

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
