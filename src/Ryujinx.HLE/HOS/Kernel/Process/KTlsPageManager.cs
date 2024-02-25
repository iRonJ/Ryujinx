using Ryujinx.HLE.HOS.Kernel.Memory;
using System;

namespace Ryujinx.HLE.HOS.Kernel.Process
{
    class KTlsPageManager
    {
        private const int TlsEntrySize = 0x200;

<<<<<<< HEAD
        private readonly long _pagePosition;

        private int _usedSlots;

        private readonly bool[] _slots;

        public bool IsEmpty => _usedSlots == 0;
        public bool IsFull => _usedSlots == _slots.Length;
=======
        private long _pagePosition;

        private int _usedSlots;

        private bool[] _slots;

        public bool IsEmpty => _usedSlots == 0;
        public bool IsFull  => _usedSlots == _slots.Length;
>>>>>>> 1ec71635b (sync with main branch)

        public KTlsPageManager(long pagePosition)
        {
            _pagePosition = pagePosition;

            _slots = new bool[KPageTableBase.PageSize / TlsEntrySize];
        }

        public bool TryGetFreeTlsAddr(out long position)
        {
            position = _pagePosition;

            for (int index = 0; index < _slots.Length; index++)
            {
                if (!_slots[index])
                {
                    _slots[index] = true;

                    _usedSlots++;

                    return true;
                }

                position += TlsEntrySize;
            }

            position = 0;

            return false;
        }

        public void FreeTlsSlot(int slot)
        {
            if ((uint)slot > _slots.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(slot));
            }

            _slots[slot] = false;

            _usedSlots--;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
