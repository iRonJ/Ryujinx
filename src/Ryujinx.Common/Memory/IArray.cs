<<<<<<< HEAD
namespace Ryujinx.Common.Memory
=======
﻿namespace Ryujinx.Common.Memory
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Array interface.
    /// </summary>
    /// <typeparam name="T">Element type</typeparam>
    public interface IArray<T> where T : unmanaged
    {
        /// <summary>
        /// Used to index the array.
        /// </summary>
        /// <param name="index">Element index</param>
        /// <returns>Element at the specified index</returns>
        ref T this[int index] { get; }

        /// <summary>
        /// Number of elements on the array.
        /// </summary>
        int Length { get; }
    }
}
