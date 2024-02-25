<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nifm.StaticService.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0xc2)]
    struct IpSettingData
    {
        public IpAddressSetting IpAddressSetting;
<<<<<<< HEAD
        public DnsSetting DnsSetting;
        public ProxySetting ProxySetting;
        public short Mtu;
    }
}
=======
        public DnsSetting       DnsSetting;
        public ProxySetting     ProxySetting;
        public short            Mtu;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
