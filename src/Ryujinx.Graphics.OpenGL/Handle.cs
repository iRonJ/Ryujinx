<<<<<<< HEAD
using Ryujinx.Graphics.GAL;
=======
﻿using Ryujinx.Graphics.GAL;
>>>>>>> 1ec71635b (sync with main branch)
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Ryujinx.Graphics.OpenGL
{
    static class Handle
    {
        public static T FromInt32<T>(int handle) where T : unmanaged
        {
            Debug.Assert(Unsafe.SizeOf<T>() == sizeof(ulong));

            ulong handle64 = (uint)handle;

            return Unsafe.As<ulong, T>(ref handle64);
        }

        public static int ToInt32(this BufferHandle handle)
        {
            return (int)Unsafe.As<BufferHandle, ulong>(ref handle);
        }
    }
}
