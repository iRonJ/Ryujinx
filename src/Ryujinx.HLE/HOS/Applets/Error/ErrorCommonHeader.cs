<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
﻿using System.Runtime.InteropServices;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Applets.Error
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ErrorCommonHeader
    {
        public ErrorType Type;
<<<<<<< HEAD
        public byte JumpFlag;
        public byte ReservedFlag1;
        public byte ReservedFlag2;
        public byte ReservedFlag3;
        public byte ContextFlag;
        public byte MessageFlag;
        public byte ContextFlag2;
    }
}
=======
        public byte      JumpFlag;
        public byte      ReservedFlag1;
        public byte      ReservedFlag2;
        public byte      ReservedFlag3;
        public byte      ContextFlag;
        public byte      MessageFlag;
        public byte      ContextFlag2;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
