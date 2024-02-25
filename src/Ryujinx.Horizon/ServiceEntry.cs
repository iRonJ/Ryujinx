using Ryujinx.Horizon.Common;
using Ryujinx.Memory;
using System;

namespace Ryujinx.Horizon
{
<<<<<<< HEAD
    public readonly struct ServiceEntry
    {
        private readonly Action<ServiceTable> _entrypoint;
        private readonly ServiceTable _serviceTable;
        private readonly HorizonOptions _options;

        internal ServiceEntry(Action<ServiceTable> entrypoint, ServiceTable serviceTable, HorizonOptions options)
        {
            _entrypoint = entrypoint;
            _serviceTable = serviceTable;
            _options = options;
=======
    public struct ServiceEntry
    {
        private readonly Action<ServiceTable> _entrypoint;
        private readonly ServiceTable         _serviceTable;
        private readonly HorizonOptions       _options;

        internal ServiceEntry(Action<ServiceTable> entrypoint, ServiceTable serviceTable, HorizonOptions options)
        {
            _entrypoint   = entrypoint;
            _serviceTable = serviceTable;
            _options      = options;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Start(ISyscallApi syscallApi, IVirtualMemoryManager addressSpace, IThreadContext threadContext)
        {
            HorizonStatic.Register(_options, syscallApi, addressSpace, threadContext, (int)threadContext.GetX(1));

            _entrypoint(_serviceTable);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
