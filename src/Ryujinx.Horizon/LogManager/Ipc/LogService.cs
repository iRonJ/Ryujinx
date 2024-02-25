<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Lm;
using Ryujinx.Horizon.Sdk.Sf;

namespace Ryujinx.Horizon.LogManager.Ipc
{
    partial class LogService : ILogService
    {
        public LogDestination LogDestination { get; set; } = LogDestination.TargetManager;

        [CmifCommand(0)]
        public Result OpenLogger(out LmLogger logger, [ClientProcessId] ulong pid)
        {
<<<<<<< HEAD
            // NOTE: Internal name is Logger, but we rename it to LmLogger to avoid name clash with Ryujinx.Common.Logging logger.
=======
            // NOTE: Internal name is Logger, but we rename it LmLogger to avoid name clash with Ryujinx.Common.Logging logger.
>>>>>>> 1ec71635b (sync with main branch)
            logger = new LmLogger(this, pid);

            return Result.Success;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
