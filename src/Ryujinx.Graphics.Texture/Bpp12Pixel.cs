<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Texture
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
<<<<<<< HEAD
    public readonly struct Bpp12Pixel
    {
        private readonly ulong _elem1;
        private readonly uint _elem2;
=======
    public struct Bpp12Pixel
    {
        private ulong _elem1;
        private uint _elem2;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
