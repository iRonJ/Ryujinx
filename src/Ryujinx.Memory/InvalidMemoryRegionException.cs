<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Memory
{
    public class InvalidMemoryRegionException : Exception
    {
        public InvalidMemoryRegionException() : base("Attempted to access an invalid memory region.")
        {
        }

        public InvalidMemoryRegionException(string message) : base(message)
        {
        }

        public InvalidMemoryRegionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
