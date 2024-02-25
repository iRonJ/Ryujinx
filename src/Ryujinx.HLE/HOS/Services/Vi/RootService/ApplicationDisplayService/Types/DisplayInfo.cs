<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Vi.RootService.ApplicationDisplayService.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x60)]
    struct DisplayInfo
    {
        public Array64<byte> Name;
<<<<<<< HEAD
        public bool LayerLimitEnabled;
        public Array7<byte> Padding;
        public ulong LayerLimitMax;
        public ulong Width;
        public ulong Height;
    }
}
=======
        public bool          LayerLimitEnabled;
        public Array7<byte>  Padding;
        public ulong         LayerLimitMax;
        public ulong         Width;
        public ulong         Height;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
