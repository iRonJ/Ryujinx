<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    internal struct LoopFilterInfoN
    {
        public Array64<LoopFilterThresh> Lfthr;
        public Array8<Array4<Array2<byte>>> Lvl;
    }
}
