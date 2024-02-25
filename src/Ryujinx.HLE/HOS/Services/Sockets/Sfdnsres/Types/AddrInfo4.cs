<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Sockets.Sfdnsres.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x10)]
    struct AddrInfo4
    {
<<<<<<< HEAD
        public byte Length;
        public byte Family;
        public short Port;
=======
        public byte         Length;
        public byte         Family;
        public short        Port;
>>>>>>> 1ec71635b (sync with main branch)
        public Array4<byte> Address;
        public Array8<byte> Padding;

        public AddrInfo4(IPAddress address, short port)
        {
<<<<<<< HEAD
            Length = (byte)Unsafe.SizeOf<Array4<byte>>();
            Family = (byte)AddressFamily.InterNetwork;
            Port = IPAddress.HostToNetworkOrder(port);
=======
            Length  = (byte)Unsafe.SizeOf<Array4<byte>>();
            Family  = (byte)AddressFamily.InterNetwork;
            Port    = IPAddress.HostToNetworkOrder(port);
>>>>>>> 1ec71635b (sync with main branch)
            Address = new Array4<byte>();

            address.TryWriteBytes(Address.AsSpan(), out _);
        }

        public void ToNetworkOrder()
        {
            Port = IPAddress.HostToNetworkOrder(Port);

            RawIpv4AddressNetworkEndianSwap(ref Address);
        }

        public void ToHostOrder()
        {
            Port = IPAddress.NetworkToHostOrder(Port);

            RawIpv4AddressNetworkEndianSwap(ref Address);
        }

        public static void RawIpv4AddressNetworkEndianSwap(ref Array4<byte> address)
        {
            if (BitConverter.IsLittleEndian)
            {
                address.AsSpan().Reverse();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
