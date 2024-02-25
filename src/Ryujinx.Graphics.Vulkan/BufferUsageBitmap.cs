<<<<<<< HEAD
namespace Ryujinx.Graphics.Vulkan
{
    internal class BufferUsageBitmap
    {
        private readonly BitMap _bitmap;
        private readonly int _size;
        private readonly int _granularity;
        private readonly int _bits;
        private readonly int _writeBitOffset;

        private readonly int _intsPerCb;
        private readonly int _bitsPerCb;
=======
﻿namespace Ryujinx.Graphics.Vulkan
{
    internal class BufferUsageBitmap
    {
        private BitMap _bitmap;
        private int _size;
        private int _granularity;
        private int _bits;

        private int _intsPerCb;
        private int _bitsPerCb;
>>>>>>> 1ec71635b (sync with main branch)

        public BufferUsageBitmap(int size, int granularity)
        {
            _size = size;
            _granularity = granularity;
<<<<<<< HEAD

            // There are two sets of bits - one for read tracking, and the other for write.
            int bits = (size + (granularity - 1)) / granularity;
            _writeBitOffset = bits;
            _bits = bits << 1;
=======
            _bits = (size + (granularity - 1)) / granularity;
>>>>>>> 1ec71635b (sync with main branch)

            _intsPerCb = (_bits + (BitMap.IntSize - 1)) / BitMap.IntSize;
            _bitsPerCb = _intsPerCb * BitMap.IntSize;

            _bitmap = new BitMap(_bitsPerCb * CommandBufferPool.MaxCommandBuffers);
        }

<<<<<<< HEAD
        public void Add(int cbIndex, int offset, int size, bool write)
=======
        public void Add(int cbIndex, int offset, int size)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (size == 0)
            {
                return;
            }

            // Some usages can be out of bounds (vertex buffer on amd), so bound if necessary.
            if (offset + size > _size)
            {
                size = _size - offset;
            }

<<<<<<< HEAD
            int cbBase = cbIndex * _bitsPerCb + (write ? _writeBitOffset : 0);
=======
            int cbBase = cbIndex * _bitsPerCb;
>>>>>>> 1ec71635b (sync with main branch)
            int start = cbBase + offset / _granularity;
            int end = cbBase + (offset + size - 1) / _granularity;

            _bitmap.SetRange(start, end);
        }

<<<<<<< HEAD
        public bool OverlapsWith(int cbIndex, int offset, int size, bool write = false)
=======
        public bool OverlapsWith(int cbIndex, int offset, int size)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (size == 0)
            {
                return false;
            }

<<<<<<< HEAD
            int cbBase = cbIndex * _bitsPerCb + (write ? _writeBitOffset : 0);
=======
            int cbBase = cbIndex * _bitsPerCb;
>>>>>>> 1ec71635b (sync with main branch)
            int start = cbBase + offset / _granularity;
            int end = cbBase + (offset + size - 1) / _granularity;

            return _bitmap.IsSet(start, end);
        }

<<<<<<< HEAD
        public bool OverlapsWith(int offset, int size, bool write)
        {
            for (int i = 0; i < CommandBufferPool.MaxCommandBuffers; i++)
            {
                if (OverlapsWith(i, offset, size, write))
=======
        public bool OverlapsWith(int offset, int size)
        {
            for (int i = 0; i < CommandBufferPool.MaxCommandBuffers; i++)
            {
                if (OverlapsWith(i, offset, size))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear(int cbIndex)
        {
            _bitmap.ClearInt(cbIndex * _intsPerCb, (cbIndex + 1) * _intsPerCb - 1);
        }
    }
}
