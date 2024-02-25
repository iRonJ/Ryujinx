<<<<<<< HEAD
using Silk.NET.Vulkan;
using System;
using Buffer = Silk.NET.Vulkan.Buffer;
=======
﻿using Silk.NET.Vulkan;
using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct DisposableBuffer : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;

<<<<<<< HEAD
        public Buffer Value { get; }

        public DisposableBuffer(Vk api, Device device, Buffer buffer)
=======
        public Silk.NET.Vulkan.Buffer Value { get; }

        public DisposableBuffer(Vk api, Device device, Silk.NET.Vulkan.Buffer buffer)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _api = api;
            _device = device;
            Value = buffer;
        }

        public void Dispose()
        {
            _api.DestroyBuffer(_device, Value, Span<AllocationCallbacks>.Empty);
        }
    }
}
