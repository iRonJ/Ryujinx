using Silk.NET.Vulkan;
using System;
using VkBuffer = Silk.NET.Vulkan.Buffer;

namespace Ryujinx.Graphics.Vulkan
{
    struct DescriptorSetCollection : IDisposable
    {
        private DescriptorSetManager.DescriptorPoolHolder _holder;
        private readonly DescriptorSet[] _descriptorSets;
<<<<<<< HEAD
        public readonly int SetsCount => _descriptorSets.Length;
=======
        public int SetsCount => _descriptorSets.Length;
>>>>>>> 1ec71635b (sync with main branch)

        public DescriptorSetCollection(DescriptorSetManager.DescriptorPoolHolder holder, DescriptorSet[] descriptorSets)
        {
            _holder = holder;
            _descriptorSets = descriptorSets;
        }

<<<<<<< HEAD
        public void InitializeBuffers(int setIndex, int baseBinding, int count, DescriptorType type, VkBuffer dummyBuffer)
        {
            Span<DescriptorBufferInfo> infos = stackalloc DescriptorBufferInfo[count];

            infos.Fill(new DescriptorBufferInfo
            {
                Buffer = dummyBuffer,
                Range = Vk.WholeSize,
=======
        public void InitializeBuffers(int setIndex, int baseBinding, int countPerUnit, DescriptorType type, VkBuffer dummyBuffer)
        {
            Span<DescriptorBufferInfo> infos = stackalloc DescriptorBufferInfo[countPerUnit];

            infos.Fill(new DescriptorBufferInfo()
            {
                Buffer = dummyBuffer,
                Range = Vk.WholeSize
>>>>>>> 1ec71635b (sync with main branch)
            });

            UpdateBuffers(setIndex, baseBinding, infos, type);
        }

        public unsafe void UpdateBuffer(int setIndex, int bindingIndex, DescriptorBufferInfo bufferInfo, DescriptorType type)
        {
            if (bufferInfo.Buffer.Handle != 0UL)
            {
                var writeDescriptorSet = new WriteDescriptorSet
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = _descriptorSets[setIndex],
                    DstBinding = (uint)bindingIndex,
                    DescriptorType = type,
                    DescriptorCount = 1,
<<<<<<< HEAD
                    PBufferInfo = &bufferInfo,
=======
                    PBufferInfo = &bufferInfo
>>>>>>> 1ec71635b (sync with main branch)
                };

                _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);
            }
        }

        public unsafe void UpdateBuffers(int setIndex, int baseBinding, ReadOnlySpan<DescriptorBufferInfo> bufferInfo, DescriptorType type)
        {
            if (bufferInfo.Length == 0)
            {
                return;
            }

            fixed (DescriptorBufferInfo* pBufferInfo = bufferInfo)
            {
                var writeDescriptorSet = new WriteDescriptorSet
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = _descriptorSets[setIndex],
                    DstBinding = (uint)baseBinding,
                    DescriptorType = type,
                    DescriptorCount = (uint)bufferInfo.Length,
<<<<<<< HEAD
                    PBufferInfo = pBufferInfo,
=======
                    PBufferInfo = pBufferInfo
                };

                _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);
            }
        }

