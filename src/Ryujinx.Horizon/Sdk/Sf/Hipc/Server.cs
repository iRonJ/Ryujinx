<<<<<<< HEAD
using Ryujinx.Horizon.Sdk.OsTypes;
=======
﻿using Ryujinx.Horizon.Sdk.OsTypes;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Sf.Cmif;
using Ryujinx.Horizon.Sdk.Sm;

namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    class Server : MultiWaitHolderOfHandle
    {
<<<<<<< HEAD
        public int PortIndex { get; }
        public int PortHandle { get; }
        public ServiceName Name { get; }
        public bool Managed { get; }
        public ServiceObjectHolder StaticObject { get; }

        public Server(
            int portIndex,
            int portHandle,
            ServiceName name,
            bool managed,
            ServiceObjectHolder staticHoder) : base(portHandle)
        {
            PortHandle = portHandle;
            Name = name;
            Managed = managed;
=======
        public int                 PortIndex    { get; }
        public int                 PortHandle   { get; }
        public ServiceName         Name         { get; }
        public bool                Managed      { get; }
        public ServiceObjectHolder StaticObject { get; }

        public Server(
            int                 portIndex,
            int                 portHandle,
            ServiceName         name,
            bool                managed,
            ServiceObjectHolder staticHoder) : base(portHandle)
        {
            PortHandle = portHandle;
            Name       = name;
            Managed    = managed;
>>>>>>> 1ec71635b (sync with main branch)

            if (staticHoder != null)
            {
                StaticObject = staticHoder;
            }
            else
            {
                PortIndex = portIndex;
            }
        }
    }
}
