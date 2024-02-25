<<<<<<< HEAD
namespace Ryujinx.Memory
=======
﻿namespace Ryujinx.Memory
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Function that handles a invalid memory access from the emulated CPU.
    /// </summary>
    /// <param name="va">Virtual address of the invalid region that is being accessed</param>
    /// <returns>True if the invalid access should be ignored, false otherwise</returns>
    public delegate bool InvalidAccessHandler(ulong va);
}
