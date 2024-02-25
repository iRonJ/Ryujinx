<<<<<<< HEAD
using System;
=======
﻿using Silk.NET.Vulkan;
using System;

>>>>>>> 1ec71635b (sync with main branch)
using VkBuffer = Silk.NET.Vulkan.Buffer;

namespace Ryujinx.Graphics.Vulkan
{
    internal class VertexBufferUpdater : IDisposable
    {
<<<<<<< HEAD
        private readonly VulkanRenderer _gd;
=======
        private VulkanRenderer _gd;
>>>>>>> 1ec71635b (sync with main branch)

        private uint _baseBinding;
        private uint _count;

<<<<<<< HEAD
        private readonly NativeArray<VkBuffer> _buffers;
        private readonly NativeArray<ulong> _offsets;
        private readonly NativeArray<ulong> _sizes;
        private readonly NativeArray<ulong> _strides;
=======
        private NativeArray<VkBuffer> _buffers;
        private NativeArray<ulong> _offsets;
        private NativeArray<ulong> _sizes;
        private NativeArray<ulong> _strides;
>>>>>>> 1ec71635b (sync with main branch)

        public VertexBufferUpdater(VulkanRenderer gd)
        {
            _gd = gd;

            _buffers = new NativeArray<VkBuffer>(Constants.MaxVertexBuffers);
            _offsets = new NativeArray<ulong>(Constants.MaxVertexBuffers);
            _sizes = new NativeArray<ulong>(Constants.MaxVertexBuffers);
            _strides = new NativeArray<ulong>(Constants.MaxVertexBuffers);
        }

        public void BindVertexBuffer(CommandBufferScoped cbs, uint binding, VkBuffer buffer, ulong offset, ulong size, ulong stride)
        {
            if (_count == 0)
            {
                _baseBinding = binding;
            }
            else if (_baseBinding + _count != binding)
            {
                Commit(cbs);
                _baseBinding = binding;
            }

            int index = (int)_count;

            _buffers[index] = buffer;
            _offsets[index] = offset;
            _sizes[index] = size;
            _strides[index] = stride;

            _count++;
        }

        public unsafe void Commit(CommandBufferScoped cbs)
        {
            if (_count != 0)
            {
                if (_gd.Capabilities.SupportsExtendedDynamicState)
                {
                    _gd.ExtendedDynamicStateApi.CmdBindVertexBuffers2(
                        cbs.CommandBuffer,
                        _baseBinding,
                        _count,
                        _buffers.Pointer,
                        _offsets.Pointer,
                        _sizes.Pointer,
                        _strides.Pointer);
                }
                else
                {
                    _gd.Api.CmdBindVertexBuffers(cbs.CommandBuffer, _baseBinding, _count, _buffers.Pointer, _offsets.Pointer);
                }

                _count = 0;
            }
        }

        public void Dispose()
        {
            _buffers.Dispose();
            _offsets.Dispose();
            _sizes.Dispose();
            _strides.Dispose();
        }
    }
}
