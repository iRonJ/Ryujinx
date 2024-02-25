<<<<<<< HEAD
using Ryujinx.Memory;
=======
﻿using Ryujinx.Memory;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Kernel.Process
{
    class ProcessContextFactory : IProcessContextFactory
    {
        public IProcessContext Create(KernelContext context, ulong pid, ulong addressSpaceSize, InvalidAccessHandler invalidAccessHandler, bool for64Bit)
        {
<<<<<<< HEAD
            return new ProcessContext(new AddressSpaceManager(context.Memory, addressSpaceSize), addressSpaceSize);
=======
            return new ProcessContext(new AddressSpaceManager(context.Memory, addressSpaceSize));
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
