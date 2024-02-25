<<<<<<< HEAD
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.Common
{
    public static class BinaryReaderExtensions
    {
<<<<<<< HEAD
        public static T ReadStruct<T>(this BinaryReader reader) where T : unmanaged
=======
        public unsafe static T ReadStruct<T>(this BinaryReader reader)
            where T : unmanaged
>>>>>>> 1ec71635b (sync with main branch)
        {
            return MemoryMarshal.Cast<byte, T>(reader.ReadBytes(Unsafe.SizeOf<T>()))[0];
        }
    }
}
