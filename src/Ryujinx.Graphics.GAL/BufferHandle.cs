<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.GAL
{
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public readonly record struct BufferHandle
    {
        private readonly ulong _value;

<<<<<<< HEAD
        public static BufferHandle Null => new(0);
=======
        public static BufferHandle Null => new BufferHandle(0);
>>>>>>> 1ec71635b (sync with main branch)

        private BufferHandle(ulong value) => _value = value;
    }
}
