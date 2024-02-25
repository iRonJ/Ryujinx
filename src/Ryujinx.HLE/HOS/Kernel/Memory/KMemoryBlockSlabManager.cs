namespace Ryujinx.HLE.HOS.Kernel.Memory
{
    class KMemoryBlockSlabManager
    {
<<<<<<< HEAD
        private readonly ulong _capacityElements;
=======
        private ulong _capacityElements;
>>>>>>> 1ec71635b (sync with main branch)

        public int Count { get; set; }

        public KMemoryBlockSlabManager(ulong capacityElements)
        {
            _capacityElements = capacityElements;
        }

        public bool CanAllocate(int count)
        {
            return (ulong)(Count + count) <= _capacityElements;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
