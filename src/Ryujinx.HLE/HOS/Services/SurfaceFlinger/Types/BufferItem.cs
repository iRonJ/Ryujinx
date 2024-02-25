<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.SurfaceFlinger.Types;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
    class BufferItem : ICloneable
    {
        public AndroidStrongPointer<GraphicBuffer> GraphicBuffer;
<<<<<<< HEAD
        public AndroidFence Fence;
        public Rect Crop;
        public NativeWindowTransform Transform;
        public NativeWindowScalingMode ScalingMode;
        public long Timestamp;
        public bool IsAutoTimestamp;
        public int SwapInterval;
        public ulong FrameNumber;
        public int Slot;
        public bool IsDroppable;
        public bool AcquireCalled;
        public bool TransformToDisplayInverse;

        public BufferItem()
        {
            GraphicBuffer = new AndroidStrongPointer<GraphicBuffer>();
            Transform = NativeWindowTransform.None;
            ScalingMode = NativeWindowScalingMode.Freeze;
            Timestamp = 0;
            IsAutoTimestamp = false;
            FrameNumber = 0;
            Slot = BufferSlotArray.InvalidBufferSlot;
            IsDroppable = false;
            AcquireCalled = false;
            TransformToDisplayInverse = false;
            SwapInterval = 1;
            Fence = AndroidFence.NoFence;
=======
        public AndroidFence                        Fence;
        public Rect                                Crop;
        public NativeWindowTransform               Transform;
        public NativeWindowScalingMode             ScalingMode;
        public long                                Timestamp;
        public bool                                IsAutoTimestamp;
        public int                                 SwapInterval;
        public ulong                               FrameNumber;
        public int                                 Slot;
        public bool                                IsDroppable;
        public bool                                AcquireCalled;
        public bool                                TransformToDisplayInverse;

        public BufferItem()
        {
            GraphicBuffer             = new AndroidStrongPointer<GraphicBuffer>();
            Transform                 = NativeWindowTransform.None;
            ScalingMode               = NativeWindowScalingMode.Freeze;
            Timestamp                 = 0;
            IsAutoTimestamp           = false;
            FrameNumber               = 0;
            Slot                      = BufferSlotArray.InvalidBufferSlot;
            IsDroppable               = false;
            AcquireCalled             = false;
            TransformToDisplayInverse = false;
            SwapInterval              = 1;
            Fence                     = AndroidFence.NoFence;
>>>>>>> 1ec71635b (sync with main branch)

            Crop = new Rect();
            Crop.MakeInvalid();
        }

        public object Clone()
        {
<<<<<<< HEAD
            BufferItem item = new()
            {
                Transform = Transform,
                ScalingMode = ScalingMode,
                IsAutoTimestamp = IsAutoTimestamp,
                FrameNumber = FrameNumber,
                Slot = Slot,
                IsDroppable = IsDroppable,
                AcquireCalled = AcquireCalled,
                TransformToDisplayInverse = TransformToDisplayInverse,
                SwapInterval = SwapInterval,
                Fence = Fence,
                Crop = Crop,
            };
=======
            BufferItem item = new BufferItem();

            item.Transform                 = Transform;
            item.ScalingMode               = ScalingMode;
            item.IsAutoTimestamp           = IsAutoTimestamp;
            item.FrameNumber               = FrameNumber;
            item.Slot                      = Slot;
            item.IsDroppable               = IsDroppable;
            item.AcquireCalled             = AcquireCalled;
            item.TransformToDisplayInverse = TransformToDisplayInverse;
            item.SwapInterval              = SwapInterval;
            item.Fence                     = Fence;
            item.Crop                      = Crop;
>>>>>>> 1ec71635b (sync with main branch)

            item.GraphicBuffer.Set(GraphicBuffer);

            return item;
        }
    }
}
