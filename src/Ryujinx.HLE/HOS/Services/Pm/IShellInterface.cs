<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Pm
=======
﻿namespace Ryujinx.HLE.HOS.Services.Pm
>>>>>>> 1ec71635b (sync with main branch)
{
    [Service("pm:shell")]
    class IShellInterface : IpcService
    {
        public IShellInterface(ServiceCtx context) { }

        [CommandCmif(6)]
        // GetApplicationPid() -> u64
        public ResultCode GetApplicationPid(ServiceCtx context)
        {
            // FIXME: This is wrong but needed to make hb loader works
            // TODO: Change this when we will have a way to process via a PM like interface.
            ulong pid = context.Process.Pid;

            context.ResponseData.Write(pid);

            return ResultCode.Success;
        }
    }
}
