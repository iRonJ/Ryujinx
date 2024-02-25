<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Npad
{
    [StructLayout(LayoutKind.Sequential, Size = 0x5000)]
    struct NpadState
    {
        public NpadInternalState InternalState;

        public static NpadState Create()
        {
            return new NpadState
            {
<<<<<<< HEAD
                InternalState = NpadInternalState.Create(),
=======
                InternalState = NpadInternalState.Create()
>>>>>>> 1ec71635b (sync with main branch)
            };
        }
    }
}
