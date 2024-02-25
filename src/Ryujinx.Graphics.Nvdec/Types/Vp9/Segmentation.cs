<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Nvdec.Types.Vp9
{
    struct Segmentation
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public byte Enabled;
        public byte UpdateMap;
        public byte TemporalUpdate;
        public byte AbsDelta;
        public Array8<uint> FeatureMask;
        public Array8<Array4<short>> FeatureData;
#pragma warning restore CS0649
    }
}
