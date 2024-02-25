<<<<<<< HEAD
namespace Ryujinx.Graphics.Nvdec.Types.Vp9
=======
﻿namespace Ryujinx.Graphics.Nvdec.Types.Vp9
>>>>>>> 1ec71635b (sync with main branch)
{
    enum FrameFlags : uint
    {
        IsKeyFrame = 1 << 0,
        LastFrameIsKeyFrame = 1 << 1,
        FrameSizeChanged = 1 << 2,
        ErrorResilientMode = 1 << 3,
        LastShowFrame = 1 << 4,
<<<<<<< HEAD
        IntraOnly = 1 << 5,
=======
        IntraOnly = 1 << 5
>>>>>>> 1ec71635b (sync with main branch)
    }
}
