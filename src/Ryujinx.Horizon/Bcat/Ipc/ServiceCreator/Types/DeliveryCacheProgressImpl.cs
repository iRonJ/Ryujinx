<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Bcat.Ipc.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 0x200)]
    public struct DeliveryCacheProgressImpl
    {
        public enum Status
        {
            // TODO: determine other values
<<<<<<< HEAD
            Done = 9,
        }

        public Status State;
        public uint Result;
=======
            Done = 9
        }

        public Status State;
        public uint   Result;
>>>>>>> 1ec71635b (sync with main branch)
        // TODO: reverse the rest of the structure
    }
}
