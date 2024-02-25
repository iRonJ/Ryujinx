<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct DisposableRenderPass : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;

        public RenderPass Value { get; }

        public DisposableRenderPass(Vk api, Device device, RenderPass renderPass)
        {
            _api = api;
            _device = device;
            Value = renderPass;
        }

        public void Dispose()
        {
            _api.DestroyRenderPass(_device, Value, Span<AllocationCallbacks>.Empty);
        }
    }
}
