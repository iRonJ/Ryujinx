<<<<<<< HEAD
namespace Ryujinx.Graphics.Gpu.Engine.Types
=======
﻿namespace Ryujinx.Graphics.Gpu.Engine.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Storage buffer address and size information.
    /// </summary>
    struct SbDescriptor
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public uint AddressLow;
        public uint AddressHigh;
        public int Size;
        public int Padding;
#pragma warning restore CS0649

<<<<<<< HEAD
        public readonly ulong PackAddress()
=======
        public ulong PackAddress()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return AddressLow | ((ulong)AddressHigh << 32);
        }
    }
}
