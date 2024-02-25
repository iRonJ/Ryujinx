<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Ngct
=======
﻿namespace Ryujinx.HLE.HOS.Services.Ngct
>>>>>>> 1ec71635b (sync with main branch)
{
    [Service("ngct:s")] // 9.0.0+
    class IServiceWithManagementApi : IpcService
    {
        public IServiceWithManagementApi(ServiceCtx context) { }

        [CommandCmif(0)]
        // Match(buffer<string, 9>) -> b8
        public ResultCode Match(ServiceCtx context)
        {
            return NgctServer.Match(context);
        }

        [CommandCmif(1)]
        // Filter(buffer<string, 9>) -> buffer<filtered_string, 10>
        public ResultCode Filter(ServiceCtx context)
        {
            return NgctServer.Filter(context);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
