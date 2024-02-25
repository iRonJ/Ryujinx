<<<<<<< HEAD
using Ryujinx.Memory.Range;

=======
>>>>>>> 1ec71635b (sync with main branch)
namespace Ryujinx.Graphics.Gpu.Memory
{
    /// <summary>
    /// GPU Vertex Buffer information.
    /// </summary>
    struct VertexBuffer
    {
<<<<<<< HEAD
        public MultiRange Range;
        public int Stride;
        public int Divisor;
    }
}
=======
        public ulong Address;
        public ulong Size;
        public int   Stride;
        public int   Divisor;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
