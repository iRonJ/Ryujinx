using Ryujinx.Graphics.GAL;
using Silk.NET.Vulkan;
<<<<<<< HEAD
using System;
=======
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ryujinx.Graphics.Vulkan
{
    class PipelineLayoutCacheEntry
    {
<<<<<<< HEAD
        // Those were adjusted based on current descriptor usage and the descriptor counts usually used on pipeline layouts.
        // It might be a good idea to tweak them again if those change, or maybe find a way to calculate an optimal value dynamically.
        private const uint DefaultUniformBufferPoolCapacity = 19 * DescriptorSetManager.MaxSets;
        private const uint DefaultStorageBufferPoolCapacity = 16 * DescriptorSetManager.MaxSets;
        private const uint DefaultTexturePoolCapacity = 128 * DescriptorSetManager.MaxSets;
        private const uint DefaultImagePoolCapacity = 8 * DescriptorSetManager.MaxSets;

        private const int MaxPoolSizesPerSet = 2;

=======
>>>>>>> 1ec71635b (sync with main branch)
        private readonly VulkanRenderer _gd;
        private readonly Device _device;

        public DescriptorSetLayout[] DescriptorSetLayouts { get; }
        public PipelineLayout PipelineLayout { get; }

<<<<<<< HEAD
        private readonly int[] _consumedDescriptorsPerSet;

        private readonly List<Auto<DescriptorSetCollection>>[][] _dsCache;
        private List<Auto<DescriptorSetCollection>>[] _currentDsCache;
        private readonly int[] _dsCacheCursor;
        private int _dsLastCbIndex;
        private int _dsLastSubmissionCount;

        private readonly Dictionary<long, DescriptorSetTemplate> _pdTemplates;
        private readonly ResourceDescriptorCollection _pdDescriptors;
        private long _lastPdUsage;
        private DescriptorSetTemplate _lastPdTemplate;
=======
        private readonly List<Auto<DescriptorSetCollection>>[][] _dsCache;
        private readonly int[] _dsCacheCursor;
        private int _dsLastCbIndex;
>>>>>>> 1ec71635b (sync with main branch)

        private PipelineLayoutCacheEntry(VulkanRenderer gd, Device device, int setsCount)
        {
            _gd = gd;
            _device = device;

            _dsCache = new List<Auto<DescriptorSetCollection>>[CommandBufferPool.MaxCommandBuffers][];

            for (int i = 0; i < CommandBufferPool.MaxCommandBuffers; i++)
            {
                _dsCache[i] = new List<Auto<DescriptorSetCollection>>[setsCount];

                for (int j = 0; j < _dsCache[i].Length; j++)
                {
                    _dsCache[i][j] = new List<Auto<DescriptorSetCollection>>();
                }
            }

            _dsCacheCursor = new int[setsCount];
        }

        public PipelineLayoutCacheEntry(
            VulkanRenderer gd,
            Device device,
            ReadOnlyCollection<ResourceDescriptorCollection> setDescriptors,
            bool usePushDescriptors) : this(gd, device, setDescriptors.Count)
        {
            (DescriptorSetLayouts, PipelineLayout) = PipelineLayoutFactory.Create(gd, device, setDescriptors, usePushDescriptors);
<<<<<<< HEAD

            _consumedDescriptorsPerSet = new int[setDescriptors.Count];

            for (int setIndex = 0; setIndex < setDescriptors.Count; setIndex++)
            {
                int count = 0;

                foreach (var descriptor in setDescriptors[setIndex].Descriptors)
                {
                    count += descriptor.Count;
                }

                _consumedDescriptorsPerSet[setIndex] = count;
            }

            if (usePushDescriptors)
            {
                _pdDescriptors = setDescriptors[0];
                _pdTemplates = new();
            }
        }

        public void UpdateCommandBufferIndex(int commandBufferIndex)
        {
            int submissionCount = _gd.CommandBufferPool.GetSubmissionCount(commandBufferIndex);

            if (_dsLastCbIndex != commandBufferIndex || _dsLastSubmissionCount != submissionCount)
            {
                _dsLastCbIndex = commandBufferIndex;
                _dsLastSubmissionCount = submissionCount;
                Array.Clear(_dsCacheCursor);
            }

            _currentDsCache = _dsCache[commandBufferIndex];
        }

        public Auto<DescriptorSetCollection> GetNewDescriptorSetCollection(int setIndex, out bool isNew)
        {
            var list = _currentDsCache[setIndex];
            int index = _dsCacheCursor[setIndex]++;
            if (index == list.Count)
            {
                Span<DescriptorPoolSize> poolSizes = stackalloc DescriptorPoolSize[MaxPoolSizesPerSet];
                poolSizes = GetDescriptorPoolSizes(poolSizes, setIndex);

                int consumedDescriptors = _consumedDescriptorsPerSet[setIndex];

                var dsc = _gd.DescriptorSetManager.AllocateDescriptorSet(
                    _gd.Api,
                    DescriptorSetLayouts[setIndex],
                    poolSizes,
                    setIndex,
                    consumedDescriptors,
                    false);

=======
        }

        public Auto<DescriptorSetCollection> GetNewDescriptorSetCollection(
            VulkanRenderer gd,
            int commandBufferIndex,
            int setIndex,
            out bool isNew)
        {
            if (_dsLastCbIndex != commandBufferIndex)
            {
                _dsLastCbIndex = commandBufferIndex;

                for (int i = 0; i < _dsCacheCursor.Length; i++)
                {
                    _dsCacheCursor[i] = 0;
                }
            }

            var list = _dsCache[commandBufferIndex][setIndex];
            int index = _dsCacheCursor[setIndex]++;
            if (index == list.Count)
            {
                var dsc = gd.DescriptorSetManager.AllocateDescriptorSet(gd.Api, DescriptorSetLayouts[setIndex]);
>>>>>>> 1ec71635b (sync with main branch)
                list.Add(dsc);
                isNew = true;
                return dsc;
            }

            isNew = false;
            return list[index];
        }

<<<<<<< HEAD
        private static Span<DescriptorPoolSize> GetDescriptorPoolSizes(Span<DescriptorPoolSize> output, int setIndex)
        {
            int count = 1;

            switch (setIndex)
            {
                case PipelineBase.UniformSetIndex:
                    output[0] = new(DescriptorType.UniformBuffer, DefaultUniformBufferPoolCapacity);
                    break;
                case PipelineBase.StorageSetIndex:
                    output[0] = new(DescriptorType.StorageBuffer, DefaultStorageBufferPoolCapacity);
                    break;
                case PipelineBase.TextureSetIndex:
                    output[0] = new(DescriptorType.CombinedImageSampler, DefaultTexturePoolCapacity);
                    output[1] = new(DescriptorType.UniformTexelBuffer, DefaultTexturePoolCapacity);
                    count = 2;
                    break;
                case PipelineBase.ImageSetIndex:
                    output[0] = new(DescriptorType.StorageImage, DefaultImagePoolCapacity);
                    output[1] = new(DescriptorType.StorageTexelBuffer, DefaultImagePoolCapacity);
                    count = 2;
                    break;
            }

            return output[..count];
        }

        public DescriptorSetTemplate GetPushDescriptorTemplate(PipelineBindPoint pbp, long updateMask)
        {
            if (_lastPdUsage == updateMask && _lastPdTemplate != null)
            {
                // Most likely result is that it asks to update the same buffers.
                return _lastPdTemplate;
            }

            if (!_pdTemplates.TryGetValue(updateMask, out DescriptorSetTemplate template))
            {
                template = new DescriptorSetTemplate(_gd, _device, _pdDescriptors, updateMask, this, pbp, 0);

                _pdTemplates.Add(updateMask, template);
            }

            _lastPdUsage = updateMask;
            _lastPdTemplate = template;

            return template;
        }

=======
>>>>>>> 1ec71635b (sync with main branch)
        protected virtual unsafe void Dispose(bool disposing)
        {
            if (disposing)
            {
<<<<<<< HEAD
                if (_pdTemplates != null)
                {
                    foreach (DescriptorSetTemplate template in _pdTemplates.Values)
                    {
                        template.Dispose();
                    }
                }

=======
>>>>>>> 1ec71635b (sync with main branch)
                for (int i = 0; i < _dsCache.Length; i++)
                {
                    for (int j = 0; j < _dsCache[i].Length; j++)
                    {
                        for (int k = 0; k < _dsCache[i][j].Count; k++)
                        {
                            _dsCache[i][j][k].Dispose();
                        }

                        _dsCache[i][j].Clear();
                    }
                }

                _gd.Api.DestroyPipelineLayout(_device, PipelineLayout, null);

                for (int i = 0; i < DescriptorSetLayouts.Length; i++)
                {
                    _gd.Api.DestroyDescriptorSetLayout(_device, DescriptorSetLayouts[i], null);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
