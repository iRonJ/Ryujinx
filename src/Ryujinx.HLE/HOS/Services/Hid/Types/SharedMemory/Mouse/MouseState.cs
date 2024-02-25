<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
=======
﻿using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Mouse
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MouseState : ISampledDataStruct
    {
        public ulong SamplingNumber;
        public int X;
        public int Y;
        public int DeltaX;
        public int DeltaY;
        public int WheelDeltaX;
        public int WheelDeltaY;
        public MouseButton Buttons;
        public MouseAttribute Attributes;
    }
}
