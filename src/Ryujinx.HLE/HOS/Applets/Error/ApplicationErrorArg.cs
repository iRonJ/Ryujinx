<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Applets.Error
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ApplicationErrorArg
    {
<<<<<<< HEAD
        public uint ErrorNumber;
        public ulong LanguageCode;
        public ByteArray2048 MessageText;
        public ByteArray2048 DetailsText;
    }
}
=======
        public uint          ErrorNumber;
        public ulong         LanguageCode;
        public ByteArray2048 MessageText;
        public ByteArray2048 DetailsText;
    }
} 
>>>>>>> 1ec71635b (sync with main branch)
