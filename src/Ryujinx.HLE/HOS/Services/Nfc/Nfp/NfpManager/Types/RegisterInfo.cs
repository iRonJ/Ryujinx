<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Services.Mii.Types;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    [StructLayout(LayoutKind.Sequential, Size = 0x100)]
    struct RegisterInfo
    {
<<<<<<< HEAD
        public CharInfo MiiCharInfo;
        public ushort FirstWriteYear;
        public byte FirstWriteMonth;
        public byte FirstWriteDay;
        public Array41<byte> Nickname;
        public byte FontRegion;
        public Array64<byte> Reserved1;
        public Array58<byte> Reserved2;
    }
}
=======
        public CharInfo      MiiCharInfo;
        public ushort        FirstWriteYear;
        public byte          FirstWriteMonth;
        public byte          FirstWriteDay;
        public Array41<byte> Nickname;
        public byte          FontRegion;
        public Array64<byte> Reserved1;
        public Array58<byte> Reserved2;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
