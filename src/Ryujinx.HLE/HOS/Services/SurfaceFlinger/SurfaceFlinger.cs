<<<<<<< HEAD
using Ryujinx.Common;
using Ryujinx.Common.Configuration;
using Ryujinx.Common.Logging;
using Ryujinx.Common.PreciseSleep;
=======
﻿using Ryujinx.Common.Configuration;
using Ryujinx.Common.Logging;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.Gpu;
using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvMap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
{
<<<<<<< HEAD
=======
    using ResultCode = Ryujinx.HLE.HOS.Services.Vi.ResultCode;

>>>>>>> 1ec71635b (sync with main branch)
    class SurfaceFlinger : IConsumerListener, IDisposable
    {
        private const int TargetFps = 60;

<<<<<<< HEAD
        private readonly Switch _device;

        private readonly Dictionary<long, Layer> _layers;

        private bool _isRunning;

        private readonly Thread _composerThread;

        private readonly AutoResetEvent _event = new(false);
        private readonly AutoResetEvent _nextFrameEvent = new(true);
        private long _ticks;
        private long _ticksPerFrame;
        private readonly long _spinTicks;
        private readonly long _1msTicks;
=======
        private Switch _device;

        private Dictionary<long, Layer> _layers;

        private bool _isRunning;

        private Thread _composerThread;

        private Stopwatch _chrono;

        private ManualResetEvent _event = new ManualResetEvent(false);
        private AutoResetEvent _nextFrameEvent = new AutoResetEvent(true);
        private long _ticks;
        private long _ticksPerFrame;
        private long _spinTicks;
        private long _1msTicks;
>>>>>>> 1ec71635b (sync with main branch)

        private int _swapInterval;
        private int _swapIntervalDelay;

<<<<<<< HEAD
        private readonly object _lock = new();
=======
        private readonly object Lock = new object();
>>>>>>> 1ec71635b (sync with main branch)

        public long RenderLayerId { get; private set; }

        private class Layer
        {
<<<<<<< HEAD
            public int ProducerBinderId;
            public IGraphicBufferProducer Producer;
            public BufferItemConsumer Consumer;
            public BufferQueueCore Core;
            public ulong Owner;
            public LayerState State;
=======
            public int                    ProducerBinderId;
            public IGraphicBufferProducer Producer;
            public BufferItemConsumer     Consumer;
            public BufferQueueCore        Core;
            public ulong                  Owner;
            public LayerState             State;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private class TextureCallbackInformation
        {
<<<<<<< HEAD
            public Layer Layer;
=======
            public Layer      Layer;
>>>>>>> 1ec71635b (sync with main branch)
            public BufferItem Item;
        }

        public SurfaceFlinger(Switch device)
        {
            _device = device;
            _layers = new Dictionary<long, Layer>();
            RenderLayerId = 0;

            _composerThread = new Thread(HandleComposition)
            {
<<<<<<< HEAD
                Name = "SurfaceFlinger.Composer",
                Priority = ThreadPriority.AboveNormal
            };

=======
                Name = "SurfaceFlinger.Composer"
            };

            _chrono = new Stopwatch();
            _chrono.Start();

>>>>>>> 1ec71635b (sync with main branch)
            _ticks = 0;
            _spinTicks = Stopwatch.Frequency / 500;
            _1msTicks = Stopwatch.Frequency / 1000;

            UpdateSwapInterval(1);

            _composerThread.Start();
        }

        private void UpdateSwapInterval(int swapInterval)
        {
            _swapInterval = swapInterval;

            // If the swap interval is 0, Game VSync is disabled.
            if (_swapInterval == 0)
            {
                _nextFrameEvent.Set();
                _ticksPerFrame = 1;
            }
            else
            {
                _ticksPerFrame = Stopwatch.Frequency / TargetFps;
            }
        }

        public IGraphicBufferProducer CreateLayer(out long layerId, ulong pid, LayerState initialState = LayerState.ManagedClosed)
        {
            layerId = 1;

<<<<<<< HEAD
            lock (_lock)
=======
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                foreach (KeyValuePair<long, Layer> pair in _layers)
                {
                    if (pair.Key >= layerId)
                    {
                        layerId = pair.Key + 1;
                    }
                }
            }

            CreateLayerFromId(pid, layerId, initialState);

            return GetProducerByLayerId(layerId);
        }

        private void CreateLayerFromId(ulong pid, long layerId, LayerState initialState)
        {
<<<<<<< HEAD
            lock (_lock)
=======
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Logger.Info?.Print(LogClass.SurfaceFlinger, $"Creating layer {layerId}");

                BufferQueueCore core = BufferQueue.CreateBufferQueue(_device, pid, out BufferQueueProducer producer, out BufferQueueConsumer consumer);

                core.BufferQueued += () =>
                {
                    _nextFrameEvent.Set();
                };

                _layers.Add(layerId, new Layer
                {
                    ProducerBinderId = HOSBinderDriverServer.RegisterBinderObject(producer),
<<<<<<< HEAD
                    Producer = producer,
                    Consumer = new BufferItemConsumer(_device, consumer, 0, -1, false, this),
                    Core = core,
                    Owner = pid,
                    State = initialState,
=======
                    Producer         = producer,
                    Consumer         = new BufferItemConsumer(_device, consumer, 0, -1, false, this),
                    Core             = core,
                    Owner            = pid,
                    State            = initialState
>>>>>>> 1ec71635b (sync with main branch)
                });
            }
        }

