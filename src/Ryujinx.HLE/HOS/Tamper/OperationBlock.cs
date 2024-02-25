<<<<<<< HEAD
using Ryujinx.HLE.HOS.Tamper.Operations;
=======
﻿using Ryujinx.HLE.HOS.Tamper.Operations;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;

namespace Ryujinx.HLE.HOS.Tamper
{
    readonly struct OperationBlock
    {
        public byte[] BaseInstruction { get; }
        public List<IOperation> Operations { get; }

        public OperationBlock(byte[] baseInstruction)
        {
            BaseInstruction = baseInstruction;
            Operations = new List<IOperation>();
        }
    }
}
