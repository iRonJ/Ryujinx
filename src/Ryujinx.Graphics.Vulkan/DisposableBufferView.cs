<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct DisposableBufferView : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;

        public BufferView Value { get; }

        public DisposableBufferView(Vk api, Device device, BufferView bufferView)
        {
            _api = api;
            _device = device;
            Value = bufferView;
        }

        public void Dispose()
        {
            _api.DestroyBufferView(_device, Value, Span<AllocationCallbacks>.Empty);
        }
    }
}