<<<<<<< HEAD
        public Vi.ResultCode OpenLayer(ulong pid, long layerId, out IBinder producer)
=======
        public ResultCode OpenLayer(ulong pid, long layerId, out IBinder producer)
>>>>>>> 1ec71635b (sync with main branch)
        {
            Layer layer = GetLayerByIdLocked(layerId);

            if (layer == null || layer.State != LayerState.ManagedClosed)
            {
                producer = null;

<<<<<<< HEAD
                return Vi.ResultCode.InvalidArguments;
=======
                return ResultCode.InvalidArguments;
>>>>>>> 1ec71635b (sync with main branch)
            }

            layer.State = LayerState.ManagedOpened;
            producer = layer.Producer;

<<<<<<< HEAD
            return Vi.ResultCode.Success;
        }

        public Vi.ResultCode CloseLayer(long layerId)
        {
            lock (_lock)
=======
            return ResultCode.Success;
        }

        public ResultCode CloseLayer(long layerId)
        {
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Layer layer = GetLayerByIdLocked(layerId);

                if (layer == null)
                {
                    Logger.Error?.Print(LogClass.SurfaceFlinger, $"Failed to close layer {layerId}");

<<<<<<< HEAD
                    return Vi.ResultCode.InvalidValue;
=======
                    return ResultCode.InvalidValue;
>>>>>>> 1ec71635b (sync with main branch)
                }

                CloseLayer(layerId, layer);

<<<<<<< HEAD
                return Vi.ResultCode.Success;
            }
        }

        public Vi.ResultCode DestroyManagedLayer(long layerId)
        {
            lock (_lock)
=======
                return ResultCode.Success;
            }
        }

        public ResultCode DestroyManagedLayer(long layerId)
        {
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Layer layer = GetLayerByIdLocked(layerId);

                if (layer == null)
                {
                    Logger.Error?.Print(LogClass.SurfaceFlinger, $"Failed to destroy managed layer {layerId} (not found)");

<<<<<<< HEAD
                    return Vi.ResultCode.InvalidValue;
=======
                    return ResultCode.InvalidValue;
>>>>>>> 1ec71635b (sync with main branch)
                }

                if (layer.State != LayerState.ManagedClosed && layer.State != LayerState.ManagedOpened)
                {
                    Logger.Error?.Print(LogClass.SurfaceFlinger, $"Failed to destroy managed layer {layerId} (permission denied)");

<<<<<<< HEAD
                    return Vi.ResultCode.PermissionDenied;
=======
                    return ResultCode.PermissionDenied;
>>>>>>> 1ec71635b (sync with main branch)
                }

                HOSBinderDriverServer.UnregisterBinderObject(layer.ProducerBinderId);

                if (_layers.Remove(layerId) && layer.State == LayerState.ManagedOpened)
                {
                    CloseLayer(layerId, layer);
                }

<<<<<<< HEAD
                return Vi.ResultCode.Success;
            }
        }

        public Vi.ResultCode DestroyStrayLayer(long layerId)
        {
            lock (_lock)
=======
                return ResultCode.Success;
            }
        }

        public ResultCode DestroyStrayLayer(long layerId)
        {
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Layer layer = GetLayerByIdLocked(layerId);

                if (layer == null)
                {
                    Logger.Error?.Print(LogClass.SurfaceFlinger, $"Failed to destroy stray layer {layerId} (not found)");

<<<<<<< HEAD
                    return Vi.ResultCode.InvalidValue;
=======
                    return ResultCode.InvalidValue;
>>>>>>> 1ec71635b (sync with main branch)
                }

                if (layer.State != LayerState.Stray)
                {
                    Logger.Error?.Print(LogClass.SurfaceFlinger, $"Failed to destroy stray layer {layerId} (permission denied)");

<<<<<<< HEAD
                    return Vi.ResultCode.PermissionDenied;
=======
                    return ResultCode.PermissionDenied;
>>>>>>> 1ec71635b (sync with main branch)
                }

                HOSBinderDriverServer.UnregisterBinderObject(layer.ProducerBinderId);

                if (_layers.Remove(layerId))
                {
                    CloseLayer(layerId, layer);
                }

<<<<<<< HEAD
                return Vi.ResultCode.Success;
=======
                return ResultCode.Success;
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private void CloseLayer(long layerId, Layer layer)
        {
            // If the layer was removed and the current in use, we need to change the current layer in use.
            if (RenderLayerId == layerId)
            {
                // If no layer is availaible, reset to default value.
                if (_layers.Count == 0)
                {
                    SetRenderLayer(0);
                }
                else
                {
                    SetRenderLayer(_layers.Last().Key);
                }
            }

            if (layer.State == LayerState.ManagedOpened)
            {
                layer.State = LayerState.ManagedClosed;
            }
        }

        public void SetRenderLayer(long layerId)
        {
<<<<<<< HEAD
            lock (_lock)
=======
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                RenderLayerId = layerId;
            }
        }

        private Layer GetLayerByIdLocked(long layerId)
        {
            foreach (KeyValuePair<long, Layer> pair in _layers)
            {
                if (pair.Key == layerId)
                {
                    return pair.Value;
                }
            }

            return null;
        }

        public IGraphicBufferProducer GetProducerByLayerId(long layerId)
        {
<<<<<<< HEAD
            lock (_lock)
=======
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Layer layer = GetLayerByIdLocked(layerId);

                if (layer != null)
                {
                    return layer.Producer;
                }
            }

            return null;
        }

        private void HandleComposition()
        {
            _isRunning = true;

<<<<<<< HEAD
            long lastTicks = PerformanceCounter.ElapsedTicks;

            while (_isRunning)
            {
                long ticks = PerformanceCounter.ElapsedTicks;
=======
            long lastTicks = _chrono.ElapsedTicks;

            while (_isRunning)
            {
                long ticks = _chrono.ElapsedTicks;
>>>>>>> 1ec71635b (sync with main branch)

                if (_swapInterval == 0)
                {
                    Compose();

                    _device.System?.SignalVsync();

                    _nextFrameEvent.WaitOne(17);
                    lastTicks = ticks;
                }
                else
                {
                    _ticks += ticks - lastTicks;
                    lastTicks = ticks;

                    if (_ticks >= _ticksPerFrame)
                    {
                        if (_swapIntervalDelay-- == 0)
                        {
                            Compose();

                            // When a frame is presented, delay the next one by its swap interval value.
                            _swapIntervalDelay = Math.Max(0, _swapInterval - 1);
                        }

                        _device.System?.SignalVsync();

                        // Apply a maximum bound of 3 frames to the tick remainder, in case some event causes Ryujinx to pause for a long time or messes with the timer.
                        _ticks = Math.Min(_ticks - _ticksPerFrame, _ticksPerFrame * 3);
                    }

                    // Sleep if possible. If the time til the next frame is too low, spin wait instead.
<<<<<<< HEAD
                    long diff = _ticksPerFrame - (_ticks + PerformanceCounter.ElapsedTicks - ticks);
                    if (diff > 0)
                    {
                        PreciseSleepHelper.SleepUntilTimePoint(_event, PerformanceCounter.ElapsedTicks + diff);

                        diff = _ticksPerFrame - (_ticks + PerformanceCounter.ElapsedTicks - ticks);

                        if (diff < _spinTicks)
                        {
                            PreciseSleepHelper.SpinWaitUntilTimePoint(PerformanceCounter.ElapsedTicks + diff);
=======
                    long diff = _ticksPerFrame - (_ticks + _chrono.ElapsedTicks - ticks);
                    if (diff > 0)
                    {
                        if (diff < _spinTicks)
                        {
                            do
                            {
                                // SpinWait is a little more HT/SMT friendly than aggressively updating/checking ticks.
                                // The value of 5 still gives us quite a bit of precision (~0.0003ms variance at worst) while waiting a reasonable amount of time.
                                Thread.SpinWait(5);

                                ticks = _chrono.ElapsedTicks;
                                _ticks += ticks - lastTicks;
                                lastTicks = ticks;
                            } while (_ticks < _ticksPerFrame);
>>>>>>> 1ec71635b (sync with main branch)
                        }
                        else
                        {
                            _event.WaitOne((int)(diff / _1msTicks));
                        }
                    }
                }
            }
        }

        public void Compose()
        {
<<<<<<< HEAD
            lock (_lock)
=======
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                // TODO: support multilayers (& multidisplay ?)
                if (RenderLayerId == 0)
                {
                    return;
                }

                Layer layer = GetLayerByIdLocked(RenderLayerId);

                Status acquireStatus = layer.Consumer.AcquireBuffer(out BufferItem item, 0);

                if (acquireStatus == Status.Success)
                {
                    // If device vsync is disabled, reflect the change.
                    if (!_device.EnableDeviceVsync)
                    {
                        if (_swapInterval != 0)
                        {
                            UpdateSwapInterval(0);
                        }
                    }
                    else if (item.SwapInterval != _swapInterval)
                    {
                        UpdateSwapInterval(item.SwapInterval);
                    }

                    PostFrameBuffer(layer, item);
                }
                else if (acquireStatus != Status.NoBufferAvailaible && acquireStatus != Status.InvalidOperation)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void PostFrameBuffer(Layer layer, BufferItem item)
        {
<<<<<<< HEAD
            int frameBufferWidth = item.GraphicBuffer.Object.Width;
=======
            int frameBufferWidth  = item.GraphicBuffer.Object.Width;
>>>>>>> 1ec71635b (sync with main branch)
            int frameBufferHeight = item.GraphicBuffer.Object.Height;

            int nvMapHandle = item.GraphicBuffer.Object.Buffer.Surfaces[0].NvMapHandle;

            if (nvMapHandle == 0)
            {
                nvMapHandle = item.GraphicBuffer.Object.Buffer.NvMapId;
            }

            ulong bufferOffset = (ulong)item.GraphicBuffer.Object.Buffer.Surfaces[0].Offset;

            NvMapHandle map = NvMapDeviceFile.GetMapFromHandle(layer.Owner, nvMapHandle);

            ulong frameBufferAddress = map.Address + bufferOffset;

            Format format = ConvertColorFormat(item.GraphicBuffer.Object.Buffer.Surfaces[0].ColorFormat);

            int bytesPerPixel =
                format == Format.B5G6R5Unorm ||
                format == Format.R4G4B4A4Unorm ? 2 : 4;

            int gobBlocksInY = 1 << item.GraphicBuffer.Object.Buffer.Surfaces[0].BlockHeightLog2;

            // Note: Rotation is being ignored.
            Rect cropRect = item.Crop;

            bool flipX = item.Transform.HasFlag(NativeWindowTransform.FlipX);
            bool flipY = item.Transform.HasFlag(NativeWindowTransform.FlipY);

            AspectRatio aspectRatio = _device.Configuration.AspectRatio;
<<<<<<< HEAD
            bool isStretched = aspectRatio == AspectRatio.Stretched;

            ImageCrop crop = new(
=======
            bool        isStretched = aspectRatio == AspectRatio.Stretched;

            ImageCrop crop = new ImageCrop(
>>>>>>> 1ec71635b (sync with main branch)
                cropRect.Left,
                cropRect.Right,
                cropRect.Top,
                cropRect.Bottom,
                flipX,
                flipY,
                isStretched,
                aspectRatio.ToFloatX(),
                aspectRatio.ToFloatY());

<<<<<<< HEAD
            TextureCallbackInformation textureCallbackInformation = new()
            {
                Layer = layer,
                Item = item,
=======
            TextureCallbackInformation textureCallbackInformation = new TextureCallbackInformation
            {
                Layer = layer,
                Item  = item
>>>>>>> 1ec71635b (sync with main branch)
            };

            if (_device.Gpu.Window.EnqueueFrameThreadSafe(
                layer.Owner,
                frameBufferAddress,
                frameBufferWidth,
                frameBufferHeight,
                0,
                false,
                gobBlocksInY,
                format,
                bytesPerPixel,
                crop,
                AcquireBuffer,
                ReleaseBuffer,
                textureCallbackInformation))
            {
                if (item.Fence.FenceCount == 0)
                {
                    _device.Gpu.Window.SignalFrameReady();
                    _device.Gpu.GPFifo.Interrupt();
                }
                else
                {
                    item.Fence.RegisterCallback(_device.Gpu, (x) =>
                    {
                        _device.Gpu.Window.SignalFrameReady();
                        _device.Gpu.GPFifo.Interrupt();
                    });
                }
            }
            else
            {
                ReleaseBuffer(textureCallbackInformation);
            }
        }

        private void ReleaseBuffer(object obj)
        {
            ReleaseBuffer((TextureCallbackInformation)obj);
        }

        private void ReleaseBuffer(TextureCallbackInformation information)
        {
            AndroidFence fence = AndroidFence.NoFence;

            information.Layer.Consumer.ReleaseBuffer(information.Item, ref fence);
        }

        private void AcquireBuffer(GpuContext ignored, object obj)
        {
            AcquireBuffer((TextureCallbackInformation)obj);
        }

        private void AcquireBuffer(TextureCallbackInformation information)
        {
            information.Item.Fence.WaitForever(_device.Gpu);
        }

        public static Format ConvertColorFormat(ColorFormat colorFormat)
        {
            return colorFormat switch
            {
                ColorFormat.A8B8G8R8 => Format.R8G8B8A8Unorm,
                ColorFormat.X8B8G8R8 => Format.R8G8B8A8Unorm,
                ColorFormat.R5G6B5 => Format.B5G6R5Unorm,
                ColorFormat.A8R8G8B8 => Format.B8G8R8A8Unorm,
                ColorFormat.A4B4G4R4 => Format.R4G4B4A4Unorm,
                _ => throw new NotImplementedException($"Color Format \"{colorFormat}\" not implemented!"),
            };
        }

        public void Dispose()
        {
            _isRunning = false;

            foreach (Layer layer in _layers.Values)
            {
                layer.Core.PrepareForExit();
            }
        }

        public void OnFrameAvailable(ref BufferItem item)
        {
            _device.Statistics.RecordGameFrameTime();
        }

        public void OnFrameReplaced(ref BufferItem item)
        {
            _device.Statistics.RecordGameFrameTime();
        }

<<<<<<< HEAD
        public void OnBuffersReleased() { }
=======
        public void OnBuffersReleased() {}
>>>>>>> 1ec71635b (sync with main branch)
    }
}
