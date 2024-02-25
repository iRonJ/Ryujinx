<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace ARMeilleure.CodeGen.RegisterAllocators
{
    unsafe struct UseList
    {
        private int* _items;
        private int _capacity;
<<<<<<< HEAD

        public int Count { get; private set; }

        public readonly int FirstUse => Count > 0 ? _items[Count - 1] : LiveInterval.NotFound;
        public readonly Span<int> Span => new(_items, Count);

        public void Add(int position)
        {
            if (Count + 1 > _capacity)
=======
        private int _count;

        public int Count => _count;
        public int FirstUse => _count > 0 ? _items[_count - 1] : LiveInterval.NotFound;
        public Span<int> Span => new(_items, _count);

        public void Add(int position)
        {
            if (_count + 1 > _capacity)
>>>>>>> 1ec71635b (sync with main branch)
            {
                var oldSpan = Span;

                _capacity = Math.Max(4, _capacity * 2);
                _items = Allocators.Default.Allocate<int>((uint)_capacity);

                var newSpan = Span;

                oldSpan.CopyTo(newSpan);
            }

            // Use positions are usually inserted in descending order, so inserting in descending order is faster,
            // since the number of half exchanges is reduced.
<<<<<<< HEAD
            int i = Count - 1;
=======
            int i = _count - 1;
>>>>>>> 1ec71635b (sync with main branch)

            while (i >= 0 && _items[i] < position)
            {
                _items[i + 1] = _items[i--];
            }

            _items[i + 1] = position;
<<<<<<< HEAD
            Count++;
        }

        public readonly int NextUse(int position)
=======
            _count++;
        }

        public int NextUse(int position)
>>>>>>> 1ec71635b (sync with main branch)
        {
            int index = NextUseIndex(position);

            return index != LiveInterval.NotFound ? _items[index] : LiveInterval.NotFound;
        }

<<<<<<< HEAD
        public readonly int NextUseIndex(int position)
        {
            int i = Count - 1;
=======
        public int NextUseIndex(int position)
        {
            int i = _count - 1;
>>>>>>> 1ec71635b (sync with main branch)

            if (i == -1 || position > _items[0])
            {
                return LiveInterval.NotFound;
            }

            while (i >= 0 && _items[i] < position)
            {
                i--;
            }

            return i;
        }

        public UseList Split(int position)
        {
            int index = NextUseIndex(position);

            // Since the list is in descending order, the new split list takes the front of the list and the current
            // list takes the back of the list.
<<<<<<< HEAD
            UseList result = new()
            {
                Count = index + 1,
            };
            result._capacity = result.Count;
            result._items = _items;

            Count -= result.Count;
            _capacity = Count;
            _items += result.Count;
=======
            UseList result = new();
            result._count = index + 1;
            result._capacity = result._count;
            result._items = _items;

            _count = _count - result._count;
            _capacity = _count;
            _items = _items + result._count;
>>>>>>> 1ec71635b (sync with main branch)

            return result;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
