<<<<<<< HEAD
namespace Ryujinx.Graphics.Gpu.Image
=======
﻿namespace Ryujinx.Graphics.Gpu.Image
>>>>>>> 1ec71635b (sync with main branch)
{
    interface ITextureDescriptor
    {
        public uint UnpackFormat();
        public TextureTarget UnpackTextureTarget();
        public bool UnpackSrgb();
        public bool UnpackTextureCoordNormalized();
    }
}
