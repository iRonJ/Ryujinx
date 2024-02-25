<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    struct BufferState : IDisposable
    {
<<<<<<< HEAD
        public static BufferState Null => new(null, 0, 0);
=======
        public static BufferState Null => new BufferState(null, 0, 0);
>>>>>>> 1ec71635b (sync with main branch)

        private readonly int _offset;
        private readonly int _size;

        private Auto<DisposableBuffer> _buffer;

        public BufferState(Auto<DisposableBuffer> buffer, int offset, int size)
        {
            _buffer = buffer;
            _offset = offset;
            _size = size;
            buffer?.IncrementReferenceCount();
        }

<<<<<<< HEAD
        public readonly void BindTransformFeedbackBuffer(VulkanRenderer gd, CommandBufferScoped cbs, uint binding)
        {
            if (_buffer != null)
            {
                var buffer = _buffer.Get(cbs, _offset, _size, true).Value;
=======
        public void BindTransformFeedbackBuffer(VulkanRenderer gd, CommandBufferScoped cbs, uint binding)
        {
            if (_buffer != null)
            {
                var buffer = _buffer.Get(cbs, _offset, _size).Value;
>>>>>>> 1ec71635b (sync with main branch)

                gd.TransformFeedbackApi.CmdBindTransformFeedbackBuffers(cbs.CommandBuffer, binding, 1, buffer, (ulong)_offset, (ulong)_size);
            }
        }

        public void Swap(Auto<DisposableBuffer> from, Auto<DisposableBuffer> to)
        {
            if (_buffer == from)
            {
                _buffer.DecrementReferenceCount();
                to.IncrementReferenceCount();

                _buffer = to;
            }
        }

<<<<<<< HEAD
        public readonly bool Overlaps(Auto<DisposableBuffer> buffer, int offset, int size)
        {
            return buffer == _buffer && offset < _offset + _size && offset + size > _offset;
        }

        public readonly void Dispose()
=======
        public void Dispose()
>>>>>>> 1ec71635b (sync with main branch)
        {
            _buffer?.DecrementReferenceCount();
        }
    }
}
