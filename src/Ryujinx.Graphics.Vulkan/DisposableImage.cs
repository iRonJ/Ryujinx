<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
    readonly struct DisposableImage : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;

        public Image Value { get; }

        public DisposableImage(Vk api, Device device, Image image)
        {
            _api = api;
            _device = device;
            Value = image;
        }

        public void Dispose()
        {
            _api.DestroyImage(_device, Value, Span<AllocationCallbacks>.Empty);
        }
    }
}
