<<<<<<< HEAD
using Ryujinx.Common.Memory;
=======
﻿using Ryujinx.Common.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Keyboard
{
    struct KeyboardKey
    {
        public Array4<ulong> RawData;

        public bool this[KeyboardKeyShift index]
        {
            get
            {
                return (RawData[(int)index / 64] & (1UL << ((int)index & 63))) != 0;
            }
            set
            {
                int arrayIndex = (int)index / 64;
                ulong mask = 1UL << ((int)index & 63);

                RawData[arrayIndex] &= ~mask;

                if (value)
                {
                    RawData[arrayIndex] |= mask;
                }
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
