using Ryujinx.HLE.HOS.Kernel.Memory;

namespace Ryujinx.HLE.HOS.Kernel.Ipc
{
    class KBufferDescriptor
    {
<<<<<<< HEAD
        public ulong ClientAddress { get; }
        public ulong ServerAddress { get; }
        public ulong Size { get; }
        public MemoryState State { get; }
=======
        public ulong       ClientAddress { get; }
        public ulong       ServerAddress { get; }
        public ulong       Size          { get; }
        public MemoryState State         { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public KBufferDescriptor(ulong src, ulong dst, ulong size, MemoryState state)
        {
            ClientAddress = src;
            ServerAddress = dst;
<<<<<<< HEAD
            Size = size;
            State = state;
        }
    }
}
=======
            Size          = size;
            State         = state;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
