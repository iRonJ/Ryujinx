using Silk.NET.Vulkan;
using System;
using System.Diagnostics;

namespace Ryujinx.Graphics.Vulkan
{
    class DescriptorSetManager : IDisposable
    {
<<<<<<< HEAD
        public const uint MaxSets = 16;
=======
        private const uint DescriptorPoolMultiplier = 16;
>>>>>>> 1ec71635b (sync with main branch)

        public class DescriptorPoolHolder : IDisposable
        {
            public Vk Api { get; }
            public Device Device { get; }

            private readonly DescriptorPool _pool;
<<<<<<< HEAD
            private int _freeDescriptors;
=======
            private readonly uint _capacity;
>>>>>>> 1ec71635b (sync with main branch)
            private int _totalSets;
            private int _setsInUse;
            private bool _done;

<<<<<<< HEAD
            public unsafe DescriptorPoolHolder(Vk api, Device device, ReadOnlySpan<DescriptorPoolSize> poolSizes, bool updateAfterBind)
=======
            public unsafe DescriptorPoolHolder(Vk api, Device device)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Api = api;
                Device = device;

<<<<<<< HEAD
                foreach (var poolSize in poolSizes)
                {
                    _freeDescriptors += (int)poolSize.DescriptorCount;
                }

                fixed (DescriptorPoolSize* pPoolsSize = poolSizes)
                {
                    var descriptorPoolCreateInfo = new DescriptorPoolCreateInfo
                    {
                        SType = StructureType.DescriptorPoolCreateInfo,
                        Flags = updateAfterBind ? DescriptorPoolCreateFlags.UpdateAfterBindBit : DescriptorPoolCreateFlags.None,
                        MaxSets = MaxSets,
                        PoolSizeCount = (uint)poolSizes.Length,
                        PPoolSizes = pPoolsSize,
=======
                var poolSizes = new DescriptorPoolSize[]
                {
                    new DescriptorPoolSize(DescriptorType.UniformBuffer, (1 + Constants.MaxUniformBufferBindings) * DescriptorPoolMultiplier),
                    new DescriptorPoolSize(DescriptorType.StorageBuffer, Constants.MaxStorageBufferBindings * DescriptorPoolMultiplier),
                    new DescriptorPoolSize(DescriptorType.CombinedImageSampler, Constants.MaxTextureBindings * DescriptorPoolMultiplier),
                    new DescriptorPoolSize(DescriptorType.StorageImage, Constants.MaxImageBindings * DescriptorPoolMultiplier),
                    new DescriptorPoolSize(DescriptorType.UniformTexelBuffer, Constants.MaxTextureBindings * DescriptorPoolMultiplier),
                    new DescriptorPoolSize(DescriptorType.StorageTexelBuffer, Constants.MaxImageBindings * DescriptorPoolMultiplier)
                };

                uint maxSets = (uint)poolSizes.Length * DescriptorPoolMultiplier;

                _capacity = maxSets;

                fixed (DescriptorPoolSize* pPoolsSize = poolSizes)
                {
                    var descriptorPoolCreateInfo = new DescriptorPoolCreateInfo()
                    {
                        SType = StructureType.DescriptorPoolCreateInfo,
                        MaxSets = maxSets,
                        PoolSizeCount = (uint)poolSizes.Length,
                        PPoolSizes = pPoolsSize
>>>>>>> 1ec71635b (sync with main branch)
                    };

                    Api.CreateDescriptorPool(device, descriptorPoolCreateInfo, null, out _pool).ThrowOnError();
                }
            }

<<<<<<< HEAD
            public unsafe DescriptorSetCollection AllocateDescriptorSets(ReadOnlySpan<DescriptorSetLayout> layouts, int consumedDescriptors)
            {
                TryAllocateDescriptorSets(layouts, consumedDescriptors, isTry: false, out var dsc);
                return dsc;
            }

            public bool TryAllocateDescriptorSets(ReadOnlySpan<DescriptorSetLayout> layouts, int consumedDescriptors, out DescriptorSetCollection dsc)
            {
                return TryAllocateDescriptorSets(layouts, consumedDescriptors, isTry: true, out dsc);
            }

            private unsafe bool TryAllocateDescriptorSets(
                ReadOnlySpan<DescriptorSetLayout> layouts,
                int consumedDescriptors,
                bool isTry,
                out DescriptorSetCollection dsc)
=======
            public unsafe DescriptorSetCollection AllocateDescriptorSets(ReadOnlySpan<DescriptorSetLayout> layouts)
            {
                TryAllocateDescriptorSets(layouts, isTry: false, out var dsc);
                return dsc;
            }

            public bool TryAllocateDescriptorSets(ReadOnlySpan<DescriptorSetLayout> layouts, out DescriptorSetCollection dsc)
            {
                return TryAllocateDescriptorSets(layouts, isTry: true, out dsc);
            }

            private unsafe bool TryAllocateDescriptorSets(ReadOnlySpan<DescriptorSetLayout> layouts, bool isTry, out DescriptorSetCollection dsc)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Debug.Assert(!_done);

                DescriptorSet[] descriptorSets = new DescriptorSet[layouts.Length];

                fixed (DescriptorSet* pDescriptorSets = descriptorSets)
                {
                    fixed (DescriptorSetLayout* pLayouts = layouts)
                    {
<<<<<<< HEAD
                        var descriptorSetAllocateInfo = new DescriptorSetAllocateInfo
=======
                        var descriptorSetAllocateInfo = new DescriptorSetAllocateInfo()
>>>>>>> 1ec71635b (sync with main branch)
                        {
                            SType = StructureType.DescriptorSetAllocateInfo,
                            DescriptorPool = _pool,
                            DescriptorSetCount = (uint)layouts.Length,
<<<<<<< HEAD
                            PSetLayouts = pLayouts,
=======
                            PSetLayouts = pLayouts
>>>>>>> 1ec71635b (sync with main branch)
                        };

                        var result = Api.AllocateDescriptorSets(Device, &descriptorSetAllocateInfo, pDescriptorSets);
                        if (isTry && result == Result.ErrorOutOfPoolMemory)
                        {
<<<<<<< HEAD
                            _totalSets = (int)MaxSets;
=======
                            _totalSets = (int)_capacity;
>>>>>>> 1ec71635b (sync with main branch)
                            _done = true;
                            DestroyIfDone();
                            dsc = default;
                            return false;
                        }

                        result.ThrowOnError();
                    }
                }

<<<<<<< HEAD
                _freeDescriptors -= consumedDescriptors;
=======
>>>>>>> 1ec71635b (sync with main branch)
                _totalSets += layouts.Length;
                _setsInUse += layouts.Length;

                dsc = new DescriptorSetCollection(this, descriptorSets);
                return true;
            }

