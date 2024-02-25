<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vic.Types
{
    struct ConfigStruct
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public PipeConfig PipeConfig;
        public OutputConfig OutputConfig;
        public OutputSurfaceConfig OutputSurfaceConfig;
        public MatrixStruct OutColorMatrix;
        public Array4<ClearRectStruct> ClearRectStruct;
        public Array8<SlotStruct> SlotStruct;
#pragma warning restore CS0649
    }
}
