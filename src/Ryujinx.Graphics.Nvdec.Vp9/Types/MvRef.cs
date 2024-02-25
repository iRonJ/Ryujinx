<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    internal struct MvRef
    {
        public Array2<Mv> Mv;
        public Array2<sbyte> RefFrame;
    }
}
