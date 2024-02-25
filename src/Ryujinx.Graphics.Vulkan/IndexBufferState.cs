<<<<<<< HEAD
using Ryujinx.Graphics.GAL;
using IndexType = Silk.NET.Vulkan.IndexType;
=======
﻿using Silk.NET.Vulkan;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    internal struct IndexBufferState
    {
<<<<<<< HEAD
        private const int IndexBufferMaxMirrorable = 0x20000;

        public static IndexBufferState Null => new(BufferHandle.Null, 0, 0);
=======
        public static IndexBufferState Null => new IndexBufferState(GAL.BufferHandle.Null, 0, 0);
>>>>>>> 1ec71635b (sync with main branch)

        private readonly int _offset;
        private readonly int _size;
        private readonly IndexType _type;

<<<<<<< HEAD
        private readonly BufferHandle _handle;
        private Auto<DisposableBuffer> _buffer;

        public IndexBufferState(BufferHandle handle, int offset, int size, IndexType type)
=======
        private readonly GAL.BufferHandle _handle;
        private Auto<DisposableBuffer> _buffer;

        public IndexBufferState(GAL.BufferHandle handle, int offset, int size, IndexType type)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _handle = handle;
            _offset = offset;
            _size = size;
            _type = type;
            _buffer = null;
        }

<<<<<<< HEAD
        public IndexBufferState(BufferHandle handle, int offset, int size)
=======
        public IndexBufferState(GAL.BufferHandle handle, int offset, int size)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _handle = handle;
            _offset = offset;
            _size = size;
            _type = IndexType.Uint16;
            _buffer = null;
        }

        public void BindIndexBuffer(VulkanRenderer gd, CommandBufferScoped cbs)
        {
            Auto<DisposableBuffer> autoBuffer;
            int offset, size;
            IndexType type = _type;
<<<<<<< HEAD
            bool mirrorable = false;
=======
>>>>>>> 1ec71635b (sync with main branch)

            if (_type == IndexType.Uint8Ext && !gd.Capabilities.SupportsIndexTypeUint8)
            {
                // Index type is not supported. Convert to I16.
                autoBuffer = gd.BufferManager.GetBufferI8ToI16(cbs, _handle, _offset, _size);

                type = IndexType.Uint16;
                offset = 0;
                size = _size * 2;
            }
            else
            {
                autoBuffer = gd.BufferManager.GetBuffer(cbs.CommandBuffer, _handle, false, out int bufferSize);

                if (_offset >= bufferSize)
                {
                    autoBuffer = null;
                }

<<<<<<< HEAD
                mirrorable = _size < IndexBufferMaxMirrorable;

=======
>>>>>>> 1ec71635b (sync with main branch)
                offset = _offset;
                size = _size;
            }

            _buffer = autoBuffer;

            if (autoBuffer != null)
            {
<<<<<<< HEAD
                DisposableBuffer buffer = mirrorable ? autoBuffer.GetMirrorable(cbs, ref offset, size, out _) : autoBuffer.Get(cbs, offset, size);

                gd.Api.CmdBindIndexBuffer(cbs.CommandBuffer, buffer.Value, (ulong)offset, type);
=======
                gd.Api.CmdBindIndexBuffer(cbs.CommandBuffer, autoBuffer.Get(cbs, offset, size).Value, (ulong)offset, type);
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public void BindConvertedIndexBuffer(
            VulkanRenderer gd,
            CommandBufferScoped cbs,
            int firstIndex,
            int indexCount,
            int convertedCount,
            IndexBufferPattern pattern)
        {
            Auto<DisposableBuffer> autoBuffer;

            // Convert the index buffer using the given pattern.
            int indexSize = GetIndexSize();

            int firstIndexOffset = firstIndex * indexSize;

            autoBuffer = gd.BufferManager.GetBufferTopologyConversion(cbs, _handle, _offset + firstIndexOffset, indexCount * indexSize, pattern, indexSize);

            int size = convertedCount * 4;

            _buffer = autoBuffer;

            if (autoBuffer != null)
            {
                gd.Api.CmdBindIndexBuffer(cbs.CommandBuffer, autoBuffer.Get(cbs, 0, size).Value, 0, IndexType.Uint32);
            }
        }

        public Auto<DisposableBuffer> BindConvertedIndexBufferIndirect(
            VulkanRenderer gd,
            CommandBufferScoped cbs,
<<<<<<< HEAD
            BufferRange indirectBuffer,
            BufferRange drawCountBuffer,
=======
            GAL.BufferRange indirectBuffer,
            GAL.BufferRange drawCountBuffer,
>>>>>>> 1ec71635b (sync with main branch)
            IndexBufferPattern pattern,
            bool hasDrawCount,
            int maxDrawCount,
            int indirectDataStride)
        {
            // Convert the index buffer using the given pattern.
            int indexSize = GetIndexSize();

            (var indexBufferAuto, var indirectBufferAuto) = gd.BufferManager.GetBufferTopologyConversionIndirect(
                gd,
                cbs,
<<<<<<< HEAD
                new BufferRange(_handle, _offset, _size),
=======
                new GAL.BufferRange(_handle, _offset, _size),
>>>>>>> 1ec71635b (sync with main branch)
                indirectBuffer,
                drawCountBuffer,
                pattern,
                indexSize,
                hasDrawCount,
                maxDrawCount,
                indirectDataStride);

            int convertedCount = pattern.GetConvertedCount(_size / indexSize);
            int size = convertedCount * 4;

            _buffer = indexBufferAuto;

            if (indexBufferAuto != null)
            {
                gd.Api.CmdBindIndexBuffer(cbs.CommandBuffer, indexBufferAuto.Get(cbs, 0, size).Value, 0, IndexType.Uint32);
            }

            return indirectBufferAuto;
        }

<<<<<<< HEAD
        private readonly int GetIndexSize()
=======
        private int GetIndexSize()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _type switch
            {
                IndexType.Uint32 => 4,
                IndexType.Uint16 => 2,
                _ => 1,
            };
        }

<<<<<<< HEAD
        public readonly bool BoundEquals(Auto<DisposableBuffer> buffer)
=======
        public bool BoundEquals(Auto<DisposableBuffer> buffer)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _buffer == buffer;
        }

        public void Swap(Auto<DisposableBuffer> from, Auto<DisposableBuffer> to)
        {
            if (_buffer == from)
            {
<<<<<<< HEAD
                _buffer = to;
            }
        }

        public readonly bool Overlaps(Auto<DisposableBuffer> buffer, int offset, int size)
        {
            return buffer == _buffer && offset < _offset + _size && offset + size > _offset;
        }
=======
                _buffer.DecrementReferenceCount();
                to.IncrementReferenceCount();

                _buffer = to;
            }
        }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
