<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nifm.StaticService.Types
{
    [StructLayout(LayoutKind.Sequential)]
    struct InternetConnectionStatus
    {
<<<<<<< HEAD
        public InternetConnectionType Type;
        public byte WifiStrength;
=======
        public InternetConnectionType  Type;
        public byte                    WifiStrength;
>>>>>>> 1ec71635b (sync with main branch)
        public InternetConnectionState State;
    }
}
