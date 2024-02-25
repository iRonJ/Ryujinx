<<<<<<< HEAD
using Ryujinx.Cpu;
=======
﻿using Ryujinx.Cpu;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Memory;
using System;

namespace Ryujinx.HLE.HOS.Kernel.Process
{
    interface IProcessContext : IDisposable
    {
        IVirtualMemoryManager AddressSpace { get; }

<<<<<<< HEAD
        ulong AddressSpaceSize { get; }

=======
>>>>>>> 1ec71635b (sync with main branch)
        IExecutionContext CreateExecutionContext(ExceptionCallbacks exceptionCallbacks);
        void Execute(IExecutionContext context, ulong codeAddress);
        void InvalidateCacheRegion(ulong address, ulong size);
    }
}
