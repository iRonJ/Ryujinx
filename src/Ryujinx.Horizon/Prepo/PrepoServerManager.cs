<<<<<<< HEAD
using Ryujinx.Horizon.Common;
using Ryujinx.Horizon.Prepo.Ipc;
using Ryujinx.Horizon.Prepo.Types;
using Ryujinx.Horizon.Sdk.Arp;
=======
﻿using Ryujinx.Horizon.Common;
using Ryujinx.Horizon.Prepo.Ipc;
using Ryujinx.Horizon.Prepo.Types;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Sf.Hipc;
using Ryujinx.Horizon.Sdk.Sm;
using System;

namespace Ryujinx.Horizon.Prepo
{
    class PrepoServerManager : ServerManager
    {
<<<<<<< HEAD
        private readonly ArpApi _arp;

        public PrepoServerManager(HeapAllocator allocator, SmApi sm, ArpApi arp, int maxPorts, ManagerOptions options, int maxSessions) : base(allocator, sm, maxPorts, options, maxSessions)
        {
            _arp = arp;
=======
        public PrepoServerManager(HeapAllocator allocator, SmApi sm, int maxPorts, ManagerOptions options, int maxSessions) : base(allocator, sm, maxPorts, options, maxSessions)
        {
>>>>>>> 1ec71635b (sync with main branch)
        }

        protected override Result OnNeedsToAccept(int portIndex, Server server)
        {
            return (PrepoPortIndex)portIndex switch
            {
<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
                PrepoPortIndex.Admin   => AcceptImpl(server, new PrepoService(_arp, PrepoServicePermissionLevel.Admin)),
                PrepoPortIndex.Admin2  => AcceptImpl(server, new PrepoService(_arp, PrepoServicePermissionLevel.Admin)),
                PrepoPortIndex.Manager => AcceptImpl(server, new PrepoService(_arp, PrepoServicePermissionLevel.Manager)),
                PrepoPortIndex.User    => AcceptImpl(server, new PrepoService(_arp, PrepoServicePermissionLevel.User)),
                PrepoPortIndex.System  => AcceptImpl(server, new PrepoService(_arp, PrepoServicePermissionLevel.System)),
                PrepoPortIndex.Debug   => AcceptImpl(server, new PrepoService(_arp, PrepoServicePermissionLevel.Debug)),
                _                      => throw new ArgumentOutOfRangeException(nameof(portIndex)),
#pragma warning restore IDE0055
            };
        }
    }
}
=======
                PrepoPortIndex.Admin   => AcceptImpl(server, new PrepoService(PrepoServicePermissionLevel.Admin)),
                PrepoPortIndex.Admin2  => AcceptImpl(server, new PrepoService(PrepoServicePermissionLevel.Admin)),
                PrepoPortIndex.Manager => AcceptImpl(server, new PrepoService(PrepoServicePermissionLevel.Manager)),
                PrepoPortIndex.User    => AcceptImpl(server, new PrepoService(PrepoServicePermissionLevel.User)),
                PrepoPortIndex.System  => AcceptImpl(server, new PrepoService(PrepoServicePermissionLevel.System)),
                PrepoPortIndex.Debug   => AcceptImpl(server, new PrepoService(PrepoServicePermissionLevel.Debug)),
                _                      => throw new ArgumentOutOfRangeException(nameof(portIndex)),
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
