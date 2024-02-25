<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Mii.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.Mii.Types;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Mii
{
    class DatabaseSessionMetadata
    {
<<<<<<< HEAD
        public uint InterfaceVersion;
=======
        public uint  InterfaceVersion;
>>>>>>> 1ec71635b (sync with main branch)
        public ulong UpdateCounter;

        public SpecialMiiKeyCode MiiKeyCode { get; private set; }

        public DatabaseSessionMetadata(ulong updateCounter, SpecialMiiKeyCode miiKeyCode)
        {
            InterfaceVersion = 0;
<<<<<<< HEAD
            UpdateCounter = updateCounter;
            MiiKeyCode = miiKeyCode;
=======
            UpdateCounter    = updateCounter;
            MiiKeyCode       = miiKeyCode;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public bool IsInterfaceVersionSupported(uint interfaceVersion)
        {
            return InterfaceVersion >= interfaceVersion;
        }
    }
}
