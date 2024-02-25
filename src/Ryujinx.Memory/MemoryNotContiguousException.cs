<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Memory
{
    public class MemoryNotContiguousException : Exception
    {
        public MemoryNotContiguousException() : base("The specified memory region is not contiguous.")
        {
        }

        public MemoryNotContiguousException(string message) : base(message)
        {
        }

        public MemoryNotContiguousException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
