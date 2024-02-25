using System;

namespace Ryujinx.Memory
{
    /// <summary>
    /// Flags that indicate how the host memory should be mapped.
    /// </summary>
    [Flags]
    public enum MemoryMapFlags
    {
        /// <summary>
        /// No mapping flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that the implementation is free to ignore the specified backing memory offset
        /// and allocate its own private storage for the mapping.
        /// This allows some mappings that would otherwise fail due to host platform restrictions to succeed.
        /// </summary>
<<<<<<< HEAD
        Private = 1 << 0,
=======
        Private = 1 << 0
>>>>>>> 1ec71635b (sync with main branch)
    }
}
