<<<<<<< HEAD
using Silk.NET.Vulkan;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using System.Threading;

namespace Ryujinx.Graphics.Vulkan
{
    class BackgroundResource : IDisposable
    {
<<<<<<< HEAD
        private readonly VulkanRenderer _gd;
=======
        private VulkanRenderer _gd;
>>>>>>> 1ec71635b (sync with main branch)
        private Device _device;

        private CommandBufferPool _pool;
        private PersistentFlushBuffer _flushBuffer;

        public BackgroundResource(VulkanRenderer gd, Device device)
        {
            _gd = gd;
            _device = device;
        }

        public CommandBufferPool GetPool()
        {
            if (_pool == null)
            {
                bool useBackground = _gd.BackgroundQueue.Handle != 0 && _gd.Vendor != Vendor.Amd;
                Queue queue = useBackground ? _gd.BackgroundQueue : _gd.Queue;
                object queueLock = useBackground ? _gd.BackgroundQueueLock : _gd.QueueLock;

                lock (queueLock)
                {
                    _pool = new CommandBufferPool(_gd.Api, _device, queue, queueLock, _gd.QueueFamilyIndex, isLight: true);
                }
            }

            return _pool;
        }

        public PersistentFlushBuffer GetFlushBuffer()
        {
<<<<<<< HEAD
            _flushBuffer ??= new PersistentFlushBuffer(_gd);
=======
            if (_flushBuffer == null)
            {
                _flushBuffer = new PersistentFlushBuffer(_gd);
            }
>>>>>>> 1ec71635b (sync with main branch)

            return _flushBuffer;
        }

        public void Dispose()
        {
            _pool?.Dispose();
            _flushBuffer?.Dispose();
        }
    }

    class BackgroundResources : IDisposable
    {
<<<<<<< HEAD
        private readonly VulkanRenderer _gd;
        private Device _device;

        private readonly Dictionary<Thread, BackgroundResource> _resources;
=======
        private VulkanRenderer _gd;
        private Device _device;

        private Dictionary<Thread, BackgroundResource> _resources;
>>>>>>> 1ec71635b (sync with main branch)

        public BackgroundResources(VulkanRenderer gd, Device device)
        {
            _gd = gd;
            _device = device;

            _resources = new Dictionary<Thread, BackgroundResource>();
        }

        private void Cleanup()
        {
            lock (_resources)
            {
                foreach (KeyValuePair<Thread, BackgroundResource> tuple in _resources)
                {
                    if (!tuple.Key.IsAlive)
                    {
                        tuple.Value.Dispose();
                        _resources.Remove(tuple.Key);
                    }
                }
            }
        }

        public BackgroundResource Get()
        {
            Thread thread = Thread.CurrentThread;

            lock (_resources)
            {
<<<<<<< HEAD
                if (!_resources.TryGetValue(thread, out BackgroundResource resource))
=======
                BackgroundResource resource;
                if (!_resources.TryGetValue(thread, out resource))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    Cleanup();

                    resource = new BackgroundResource(_gd, _device);

                    _resources[thread] = resource;
                }

                return resource;
            }
        }

        public void Dispose()
        {
            lock (_resources)
            {
                foreach (var resource in _resources.Values)
                {
                    resource.Dispose();
                }
            }
        }
    }
}
