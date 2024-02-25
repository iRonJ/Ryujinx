<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.OsTypes
{
    static partial class Os
    {
        private const int SelfProcessHandle = (0x1ffff << 15) | 1;

        public static int GetCurrentProcessHandle()
        {
            return SelfProcessHandle;
        }

        public static ulong GetCurrentProcessId()
        {
            return GetProcessId(GetCurrentProcessHandle());
        }

        private static ulong GetProcessId(int handle)
        {
            Result result = TryGetProcessId(handle, out ulong pid);

            result.AbortOnFailure();

            return pid;
        }

        private static Result TryGetProcessId(int handle, out ulong pid)
        {
            return HorizonStatic.Syscall.GetProcessId(out pid, handle);
        }
    }
}
