<<<<<<< HEAD
namespace Ryujinx.Graphics.Nvdec.Vp9.Types
=======
﻿namespace Ryujinx.Graphics.Nvdec.Vp9.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    internal enum MvJointType
    {
        MvJointZero = 0,   /* Zero vector */
        MvJointHnzvz = 1,  /* Vert zero, hor nonzero */
        MvJointHzvnz = 2,  /* Hor zero, vert nonzero */
        MvJointHnzvnz = 3, /* Both components nonzero */
    }
}