            public void FreeDescriptorSets(DescriptorSetCollection dsc)
            {
                _setsInUse -= dsc.SetsCount;
                Debug.Assert(_setsInUse >= 0);
                DestroyIfDone();
            }

<<<<<<< HEAD
            public bool CanFit(int setsCount, int descriptorsCount)
            {
                // Try to determine if an allocation with the given parameters will succeed.
                // An allocation may fail if the sets count or descriptors count exceeds the available counts
                // of the pool.
                // Not getting that right is not fatal, it will just create a new pool and try again,
                // but it is less efficient.

                if (_totalSets + setsCount <= MaxSets && _freeDescriptors >= descriptorsCount)
=======
            public bool CanFit(int count)
            {
                if (_totalSets + count <= _capacity)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    return true;
                }

                _done = true;
                DestroyIfDone();
                return false;
            }

            private unsafe void DestroyIfDone()
            {
                if (_done && _setsInUse == 0)
                {
                    Api.DestroyDescriptorPool(Device, _pool, null);
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    unsafe
                    {
                        Api.DestroyDescriptorPool(Device, _pool, null);
                    }
                }
            }

            public void Dispose()
            {
<<<<<<< HEAD
                GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
                Dispose(true);
            }
        }

        private readonly Device _device;
<<<<<<< HEAD
        private readonly DescriptorPoolHolder[] _currentPools;

