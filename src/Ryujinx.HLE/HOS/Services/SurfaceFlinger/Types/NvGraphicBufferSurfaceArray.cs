<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    [StructLayout(LayoutKind.Explicit)]
    struct NvGraphicBufferSurfaceArray
    {
        [FieldOffset(0x0)]
        private NvGraphicBufferSurface Surface0;

        [FieldOffset(0x58)]
        private NvGraphicBufferSurface Surface1;

        [FieldOffset(0xb0)]
        private NvGraphicBufferSurface Surface2;

<<<<<<< HEAD
        public readonly NvGraphicBufferSurface this[int index]
        {
            get
            {
                return index switch
                {
                    0 => Surface0,
                    1 => Surface1,
                    2 => Surface2,
                    _ => throw new IndexOutOfRangeException(),
                };
            }
        }

        public static int Length => 3;
    }
}
=======
        public NvGraphicBufferSurface this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return Surface0;
                }
                else if (index == 1)
                {
                    return Surface1;
                }
                else if (index == 2)
                {
                    return Surface2;
                }

                throw new IndexOutOfRangeException();
            }
        }

        public int Length => 3;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
