<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct DisposableSampler : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;

        public Sampler Value { get; }

        public DisposableSampler(Vk api, Device device, Sampler sampler)
        {
            _api = api;
            _device = device;
            Value = sampler;
        }

        public void Dispose()
        {
            _api.DestroySampler(_device, Value, Span<AllocationCallbacks>.Empty);
        }
    }
}
