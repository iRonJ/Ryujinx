<<<<<<< HEAD
using Ryujinx.Horizon.Common;
=======
﻿using Ryujinx.Horizon.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;

namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    class ServiceDispatchTable : ServiceDispatchTableBase
    {
        private readonly string _objectName;
        private readonly IReadOnlyDictionary<int, CommandHandler> _entries;

        public ServiceDispatchTable(string objectName, IReadOnlyDictionary<int, CommandHandler> entries)
        {
            _objectName = objectName;
<<<<<<< HEAD
            _entries = entries;
=======
            _entries    = entries;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override Result ProcessMessage(ref ServiceDispatchContext context, ReadOnlySpan<byte> inRawData)
        {
            return ProcessMessageImpl(ref context, inRawData, _entries, _objectName);
        }

        public static ServiceDispatchTableBase Create(IServiceObject instance)
        {
            if (instance is DomainServiceObject)
            {
                return new DomainServiceObjectDispatchTable();
            }

            return new ServiceDispatchTable(instance.GetType().Name, instance.GetCommandHandlers());
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
