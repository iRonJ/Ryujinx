<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Irs.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x8)]
    struct PackedTeraPluginProcessorConfig
    {
        public uint RequiredMcuVersion;
        public byte Mode;
        public byte Unknown1;
        public byte Unknown2;
        public byte Unknown3;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
