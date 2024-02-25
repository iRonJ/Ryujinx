<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    [StructLayout(LayoutKind.Sequential, Size = 0x28, Pack = 1)]
    struct GraphicBufferHeader
    {
<<<<<<< HEAD
        public int Magic;
        public int Width;
        public int Height;
        public int Stride;
        public PixelFormat Format;
        public int Usage;
=======
        public int         Magic;
        public int         Width;
        public int         Height;
        public int         Stride;
        public PixelFormat Format;
        public int         Usage;
>>>>>>> 1ec71635b (sync with main branch)

        public int Pid;
        public int RefCount;

        public int FdsCount;
        public int IntsCount;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
