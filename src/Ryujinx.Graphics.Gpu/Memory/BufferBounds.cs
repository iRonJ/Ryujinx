using Ryujinx.Graphics.Shader;
<<<<<<< HEAD
using Ryujinx.Memory.Range;
=======
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Gpu.Memory
{
    /// <summary>
    /// Memory range used for buffers.
    /// </summary>
    readonly struct BufferBounds
    {
        /// <summary>
<<<<<<< HEAD
        /// Physical memory ranges where the buffer is mapped.
        /// </summary>
        public MultiRange Range { get; }
=======
        /// Region virtual address.
        /// </summary>
        public ulong Address { get; }

        /// <summary>
        /// Region size in bytes.
        /// </summary>
        public ulong Size { get; }
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Buffer usage flags.
        /// </summary>
        public BufferUsageFlags Flags { get; }

        /// <summary>
<<<<<<< HEAD
        /// Indicates that the backing memory for the buffer does not exist.
        /// </summary>
        public bool IsUnmapped => Range.IsUnmapped;

        /// <summary>
        /// Creates a new buffer region.
        /// </summary>
        /// <param name="range">Physical memory ranges where the buffer is mapped</param>
        /// <param name="flags">Buffer usage flags</param>
        public BufferBounds(MultiRange range, BufferUsageFlags flags = BufferUsageFlags.None)
        {
            Range = range;
            Flags = flags;
        }
    }
}
=======
        /// Creates a new buffer region.
        /// </summary>
        /// <param name="address">Region address</param>
        /// <param name="size">Region size</param>
        /// <param name="flags">Buffer usage flags</param>
        public BufferBounds(ulong address, ulong size, BufferUsageFlags flags = BufferUsageFlags.None)
        {
            Address = address;
            Size = size;
            Flags = flags;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
