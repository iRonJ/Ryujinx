<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
=======
﻿using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.DebugPad
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct DebugPadState : ISampledDataStruct
    {
        public ulong SamplingNumber;
        public DebugPadAttribute Attributes;
        public DebugPadButton Buttons;
        public AnalogStickState AnalogStickR;
        public AnalogStickState AnalogStickL;
    }
}
