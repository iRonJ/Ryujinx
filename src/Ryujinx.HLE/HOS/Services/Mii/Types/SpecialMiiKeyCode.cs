<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 4)]
    struct SpecialMiiKeyCode
    {
        private const uint SpecialMiiMagic = 0xA523B78F;

        public uint RawValue;

<<<<<<< HEAD
        public readonly bool IsEnabledSpecialMii()
=======
        public bool IsEnabledSpecialMii()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return RawValue == SpecialMiiMagic;
        }
    }
}
