<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    [StructLayout(LayoutKind.Sequential, Size = 0x40)]
    struct ModelInfo
    {
<<<<<<< HEAD
        public ushort CharacterId;
        public byte CharacterVariant;
        public byte Series;
        public ushort ModelNumber;
        public byte Type;
        public Array57<byte> Reserved;
    }
}
=======
        public ushort        CharacterId;
        public byte          CharacterVariant;
        public byte          Series;
        public ushort        ModelNumber;
        public byte          Type;
        public Array57<byte> Reserved;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
