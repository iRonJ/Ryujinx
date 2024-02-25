<<<<<<< HEAD
using Ryujinx.Common.Logging;
=======
﻿using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Kernel.Threading;
using Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    abstract class IGraphicBufferProducer : IBinder
    {
        public string InterfaceToken => "android.gui.IGraphicBufferProducer";

        enum TransactionCode : uint
        {
            RequestBuffer = 1,
            SetBufferCount,
            DequeueBuffer,
            DetachBuffer,
            DetachNextBuffer,
            AttachBuffer,
            QueueBuffer,
            CancelBuffer,
            Query,
            Connect,
            Disconnect,
            SetSidebandStream,
            AllocateBuffers,
            SetPreallocatedBuffer,
            Reserved15,
            GetBufferInfo,
<<<<<<< HEAD
            GetBufferHistory,
=======
            GetBufferHistory
>>>>>>> 1ec71635b (sync with main branch)
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x54)]
        public struct QueueBufferInput : IFlattenable
        {
<<<<<<< HEAD
            public long Timestamp;
            public int IsAutoTimestamp;
            public Rect Crop;
            public NativeWindowScalingMode ScalingMode;
            public NativeWindowTransform Transform;
            public uint StickyTransform;
            public int Async;
            public int SwapInterval;
            public AndroidFence Fence;
=======
            public long                    Timestamp;
            public int                     IsAutoTimestamp;
            public Rect                    Crop;
            public NativeWindowScalingMode ScalingMode;
            public NativeWindowTransform   Transform;
            public uint                    StickyTransform;
            public int                     Async;
            public int                     SwapInterval;
            public AndroidFence            Fence;
>>>>>>> 1ec71635b (sync with main branch)

            public void Flatten(Parcel parcel)
            {
                parcel.WriteUnmanagedType(ref this);
            }

<<<<<<< HEAD
            public readonly uint GetFdCount()
=======
            public uint GetFdCount()
>>>>>>> 1ec71635b (sync with main branch)
            {
                return 0;
            }

<<<<<<< HEAD
            public readonly uint GetFlattenedSize()
=======
            public uint GetFlattenedSize()
>>>>>>> 1ec71635b (sync with main branch)
            {
                return (uint)Unsafe.SizeOf<QueueBufferInput>();
            }

            public void Unflatten(Parcel parcel)
            {
                this = parcel.ReadUnmanagedType<QueueBufferInput>();
            }
        }

        public struct QueueBufferOutput
        {
<<<<<<< HEAD
            public uint Width;
            public uint Height;
            public NativeWindowTransform TransformHint;
            public uint NumPendingBuffers;
            public ulong FrameNumber;
=======
            public uint                  Width;
            public uint                  Height;
            public NativeWindowTransform TransformHint;
            public uint                  NumPendingBuffers;
            public ulong                 FrameNumber;
>>>>>>> 1ec71635b (sync with main branch)

            public void WriteToParcel(Parcel parcel)
            {
                parcel.WriteUInt32(Width);
                parcel.WriteUInt32(Height);
                parcel.WriteUnmanagedType(ref TransformHint);
                parcel.WriteUInt32(NumPendingBuffers);

                if (TransformHint.HasFlag(NativeWindowTransform.ReturnFrameNumber))
                {
                    parcel.WriteUInt64(FrameNumber);
                }
            }
        }

        public ResultCode AdjustRefcount(int addVal, int type)
        {
            // TODO?
            return ResultCode.Success;
        }

        public void GetNativeHandle(uint typeId, out KReadableEvent readableEvent)
        {
            if (typeId == 0xF)
            {
                readableEvent = GetWaitBufferFreeEvent();
            }
            else
            {
                throw new NotImplementedException($"Unimplemented native event type {typeId}!");
            }
        }

        public void OnTransact(uint code, uint flags, Parcel inputParcel, Parcel outputParcel)
        {
<<<<<<< HEAD
            Status status = Status.Success;
            int slot;
            AndroidFence fence;
            QueueBufferInput queueInput;
            QueueBufferOutput queueOutput;
            NativeWindowApi api;

            AndroidStrongPointer<GraphicBuffer> graphicBuffer;
            AndroidStrongPointer<AndroidFence> strongFence;
=======
            Status            status = Status.Success;
            int               slot;
            AndroidFence      fence;
            QueueBufferInput  queueInput;
            QueueBufferOutput queueOutput;
            NativeWindowApi   api;

            AndroidStrongPointer<GraphicBuffer> graphicBuffer;
            AndroidStrongPointer<AndroidFence>  strongFence;
>>>>>>> 1ec71635b (sync with main branch)

            switch ((TransactionCode)code)
            {
                case TransactionCode.RequestBuffer:
                    slot = inputParcel.ReadInt32();

                    status = RequestBuffer(slot, out graphicBuffer);

                    outputParcel.WriteStrongPointer(ref graphicBuffer);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.SetBufferCount:
                    int bufferCount = inputParcel.ReadInt32();

                    status = SetBufferCount(bufferCount);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.DequeueBuffer:
<<<<<<< HEAD
                    bool async = inputParcel.ReadBoolean();
                    uint width = inputParcel.ReadUInt32();
                    uint height = inputParcel.ReadUInt32();
                    PixelFormat format = inputParcel.ReadUnmanagedType<PixelFormat>();
                    uint usage = inputParcel.ReadUInt32();

                    status = DequeueBuffer(out int dequeueSlot, out fence, async, width, height, format, usage);
=======
                    bool        async  = inputParcel.ReadBoolean();
                    uint        width  = inputParcel.ReadUInt32();
                    uint        height = inputParcel.ReadUInt32();
                    PixelFormat format = inputParcel.ReadUnmanagedType<PixelFormat>();
                    uint        usage  = inputParcel.ReadUInt32();

                    status      = DequeueBuffer(out int dequeueSlot, out fence, async, width, height, format, usage);
>>>>>>> 1ec71635b (sync with main branch)
                    strongFence = new AndroidStrongPointer<AndroidFence>(fence);

                    outputParcel.WriteInt32(dequeueSlot);
                    outputParcel.WriteStrongPointer(ref strongFence);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.DetachBuffer:
                    slot = inputParcel.ReadInt32();

                    status = DetachBuffer(slot);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.DetachNextBuffer:
<<<<<<< HEAD
                    status = DetachNextBuffer(out graphicBuffer, out fence);
=======
                    status      = DetachNextBuffer(out graphicBuffer, out fence);
>>>>>>> 1ec71635b (sync with main branch)
                    strongFence = new AndroidStrongPointer<AndroidFence>(fence);

                    outputParcel.WriteStrongPointer(ref graphicBuffer);
                    outputParcel.WriteStrongPointer(ref strongFence);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.AttachBuffer:
                    graphicBuffer = inputParcel.ReadStrongPointer<GraphicBuffer>();

                    status = AttachBuffer(out slot, graphicBuffer);

                    outputParcel.WriteInt32(slot);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.QueueBuffer:
<<<<<<< HEAD
                    slot = inputParcel.ReadInt32();
=======
                    slot       = inputParcel.ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)
                    queueInput = inputParcel.ReadFlattenable<QueueBufferInput>();

                    status = QueueBuffer(slot, ref queueInput, out queueOutput);

                    queueOutput.WriteToParcel(outputParcel);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.CancelBuffer:
<<<<<<< HEAD
                    slot = inputParcel.ReadInt32();
=======
                    slot  = inputParcel.ReadInt32();
>>>>>>> 1ec71635b (sync with main branch)
                    fence = inputParcel.ReadFlattenable<AndroidFence>();

                    CancelBuffer(slot, ref fence);

                    outputParcel.WriteStatus(Status.Success);

                    break;
                case TransactionCode.Query:
                    NativeWindowAttribute what = inputParcel.ReadUnmanagedType<NativeWindowAttribute>();

                    status = Query(what, out int outValue);

                    outputParcel.WriteInt32(outValue);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.Connect:
                    bool hasListener = inputParcel.ReadBoolean();

                    IProducerListener listener = null;

                    if (hasListener)
                    {
                        throw new NotImplementedException("Connect with a strong binder listener isn't implemented");
                    }

                    api = inputParcel.ReadUnmanagedType<NativeWindowApi>();

                    bool producerControlledByApp = inputParcel.ReadBoolean();

                    status = Connect(listener, api, producerControlledByApp, out queueOutput);

                    queueOutput.WriteToParcel(outputParcel);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.Disconnect:
                    api = inputParcel.ReadUnmanagedType<NativeWindowApi>();

                    status = Disconnect(api);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.SetPreallocatedBuffer:
                    slot = inputParcel.ReadInt32();

                    graphicBuffer = inputParcel.ReadStrongPointer<GraphicBuffer>();

                    status = SetPreallocatedBuffer(slot, graphicBuffer);

                    outputParcel.WriteStatus(status);

                    break;
                case TransactionCode.GetBufferHistory:
                    int bufferHistoryCount = inputParcel.ReadInt32();

                    status = GetBufferHistory(bufferHistoryCount, out Span<BufferInfo> bufferInfos);

                    outputParcel.WriteStatus(status);

                    outputParcel.WriteInt32(bufferInfos.Length);

                    outputParcel.WriteUnmanagedSpan<BufferInfo>(bufferInfos);

                    break;
                default:
                    throw new NotImplementedException($"Transaction {(TransactionCode)code} not implemented");
            }

            if (status != Status.Success)
            {
                Logger.Error?.Print(LogClass.SurfaceFlinger, $"Error returned by transaction {(TransactionCode)code}: {status}");
            }
        }

        protected abstract KReadableEvent GetWaitBufferFreeEvent();

        public abstract Status RequestBuffer(int slot, out AndroidStrongPointer<GraphicBuffer> graphicBuffer);

        public abstract Status SetBufferCount(int bufferCount);

        public abstract Status DequeueBuffer(out int slot, out AndroidFence fence, bool async, uint width, uint height, PixelFormat format, uint usage);

        public abstract Status DetachBuffer(int slot);

        public abstract Status DetachNextBuffer(out AndroidStrongPointer<GraphicBuffer> graphicBuffer, out AndroidFence fence);

        public abstract Status AttachBuffer(out int slot, AndroidStrongPointer<GraphicBuffer> graphicBuffer);

        public abstract Status QueueBuffer(int slot, ref QueueBufferInput input, out QueueBufferOutput output);

        public abstract void CancelBuffer(int slot, ref AndroidFence fence);

        public abstract Status Query(NativeWindowAttribute what, out int outValue);

        public abstract Status Connect(IProducerListener listener, NativeWindowApi api, bool producerControlledByApp, out QueueBufferOutput output);

        public abstract Status Disconnect(NativeWindowApi api);

        public abstract Status SetPreallocatedBuffer(int slot, AndroidStrongPointer<GraphicBuffer> graphicBuffer);

        public abstract Status GetBufferHistory(int bufferHistoryCount, out Span<BufferInfo> bufferInfos);
    }
}
