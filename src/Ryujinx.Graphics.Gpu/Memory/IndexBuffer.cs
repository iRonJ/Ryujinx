using Ryujinx.Graphics.GAL;
<<<<<<< HEAD
using Ryujinx.Memory.Range;
=======
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Gpu.Memory
{
    /// <summary>
    /// GPU Index Buffer information.
    /// </summary>
    struct IndexBuffer
    {
<<<<<<< HEAD
        public MultiRange Range;
        public IndexType Type;
    }
}
=======
        public ulong Address;
        public ulong Size;

        public IndexType Type;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
