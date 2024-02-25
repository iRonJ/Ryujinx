<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct DisposablePipeline : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;

        public Pipeline Value { get; }

        public DisposablePipeline(Vk api, Device device, Pipeline pipeline)
        {
            _api = api;
            _device = device;
            Value = pipeline;
        }

        public void Dispose()
        {
            _api.DestroyPipeline(_device, Value, Span<AllocationCallbacks>.Empty);
        }
    }
}
