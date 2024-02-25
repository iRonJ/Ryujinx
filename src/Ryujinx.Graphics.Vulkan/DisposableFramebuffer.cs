<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct DisposableFramebuffer : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;

        public Framebuffer Value { get; }

        public DisposableFramebuffer(Vk api, Device device, Framebuffer framebuffer)
        {
            _api = api;
            _device = device;
            Value = framebuffer;
        }

        public void Dispose()
        {
            _api.DestroyFramebuffer(_device, Value, Span<AllocationCallbacks>.Empty);
        }
    }
}
