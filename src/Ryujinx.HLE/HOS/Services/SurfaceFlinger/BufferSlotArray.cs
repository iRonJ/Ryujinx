<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
=======
﻿namespace Ryujinx.HLE.HOS.Services.SurfaceFlinger
>>>>>>> 1ec71635b (sync with main branch)
{
    class BufferSlotArray
    {
        // TODO: move to BufferQueue
<<<<<<< HEAD
        public const int NumBufferSlots = 0x40;
        public const int MaxAcquiredBuffers = NumBufferSlots - 2;
        public const int InvalidBufferSlot = -1;

        private readonly BufferSlot[] _raw = new BufferSlot[NumBufferSlots];
=======
        public const int NumBufferSlots     = 0x40;
        public const int MaxAcquiredBuffers = NumBufferSlots - 2;
        public const int InvalidBufferSlot  = -1;

        private BufferSlot[] _raw = new BufferSlot[NumBufferSlots];
>>>>>>> 1ec71635b (sync with main branch)

        public BufferSlotArray()
        {
            for (int i = 0; i < _raw.Length; i++)
            {
                _raw[i] = new BufferSlot();
            }
        }

        public BufferSlot this[int index]
        {
            get => _raw[index];
            set => _raw[index] = value;
        }

        public int Length => NumBufferSlots;
    }
}
