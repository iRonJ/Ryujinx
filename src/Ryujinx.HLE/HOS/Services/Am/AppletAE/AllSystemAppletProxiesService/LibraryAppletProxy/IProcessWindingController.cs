<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Am.AppletAE.AllSystemAppletProxiesService.LibraryAppletProxy
{
    class IProcessWindingController : IpcService
    {
        public IProcessWindingController() { }

        [CommandCmif(0)]
        // GetLaunchReason() -> nn::am::service::AppletProcessLaunchReason
        public ResultCode GetLaunchReason(ServiceCtx context)
        {
            // NOTE: Flag is set by using an internal field.
<<<<<<< HEAD
            AppletProcessLaunchReason appletProcessLaunchReason = new()
            {
                Flag = 0,
=======
            AppletProcessLaunchReason appletProcessLaunchReason = new AppletProcessLaunchReason()
            {
                Flag = 0
>>>>>>> 1ec71635b (sync with main branch)
            };

            context.ResponseData.WriteStruct(appletProcessLaunchReason);

            return ResultCode.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
