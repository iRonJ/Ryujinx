<<<<<<< HEAD
using Ryujinx.Graphics.Gpu;
=======
﻿using Ryujinx.Graphics.Gpu;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostCtrl;
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Nv.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x8)]
    internal struct NvFence
    {
        public const uint InvalidSyncPointId = uint.MaxValue;

        public uint Id;
        public uint Value;

<<<<<<< HEAD
        public readonly bool IsValid()
=======
        public bool IsValid()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Id != InvalidSyncPointId;
        }

        public void UpdateValue(NvHostSyncpt hostSyncpt)
        {
            Value = hostSyncpt.ReadSyncpointValue(Id);
        }

        public void Increment(GpuContext gpuContext)
        {
            Value = gpuContext.Synchronization.IncrementSyncpoint(Id);
        }

<<<<<<< HEAD
        public readonly bool Wait(GpuContext gpuContext, TimeSpan timeout)
=======
        public bool Wait(GpuContext gpuContext, TimeSpan timeout)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (IsValid())
            {
                return gpuContext.Synchronization.WaitOnSyncpoint(Id, Value, timeout);
            }

            return false;
        }
    }
}