        public unsafe void UpdateStorageBuffers(int setIndex, int baseBinding, ReadOnlySpan<DescriptorBufferInfo> bufferInfo)
        {
            if (bufferInfo.Length == 0)
            {
                return;
            }

            fixed (DescriptorBufferInfo* pBufferInfo = bufferInfo)
            {
                var writeDescriptorSet = new WriteDescriptorSet
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = _descriptorSets[setIndex],
                    DstBinding = (uint)(baseBinding & ~(Constants.MaxStorageBuffersPerStage - 1)),
                    DstArrayElement = (uint)(baseBinding & (Constants.MaxStorageBuffersPerStage - 1)),
                    DescriptorType = DescriptorType.StorageBuffer,
                    DescriptorCount = (uint)bufferInfo.Length,
                    PBufferInfo = pBufferInfo
>>>>>>> 1ec71635b (sync with main branch)
                };

                _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);
            }
        }

        public unsafe void UpdateImage(int setIndex, int bindingIndex, DescriptorImageInfo imageInfo, DescriptorType type)
        {
            if (imageInfo.ImageView.Handle != 0UL)
            {
                var writeDescriptorSet = new WriteDescriptorSet
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = _descriptorSets[setIndex],
                    DstBinding = (uint)bindingIndex,
                    DescriptorType = type,
                    DescriptorCount = 1,
<<<<<<< HEAD
                    PImageInfo = &imageInfo,
=======
                    PImageInfo = &imageInfo
>>>>>>> 1ec71635b (sync with main branch)
                };

                _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);
            }
        }

        public unsafe void UpdateImages(int setIndex, int baseBinding, ReadOnlySpan<DescriptorImageInfo> imageInfo, DescriptorType type)
        {
            if (imageInfo.Length == 0)
            {
                return;
            }

            fixed (DescriptorImageInfo* pImageInfo = imageInfo)
            {
                var writeDescriptorSet = new WriteDescriptorSet
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = _descriptorSets[setIndex],
                    DstBinding = (uint)baseBinding,
                    DescriptorType = type,
                    DescriptorCount = (uint)imageInfo.Length,
<<<<<<< HEAD
                    PImageInfo = pImageInfo,
=======
                    PImageInfo = pImageInfo
>>>>>>> 1ec71635b (sync with main branch)
                };

                _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);
            }
        }

        public unsafe void UpdateImagesCombined(int setIndex, int baseBinding, ReadOnlySpan<DescriptorImageInfo> imageInfo, DescriptorType type)
        {
            if (imageInfo.Length == 0)
            {
                return;
            }

            fixed (DescriptorImageInfo* pImageInfo = imageInfo)
            {
                for (int i = 0; i < imageInfo.Length; i++)
                {
                    bool nonNull = imageInfo[i].ImageView.Handle != 0 && imageInfo[i].Sampler.Handle != 0;
                    if (nonNull)
                    {
                        int count = 1;

                        while (i + count < imageInfo.Length &&
                            imageInfo[i + count].ImageView.Handle != 0 &&
                            imageInfo[i + count].Sampler.Handle != 0)
                        {
                            count++;
                        }

                        var writeDescriptorSet = new WriteDescriptorSet
                        {
                            SType = StructureType.WriteDescriptorSet,
                            DstSet = _descriptorSets[setIndex],
                            DstBinding = (uint)(baseBinding + i),
                            DescriptorType = DescriptorType.CombinedImageSampler,
                            DescriptorCount = (uint)count,
<<<<<<< HEAD
                            PImageInfo = pImageInfo,
=======
                            PImageInfo = pImageInfo
>>>>>>> 1ec71635b (sync with main branch)
                        };

                        _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);

                        i += count - 1;
                    }
                }
            }
        }

        public unsafe void UpdateBufferImage(int setIndex, int bindingIndex, BufferView texelBufferView, DescriptorType type)
        {
            if (texelBufferView.Handle != 0UL)
            {
                var writeDescriptorSet = new WriteDescriptorSet
                {
                    SType = StructureType.WriteDescriptorSet,
                    DstSet = _descriptorSets[setIndex],
                    DstBinding = (uint)bindingIndex,
                    DescriptorType = type,
                    DescriptorCount = 1,
<<<<<<< HEAD
                    PTexelBufferView = &texelBufferView,
=======
                    PTexelBufferView = &texelBufferView
>>>>>>> 1ec71635b (sync with main branch)
                };

                _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);
            }
        }

        public unsafe void UpdateBufferImages(int setIndex, int baseBinding, ReadOnlySpan<BufferView> texelBufferView, DescriptorType type)
        {
            if (texelBufferView.Length == 0)
            {
                return;
            }

            fixed (BufferView* pTexelBufferView = texelBufferView)
            {
                for (uint i = 0; i < texelBufferView.Length;)
                {
                    uint count = 1;

                    if (texelBufferView[(int)i].Handle != 0UL)
                    {
                        while (i + count < texelBufferView.Length && texelBufferView[(int)(i + count)].Handle != 0UL)
                        {
                            count++;
                        }

                        var writeDescriptorSet = new WriteDescriptorSet
                        {
                            SType = StructureType.WriteDescriptorSet,
                            DstSet = _descriptorSets[setIndex],
                            DstBinding = (uint)baseBinding + i,
                            DescriptorType = type,
                            DescriptorCount = count,
<<<<<<< HEAD
                            PTexelBufferView = pTexelBufferView + i,
=======
                            PTexelBufferView = pTexelBufferView + i
>>>>>>> 1ec71635b (sync with main branch)
                        };

                        _holder.Api.UpdateDescriptorSets(_holder.Device, 1, writeDescriptorSet, 0, null);
                    }

                    i += count;
                }
            }
        }

<<<<<<< HEAD
        public readonly DescriptorSet[] GetSets()
=======
        public DescriptorSet[] GetSets()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _descriptorSets;
        }

        public void Dispose()
        {
            _holder?.FreeDescriptorSets(this);
            _holder = null;
        }
    }
}
