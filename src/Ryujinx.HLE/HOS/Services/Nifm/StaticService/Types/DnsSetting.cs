<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nifm.StaticService.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 9)]
    struct DnsSetting
    {
        [MarshalAs(UnmanagedType.U1)]
<<<<<<< HEAD
        public bool IsDynamicDnsEnabled;
=======
        public bool        IsDynamicDnsEnabled;
>>>>>>> 1ec71635b (sync with main branch)
        public IpV4Address PrimaryDns;
        public IpV4Address SecondaryDns;

        public DnsSetting(IPInterfaceProperties interfaceProperties)
        {
            IsDynamicDnsEnabled = OperatingSystem.IsWindows() && interfaceProperties.IsDynamicDnsEnabled;

            if (interfaceProperties.DnsAddresses.Count == 0)
            {
<<<<<<< HEAD
                PrimaryDns = new IpV4Address();
=======
                PrimaryDns   = new IpV4Address();
>>>>>>> 1ec71635b (sync with main branch)
                SecondaryDns = new IpV4Address();
            }
            else
            {
<<<<<<< HEAD
                PrimaryDns = new IpV4Address(interfaceProperties.DnsAddresses[0]);
=======
                PrimaryDns   = new IpV4Address(interfaceProperties.DnsAddresses[0]);
>>>>>>> 1ec71635b (sync with main branch)
                SecondaryDns = new IpV4Address(interfaceProperties.DnsAddresses[interfaceProperties.DnsAddresses.Count > 1 ? 1 : 0]);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
