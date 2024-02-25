<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Shader
{
    /// <summary>
    /// Flags that indicate how a buffer will be used in a shader.
    /// </summary>
    [Flags]
    public enum BufferUsageFlags : byte
    {
        None = 0,

        /// <summary>
        /// Buffer is written to.
        /// </summary>
<<<<<<< HEAD
        Write = 1 << 0,
=======
        Write = 1 << 0
>>>>>>> 1ec71635b (sync with main branch)
    }
}
