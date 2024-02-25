<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    [StructLayout(LayoutKind.Sequential, Size = 0x58)]
    struct TagInfo
    {
        public Array10<byte> Uuid;
<<<<<<< HEAD
        public byte UuidLength;
        public Array21<byte> Reserved1;
        public uint Protocol;
        public uint TagType;
        public Array6<byte> Reserved2;
=======
        public byte          UuidLength;
        public Array21<byte> Reserved1;
        public uint          Protocol;
        public uint          TagType;
        public Array6<byte>  Reserved2;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
