<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    [StructLayout(LayoutKind.Sequential, Size = 0x40)]
    struct CommonInfo
    {
<<<<<<< HEAD
        public ushort LastWriteYear;
        public byte LastWriteMonth;
        public byte LastWriteDay;
        public ushort WriteCounter;
        public ushort Version;
        public uint ApplicationAreaSize;
        public Array52<byte> Reserved;
    }
}
=======
        public ushort        LastWriteYear;
        public byte          LastWriteMonth;
        public byte          LastWriteDay;
        public ushort        WriteCounter;
        public ushort        Version;
        public uint          ApplicationAreaSize;
        public Array52<byte> Reserved;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
