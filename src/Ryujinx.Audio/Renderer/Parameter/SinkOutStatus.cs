using System.Runtime.InteropServices;

namespace Ryujinx.Audio.Renderer.Parameter
{
    /// <summary>
    /// Output information for a sink.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SinkOutStatus
    {
        /// <summary>
        /// Last written offset if the sink type is <see cref="Common.SinkType.CircularBuffer"/>.
        /// </summary>
        public uint LastWrittenOffset;

        /// <summary>
        /// Reserved/padding.
        /// </summary>
<<<<<<< HEAD
        private readonly uint _padding;
=======
        private uint _padding;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Reserved/padding.
        /// </summary>
        private unsafe fixed ulong _reserved[3];
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
