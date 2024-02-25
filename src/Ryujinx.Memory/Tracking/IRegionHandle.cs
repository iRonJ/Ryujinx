<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Memory.Tracking
{
    public interface IRegionHandle : IDisposable
    {
        bool Dirty { get; }

        ulong Address { get; }
        ulong Size { get; }
        ulong EndAddress { get; }

        void ForceDirty();
        void Reprotect(bool asDirty = false);
        void RegisterAction(RegionSignal action);
        void RegisterPreciseAction(PreciseRegionSignal action);
    }
}
