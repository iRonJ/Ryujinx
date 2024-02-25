<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Memory;
using System;

namespace Ryujinx.Horizon
{
<<<<<<< HEAD
    public static class HorizonStatic
=======
    static class HorizonStatic
>>>>>>> 1ec71635b (sync with main branch)
    {
        [ThreadStatic]
        private static HorizonOptions _options;

        [ThreadStatic]
        private static ISyscallApi _syscall;

        [ThreadStatic]
        private static IVirtualMemoryManager _addressSpace;

        [ThreadStatic]
        private static IThreadContext _threadContext;

        [ThreadStatic]
        private static int _threadHandle;

<<<<<<< HEAD
        public static HorizonOptions Options => _options;
        public static ISyscallApi Syscall => _syscall;
        public static IVirtualMemoryManager AddressSpace => _addressSpace;
        public static IThreadContext ThreadContext => _threadContext;
        public static int CurrentThreadHandle => _threadHandle;

        public static void Register(
            HorizonOptions options,
            ISyscallApi syscallApi,
            IVirtualMemoryManager addressSpace,
            IThreadContext threadContext,
            int threadHandle)
        {
            _options = options;
            _syscall = syscallApi;
            _addressSpace = addressSpace;
            _threadContext = threadContext;
            _threadHandle = threadHandle;
=======
        public static HorizonOptions        Options             => _options;
        public static ISyscallApi           Syscall             => _syscall;
        public static IVirtualMemoryManager AddressSpace        => _addressSpace;
        public static IThreadContext        ThreadContext       => _threadContext;
        public static int                   CurrentThreadHandle => _threadHandle;

        public static void Register(
            HorizonOptions        options,
            ISyscallApi           syscallApi,
            IVirtualMemoryManager addressSpace,
            IThreadContext        threadContext,
            int                   threadHandle)
        {
            _options       = options;
            _syscall       = syscallApi;
            _addressSpace  = addressSpace;
            _threadContext = threadContext;
            _threadHandle  = threadHandle;
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
