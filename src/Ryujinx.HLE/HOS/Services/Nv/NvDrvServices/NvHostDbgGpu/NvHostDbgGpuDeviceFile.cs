<<<<<<< HEAD
using Ryujinx.Memory;

=======
﻿using Ryujinx.Memory;
using System;
>>>>>>> 1ec71635b (sync with main branch)
namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvHostDbgGpu
{
    class NvHostDbgGpuDeviceFile : NvDeviceFile
    {
        public NvHostDbgGpuDeviceFile(ServiceCtx context, IVirtualMemoryManager memory, ulong owner) : base(context, owner) { }

        public override void Close() { }
    }
}
