<<<<<<< HEAD
using Ryujinx.HLE.HOS.Kernel.Memory;
=======
﻿using Ryujinx.HLE.HOS.Kernel.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Kernel.Process;
using Ryujinx.HLE.HOS.Kernel.Threading;
using Ryujinx.Horizon.Common;
using System;
using System.Threading;

namespace Ryujinx.HLE.HOS.Kernel
{
    static class KernelStatic
    {
        [ThreadStatic]
<<<<<<< HEAD
        private static KernelContext _context;

        [ThreadStatic]
        private static KThread _currentThread;
=======
        private static KernelContext Context;

        [ThreadStatic]
        private static KThread CurrentThread;
>>>>>>> 1ec71635b (sync with main branch)

        public static Result StartInitialProcess(
            KernelContext context,
            ProcessCreationInfo creationInfo,
            ReadOnlySpan<uint> capabilities,
            int mainThreadPriority,
            ThreadStart customThreadStart)
        {
<<<<<<< HEAD
            KProcess process = new(context);
=======
            KProcess process = new KProcess(context);
>>>>>>> 1ec71635b (sync with main branch)

            Result result = process.Initialize(
                creationInfo,
                capabilities,
                context.ResourceLimit,
                MemoryRegion.Service,
                null,
                customThreadStart);

            if (result != Result.Success)
            {
                return result;
            }

            process.DefaultCpuCore = 3;

            context.Processes.TryAdd(process.Pid, process);

            return process.Start(mainThreadPriority, 0x1000UL);
        }

        internal static void SetKernelContext(KernelContext context, KThread thread)
        {
<<<<<<< HEAD
            _context = context;
            _currentThread = thread;
=======
            Context = context;
            CurrentThread = thread;
>>>>>>> 1ec71635b (sync with main branch)
        }

        internal static KThread GetCurrentThread()
        {
<<<<<<< HEAD
            return _currentThread;
=======
            return CurrentThread;
>>>>>>> 1ec71635b (sync with main branch)
        }

        internal static KProcess GetCurrentProcess()
        {
            return GetCurrentThread().Owner;
        }

        internal static KProcess GetProcessByPid(ulong pid)
        {
<<<<<<< HEAD
            if (_context.Processes.TryGetValue(pid, out KProcess process))
=======
            if (Context.Processes.TryGetValue(pid, out KProcess process))
>>>>>>> 1ec71635b (sync with main branch)
            {
                return process;
            }

            return null;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
