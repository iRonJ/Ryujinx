<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Nvdec.Types.H264
{
    struct ReferenceFrame
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public uint Flags;
        public Array2<uint> FieldOrderCnt;
        public uint FrameNum;
#pragma warning restore CS0649

<<<<<<< HEAD
        public readonly uint OutputSurfaceIndex => (uint)Flags & 0x7f;
=======
        public uint OutputSurfaceIndex => (uint)Flags & 0x7f;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
