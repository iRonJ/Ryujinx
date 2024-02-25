using System;

namespace Ryujinx.Horizon.Sdk.Lm
{
    [Flags]
    enum LogPacketFlags : byte
    {
        IsHead = 1 << 0,
        IsTail = 1 << 1,
<<<<<<< HEAD
        IsLittleEndian = 1 << 2,
=======
        IsLittleEndian = 1 << 2
>>>>>>> 1ec71635b (sync with main branch)
    }
}