        public DescriptorSetManager(Device device, int poolCount)
        {
            _device = device;
            _currentPools = new DescriptorPoolHolder[poolCount];
        }

        public Auto<DescriptorSetCollection> AllocateDescriptorSet(
            Vk api,
            DescriptorSetLayout layout,
            ReadOnlySpan<DescriptorPoolSize> poolSizes,
            int poolIndex,
            int consumedDescriptors,
            bool updateAfterBind)
        {
            Span<DescriptorSetLayout> layouts = stackalloc DescriptorSetLayout[1];
            layouts[0] = layout;
            return AllocateDescriptorSets(api, layouts, poolSizes, poolIndex, consumedDescriptors, updateAfterBind);
        }

        public Auto<DescriptorSetCollection> AllocateDescriptorSets(
            Vk api,
            ReadOnlySpan<DescriptorSetLayout> layouts,
            ReadOnlySpan<DescriptorPoolSize> poolSizes,
            int poolIndex,
            int consumedDescriptors,
            bool updateAfterBind)
        {
            // If we fail the first time, just create a new pool and try again.

            var pool = GetPool(api, poolSizes, poolIndex, layouts.Length, consumedDescriptors, updateAfterBind);
            if (!pool.TryAllocateDescriptorSets(layouts, consumedDescriptors, out var dsc))
            {
                pool = GetPool(api, poolSizes, poolIndex, layouts.Length, consumedDescriptors, updateAfterBind);
                dsc = pool.AllocateDescriptorSets(layouts, consumedDescriptors);
=======
        private DescriptorPoolHolder _currentPool;

        public DescriptorSetManager(Device device)
        {
            _device = device;
        }

        public Auto<DescriptorSetCollection> AllocateDescriptorSet(Vk api, DescriptorSetLayout layout)
        {
            Span<DescriptorSetLayout> layouts = stackalloc DescriptorSetLayout[1];
            layouts[0] = layout;
            return AllocateDescriptorSets(api, layouts);
        }

        public Auto<DescriptorSetCollection> AllocateDescriptorSets(Vk api, ReadOnlySpan<DescriptorSetLayout> layouts)
        {
            // If we fail the first time, just create a new pool and try again.
            if (!GetPool(api, layouts.Length).TryAllocateDescriptorSets(layouts, out var dsc))
            {
                dsc = GetPool(api, layouts.Length).AllocateDescriptorSets(layouts);
>>>>>>> 1ec71635b (sync with main branch)
            }

            return new Auto<DescriptorSetCollection>(dsc);
        }

<<<<<<< HEAD
        private DescriptorPoolHolder GetPool(
            Vk api,
            ReadOnlySpan<DescriptorPoolSize> poolSizes,
            int poolIndex,
            int setsCount,
            int descriptorsCount,
            bool updateAfterBind)
        {
            ref DescriptorPoolHolder currentPool = ref _currentPools[poolIndex];

            if (currentPool == null || !currentPool.CanFit(setsCount, descriptorsCount))
            {
                currentPool = new DescriptorPoolHolder(api, _device, poolSizes, updateAfterBind);
            }

            return currentPool;
=======
        private DescriptorPoolHolder GetPool(Vk api, int requiredCount)
        {
            if (_currentPool == null || !_currentPool.CanFit(requiredCount))
            {
                _currentPool = new DescriptorPoolHolder(api, _device);
            }

            return _currentPool;
>>>>>>> 1ec71635b (sync with main branch)
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
<<<<<<< HEAD
                for (int index = 0; index < _currentPools.Length; index++)
                {
                    _currentPools[index]?.Dispose();
                    _currentPools[index] = null;
=======
                unsafe
                {
                    _currentPool?.Dispose();
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            Dispose(true);
        }
    }
}
