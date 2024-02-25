<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Video
{
    // This must match the structure used by NVDEC, do not modify.
    public struct Vp9MvRef
    {
        public Array2<Vp9Mv> Mvs;
        public Array2<int> RefFrames;
    }
}
