<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Net;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x10)]
    struct BsdSockAddr
    {
        public byte Length;
        public byte Family;
        public ushort Port;
        public Array4<byte> Address;
        private Array8<byte> _reserved;

        public IPEndPoint ToIPEndPoint()
        {
<<<<<<< HEAD
            IPAddress address = new(Address.AsSpan());
=======
            IPAddress address = new IPAddress(Address.AsSpan());
>>>>>>> 1ec71635b (sync with main branch)
            int port = (ushort)IPAddress.NetworkToHostOrder((short)Port);

            return new IPEndPoint(address, port);
        }

        public static BsdSockAddr FromIPEndPoint(IPEndPoint endpoint)
        {
<<<<<<< HEAD
            BsdSockAddr result = new()
            {
                Length = 0,
                Family = (byte)endpoint.AddressFamily,
                Port = (ushort)IPAddress.HostToNetworkOrder((short)endpoint.Port),
=======
            BsdSockAddr result = new BsdSockAddr
            {
                Length = 0,
                Family = (byte)endpoint.AddressFamily,
                Port = (ushort)IPAddress.HostToNetworkOrder((short)endpoint.Port)
>>>>>>> 1ec71635b (sync with main branch)
            };

            endpoint.Address.GetAddressBytes().AsSpan().CopyTo(result.Address.AsSpan());

            return result;
        }
    }
}
