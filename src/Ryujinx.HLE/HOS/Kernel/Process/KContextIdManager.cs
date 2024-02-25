using System;
using System.Numerics;

namespace Ryujinx.HLE.HOS.Kernel.Process
{
    class KContextIdManager
    {
        private const int IdMasksCount = 8;

<<<<<<< HEAD
        private readonly int[] _idMasks;
=======
        private int[] _idMasks;
>>>>>>> 1ec71635b (sync with main branch)

        private int _nextFreeBitHint;

        public KContextIdManager()
        {
            _idMasks = new int[IdMasksCount];
        }

        public int GetId()
        {
            lock (_idMasks)
            {
                int id = 0;

                if (!TestBit(_nextFreeBitHint))
                {
                    id = _nextFreeBitHint;
                }
                else
                {
                    for (int index = 0; index < IdMasksCount; index++)
                    {
                        int mask = _idMasks[index];

                        int firstFreeBit = BitOperations.LeadingZeroCount((uint)((mask + 1) & ~mask));

                        if (firstFreeBit < 32)
                        {
                            int baseBit = index * 32 + 31;

                            id = baseBit - firstFreeBit;

                            break;
                        }
                        else if (index == IdMasksCount - 1)
                        {
                            throw new InvalidOperationException("Maximum number of Ids reached!");
                        }
                    }
                }

                _nextFreeBitHint = id + 1;

                SetBit(id);

                return id;
            }
        }

        public void PutId(int id)
        {
            lock (_idMasks)
            {
                ClearBit(id);
            }
        }

        private bool TestBit(int bit)
        {
<<<<<<< HEAD
            return (_idMasks[bit / 32] & (1 << (bit & 31))) != 0;
=======
            return (_idMasks[_nextFreeBitHint / 32] & (1 << (_nextFreeBitHint & 31))) != 0;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void SetBit(int bit)
        {
<<<<<<< HEAD
            _idMasks[bit / 32] |= (1 << (bit & 31));
=======
            _idMasks[_nextFreeBitHint / 32] |= (1 << (_nextFreeBitHint & 31));
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void ClearBit(int bit)
        {
<<<<<<< HEAD
            _idMasks[bit / 32] &= ~(1 << (bit & 31));
        }
    }
}
=======
            _idMasks[_nextFreeBitHint / 32] &= ~(1 << (_nextFreeBitHint & 31));
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
