<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common
{
    /// <summary>
    /// This is a "marker interface" to add some compile-time safety to a convention-based optimization.
    ///
    /// Any struct implementing this interface should:
    ///   - use <c>StructLayoutAttribute</c> (and related attributes) to explicity control how the struct is laid out in memory.
    ///   - ensure that the method <c>ISampledDataStruct.GetSamplingNumberFieldOffset()</c> correctly returns the offset, in bytes,
    ///     to the ulong "Sampling Number" field within the struct. Most types have it as the first field, so the default offset is 0.
<<<<<<< HEAD
    ///
    /// Example:
    ///
=======
    /// 
    /// Example:
    /// 
>>>>>>> 1ec71635b (sync with main branch)
    /// <c>
    ///         [StructLayout(LayoutKind.Sequential, Pack = 8)]
    ///         struct DebugPadState : ISampledDataStruct
    ///         {
    ///             public ulong SamplingNumber;    // 1st field, so no need to add special handling to GetSamplingNumberFieldOffset()
    ///             // other members...
    ///         }
    ///
    ///         [StructLayout(LayoutKind.Sequential, Pack = 8)]
    ///         struct SixAxisSensorState : ISampledDataStruct
    ///         {
    ///             public ulong DeltaTime;
    ///             public ulong SamplingNumber;    // Not the first field - needs special handling in GetSamplingNumberFieldOffset()
    ///             // other members...
    ///         }
    /// </c>
    /// </summary>
    internal interface ISampledDataStruct
    {
        // No Instance Members - marker interface only

        public static ulong GetSamplingNumber<T>(ref T sampledDataStruct) where T : unmanaged, ISampledDataStruct
        {
            ReadOnlySpan<T> structSpan = MemoryMarshal.CreateReadOnlySpan(ref sampledDataStruct, 1);

            ReadOnlySpan<byte> byteSpan = MemoryMarshal.Cast<T, byte>(structSpan);

            int fieldOffset = GetSamplingNumberFieldOffset(ref sampledDataStruct);

            if (fieldOffset > 0)
            {
<<<<<<< HEAD
                byteSpan = byteSpan[fieldOffset..];
=======
                byteSpan = byteSpan.Slice(fieldOffset);
>>>>>>> 1ec71635b (sync with main branch)
            }

            ulong value = BinaryPrimitives.ReadUInt64LittleEndian(byteSpan);

            return value;
        }

        private static int GetSamplingNumberFieldOffset<T>(ref T sampledDataStruct) where T : unmanaged, ISampledDataStruct
        {
            return sampledDataStruct switch
            {
                Npad.SixAxisSensorState _ => sizeof(ulong),
<<<<<<< HEAD
                _ => 0,
=======
                _ => 0
>>>>>>> 1ec71635b (sync with main branch)
            };
        }
    }
}
