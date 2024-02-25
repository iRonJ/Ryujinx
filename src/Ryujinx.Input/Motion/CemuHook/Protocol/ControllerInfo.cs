<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.Input.Motion.CemuHook.Protocol
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerInfoResponse
    {
        public SharedResponse Shared;
<<<<<<< HEAD
        private readonly byte _zero;
=======
        private byte _zero;
>>>>>>> 1ec71635b (sync with main branch)
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerInfoRequest
    {
        public MessageType Type;
        public int PortsCount;
        public Array4<byte> PortIndices;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
