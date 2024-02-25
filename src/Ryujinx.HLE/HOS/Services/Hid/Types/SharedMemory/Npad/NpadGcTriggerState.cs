<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
=======
﻿using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Npad
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct NpadGcTriggerState : ISampledDataStruct
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public ulong SamplingNumber;
        public uint TriggerL;
        public uint TriggerR;
#pragma warning restore CS0649
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
