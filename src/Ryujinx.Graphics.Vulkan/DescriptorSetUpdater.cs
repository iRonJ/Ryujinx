<<<<<<< HEAD
using Ryujinx.Common.Memory;
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.Shader;
using Silk.NET.Vulkan;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CompareOp = Ryujinx.Graphics.GAL.CompareOp;
using Format = Ryujinx.Graphics.GAL.Format;
using SamplerCreateInfo = Ryujinx.Graphics.GAL.SamplerCreateInfo;
=======
﻿using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.Shader;
using Silk.NET.Vulkan;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    class DescriptorSetUpdater
    {
<<<<<<< HEAD
        private const ulong StorageBufferMaxMirrorable = 0x2000;
        private record struct BufferRef
        {
            public Auto<DisposableBuffer> Buffer;
            public int Offset;
            public bool Write;

            public BufferRef(Auto<DisposableBuffer> buffer)
            {
                Buffer = buffer;
                Offset = 0;
                Write = true;
            }

            public BufferRef(Auto<DisposableBuffer> buffer, ref BufferRange range)
            {
                Buffer = buffer;
                Offset = range.Offset;
                Write = range.Write;
            }
        }

        private record struct TextureRef
        {
            public ShaderStage Stage;
            public TextureStorage Storage;
            public Auto<DisposableImageView> View;
            public Auto<DisposableSampler> Sampler;

            public TextureRef(ShaderStage stage, TextureStorage storage, Auto<DisposableImageView> view, Auto<DisposableSampler> sampler)
            {
                Stage = stage;
                Storage = storage;
                View = view;
                Sampler = sampler;
            }
        }

        private record struct ImageRef
        {
            public ShaderStage Stage;
            public TextureStorage Storage;
            public Auto<DisposableImageView> View;

            public ImageRef(ShaderStage stage, TextureStorage storage, Auto<DisposableImageView> view)
            {
                Stage = stage;
                Storage = storage;
                View = view;
            }
        }

        private readonly VulkanRenderer _gd;
        private readonly Device _device;
        private readonly PipelineBase _pipeline;
        private ShaderCollection _program;

        private readonly BufferRef[] _uniformBufferRefs;
        private readonly BufferRef[] _storageBufferRefs;
        private readonly TextureRef[] _textureRefs;
        private readonly ImageRef[] _imageRefs;
        private readonly TextureBuffer[] _bufferTextureRefs;
        private readonly TextureBuffer[] _bufferImageRefs;
        private readonly Format[] _bufferImageFormats;

        private readonly DescriptorBufferInfo[] _uniformBuffers;
        private readonly DescriptorBufferInfo[] _storageBuffers;
        private readonly DescriptorImageInfo[] _textures;
        private readonly DescriptorImageInfo[] _images;
        private readonly BufferView[] _bufferTextures;
        private readonly BufferView[] _bufferImages;

        private readonly DescriptorSetTemplateUpdater _templateUpdater;

        private BitMapStruct<Array2<long>> _uniformSet;
        private BitMapStruct<Array2<long>> _storageSet;
        private BitMapStruct<Array2<long>> _uniformMirrored;
        private BitMapStruct<Array2<long>> _storageMirrored;
        private readonly int[] _uniformSetPd;
        private int _pdSequence = 1;

        private bool _updateDescriptorCacheCbIndex;
=======
        private readonly VulkanRenderer _gd;
        private readonly PipelineBase _pipeline;

        private ShaderCollection _program;

        private Auto<DisposableBuffer>[] _uniformBufferRefs;
        private Auto<DisposableBuffer>[] _storageBufferRefs;
        private Auto<DisposableImageView>[] _textureRefs;
        private Auto<DisposableSampler>[] _samplerRefs;
        private Auto<DisposableImageView>[] _imageRefs;
        private TextureBuffer[] _bufferTextureRefs;
        private TextureBuffer[] _bufferImageRefs;
        private GAL.Format[] _bufferImageFormats;

        private DescriptorBufferInfo[] _uniformBuffers;
        private DescriptorBufferInfo[] _storageBuffers;
        private DescriptorImageInfo[] _textures;
        private DescriptorImageInfo[] _images;
        private BufferView[] _bufferTextures;
        private BufferView[] _bufferImages;

        private bool[] _uniformSet;
        private bool[] _storageSet;
        private Silk.NET.Vulkan.Buffer _cachedSupportBuffer;
>>>>>>> 1ec71635b (sync with main branch)

        [Flags]
        private enum DirtyFlags
        {
            None = 0,
            Uniform = 1 << 0,
            Storage = 1 << 1,
            Texture = 1 << 2,
            Image = 1 << 3,
<<<<<<< HEAD
            All = Uniform | Storage | Texture | Image,
=======
            All = Uniform | Storage | Texture | Image
>>>>>>> 1ec71635b (sync with main branch)
        }

        private DirtyFlags _dirty;

        private readonly BufferHolder _dummyBuffer;
        private readonly TextureView _dummyTexture;
        private readonly SamplerHolder _dummySampler;

<<<<<<< HEAD
        public DescriptorSetUpdater(VulkanRenderer gd, Device device, PipelineBase pipeline)
        {
            _gd = gd;
            _device = device;
=======
        public DescriptorSetUpdater(VulkanRenderer gd, PipelineBase pipeline)
        {
            _gd = gd;
>>>>>>> 1ec71635b (sync with main branch)
            _pipeline = pipeline;

            // Some of the bindings counts needs to be multiplied by 2 because we have buffer and
            // regular textures/images interleaved on the same descriptor set.

<<<<<<< HEAD
            _uniformBufferRefs = new BufferRef[Constants.MaxUniformBufferBindings];
            _storageBufferRefs = new BufferRef[Constants.MaxStorageBufferBindings];
            _textureRefs = new TextureRef[Constants.MaxTextureBindings * 2];
            _imageRefs = new ImageRef[Constants.MaxImageBindings * 2];
            _bufferTextureRefs = new TextureBuffer[Constants.MaxTextureBindings * 2];
            _bufferImageRefs = new TextureBuffer[Constants.MaxImageBindings * 2];
            _bufferImageFormats = new Format[Constants.MaxImageBindings * 2];
=======
            _uniformBufferRefs = new Auto<DisposableBuffer>[Constants.MaxUniformBufferBindings];
            _storageBufferRefs = new Auto<DisposableBuffer>[Constants.MaxStorageBufferBindings];
            _textureRefs = new Auto<DisposableImageView>[Constants.MaxTextureBindings * 2];
            _samplerRefs = new Auto<DisposableSampler>[Constants.MaxTextureBindings * 2];
            _imageRefs = new Auto<DisposableImageView>[Constants.MaxImageBindings * 2];
            _bufferTextureRefs = new TextureBuffer[Constants.MaxTextureBindings * 2];
            _bufferImageRefs = new TextureBuffer[Constants.MaxImageBindings * 2];
            _bufferImageFormats = new GAL.Format[Constants.MaxImageBindings * 2];
>>>>>>> 1ec71635b (sync with main branch)

            _uniformBuffers = new DescriptorBufferInfo[Constants.MaxUniformBufferBindings];
            _storageBuffers = new DescriptorBufferInfo[Constants.MaxStorageBufferBindings];
            _textures = new DescriptorImageInfo[Constants.MaxTexturesPerStage];
            _images = new DescriptorImageInfo[Constants.MaxImagesPerStage];
            _bufferTextures = new BufferView[Constants.MaxTexturesPerStage];
            _bufferImages = new BufferView[Constants.MaxImagesPerStage];

<<<<<<< HEAD
            _uniformSetPd = new int[Constants.MaxUniformBufferBindings];

            var initialImageInfo = new DescriptorImageInfo
            {
                ImageLayout = ImageLayout.General,
=======
            var initialImageInfo = new DescriptorImageInfo()
            {
                ImageLayout = ImageLayout.General
>>>>>>> 1ec71635b (sync with main branch)
            };

            _textures.AsSpan().Fill(initialImageInfo);
            _images.AsSpan().Fill(initialImageInfo);

<<<<<<< HEAD
=======
            _uniformSet = new bool[Constants.MaxUniformBufferBindings];
            _storageSet = new bool[Constants.MaxStorageBufferBindings];

>>>>>>> 1ec71635b (sync with main branch)
            if (gd.Capabilities.SupportsNullDescriptors)
            {
                // If null descriptors are supported, we can pass null as the handle.
                _dummyBuffer = null;
            }
            else
            {
                // If null descriptors are not supported, we need to pass the handle of a dummy buffer on unused bindings.
                _dummyBuffer = gd.BufferManager.Create(gd, 0x10000, forConditionalRendering: false, baseType: BufferAllocationType.DeviceLocal);
            }

            _dummyTexture = gd.CreateTextureView(new TextureCreateInfo(
                1,
                1,
                1,
                1,
                1,
                1,
                1,
                4,
<<<<<<< HEAD
                Format.R8G8B8A8Unorm,
=======
                GAL.Format.R8G8B8A8Unorm,
>>>>>>> 1ec71635b (sync with main branch)
                DepthStencilMode.Depth,
                Target.Texture2D,
                SwizzleComponent.Red,
                SwizzleComponent.Green,
                SwizzleComponent.Blue,
<<<<<<< HEAD
                SwizzleComponent.Alpha));

            _dummySampler = (SamplerHolder)gd.CreateSampler(new SamplerCreateInfo(
=======
                SwizzleComponent.Alpha), 1f);

            _dummySampler = (SamplerHolder)gd.CreateSampler(new GAL.SamplerCreateInfo(
>>>>>>> 1ec71635b (sync with main branch)
                MinFilter.Nearest,
                MagFilter.Nearest,
                false,
                AddressMode.Repeat,
                AddressMode.Repeat,
                AddressMode.Repeat,
                CompareMode.None,
<<<<<<< HEAD
                CompareOp.Always,
=======
                GAL.CompareOp.Always,
>>>>>>> 1ec71635b (sync with main branch)
                new ColorF(0, 0, 0, 0),
                0,
                0,
                0,
                1f));
<<<<<<< HEAD

            _templateUpdater = new();
=======
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Initialize()
        {
            Span<byte> dummyTextureData = stackalloc byte[4];
            _dummyTexture.SetData(dummyTextureData);
        }

<<<<<<< HEAD
        private static bool BindingOverlaps(ref DescriptorBufferInfo info, int bindingOffset, int offset, int size)
        {
            return offset < bindingOffset + (int)info.Range && (offset + size) > bindingOffset;
        }

        internal void Rebind(Auto<DisposableBuffer> buffer, int offset, int size)
        {
            if (_program == null)
            {
                return;
            }

            // Check stage bindings

            _uniformMirrored.Union(_uniformSet).SignalSet((int binding, int count) =>
            {
                for (int i = 0; i < count; i++)
                {
                    ref BufferRef bufferRef = ref _uniformBufferRefs[binding];
                    if (bufferRef.Buffer == buffer)
                    {
                        ref DescriptorBufferInfo info = ref _uniformBuffers[binding];
                        int bindingOffset = bufferRef.Offset;

                        if (BindingOverlaps(ref info, bindingOffset, offset, size))
                        {
                            _uniformSet.Clear(binding);
                            _uniformSetPd[binding] = 0;
                            SignalDirty(DirtyFlags.Uniform);
                        }
                    }

                    binding++;
                }
            });

            _storageMirrored.Union(_storageSet).SignalSet((int binding, int count) =>
            {
                for (int i = 0; i < count; i++)
                {
                    ref BufferRef bufferRef = ref _storageBufferRefs[binding];
                    if (bufferRef.Buffer == buffer)
                    {
                        ref DescriptorBufferInfo info = ref _storageBuffers[binding];
                        int bindingOffset = bufferRef.Offset;

                        if (BindingOverlaps(ref info, bindingOffset, offset, size))
                        {
                            _storageSet.Clear(binding);
                            SignalDirty(DirtyFlags.Storage);
                        }
                    }

                    binding++;
                }
            });
        }

        public void InsertBindingBarriers(CommandBufferScoped cbs)
        {
            foreach (ResourceBindingSegment segment in _program.BindingSegments[PipelineBase.TextureSetIndex])
            {
                if (segment.Type == ResourceType.TextureAndSampler)
                {
                    for (int i = 0; i < segment.Count; i++)
                    {
                        ref var texture = ref _textureRefs[segment.Binding + i];
                        texture.Storage?.QueueWriteToReadBarrier(cbs, AccessFlags.ShaderReadBit, texture.Stage.ConvertToPipelineStageFlags());
                    }
                }
            }

            foreach (ResourceBindingSegment segment in _program.BindingSegments[PipelineBase.ImageSetIndex])
            {
                if (segment.Type == ResourceType.Image)
                {
                    for (int i = 0; i < segment.Count; i++)
                    {
                        ref var image = ref _imageRefs[segment.Binding + i];
                        image.Storage?.QueueWriteToReadBarrier(cbs, AccessFlags.ShaderReadBit, image.Stage.ConvertToPipelineStageFlags());
                    }
                }
            }
        }

        public void AdvancePdSequence()
        {
            if (++_pdSequence == 0)
            {
                _pdSequence = 1;
            }
        }

        public void SetProgram(CommandBufferScoped cbs, ShaderCollection program, bool isBound)
        {
            if (!program.HasSameLayout(_program))
            {
                // When the pipeline layout changes, push descriptor bindings are invalidated.

                AdvancePdSequence();
            }

            _program = program;
            _updateDescriptorCacheCbIndex = true;
            _dirty = DirtyFlags.All;
        }

        public void SetImage(
            CommandBufferScoped cbs,
            ShaderStage stage,
            int binding,
            ITexture image,
            Format imageFormat)
=======
        public void SetProgram(ShaderCollection program)
        {
            _program = program;
            _dirty = DirtyFlags.All;
        }

        public void SetImage(int binding, ITexture image, GAL.Format imageFormat)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (image is TextureBuffer imageBuffer)
            {
                _bufferImageRefs[binding] = imageBuffer;
                _bufferImageFormats[binding] = imageFormat;
            }
            else if (image is TextureView view)
            {
<<<<<<< HEAD
                view.Storage.QueueWriteToReadBarrier(cbs, AccessFlags.ShaderReadBit, stage.ConvertToPipelineStageFlags());

                _imageRefs[binding] = new(stage, view.Storage, view.GetView(imageFormat).GetIdentityImageView());
            }
            else
            {
                _imageRefs[binding] = default;
=======
                _imageRefs[binding] = view.GetView(imageFormat).GetIdentityImageView();
            }
            else
            {
                _imageRefs[binding] = null;
>>>>>>> 1ec71635b (sync with main branch)
                _bufferImageRefs[binding] = null;
                _bufferImageFormats[binding] = default;
            }

            SignalDirty(DirtyFlags.Image);
        }

        public void SetImage(int binding, Auto<DisposableImageView> image)
        {
<<<<<<< HEAD
            _imageRefs[binding] = new(ShaderStage.Compute, null, image);
=======
            _imageRefs[binding] = image;
>>>>>>> 1ec71635b (sync with main branch)

            SignalDirty(DirtyFlags.Image);
        }

        public void SetStorageBuffers(CommandBuffer commandBuffer, ReadOnlySpan<BufferAssignment> buffers)
        {
            for (int i = 0; i < buffers.Length; i++)
            {
                var assignment = buffers[i];
                var buffer = assignment.Range;
                int index = assignment.Binding;

<<<<<<< HEAD
                Auto<DisposableBuffer> vkBuffer = buffer.Handle == BufferHandle.Null
                    ? null
                    : _gd.BufferManager.GetBuffer(commandBuffer, buffer.Handle, buffer.Write, isSSBO: true);

                ref BufferRef currentBufferRef = ref _storageBufferRefs[index];

                DescriptorBufferInfo info = new()
                {
                    Offset = (ulong)buffer.Offset,
                    Range = (ulong)buffer.Size,
                };

                var newRef = new BufferRef(vkBuffer, ref buffer);

                ref DescriptorBufferInfo currentInfo = ref _storageBuffers[index];

                if (!currentBufferRef.Equals(newRef) || currentInfo.Range != info.Range)
                {
                    _storageSet.Clear(index);

                    currentInfo = info;
                    currentBufferRef = newRef;
=======
                Auto<DisposableBuffer> vkBuffer = _gd.BufferManager.GetBuffer(commandBuffer, buffer.Handle, false, isSSBO: true);
                ref Auto<DisposableBuffer> currentVkBuffer = ref _storageBufferRefs[index];

                DescriptorBufferInfo info = new DescriptorBufferInfo()
                {
                    Offset = (ulong)buffer.Offset,
                    Range = (ulong)buffer.Size
                };
                ref DescriptorBufferInfo currentInfo = ref _storageBuffers[index];

                if (vkBuffer != currentVkBuffer || currentInfo.Offset != info.Offset || currentInfo.Range != info.Range)
                {
                    _storageSet[index] = false;

                    currentInfo = info;
                    currentVkBuffer = vkBuffer;
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            SignalDirty(DirtyFlags.Storage);
        }

        public void SetStorageBuffers(CommandBuffer commandBuffer, int first, ReadOnlySpan<Auto<DisposableBuffer>> buffers)
        {
            for (int i = 0; i < buffers.Length; i++)
            {
                var vkBuffer = buffers[i];
                int index = first + i;

<<<<<<< HEAD
                ref BufferRef currentBufferRef = ref _storageBufferRefs[index];

                DescriptorBufferInfo info = new()
                {
                    Offset = 0,
                    Range = Vk.WholeSize,
                };

                BufferRef newRef = new(vkBuffer);

                ref DescriptorBufferInfo currentInfo = ref _storageBuffers[index];

                if (!currentBufferRef.Equals(newRef) || currentInfo.Range != info.Range)
                {
                    _storageSet.Clear(index);

                    currentInfo = info;
                    currentBufferRef = newRef;
=======
                ref Auto<DisposableBuffer> currentVkBuffer = ref _storageBufferRefs[index];

                DescriptorBufferInfo info = new DescriptorBufferInfo()
                {
                    Offset = 0,
                    Range = Vk.WholeSize
                };
                ref DescriptorBufferInfo currentInfo = ref _storageBuffers[index];

                if (vkBuffer != currentVkBuffer || currentInfo.Offset != info.Offset || currentInfo.Range != info.Range)
                {
                    _storageSet[index] = false;

                    currentInfo = info;
                    currentVkBuffer = vkBuffer;
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            SignalDirty(DirtyFlags.Storage);
        }

        public void SetTextureAndSampler(
            CommandBufferScoped cbs,
            ShaderStage stage,
            int binding,
            ITexture texture,
            ISampler sampler)
        {
            if (texture is TextureBuffer textureBuffer)
            {
                _bufferTextureRefs[binding] = textureBuffer;
            }
            else if (texture is TextureView view)
            {
<<<<<<< HEAD
                view.Storage.QueueWriteToReadBarrier(cbs, AccessFlags.ShaderReadBit, stage.ConvertToPipelineStageFlags());

                _textureRefs[binding] = new(stage, view.Storage, view.GetImageView(), ((SamplerHolder)sampler)?.GetSampler());
            }
            else
            {
                _textureRefs[binding] = default;
=======
                view.Storage.InsertWriteToReadBarrier(cbs, AccessFlags.ShaderReadBit, stage.ConvertToPipelineStageFlags());

                _textureRefs[binding] = view.GetImageView();
                _samplerRefs[binding] = ((SamplerHolder)sampler)?.GetSampler();
            }
            else
            {
                _textureRefs[binding] = null;
                _samplerRefs[binding] = null;
>>>>>>> 1ec71635b (sync with main branch)
                _bufferTextureRefs[binding] = null;
            }

            SignalDirty(DirtyFlags.Texture);
        }

        public void SetTextureAndSamplerIdentitySwizzle(
            CommandBufferScoped cbs,
            ShaderStage stage,
            int binding,
            ITexture texture,
            ISampler sampler)
        {
            if (texture is TextureView view)
            {
<<<<<<< HEAD
                view.Storage.QueueWriteToReadBarrier(cbs, AccessFlags.ShaderReadBit, stage.ConvertToPipelineStageFlags());

                _textureRefs[binding] = new(stage, view.Storage, view.GetIdentityImageView(), ((SamplerHolder)sampler)?.GetSampler());
=======
                view.Storage.InsertWriteToReadBarrier(cbs, AccessFlags.ShaderReadBit, stage.ConvertToPipelineStageFlags());

                _textureRefs[binding] = view.GetIdentityImageView();
                _samplerRefs[binding] = ((SamplerHolder)sampler)?.GetSampler();
>>>>>>> 1ec71635b (sync with main branch)

                SignalDirty(DirtyFlags.Texture);
            }
            else
            {
                SetTextureAndSampler(cbs, stage, binding, texture, sampler);
            }
        }

        public void SetUniformBuffers(CommandBuffer commandBuffer, ReadOnlySpan<BufferAssignment> buffers)
        {
            for (int i = 0; i < buffers.Length; i++)
            {
                var assignment = buffers[i];
                var buffer = assignment.Range;
                int index = assignment.Binding;

<<<<<<< HEAD
                Auto<DisposableBuffer> vkBuffer = buffer.Handle == BufferHandle.Null
                    ? null
                    : _gd.BufferManager.GetBuffer(commandBuffer, buffer.Handle, false);

                ref BufferRef currentBufferRef = ref _uniformBufferRefs[index];

                DescriptorBufferInfo info = new()
                {
                    Offset = (ulong)buffer.Offset,
                    Range = (ulong)buffer.Size,
                };

                BufferRef newRef = new(vkBuffer, ref buffer);

                ref DescriptorBufferInfo currentInfo = ref _uniformBuffers[index];

                if (!currentBufferRef.Equals(newRef) || currentInfo.Range != info.Range)
                {
                    _uniformSet.Clear(index);
                    _uniformSetPd[index] = 0;

                    currentInfo = info;
                    currentBufferRef = newRef;
=======
                Auto<DisposableBuffer> vkBuffer = _gd.BufferManager.GetBuffer(commandBuffer, buffer.Handle, false);
                ref Auto<DisposableBuffer> currentVkBuffer = ref _uniformBufferRefs[index];

                DescriptorBufferInfo info = new DescriptorBufferInfo()
                {
                    Offset = (ulong)buffer.Offset,
                    Range = (ulong)buffer.Size
                };
                ref DescriptorBufferInfo currentInfo = ref _uniformBuffers[index];

                if (vkBuffer != currentVkBuffer || currentInfo.Offset != info.Offset || currentInfo.Range != info.Range)
                {
                    _uniformSet[index] = false;

                    currentInfo = info;
                    currentVkBuffer = vkBuffer;
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            SignalDirty(DirtyFlags.Uniform);
        }

        private void SignalDirty(DirtyFlags flag)
        {
            _dirty |= flag;
        }

        public void UpdateAndBindDescriptorSets(CommandBufferScoped cbs, PipelineBindPoint pbp)
        {
            if ((_dirty & DirtyFlags.All) == 0)
            {
                return;
            }

            if (_dirty.HasFlag(DirtyFlags.Uniform))
            {
                if (_program.UsePushDescriptors)
                {
                    UpdateAndBindUniformBufferPd(cbs, pbp);
                }
                else
                {
                    UpdateAndBind(cbs, PipelineBase.UniformSetIndex, pbp);
                }
            }

            if (_dirty.HasFlag(DirtyFlags.Storage))
            {
                UpdateAndBind(cbs, PipelineBase.StorageSetIndex, pbp);
            }

            if (_dirty.HasFlag(DirtyFlags.Texture))
            {
                UpdateAndBind(cbs, PipelineBase.TextureSetIndex, pbp);
            }

            if (_dirty.HasFlag(DirtyFlags.Image))
            {
                UpdateAndBind(cbs, PipelineBase.ImageSetIndex, pbp);
            }

            _dirty = DirtyFlags.None;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        private static bool UpdateBuffer(
            CommandBufferScoped cbs,
            ref DescriptorBufferInfo info,
            ref BufferRef buffer,
            Auto<DisposableBuffer> dummyBuffer,
            bool mirrorable)
        {
            int offset = buffer.Offset;
            bool mirrored = false;

            if (mirrorable)
            {
                info.Buffer = buffer.Buffer?.GetMirrorable(cbs, ref offset, (int)info.Range, out mirrored).Value ?? default;
            }
            else
            {
                info.Buffer = buffer.Buffer?.Get(cbs, offset, (int)info.Range, buffer.Write).Value ?? default;
            }

            info.Offset = (ulong)offset;
=======
        private static void UpdateBuffer(
            CommandBufferScoped cbs,
            ref DescriptorBufferInfo info,
            Auto<DisposableBuffer> buffer,
            Auto<DisposableBuffer> dummyBuffer)
        {
            info.Buffer = buffer?.Get(cbs, (int)info.Offset, (int)info.Range).Value ?? default;
>>>>>>> 1ec71635b (sync with main branch)

            // The spec requires that buffers with null handle have offset as 0 and range as VK_WHOLE_SIZE.
            if (info.Buffer.Handle == 0)
            {
                info.Buffer = dummyBuffer?.Get(cbs).Value ?? default;
                info.Offset = 0;
                info.Range = Vk.WholeSize;
            }
<<<<<<< HEAD

            return mirrored;
=======
>>>>>>> 1ec71635b (sync with main branch)
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateAndBind(CommandBufferScoped cbs, int setIndex, PipelineBindPoint pbp)
        {
            var program = _program;
            var bindingSegments = program.BindingSegments[setIndex];

<<<<<<< HEAD
            if (bindingSegments.Length == 0)
=======
            if (bindingSegments.Length == 0 && setIndex != PipelineBase.UniformSetIndex)
>>>>>>> 1ec71635b (sync with main branch)
            {
                return;
            }

            var dummyBuffer = _dummyBuffer?.GetBuffer();

<<<<<<< HEAD
            if (_updateDescriptorCacheCbIndex)
            {
                _updateDescriptorCacheCbIndex = false;
                program.UpdateDescriptorCacheCommandBufferIndex(cbs.CommandBufferIndex);
            }

            var dsc = program.GetNewDescriptorSetCollection(setIndex, out var isNew).Get(cbs);
=======
            var dsc = program.GetNewDescriptorSetCollection(_gd, cbs.CommandBufferIndex, setIndex, out var isNew).Get(cbs);
>>>>>>> 1ec71635b (sync with main branch)

            if (!program.HasMinimalLayout)
            {
                if (isNew)
                {
                    Initialize(cbs, setIndex, dsc);
                }
<<<<<<< HEAD
            }

            DescriptorSetTemplate template = program.Templates[setIndex];

            DescriptorSetTemplateWriter tu = _templateUpdater.Begin(template);

=======

                if (setIndex == PipelineBase.UniformSetIndex)
                {
                    Span<DescriptorBufferInfo> uniformBuffer = stackalloc DescriptorBufferInfo[1];

                    if (!_uniformSet[0])
                    {
                        _cachedSupportBuffer = _gd.BufferManager.GetBuffer(cbs.CommandBuffer, _pipeline.SupportBufferUpdater.Handle, false).Get(cbs, 0, SupportBuffer.RequiredSize).Value;
                        _uniformSet[0] = true;
                    }

                    uniformBuffer[0] = new DescriptorBufferInfo()
                    {
                        Offset = 0,
                        Range = (ulong)SupportBuffer.RequiredSize,
                        Buffer = _cachedSupportBuffer
                    };

                    dsc.UpdateBuffers(0, 0, uniformBuffer, DescriptorType.UniformBuffer);
                }
            }

>>>>>>> 1ec71635b (sync with main branch)
            foreach (ResourceBindingSegment segment in bindingSegments)
            {
                int binding = segment.Binding;
                int count = segment.Count;

                if (setIndex == PipelineBase.UniformSetIndex)
                {
                    for (int i = 0; i < count; i++)
                    {
                        int index = binding + i;

<<<<<<< HEAD
                        if (_uniformSet.Set(index))
                        {
                            ref BufferRef buffer = ref _uniformBufferRefs[index];

                            bool mirrored = UpdateBuffer(cbs, ref _uniformBuffers[index], ref buffer, dummyBuffer, true);

                            _uniformMirrored.Set(index, mirrored);
=======
                        if (!_uniformSet[index])
                        {
                            UpdateBuffer(cbs, ref _uniformBuffers[index], _uniformBufferRefs[index], dummyBuffer);

                            _uniformSet[index] = true;
>>>>>>> 1ec71635b (sync with main branch)
                        }
                    }

                    ReadOnlySpan<DescriptorBufferInfo> uniformBuffers = _uniformBuffers;
<<<<<<< HEAD

                    tu.Push(uniformBuffers.Slice(binding, count));
=======
                    dsc.UpdateBuffers(0, binding, uniformBuffers.Slice(binding, count), DescriptorType.UniformBuffer);
>>>>>>> 1ec71635b (sync with main branch)
                }
                else if (setIndex == PipelineBase.StorageSetIndex)
                {
                    for (int i = 0; i < count; i++)
                    {
                        int index = binding + i;

<<<<<<< HEAD
                        ref BufferRef buffer = ref _storageBufferRefs[index];

                        if (_storageSet.Set(index))
                        {
                            ref var info = ref _storageBuffers[index];

                            bool mirrored = UpdateBuffer(cbs,
                                ref info,
                                ref _storageBufferRefs[index],
                                dummyBuffer,
                                !buffer.Write && info.Range <= StorageBufferMaxMirrorable);

                            _storageMirrored.Set(index, mirrored);
=======
                        if (!_storageSet[index])
                        {
                            UpdateBuffer(cbs, ref _storageBuffers[index], _storageBufferRefs[index], dummyBuffer);

                            _storageSet[index] = true;
>>>>>>> 1ec71635b (sync with main branch)
                        }
                    }

                    ReadOnlySpan<DescriptorBufferInfo> storageBuffers = _storageBuffers;
<<<<<<< HEAD

                    tu.Push(storageBuffers.Slice(binding, count));
=======
                    if (program.HasMinimalLayout)
                    {
                        dsc.UpdateBuffers(0, binding, storageBuffers.Slice(binding, count), DescriptorType.StorageBuffer);
                    }
                    else
                    {
                        dsc.UpdateStorageBuffers(0, binding, storageBuffers.Slice(binding, count));
                    }
>>>>>>> 1ec71635b (sync with main branch)
                }
                else if (setIndex == PipelineBase.TextureSetIndex)
                {
                    if (segment.Type != ResourceType.BufferTexture)
                    {
                        Span<DescriptorImageInfo> textures = _textures;

                        for (int i = 0; i < count; i++)
                        {
                            ref var texture = ref textures[i];
<<<<<<< HEAD
                            ref var refs = ref _textureRefs[binding + i];

                            texture.ImageView = refs.View?.Get(cbs).Value ?? default;
                            texture.Sampler = refs.Sampler?.Get(cbs).Value ?? default;
=======

                            texture.ImageView = _textureRefs[binding + i]?.Get(cbs).Value ?? default;
                            texture.Sampler = _samplerRefs[binding + i]?.Get(cbs).Value ?? default;
>>>>>>> 1ec71635b (sync with main branch)

                            if (texture.ImageView.Handle == 0)
                            {
                                texture.ImageView = _dummyTexture.GetImageView().Get(cbs).Value;
                            }

                            if (texture.Sampler.Handle == 0)
                            {
                                texture.Sampler = _dummySampler.GetSampler().Get(cbs).Value;
                            }
                        }

<<<<<<< HEAD
                        tu.Push<DescriptorImageInfo>(textures[..count]);
=======
                        dsc.UpdateImages(0, binding, textures.Slice(0, count), DescriptorType.CombinedImageSampler);
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    else
                    {
                        Span<BufferView> bufferTextures = _bufferTextures;

                        for (int i = 0; i < count; i++)
                        {
<<<<<<< HEAD
                            bufferTextures[i] = _bufferTextureRefs[binding + i]?.GetBufferView(cbs, false) ?? default;
                        }

                        tu.Push<BufferView>(bufferTextures[..count]);
=======
                            bufferTextures[i] = _bufferTextureRefs[binding + i]?.GetBufferView(cbs) ?? default;
                        }

                        dsc.UpdateBufferImages(0, binding, bufferTextures.Slice(0, count), DescriptorType.UniformTexelBuffer);
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }
                else if (setIndex == PipelineBase.ImageSetIndex)
                {
                    if (segment.Type != ResourceType.BufferImage)
                    {
                        Span<DescriptorImageInfo> images = _images;

                        for (int i = 0; i < count; i++)
                        {
<<<<<<< HEAD
                            images[i].ImageView = _imageRefs[binding + i].View?.Get(cbs).Value ?? default;
                        }

                        tu.Push<DescriptorImageInfo>(images[..count]);
=======
                            images[i].ImageView = _imageRefs[binding + i]?.Get(cbs).Value ?? default;
                        }

                        dsc.UpdateImages(0, binding, images.Slice(0, count), DescriptorType.StorageImage);
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    else
                    {
                        Span<BufferView> bufferImages = _bufferImages;

                        for (int i = 0; i < count; i++)
                        {
<<<<<<< HEAD
                            bufferImages[i] = _bufferImageRefs[binding + i]?.GetBufferView(cbs, _bufferImageFormats[binding + i], true) ?? default;
                        }

                        tu.Push<BufferView>(bufferImages[..count]);
=======
                            bufferImages[i] = _bufferImageRefs[binding + i]?.GetBufferView(cbs, _bufferImageFormats[binding + i]) ?? default;
                        }

                        dsc.UpdateBufferImages(0, binding, bufferImages.Slice(0, count), DescriptorType.StorageTexelBuffer);
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }
            }

            var sets = dsc.GetSets();
<<<<<<< HEAD
            _templateUpdater.Commit(_gd, _device, sets[0]);
=======
>>>>>>> 1ec71635b (sync with main branch)

            _gd.Api.CmdBindDescriptorSets(cbs.CommandBuffer, pbp, _program.PipelineLayout, (uint)setIndex, 1, sets, 0, ReadOnlySpan<uint>.Empty);
        }

        private unsafe void UpdateBuffers(
            CommandBufferScoped cbs,
            PipelineBindPoint pbp,
            int baseBinding,
            ReadOnlySpan<DescriptorBufferInfo> bufferInfo,
            DescriptorType type)
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
                    DstBinding = (uint)baseBinding,
                    DescriptorType = type,
                    DescriptorCount = (uint)bufferInfo.Length,
<<<<<<< HEAD
                    PBufferInfo = pBufferInfo,
=======
                    PBufferInfo = pBufferInfo
>>>>>>> 1ec71635b (sync with main branch)
                };

                _gd.PushDescriptorApi.CmdPushDescriptorSet(cbs.CommandBuffer, pbp, _program.PipelineLayout, 0, 1, &writeDescriptorSet);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateAndBindUniformBufferPd(CommandBufferScoped cbs, PipelineBindPoint pbp)
        {
<<<<<<< HEAD
            int sequence = _pdSequence;
            var bindingSegments = _program.BindingSegments[PipelineBase.UniformSetIndex];
            var dummyBuffer = _dummyBuffer?.GetBuffer();

            long updatedBindings = 0;
            DescriptorSetTemplateWriter writer = _templateUpdater.Begin(32 * Unsafe.SizeOf<DescriptorBufferInfo>());

=======
            if (!_uniformSet[0])
            {
                Span<DescriptorBufferInfo> uniformBuffer = stackalloc DescriptorBufferInfo[1];

                uniformBuffer[0] = new DescriptorBufferInfo()
                {
                    Offset = 0,
                    Range = (ulong)SupportBuffer.RequiredSize,
                    Buffer = _gd.BufferManager.GetBuffer(cbs.CommandBuffer, _pipeline.SupportBufferUpdater.Handle, false).Get(cbs, 0, SupportBuffer.RequiredSize).Value
                };

                _uniformSet[0] = true;

                UpdateBuffers(cbs, pbp, 0, uniformBuffer, DescriptorType.UniformBuffer);
            }

            var bindingSegments = _program.BindingSegments[PipelineBase.UniformSetIndex];
            var dummyBuffer = _dummyBuffer?.GetBuffer();

>>>>>>> 1ec71635b (sync with main branch)
            foreach (ResourceBindingSegment segment in bindingSegments)
            {
                int binding = segment.Binding;
                int count = segment.Count;

<<<<<<< HEAD
                ReadOnlySpan<DescriptorBufferInfo> uniformBuffers = _uniformBuffers;
=======
                bool doUpdate = false;
>>>>>>> 1ec71635b (sync with main branch)

                for (int i = 0; i < count; i++)
                {
                    int index = binding + i;

<<<<<<< HEAD
                    if (_uniformSet.Set(index))
                    {
                        ref BufferRef buffer = ref _uniformBufferRefs[index];

                        bool mirrored = UpdateBuffer(cbs, ref _uniformBuffers[index], ref buffer, dummyBuffer, true);

                        _uniformMirrored.Set(index, mirrored);
                    }

                    if (_uniformSetPd[index] != sequence)
                    {
                        // Need to set this push descriptor (even if the buffer binding has not changed)

                        _uniformSetPd[index] = sequence;
                        updatedBindings |= 1L << index;

                        writer.Push(MemoryMarshal.CreateReadOnlySpan(ref _uniformBuffers[index], 1));
                    }
                }
            }

            if (updatedBindings > 0)
            {
                DescriptorSetTemplate template = _program.GetPushDescriptorTemplate(updatedBindings);
                _templateUpdater.CommitPushDescriptor(_gd, cbs, template, _program.PipelineLayout);
            }
        }

        private void Initialize(CommandBufferScoped cbs, int setIndex, DescriptorSetCollection dsc)
        {
            // We don't support clearing texture descriptors currently.
            if (setIndex != PipelineBase.UniformSetIndex && setIndex != PipelineBase.StorageSetIndex)
            {
                return;
            }

            var dummyBuffer = _dummyBuffer?.GetBuffer().Get(cbs).Value ?? default;

            foreach (ResourceBindingSegment segment in _program.ClearSegments[setIndex])
            {
                dsc.InitializeBuffers(0, segment.Binding, segment.Count, segment.Type.Convert(), dummyBuffer);
=======
                    if (!_uniformSet[index])
                    {
                        UpdateBuffer(cbs, ref _uniformBuffers[index], _uniformBufferRefs[index], dummyBuffer);
                        _uniformSet[index] = true;
                        doUpdate = true;
                    }
                }

                if (doUpdate)
                {
                    ReadOnlySpan<DescriptorBufferInfo> uniformBuffers = _uniformBuffers;
                    UpdateBuffers(cbs, pbp, binding, uniformBuffers.Slice(binding, count), DescriptorType.UniformBuffer);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Initialize(CommandBufferScoped cbs, int setIndex, DescriptorSetCollection dsc)
        {
            var dummyBuffer = _dummyBuffer?.GetBuffer().Get(cbs).Value ?? default;

            uint stages = _program.Stages;

            while (stages != 0)
            {
                int stage = BitOperations.TrailingZeroCount(stages);
                stages &= ~(1u << stage);

                if (setIndex == PipelineBase.UniformSetIndex)
                {
                    dsc.InitializeBuffers(
                        0,
                        1 + stage * Constants.MaxUniformBuffersPerStage,
                        Constants.MaxUniformBuffersPerStage,
                        DescriptorType.UniformBuffer,
                        dummyBuffer);
                }
                else if (setIndex == PipelineBase.StorageSetIndex)
                {
                    dsc.InitializeBuffers(
                        0,
                        stage * Constants.MaxStorageBuffersPerStage,
                        Constants.MaxStorageBuffersPerStage,
                        DescriptorType.StorageBuffer,
                        dummyBuffer);
                }
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public void SignalCommandBufferChange()
        {
<<<<<<< HEAD
            _updateDescriptorCacheCbIndex = true;
            _dirty = DirtyFlags.All;

            _uniformSet.Clear();
            _storageSet.Clear();
            AdvancePdSequence();
        }

        private static void SwapBuffer(BufferRef[] list, Auto<DisposableBuffer> from, Auto<DisposableBuffer> to)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Buffer == from)
                {
                    list[i].Buffer = to;
=======
            _dirty = DirtyFlags.All;

            Array.Clear(_uniformSet);
            Array.Clear(_storageSet);
        }

        private void SwapBuffer(Auto<DisposableBuffer>[] list, Auto<DisposableBuffer> from, Auto<DisposableBuffer> to)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == from)
                {
                    list[i] = to;
>>>>>>> 1ec71635b (sync with main branch)
                }
            }
        }

        public void SwapBuffer(Auto<DisposableBuffer> from, Auto<DisposableBuffer> to)
        {
            SwapBuffer(_uniformBufferRefs, from, to);
            SwapBuffer(_storageBufferRefs, from, to);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dummyTexture.Dispose();
                _dummySampler.Dispose();
<<<<<<< HEAD
                _templateUpdater.Dispose();
=======
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
