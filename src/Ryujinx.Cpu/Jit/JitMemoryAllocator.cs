<<<<<<< HEAD
using ARMeilleure.Memory;
=======
﻿using ARMeilleure.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Memory;

namespace Ryujinx.Cpu.Jit
{
    public class JitMemoryAllocator : IJitMemoryAllocator
    {
<<<<<<< HEAD
        private readonly MemoryAllocationFlags _jitFlag;

        public JitMemoryAllocator(bool forJit = false)
        {
            _jitFlag = forJit ? MemoryAllocationFlags.Jit : MemoryAllocationFlags.None;
        }

        public IJitMemoryBlock Allocate(ulong size) => new JitMemoryBlock(size, MemoryAllocationFlags.None);
        public IJitMemoryBlock Reserve(ulong size) => new JitMemoryBlock(size, MemoryAllocationFlags.Reserve | _jitFlag);
=======
        public IJitMemoryBlock Allocate(ulong size) => new JitMemoryBlock(size, MemoryAllocationFlags.None);
        public IJitMemoryBlock Reserve(ulong size) => new JitMemoryBlock(size, MemoryAllocationFlags.Reserve | MemoryAllocationFlags.Jit);

        public ulong GetPageSize() => MemoryBlock.GetPageSize();
>>>>>>> 1ec71635b (sync with main branch)
    }
}
