<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Threading;
using VkSemaphore = Silk.NET.Vulkan.Semaphore;

namespace Ryujinx.Graphics.Vulkan
{
    class SemaphoreHolder : IDisposable
    {
        private readonly Vk _api;
        private readonly Device _device;
        private VkSemaphore _semaphore;
        private int _referenceCount;
<<<<<<< HEAD
        private bool _disposed;
=======
        public bool _disposed;
>>>>>>> 1ec71635b (sync with main branch)

        public unsafe SemaphoreHolder(Vk api, Device device)
        {
            _api = api;
            _device = device;

<<<<<<< HEAD
            var semaphoreCreateInfo = new SemaphoreCreateInfo
            {
                SType = StructureType.SemaphoreCreateInfo,
=======
            var semaphoreCreateInfo = new SemaphoreCreateInfo()
            {
                SType = StructureType.SemaphoreCreateInfo
>>>>>>> 1ec71635b (sync with main branch)
            };

            api.CreateSemaphore(device, in semaphoreCreateInfo, null, out _semaphore).ThrowOnError();

            _referenceCount = 1;
        }

        public VkSemaphore GetUnsafe()
        {
            return _semaphore;
        }

        public VkSemaphore Get()
        {
            Interlocked.Increment(ref _referenceCount);
            return _semaphore;
        }

        public unsafe void Put()
        {
            if (Interlocked.Decrement(ref _referenceCount) == 0)
            {
                _api.DestroySemaphore(_device, _semaphore, null);
                _semaphore = default;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Put();
                _disposed = true;
            }
        }
    }
}
