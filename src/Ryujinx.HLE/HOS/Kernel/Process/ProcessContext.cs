<<<<<<< HEAD
using Ryujinx.Cpu;
=======
﻿using Ryujinx.Cpu;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Memory;
using System;

namespace Ryujinx.HLE.HOS.Kernel.Process
{
    class ProcessContext : IProcessContext
    {
        public IVirtualMemoryManager AddressSpace { get; }

<<<<<<< HEAD
        public ulong AddressSpaceSize { get; }

        public ProcessContext(IVirtualMemoryManager asManager, ulong addressSpaceSize)
        {
            AddressSpace = asManager;
            AddressSpaceSize = addressSpaceSize;
=======
        public ProcessContext(IVirtualMemoryManager asManager)
        {
            AddressSpace = asManager;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public IExecutionContext CreateExecutionContext(ExceptionCallbacks exceptionCallbacks)
        {
            return new ProcessExecutionContext();
        }

        public void Execute(IExecutionContext context, ulong codeAddress)
        {
            throw new NotSupportedException();
        }

        public void InvalidateCacheRegion(ulong address, ulong size)
        {
        }

        public void Dispose()
        {
        }
    }
}
