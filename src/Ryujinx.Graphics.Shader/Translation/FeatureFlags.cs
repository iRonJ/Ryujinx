<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Shader.Translation
{
    /// <summary>
    /// Features used by the shader that are important for the code generator to know in advance.
    /// These typically change the declarations in the shader header.
    /// </summary>
    [Flags]
    public enum FeatureFlags
    {
        None = 0,

        // Affected by resolution scaling.
<<<<<<< HEAD
        FragCoordXY = 1 << 1,
=======
        IntegerSampling = 1 << 0,
        FragCoordXY     = 1 << 1,
>>>>>>> 1ec71635b (sync with main branch)

        Bindless = 1 << 2,
        InstanceId = 1 << 3,
        DrawParameters = 1 << 4,
        RtLayer = 1 << 5,
<<<<<<< HEAD
        Shuffle = 1 << 6,
        ViewportIndex = 1 << 7,
        ViewportMask = 1 << 8,
        FixedFuncAttr = 1 << 9,
        LocalMemory = 1 << 10,
        SharedMemory = 1 << 11,
        Store = 1 << 12,
        VtgAsCompute = 1 << 13,
=======
        IaIndexing = 1 << 7,
        OaIndexing = 1 << 8,
        FixedFuncAttr = 1 << 9
>>>>>>> 1ec71635b (sync with main branch)
    }
}
