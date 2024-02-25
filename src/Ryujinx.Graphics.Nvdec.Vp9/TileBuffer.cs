<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Nvdec.Vp9
{
    internal struct TileBuffer
    {
        public int Col;
        public ArrayPtr<byte> Data;
        public int Size;
    }
}
