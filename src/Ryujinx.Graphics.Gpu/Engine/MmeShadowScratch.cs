<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.Graphics.Gpu.Engine
{
    /// <summary>
    /// Represents temporary storage used by macros.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 1024)]
    struct MmeShadowScratch
    {
<<<<<<< HEAD
#pragma warning disable CS0169 // The private field is never used
=======
#pragma warning disable CS0169
>>>>>>> 1ec71635b (sync with main branch)
        private uint _e0;
#pragma warning restore CS0169
        public ref uint this[int index] => ref AsSpan()[index];
        public Span<uint> AsSpan() => MemoryMarshal.CreateSpan(ref _e0, 256);
    }
}
