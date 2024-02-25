<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nifm.StaticService.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x17C)]
    struct NetworkProfileData
    {
<<<<<<< HEAD
        public IpSettingData IpSettingData;
        public UInt128 Uuid;
        public Array64<byte> Name;
        public Array4<byte> Unknown;
        public WirelessSettingData WirelessSettingData;
        public byte Padding;
    }
}
=======
        public IpSettingData       IpSettingData;
        public UInt128             Uuid;
        public Array64<byte>       Name;
        public Array4<byte>        Unknown;
        public WirelessSettingData WirelessSettingData;
        public byte                Padding;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
