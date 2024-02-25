<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nfc.NfcManager
{
    class INfc : IpcService
    {
<<<<<<< HEAD
        private readonly NfcPermissionLevel _permissionLevel;
=======
        private NfcPermissionLevel _permissionLevel;
>>>>>>> 1ec71635b (sync with main branch)
        private State _state;

        public INfc(NfcPermissionLevel permissionLevel)
        {
            _permissionLevel = permissionLevel;
            _state = State.NonInitialized;
        }

        [CommandCmif(0)]
        [CommandCmif(400)] // 4.0.0+
        // Initialize(u64, u64, pid, buffer<unknown, 5>)
        public ResultCode Initialize(ServiceCtx context)
        {
            _state = State.Initialized;

            Logger.Stub?.PrintStub(LogClass.ServiceNfc, new { _permissionLevel });

            return ResultCode.Success;
        }

        [CommandCmif(1)]
        [CommandCmif(401)] // 4.0.0+
        // Finalize()
        public ResultCode Finalize(ServiceCtx context)
        {
            _state = State.NonInitialized;

            Logger.Stub?.PrintStub(LogClass.ServiceNfc, new { _permissionLevel });

            return ResultCode.Success;
        }

        [CommandCmif(2)]
        [CommandCmif(402)] // 4.0.0+
        // GetState() -> u32
<<<<<<< HEAD
        public ResultCode GetState(ServiceCtx context)
=======
        public ResultCode GetState(ServiceCtx context) 
>>>>>>> 1ec71635b (sync with main branch)
        {
            context.ResponseData.Write((int)_state);

            return ResultCode.Success;
        }

        [CommandCmif(3)]
        [CommandCmif(403)] // 4.0.0+
        // IsNfcEnabled() -> b8
        public ResultCode IsNfcEnabled(ServiceCtx context)
        {
            // NOTE: Write false value here could make nfp service not called.
            context.ResponseData.Write(true);

            Logger.Stub?.PrintStub(LogClass.ServiceNfc, new { _permissionLevel });

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
