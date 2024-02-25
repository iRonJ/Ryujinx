<<<<<<< HEAD
namespace Ryujinx.Graphics.Gpu.Engine.Types
=======
﻿namespace Ryujinx.Graphics.Gpu.Engine.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Memory layout parameters, for block linear textures.
    /// </summary>
    struct MemoryLayout
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
        public uint Packed;
#pragma warning restore CS0649

        public readonly int UnpackGobBlocksInX()
=======
#pragma warning disable CS0649
        public uint Packed;
#pragma warning restore CS0649

        public int UnpackGobBlocksInX()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 1 << (int)(Packed & 0xf);
        }

<<<<<<< HEAD
        public readonly int UnpackGobBlocksInY()
=======
        public int UnpackGobBlocksInY()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 1 << (int)((Packed >> 4) & 0xf);
        }

<<<<<<< HEAD
        public readonly int UnpackGobBlocksInZ()
=======
        public int UnpackGobBlocksInZ()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 1 << (int)((Packed >> 8) & 0xf);
        }

<<<<<<< HEAD
        public readonly bool UnpackIsLinear()
=======
        public bool UnpackIsLinear()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (Packed & 0x1000) != 0;
        }

<<<<<<< HEAD
        public readonly bool UnpackIsTarget3D()
=======
        public bool UnpackIsTarget3D()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (Packed & 0x10000) != 0;
        }
    }
}
