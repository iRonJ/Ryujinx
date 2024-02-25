<<<<<<< HEAD
namespace Ryujinx.Graphics.Gpu.Engine.Types
=======
﻿namespace Ryujinx.Graphics.Gpu.Engine.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Split GPU virtual address.
    /// </summary>
    struct GpuVa
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public uint High;
        public uint Low;
#pragma warning restore CS0649

        /// <summary>
        /// Packs the split address into a 64-bits address value.
        /// </summary>
        /// <returns>The 64-bits address value</returns>
<<<<<<< HEAD
        public readonly ulong Pack()
=======
        public ulong Pack()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Low | ((ulong)High << 32);
        }
    }
}
