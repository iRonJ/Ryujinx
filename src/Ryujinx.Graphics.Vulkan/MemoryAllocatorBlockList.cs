<<<<<<< HEAD
using Ryujinx.Common;
=======
﻿using Ryujinx.Common;
>>>>>>> 1ec71635b (sync with main branch)
using Silk.NET.Vulkan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
<<<<<<< HEAD
using System.Threading;
=======
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    class MemoryAllocatorBlockList : IDisposable
    {
        private const ulong InvalidOffset = ulong.MaxValue;

        public class Block : IComparable<Block>
        {
            public DeviceMemory Memory { get; private set; }
            public IntPtr HostPointer { get; private set; }
            public ulong Size { get; }
            public bool Mapped => HostPointer != IntPtr.Zero;

            private readonly struct Range : IComparable<Range>
            {
                public ulong Offset { get; }
                public ulong Size { get; }

                public Range(ulong offset, ulong size)
                {
                    Offset = offset;
                    Size = size;
                }

                public int CompareTo(Range other)
                {
                    return Offset.CompareTo(other.Offset);
                }
            }

            private readonly List<Range> _freeRanges;

            public Block(DeviceMemory memory, IntPtr hostPointer, ulong size)
            {
                Memory = memory;
                HostPointer = hostPointer;
                Size = size;
                _freeRanges = new List<Range>
                {
<<<<<<< HEAD
                    new Range(0, size),
=======
                    new Range(0, size)
>>>>>>> 1ec71635b (sync with main branch)
                };
            }

            public ulong Allocate(ulong size, ulong alignment)
            {
                for (int i = 0; i < _freeRanges.Count; i++)
                {
                    var range = _freeRanges[i];

<<<<<<< HEAD
                    ulong alignedOffset = BitUtils.AlignUp(range.Offset, alignment);
=======
                    ulong alignedOffset = BitUtils.AlignUp<ulong>(range.Offset, alignment);
>>>>>>> 1ec71635b (sync with main branch)
                    ulong sizeDelta = alignedOffset - range.Offset;
                    ulong usableSize = range.Size - sizeDelta;

                    if (sizeDelta < range.Size && usableSize >= size)
                    {
                        _freeRanges.RemoveAt(i);

                        if (sizeDelta != 0)
                        {
                            InsertFreeRange(range.Offset, sizeDelta);
                        }

                        ulong endOffset = range.Offset + range.Size;
                        ulong remainingSize = endOffset - (alignedOffset + size);
                        if (remainingSize != 0)
                        {
                            InsertFreeRange(endOffset - remainingSize, remainingSize);
                        }

                        return alignedOffset;
                    }
                }

                return InvalidOffset;
            }

            public void Free(ulong offset, ulong size)
            {
                InsertFreeRangeComingled(offset, size);
            }

            private void InsertFreeRange(ulong offset, ulong size)
            {
                var range = new Range(offset, size);
                int index = _freeRanges.BinarySearch(range);
                if (index < 0)
                {
                    index = ~index;
                }

                _freeRanges.Insert(index, range);
            }

            private void InsertFreeRangeComingled(ulong offset, ulong size)
            {
                ulong endOffset = offset + size;
                var range = new Range(offset, size);
                int index = _freeRanges.BinarySearch(range);
                if (index < 0)
                {
                    index = ~index;
                }

                if (index < _freeRanges.Count && _freeRanges[index].Offset == endOffset)
                {
                    endOffset = _freeRanges[index].Offset + _freeRanges[index].Size;
                    _freeRanges.RemoveAt(index);
                }

                if (index > 0 && _freeRanges[index - 1].Offset + _freeRanges[index - 1].Size == offset)
                {
                    offset = _freeRanges[index - 1].Offset;
                    _freeRanges.RemoveAt(--index);
                }

                range = new Range(offset, endOffset - offset);

                _freeRanges.Insert(index, range);
            }

            public bool IsTotallyFree()
            {
                if (_freeRanges.Count == 1 && _freeRanges[0].Size == Size)
                {
                    Debug.Assert(_freeRanges[0].Offset == 0);
                    return true;
                }

                return false;
            }

            public int CompareTo(Block other)
            {
                return Size.CompareTo(other.Size);
            }

            public unsafe void Destroy(Vk api, Device device)
            {
                if (Mapped)
                {
                    api.UnmapMemory(device, Memory);
                    HostPointer = IntPtr.Zero;
                }

                if (Memory.Handle != 0)
                {
                    api.FreeMemory(device, Memory, null);
                    Memory = default;
                }
            }
        }

        private readonly List<Block> _blocks;

        private readonly Vk _api;
        private readonly Device _device;

        public int MemoryTypeIndex { get; }
        public bool ForBuffer { get; }

        private readonly int _blockAlignment;

<<<<<<< HEAD
        private readonly ReaderWriterLockSlim _lock;

=======
>>>>>>> 1ec71635b (sync with main branch)
        public MemoryAllocatorBlockList(Vk api, Device device, int memoryTypeIndex, int blockAlignment, bool forBuffer)
        {
            _blocks = new List<Block>();
            _api = api;
            _device = device;
            MemoryTypeIndex = memoryTypeIndex;
            ForBuffer = forBuffer;
            _blockAlignment = blockAlignment;
<<<<<<< HEAD
            _lock = new(LockRecursionPolicy.NoRecursion);
=======
>>>>>>> 1ec71635b (sync with main branch)
        }

        public unsafe MemoryAllocation Allocate(ulong size, ulong alignment, bool map)
        {
            // Ensure we have a sane alignment value.
            if ((ulong)(int)alignment != alignment || (int)alignment <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(alignment), $"Invalid alignment 0x{alignment:X}.");
            }

<<<<<<< HEAD
            _lock.EnterReadLock();

            try
            {
                for (int i = 0; i < _blocks.Count; i++)
                {
                    var block = _blocks[i];

                    if (block.Mapped == map && block.Size >= size)
                    {
                        ulong offset = block.Allocate(size, alignment);
                        if (offset != InvalidOffset)
                        {
                            return new MemoryAllocation(this, block, block.Memory, GetHostPointer(block, offset), offset, size);
                        }
                    }
                }
            }
            finally
            {
                _lock.ExitReadLock();
            }

            ulong blockAlignedSize = BitUtils.AlignUp(size, (ulong)_blockAlignment);

            var memoryAllocateInfo = new MemoryAllocateInfo
            {
                SType = StructureType.MemoryAllocateInfo,
                AllocationSize = blockAlignedSize,
                MemoryTypeIndex = (uint)MemoryTypeIndex,
=======
            for (int i = 0; i < _blocks.Count; i++)
            {
                var block = _blocks[i];

                if (block.Mapped == map && block.Size >= size)
                {
                    ulong offset = block.Allocate(size, alignment);
                    if (offset != InvalidOffset)
                    {
                        return new MemoryAllocation(this, block, block.Memory, GetHostPointer(block, offset), offset, size);
                    }
                }
            }

            ulong blockAlignedSize = BitUtils.AlignUp<ulong>(size, (ulong)_blockAlignment);

            var memoryAllocateInfo = new MemoryAllocateInfo()
            {
                SType = StructureType.MemoryAllocateInfo,
                AllocationSize = blockAlignedSize,
                MemoryTypeIndex = (uint)MemoryTypeIndex
>>>>>>> 1ec71635b (sync with main branch)
            };

            _api.AllocateMemory(_device, memoryAllocateInfo, null, out var deviceMemory).ThrowOnError();

            IntPtr hostPointer = IntPtr.Zero;

            if (map)
            {
<<<<<<< HEAD
                void* pointer = null;
                _api.MapMemory(_device, deviceMemory, 0, blockAlignedSize, 0, ref pointer).ThrowOnError();
                hostPointer = (IntPtr)pointer;
=======
                unsafe
                {
                    void* pointer = null;
                    _api.MapMemory(_device, deviceMemory, 0, blockAlignedSize, 0, ref pointer).ThrowOnError();
                    hostPointer = (IntPtr)pointer;
                }
>>>>>>> 1ec71635b (sync with main branch)
            }

            var newBlock = new Block(deviceMemory, hostPointer, blockAlignedSize);

            InsertBlock(newBlock);

            ulong newBlockOffset = newBlock.Allocate(size, alignment);
            Debug.Assert(newBlockOffset != InvalidOffset);

            return new MemoryAllocation(this, newBlock, deviceMemory, GetHostPointer(newBlock, newBlockOffset), newBlockOffset, size);
        }

        private static IntPtr GetHostPointer(Block block, ulong offset)
        {
            if (block.HostPointer == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

<<<<<<< HEAD
            return (IntPtr)((nuint)block.HostPointer + offset);
        }

        public void Free(Block block, ulong offset, ulong size)
=======
            return (IntPtr)((nuint)(nint)block.HostPointer + offset);
        }

        public unsafe void Free(Block block, ulong offset, ulong size)
>>>>>>> 1ec71635b (sync with main branch)
        {
            block.Free(offset, size);

            if (block.IsTotallyFree())
            {
<<<<<<< HEAD
                _lock.EnterWriteLock();

                try
                {
                    for (int i = 0; i < _blocks.Count; i++)
                    {
                        if (_blocks[i] == block)
                        {
                            _blocks.RemoveAt(i);
                            break;
                        }
                    }
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
=======
                for (int i = 0; i < _blocks.Count; i++)
                {
                    if (_blocks[i] == block)
                    {
                        _blocks.RemoveAt(i);
                        break;
                    }
                }
>>>>>>> 1ec71635b (sync with main branch)

                block.Destroy(_api, _device);
            }
        }

        private void InsertBlock(Block block)
        {
<<<<<<< HEAD
            _lock.EnterWriteLock();

            try
            {
                int index = _blocks.BinarySearch(block);
                if (index < 0)
                {
                    index = ~index;
                }

                _blocks.Insert(index, block);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void Dispose()
=======
            int index = _blocks.BinarySearch(block);
            if (index < 0)
            {
                index = ~index;
            }

            _blocks.Insert(index, block);
        }

        public unsafe void Dispose()
>>>>>>> 1ec71635b (sync with main branch)
        {
            for (int i = 0; i < _blocks.Count; i++)
            {
                _blocks[i].Destroy(_api, _device);
            }
        }
    }
}
