<<<<<<< HEAD
namespace Ryujinx.Memory.Range
=======
﻿namespace Ryujinx.Memory.Range
>>>>>>> 1ec71635b (sync with main branch)
{
    public interface IMultiRangeItem
    {
        MultiRange Range { get; }

        ulong BaseAddress => Range.GetSubRange(0).Address;
    }
}
