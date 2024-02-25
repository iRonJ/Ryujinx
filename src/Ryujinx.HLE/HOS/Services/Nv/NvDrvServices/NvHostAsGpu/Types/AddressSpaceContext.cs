<<<<<<< HEAD
using Ryujinx.Graphics.Gpu.Memory;
=======
﻿using Ryujinx.Graphics.Gpu.Memory;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostAsGpu.Types
{
    class AddressSpaceContext
    {
        private class Range
        {
            public ulong Start { get; }
<<<<<<< HEAD
            public ulong End { get; }
=======
            public ulong End   { get; }
>>>>>>> 1ec71635b (sync with main branch)

            public Range(ulong address, ulong size)
            {
                Start = address;
<<<<<<< HEAD
                End = size + Start;
=======
                End   = size + Start;
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private class MappedMemory : Range
        {
            public ulong PhysicalAddress { get; }
<<<<<<< HEAD
            public bool VaAllocated { get; }
=======
            public bool  VaAllocated     { get; }
>>>>>>> 1ec71635b (sync with main branch)

            public MappedMemory(ulong address, ulong size, ulong physicalAddress, bool vaAllocated) : base(address, size)
            {
                PhysicalAddress = physicalAddress;
<<<<<<< HEAD
                VaAllocated = vaAllocated;
=======
                VaAllocated     = vaAllocated;
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public MemoryManager Gmm { get; }

        private readonly SortedList<ulong, Range> _maps;
        private readonly SortedList<ulong, Range> _reservations;

        public AddressSpaceContext(MemoryManager gmm)
        {
            Gmm = gmm;

<<<<<<< HEAD
            _maps = new SortedList<ulong, Range>();
=======
            _maps         = new SortedList<ulong, Range>();
>>>>>>> 1ec71635b (sync with main branch)
            _reservations = new SortedList<ulong, Range>();
        }

        public bool ValidateFixedBuffer(ulong address, ulong size, ulong alignment)
        {
            ulong mapEnd = address + size;

            // Check if size is valid (0 is also not allowed).
            if (mapEnd <= address)
            {
                return false;
            }

            // Check if address is aligned.
            if ((address & (alignment - 1)) != 0)
            {
                return false;
            }

            // Check if region is reserved.
            if (BinarySearch(_reservations, address) == null)
            {
                return false;
            }

            // Check for overlap with already mapped buffers.
            Range map = BinarySearchLt(_maps, mapEnd);

            if (map != null && map.End > address)
            {
                return false;
            }

            return true;
        }

        public void AddMap(ulong gpuVa, ulong size, ulong physicalAddress, bool vaAllocated)
        {
            _maps.Add(gpuVa, new MappedMemory(gpuVa, size, physicalAddress, vaAllocated));
        }

        public bool RemoveMap(ulong gpuVa, out ulong size)
        {
            size = 0;

            if (_maps.Remove(gpuVa, out Range value))
            {
                MappedMemory map = (MappedMemory)value;

                if (map.VaAllocated)
                {
                    size = (map.End - map.Start);
                }

                return true;
            }

            return false;
        }

        public bool TryGetMapPhysicalAddress(ulong gpuVa, out ulong physicalAddress)
        {
            Range map = BinarySearch(_maps, gpuVa);

            if (map != null)
            {
                physicalAddress = ((MappedMemory)map).PhysicalAddress;
                return true;
            }

            physicalAddress = 0;
            return false;
        }

        public void AddReservation(ulong gpuVa, ulong size)
        {
            _reservations.Add(gpuVa, new Range(gpuVa, size));
        }

        public bool RemoveReservation(ulong gpuVa)
        {
            return _reservations.Remove(gpuVa);
        }

<<<<<<< HEAD
        private Range BinarySearch(SortedList<ulong, Range> list, ulong address)
        {
            int left = 0;
=======
        private static Range BinarySearch(SortedList<ulong, Range> list, ulong address)
        {
            int left  = 0;
>>>>>>> 1ec71635b (sync with main branch)
            int right = list.Count - 1;

            while (left <= right)
            {
                int size = right - left;

                int middle = left + (size >> 1);

                Range rg = list.Values[middle];

                if (address >= rg.Start && address < rg.End)
                {
                    return rg;
                }

                if (address < rg.Start)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return null;
        }

<<<<<<< HEAD
        private Range BinarySearchLt(SortedList<ulong, Range> list, ulong address)
        {
            Range ltRg = null;

            int left = 0;
=======
        private static Range BinarySearchLt(SortedList<ulong, Range> list, ulong address)
        {
            Range ltRg = null;

            int left  = 0;
>>>>>>> 1ec71635b (sync with main branch)
            int right = list.Count - 1;

            while (left <= right)
            {
                int size = right - left;

                int middle = left + (size >> 1);

                Range rg = list.Values[middle];

                if (address < rg.Start)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;

                    if (address > rg.Start)
                    {
                        ltRg = rg;
                    }
                }
            }

            return ltRg;
        }
    }
}
