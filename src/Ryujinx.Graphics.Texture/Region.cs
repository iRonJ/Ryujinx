<<<<<<< HEAD
namespace Ryujinx.Graphics.Texture
=======
﻿namespace Ryujinx.Graphics.Texture
>>>>>>> 1ec71635b (sync with main branch)
{
    public readonly struct Region
    {
        public int Offset { get; }
        public int Size { get; }

        public Region(int offset, int size)
        {
            Offset = offset;
            Size = size;
        }
    }
}
