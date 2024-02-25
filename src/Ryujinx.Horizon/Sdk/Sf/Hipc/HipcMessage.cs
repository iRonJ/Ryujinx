<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Horizon.Sdk.Sf.Cmif;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    ref struct HipcMessage
    {
        public const int AutoReceiveStatic = byte.MaxValue;

<<<<<<< HEAD
        public HipcMetadata Meta;
        public HipcMessageData Data;
        public ulong Pid;
=======
        public HipcMetadata    Meta;
        public HipcMessageData Data;
        public ulong           Pid;
>>>>>>> 1ec71635b (sync with main branch)

        public HipcMessage(Span<byte> data)
        {
            int initialLength = data.Length;

            Header header = MemoryMarshal.Cast<byte, Header>(data)[0];

            data = data[Unsafe.SizeOf<Header>()..];

<<<<<<< HEAD
            int receiveStaticsCount = 0;
            ulong pid = 0;
=======
            int   receiveStaticsCount = 0;
            ulong pid                 = 0;
>>>>>>> 1ec71635b (sync with main branch)

            if (header.ReceiveStaticMode != 0)
            {
                if (header.ReceiveStaticMode == 2)
                {
                    receiveStaticsCount = AutoReceiveStatic;
                }
                else if (header.ReceiveStaticMode > 2)
                {
                    receiveStaticsCount = header.ReceiveStaticMode - 2;
                }
            }

            SpecialHeader specialHeader = default;

            if (header.HasSpecialHeader)
            {
                specialHeader = MemoryMarshal.Cast<byte, SpecialHeader>(data)[0];
<<<<<<< HEAD
                data = data[Unsafe.SizeOf<SpecialHeader>()..];

                if (specialHeader.SendPid)
                {
                    pid = MemoryMarshal.Cast<byte, ulong>(data)[0];
=======
                data          = data[Unsafe.SizeOf<SpecialHeader>()..];

                if (specialHeader.SendPid)
                {
                    pid  = MemoryMarshal.Cast<byte, ulong>(data)[0];
>>>>>>> 1ec71635b (sync with main branch)
                    data = data[sizeof(ulong)..];
                }
            }

<<<<<<< HEAD
            Meta = new HipcMetadata
            {
                Type = (int)header.Type,
                SendStaticsCount = header.SendStaticsCount,
                SendBuffersCount = header.SendBuffersCount,
                ReceiveBuffersCount = header.ReceiveBuffersCount,
                ExchangeBuffersCount = header.ExchangeBuffersCount,
                DataWordsCount = header.DataWordsCount,
                ReceiveStaticsCount = receiveStaticsCount,
                SendPid = specialHeader.SendPid,
                CopyHandlesCount = specialHeader.CopyHandlesCount,
                MoveHandlesCount = specialHeader.MoveHandlesCount,
            };

            Data = CreateMessageData(Meta, data, initialLength);
            Pid = pid;
=======
            Meta = new HipcMetadata()
            {
                Type                 = (int)header.Type,
                SendStaticsCount     = header.SendStaticsCount,
                SendBuffersCount     = header.SendBuffersCount,
                ReceiveBuffersCount  = header.ReceiveBuffersCount,
                ExchangeBuffersCount = header.ExchangeBuffersCount,
                DataWordsCount       = header.DataWordsCount,
                ReceiveStaticsCount  = receiveStaticsCount,
                SendPid              = specialHeader.SendPid,
                CopyHandlesCount     = specialHeader.CopyHandlesCount,
                MoveHandlesCount     = specialHeader.MoveHandlesCount
            };

            Data = CreateMessageData(Meta, data, initialLength);
            Pid  = pid;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static HipcMessageData WriteResponse(
            Span<byte> destination,
<<<<<<< HEAD
            int sendStaticCount,
            int dataWordsCount,
            int copyHandlesCount,
            int moveHandlesCount)
        {
            return WriteMessage(destination, new HipcMetadata
            {
                SendStaticsCount = sendStaticCount,
                DataWordsCount = dataWordsCount,
                CopyHandlesCount = copyHandlesCount,
                MoveHandlesCount = moveHandlesCount,
=======
            int        sendStaticCount,
            int        dataWordsCount,
            int        copyHandlesCount,
            int        moveHandlesCount)
        {
            return WriteMessage(destination, new HipcMetadata()
            {
                SendStaticsCount = sendStaticCount,
                DataWordsCount   = dataWordsCount,
                CopyHandlesCount = copyHandlesCount,
                MoveHandlesCount = moveHandlesCount
>>>>>>> 1ec71635b (sync with main branch)
            });
        }

        public static HipcMessageData WriteMessage(Span<byte> destination, HipcMetadata meta)
        {
<<<<<<< HEAD
            int initialLength = destination.Length;
            bool hasSpecialHeader = meta.SendPid || meta.CopyHandlesCount != 0 || meta.MoveHandlesCount != 0;

            MemoryMarshal.Cast<byte, Header>(destination)[0] = new Header
            {
                Type = (CommandType)meta.Type,
                SendStaticsCount = meta.SendStaticsCount,
                SendBuffersCount = meta.SendBuffersCount,
                ReceiveBuffersCount = meta.ReceiveBuffersCount,
                ExchangeBuffersCount = meta.ExchangeBuffersCount,
                DataWordsCount = meta.DataWordsCount,
                ReceiveStaticMode = meta.ReceiveStaticsCount != 0 ? (meta.ReceiveStaticsCount != AutoReceiveStatic ? meta.ReceiveStaticsCount + 2 : 2) : 0,
                HasSpecialHeader = hasSpecialHeader,
=======
            int  initialLength    = destination.Length;
            bool hasSpecialHeader = meta.SendPid || meta.CopyHandlesCount != 0 || meta.MoveHandlesCount != 0;

            MemoryMarshal.Cast<byte, Header>(destination)[0] = new Header()
            {
                Type                 = (CommandType)meta.Type,
                SendStaticsCount     = meta.SendStaticsCount,
                SendBuffersCount     = meta.SendBuffersCount,
                ReceiveBuffersCount  = meta.ReceiveBuffersCount,
                ExchangeBuffersCount = meta.ExchangeBuffersCount,
                DataWordsCount       = meta.DataWordsCount,
                ReceiveStaticMode    = meta.ReceiveStaticsCount != 0 ? (meta.ReceiveStaticsCount != AutoReceiveStatic ? meta.ReceiveStaticsCount + 2 : 2) : 0,
                HasSpecialHeader     = hasSpecialHeader
>>>>>>> 1ec71635b (sync with main branch)
            };

            destination = destination[Unsafe.SizeOf<Header>()..];

            if (hasSpecialHeader)
            {
<<<<<<< HEAD
                MemoryMarshal.Cast<byte, SpecialHeader>(destination)[0] = new SpecialHeader
                {
                    SendPid = meta.SendPid,
                    CopyHandlesCount = meta.CopyHandlesCount,
                    MoveHandlesCount = meta.MoveHandlesCount,
=======
                MemoryMarshal.Cast<byte, SpecialHeader>(destination)[0] = new SpecialHeader()
                {
                    SendPid          = meta.SendPid,
                    CopyHandlesCount = meta.CopyHandlesCount,
                    MoveHandlesCount = meta.MoveHandlesCount
>>>>>>> 1ec71635b (sync with main branch)
                };

                destination = destination[Unsafe.SizeOf<SpecialHeader>()..];

                if (meta.SendPid)
                {
                    destination = destination[sizeof(ulong)..];
                }
            }

            return CreateMessageData(meta, destination, initialLength);
        }

        private static HipcMessageData CreateMessageData(HipcMetadata meta, Span<byte> data, int initialLength)
        {
            Span<int> copyHandles = Span<int>.Empty;

            if (meta.CopyHandlesCount != 0)
            {
                copyHandles = MemoryMarshal.Cast<byte, int>(data)[..meta.CopyHandlesCount];

                data = data[(meta.CopyHandlesCount * sizeof(int))..];
            }

            Span<int> moveHandles = Span<int>.Empty;

            if (meta.MoveHandlesCount != 0)
            {
                moveHandles = MemoryMarshal.Cast<byte, int>(data)[..meta.MoveHandlesCount];

                data = data[(meta.MoveHandlesCount * sizeof(int))..];
            }

            Span<HipcStaticDescriptor> sendStatics = Span<HipcStaticDescriptor>.Empty;

            if (meta.SendStaticsCount != 0)
            {
                sendStatics = MemoryMarshal.Cast<byte, HipcStaticDescriptor>(data)[..meta.SendStaticsCount];

                data = data[(meta.SendStaticsCount * Unsafe.SizeOf<HipcStaticDescriptor>())..];
            }

            Span<HipcBufferDescriptor> sendBuffers = Span<HipcBufferDescriptor>.Empty;

            if (meta.SendBuffersCount != 0)
            {
                sendBuffers = MemoryMarshal.Cast<byte, HipcBufferDescriptor>(data)[..meta.SendBuffersCount];

                data = data[(meta.SendBuffersCount * Unsafe.SizeOf<HipcBufferDescriptor>())..];
            }

            Span<HipcBufferDescriptor> receiveBuffers = Span<HipcBufferDescriptor>.Empty;

            if (meta.ReceiveBuffersCount != 0)
            {
                receiveBuffers = MemoryMarshal.Cast<byte, HipcBufferDescriptor>(data)[..meta.ReceiveBuffersCount];

                data = data[(meta.ReceiveBuffersCount * Unsafe.SizeOf<HipcBufferDescriptor>())..];
            }

            Span<HipcBufferDescriptor> exchangeBuffers = Span<HipcBufferDescriptor>.Empty;

            if (meta.ExchangeBuffersCount != 0)
            {
                exchangeBuffers = MemoryMarshal.Cast<byte, HipcBufferDescriptor>(data)[..meta.ExchangeBuffersCount];

                data = data[(meta.ExchangeBuffersCount * Unsafe.SizeOf<HipcBufferDescriptor>())..];
            }

            Span<uint> dataWords = Span<uint>.Empty;
<<<<<<< HEAD
            Span<uint> dataWordsPadded = Span<uint>.Empty;

            if (meta.DataWordsCount != 0)
            {
                int dataOffset = initialLength - data.Length;
                int dataOffsetAligned = BitUtils.AlignUp(dataOffset, 0x10);
                int padding = (dataOffsetAligned - dataOffset) / sizeof(uint);

                dataWords = MemoryMarshal.Cast<byte, uint>(data)[padding..meta.DataWordsCount];
                dataWordsPadded = MemoryMarshal.Cast<byte, uint>(data)[..meta.DataWordsCount];
=======

            if (meta.DataWordsCount != 0)
            {
                int dataOffset        = initialLength - data.Length;
                int dataOffsetAligned = BitUtils.AlignUp(dataOffset, 0x10);
                int padding           = (dataOffsetAligned - dataOffset) / sizeof(uint);

                dataWords = MemoryMarshal.Cast<byte, uint>(data)[padding..meta.DataWordsCount];
>>>>>>> 1ec71635b (sync with main branch)

                data = data[(meta.DataWordsCount * sizeof(uint))..];
            }

            Span<HipcReceiveListEntry> receiveList = Span<HipcReceiveListEntry>.Empty;

            if (meta.ReceiveStaticsCount != 0)
            {
                int receiveListSize = meta.ReceiveStaticsCount == AutoReceiveStatic ? 1 : meta.ReceiveStaticsCount;

                receiveList = MemoryMarshal.Cast<byte, HipcReceiveListEntry>(data)[..receiveListSize];
            }

<<<<<<< HEAD
            return new HipcMessageData
            {
                SendStatics = sendStatics,
                SendBuffers = sendBuffers,
                ReceiveBuffers = receiveBuffers,
                ExchangeBuffers = exchangeBuffers,
                DataWords = dataWords,
                DataWordsPadded = dataWordsPadded,
                ReceiveList = receiveList,
                CopyHandles = copyHandles,
                MoveHandles = moveHandles,
=======
            return new HipcMessageData()
            {
                SendStatics     = sendStatics,
                SendBuffers     = sendBuffers,
                ReceiveBuffers  = receiveBuffers,
                ExchangeBuffers = exchangeBuffers,
                DataWords       = dataWords,
                ReceiveList     = receiveList,
                CopyHandles     = copyHandles,
                MoveHandles     = moveHandles
>>>>>>> 1ec71635b (sync with main branch)
            };
        }
    }
}
