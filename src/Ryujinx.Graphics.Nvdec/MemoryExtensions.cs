<<<<<<< HEAD
using Ryujinx.Graphics.Device;
=======
﻿using Ryujinx.Graphics.Gpu.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Nvdec
{
    static class MemoryExtensions
    {
<<<<<<< HEAD
        public static T DeviceRead<T>(this DeviceMemoryManager gmm, uint offset) where T : unmanaged
        {
            return gmm.Read<T>(ExtendOffset(offset));
        }

        public static ReadOnlySpan<byte> DeviceGetSpan(this DeviceMemoryManager gmm, uint offset, int size)
        {
            return gmm.GetSpan(ExtendOffset(offset), size);
        }

        public static void DeviceWrite(this DeviceMemoryManager gmm, uint offset, ReadOnlySpan<byte> data)
        {
            gmm.Write(ExtendOffset(offset), data);
=======
        public static T DeviceRead<T>(this MemoryManager gmm, uint offset) where T : unmanaged
        {
            return gmm.Read<T>((ulong)offset << 8);
        }

        public static ReadOnlySpan<byte> DeviceGetSpan(this MemoryManager gmm, uint offset, int size)
        {
            return gmm.GetSpan((ulong)offset << 8, size);
        }

        public static void DeviceWrite(this MemoryManager gmm, uint offset, ReadOnlySpan<byte> data)
        {
            gmm.Write((ulong)offset << 8, data);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static ulong ExtendOffset(uint offset)
        {
            return (ulong)offset << 8;
        }
    }
}
