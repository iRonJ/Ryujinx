using System;

namespace Ryujinx.Graphics.Shader.Translation
{
    [Flags]
    public enum TranslationFlags
    {
        None = 0,

<<<<<<< HEAD
        VertexA = 1 << 0,
        Compute = 1 << 1,
        DebugMode = 1 << 2,
    }
}
=======
        VertexA   = 1 << 0,
        Compute   = 1 << 1,
        DebugMode = 1 << 2
    }
}
>>>>>>> 1ec71635b (sync with main branch)
