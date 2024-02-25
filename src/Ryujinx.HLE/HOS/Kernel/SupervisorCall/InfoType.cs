<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Kernel.SupervisorCall
=======
﻿namespace Ryujinx.HLE.HOS.Kernel.SupervisorCall
>>>>>>> 1ec71635b (sync with main branch)
{
    enum InfoType : uint
    {
        CoreMask,
        PriorityMask,
        AliasRegionAddress,
        AliasRegionSize,
        HeapRegionAddress,
        HeapRegionSize,
        TotalMemorySize,
        UsedMemorySize,
        DebuggerAttached,
        ResourceLimit,
        IdleTickCount,
        RandomEntropy,
        AslrRegionAddress,
        AslrRegionSize,
        StackRegionAddress,
        StackRegionSize,
        SystemResourceSizeTotal,
        SystemResourceSizeUsed,
        ProgramId,
        // NOTE: Added in 4.0.0, removed in 5.0.0.
        InitialProcessIdRange,
        UserExceptionContextAddress,
        TotalNonSystemMemorySize,
        UsedNonSystemMemorySize,
        IsApplication,
        FreeThreadCount,
        ThreadTickCount,
<<<<<<< HEAD
        MesosphereCurrentProcess = 65001,
=======
        MesosphereCurrentProcess = 65001
>>>>>>> 1ec71635b (sync with main branch)
    }
}
