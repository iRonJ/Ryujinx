<<<<<<< HEAD
namespace Ryujinx.Graphics.Gpu.Image
=======
﻿namespace Ryujinx.Graphics.Gpu.Image
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// The level of view compatibility one texture has to another. 
    /// Values are increasing in compatibility from 0 (incompatible).
    /// </summary>
    enum TextureViewCompatibility
    {
        Incompatible = 0,
        LayoutIncompatible,
        CopyOnly,
        FormatAlias,
<<<<<<< HEAD
        Full,
=======
        Full
>>>>>>> 1ec71635b (sync with main branch)
    }
}
