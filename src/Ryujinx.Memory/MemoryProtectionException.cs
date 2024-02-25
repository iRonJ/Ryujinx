<<<<<<< HEAD
using System;
using System.Runtime.InteropServices;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Memory
{
    class MemoryProtectionException : Exception
    {
        public MemoryProtectionException()
        {
        }

<<<<<<< HEAD
        public MemoryProtectionException(MemoryPermission permission) : base($"Failed to set memory protection to \"{permission}\": {Marshal.GetLastPInvokeErrorMessage()}")
=======
        public MemoryProtectionException(MemoryPermission permission) : base($"Failed to set memory protection to \"{permission}\".")
>>>>>>> 1ec71635b (sync with main branch)
        {
        }

        public MemoryProtectionException(string message) : base(message)
        {
        }

        public MemoryProtectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
