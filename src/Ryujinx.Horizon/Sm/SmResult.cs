<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sm
{
    static class SmResult
    {
        private const int ModuleId = 21;

<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
=======
>>>>>>> 1ec71635b (sync with main branch)
        public static Result OutOfProcess          => new(ModuleId, 1);
        public static Result InvalidClient         => new(ModuleId, 2);
        public static Result OutOfSessions         => new(ModuleId, 3);
        public static Result AlreadyRegistered     => new(ModuleId, 4);
        public static Result OutOfServices         => new(ModuleId, 5);
        public static Result InvalidServiceName    => new(ModuleId, 6);
        public static Result NotRegistered         => new(ModuleId, 7);
        public static Result NotAllowed            => new(ModuleId, 8);
        public static Result TooLargeAccessControl => new(ModuleId, 9);
<<<<<<< HEAD
#pragma warning restore IDE0055
    }
}
=======
    }
}
>>>>>>> 1ec71635b (sync with main branch)
