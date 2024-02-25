<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Prepo
{
    static class PrepoResult
    {
        private const int ModuleId = 129;

<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
=======
>>>>>>> 1ec71635b (sync with main branch)
        public static Result InvalidArgument   => new(ModuleId, 1);
        public static Result InvalidState      => new(ModuleId, 5);
        public static Result InvalidBufferSize => new(ModuleId, 9);
        public static Result PermissionDenied  => new(ModuleId, 90);
        public static Result InvalidPid        => new(ModuleId, 101);
<<<<<<< HEAD
#pragma warning restore IDE0055
    }
}
=======
    }
}
>>>>>>> 1ec71635b (sync with main branch)
