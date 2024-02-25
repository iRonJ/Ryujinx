<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Utilities;
using Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    class Parcel
    {
        private readonly byte[] _rawData;

<<<<<<< HEAD
        private Span<byte> Raw => new(_rawData);
=======
        private Span<byte> Raw => new Span<byte>(_rawData);
>>>>>>> 1ec71635b (sync with main branch)

        private ref ParcelHeader Header => ref MemoryMarshal.Cast<byte, ParcelHeader>(_rawData)[0];

        private Span<byte> Payload => Raw.Slice((int)Header.PayloadOffset, (int)Header.PayloadSize);

        private Span<byte> Objects => Raw.Slice((int)Header.ObjectOffset, (int)Header.ObjectsSize);

        private int _payloadPosition;
        private int _objectPosition;

        public Parcel(byte[] rawData)
        {
<<<<<<< HEAD
            _rawData = rawData;

            _payloadPosition = 0;
            _objectPosition = 0;
=======
            _rawData  = rawData;

            _payloadPosition = 0;
            _objectPosition  = 0;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public Parcel(uint payloadSize, uint objectsSize)
        {
            uint headerSize = (uint)Unsafe.SizeOf<ParcelHeader>();

            _rawData = new byte[BitUtils.AlignUp<uint>(headerSize + payloadSize + objectsSize, 4)];

<<<<<<< HEAD
            Header.PayloadSize = payloadSize;
            Header.ObjectsSize = objectsSize;
            Header.PayloadOffset = headerSize;
            Header.ObjectOffset = Header.PayloadOffset + Header.ObjectsSize;
=======
            Header.PayloadSize   = payloadSize;
            Header.ObjectsSize   = objectsSize;
            Header.PayloadOffset = headerSize;
            Header.ObjectOffset  = Header.PayloadOffset + Header.ObjectsSize;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public string ReadInterfaceToken()
        {
            // Ignore the policy flags
<<<<<<< HEAD
#pragma warning disable IDE0059 // Remove unnecessary value assignment
            int strictPolicy = ReadInt32();
#pragma warning restore IDE0059
=======
            int strictPolicy = ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)

            return ReadString16();
        }

        public string ReadString16()
        {
            int size = ReadInt32();

            if (size < 0)
            {
                return "";
            }

            ReadOnlySpan<byte> data = ReadInPlace((size + 1) * 2);

            // Return the unicode string without the last character (null terminator)
<<<<<<< HEAD
            return Encoding.Unicode.GetString(data[..(size * 2)]);
=======
            return Encoding.Unicode.GetString(data.Slice(0, size * 2));
>>>>>>> 1ec71635b (sync with main branch)
        }

        public int ReadInt32() => ReadUnmanagedType<int>();
        public uint ReadUInt32() => ReadUnmanagedType<uint>();
        public bool ReadBoolean() => ReadUnmanagedType<uint>() != 0;
        public long ReadInt64() => ReadUnmanagedType<long>();
        public ulong ReadUInt64() => ReadUnmanagedType<ulong>();

        public T ReadFlattenable<T>() where T : unmanaged, IFlattenable
        {
            long flattenableSize = ReadInt64();

<<<<<<< HEAD
            T result = new();
=======
            T result = new T();
>>>>>>> 1ec71635b (sync with main branch)

            Debug.Assert(flattenableSize == result.GetFlattenedSize());

            result.Unflatten(this);

            return result;
        }

<<<<<<< HEAD
        public T ReadUnmanagedType<T>() where T : unmanaged
=======
        public T ReadUnmanagedType<T>() where T: unmanaged
>>>>>>> 1ec71635b (sync with main branch)
        {
            ReadOnlySpan<byte> data = ReadInPlace(Unsafe.SizeOf<T>());

            return MemoryMarshal.Cast<byte, T>(data)[0];
        }

        public ReadOnlySpan<byte> ReadInPlace(int size)
        {
            ReadOnlySpan<byte> result = Payload.Slice(_payloadPosition, size);

            _payloadPosition += BitUtils.AlignUp(size, 4);

            return result;
        }

        [StructLayout(LayoutKind.Sequential, Size = 0x28)]
        private struct FlatBinderObject
        {
<<<<<<< HEAD
            public int Type;
            public int Flags;
=======
            public int  Type;
            public int  Flags;
>>>>>>> 1ec71635b (sync with main branch)
            public long BinderId;
            public long Cookie;

            private byte _serviceNameStart;

            public Span<byte> ServiceName => MemoryMarshal.CreateSpan(ref _serviceNameStart, 0x8);
        }

<<<<<<< HEAD
        public void WriteObject<T>(T obj, string serviceName) where T : IBinder
        {
            FlatBinderObject flatBinderObject = new()
            {
                Type = 2,
                Flags = 0,
=======
        public void WriteObject<T>(T obj, string serviceName) where T: IBinder
        {
            FlatBinderObject flatBinderObject = new FlatBinderObject
            {
                Type     = 2,
                Flags    = 0,
>>>>>>> 1ec71635b (sync with main branch)
                BinderId = HOSBinderDriverServer.GetBinderId(obj),
            };

            Encoding.ASCII.GetBytes(serviceName).CopyTo(flatBinderObject.ServiceName);

            WriteUnmanagedType(ref flatBinderObject);

            // TODO: figure out what this value is

            WriteInplaceObject(new byte[4] { 0, 0, 0, 0 });
        }

        public AndroidStrongPointer<T> ReadStrongPointer<T>() where T : unmanaged, IFlattenable
        {
            bool hasObject = ReadBoolean();

            if (hasObject)
            {
                T obj = ReadFlattenable<T>();

                return new AndroidStrongPointer<T>(obj);
            }
            else
            {
                return new AndroidStrongPointer<T>();
            }
        }

<<<<<<< HEAD
        public void WriteStrongPointer<T>(ref AndroidStrongPointer<T> value) where T : unmanaged, IFlattenable
=======
        public void WriteStrongPointer<T>(ref AndroidStrongPointer<T> value) where T: unmanaged, IFlattenable
>>>>>>> 1ec71635b (sync with main branch)
        {
            WriteBoolean(!value.IsNull);

            if (!value.IsNull)
            {
                WriteFlattenable<T>(ref value.Object);
            }
        }

        public void WriteFlattenable<T>(ref T value) where T : unmanaged, IFlattenable
        {
            WriteInt64(value.GetFlattenedSize());

            value.Flatten(this);
        }

        public void WriteStatus(Status status) => WriteUnmanagedType(ref status);
        public void WriteBoolean(bool value) => WriteUnmanagedType(ref value);
        public void WriteInt32(int value) => WriteUnmanagedType(ref value);
        public void WriteUInt32(uint value) => WriteUnmanagedType(ref value);
        public void WriteInt64(long value) => WriteUnmanagedType(ref value);
        public void WriteUInt64(ulong value) => WriteUnmanagedType(ref value);

        public void WriteUnmanagedSpan<T>(ReadOnlySpan<T> value) where T : unmanaged
        {
            WriteInplace(MemoryMarshal.Cast<T, byte>(value));
        }

        public void WriteUnmanagedType<T>(ref T value) where T : unmanaged
        {
            WriteInplace(SpanHelpers.AsByteSpan(ref value));
        }

        public void WriteInplace(ReadOnlySpan<byte> data)
        {
            Span<byte> result = Payload.Slice(_payloadPosition, data.Length);

            data.CopyTo(result);

            _payloadPosition += BitUtils.AlignUp(data.Length, 4);
        }

        public void WriteInplaceObject(ReadOnlySpan<byte> data)
        {
            Span<byte> result = Objects.Slice(_objectPosition, data.Length);

            data.CopyTo(result);

            _objectPosition += BitUtils.AlignUp(data.Length, 4);
        }

        private void UpdateHeader()
        {
            uint headerSize = (uint)Unsafe.SizeOf<ParcelHeader>();

<<<<<<< HEAD
            Header.PayloadSize = (uint)_payloadPosition;
            Header.ObjectsSize = (uint)_objectPosition;
            Header.PayloadOffset = headerSize;
            Header.ObjectOffset = Header.PayloadOffset + Header.PayloadSize;
=======
            Header.PayloadSize   = (uint)_payloadPosition;
            Header.ObjectsSize   = (uint)_objectPosition;
            Header.PayloadOffset = headerSize;
            Header.ObjectOffset  = Header.PayloadOffset + Header.PayloadSize;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public ReadOnlySpan<byte> Finish()
        {
            UpdateHeader();

<<<<<<< HEAD
            return Raw[..(int)(Header.PayloadSize + Header.ObjectsSize + Unsafe.SizeOf<ParcelHeader>())];
=======
            return Raw.Slice(0, (int)(Header.PayloadSize + Header.ObjectsSize + Unsafe.SizeOf<ParcelHeader>()));
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
