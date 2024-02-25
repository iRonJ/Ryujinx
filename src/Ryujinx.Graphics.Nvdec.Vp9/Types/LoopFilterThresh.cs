<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Nvdec.Vp9.Types
{
    // Need to align this structure so when it is declared and
    // passed it can be loaded into vector registers.
    internal struct LoopFilterThresh
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public Array16<byte> Mblim;
        public Array16<byte> Lim;
        public Array16<byte> HevThr;
#pragma warning restore CS0649
    }
}
