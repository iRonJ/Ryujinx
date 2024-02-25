<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Ssl.Types
{
    [Flags]
    enum SslVersion : uint
    {
<<<<<<< HEAD
        Auto = 1 << 0,
=======
        Auto   = 1 << 0,
>>>>>>> 1ec71635b (sync with main branch)
        TlsV10 = 1 << 3,
        TlsV11 = 1 << 4,
        TlsV12 = 1 << 5,
        TlsV13 = 1 << 6, // 11.0.0+

<<<<<<< HEAD
        VersionMask = 0xFFFFFF,
    }
}
=======
        VersionMask = 0xFFFFFF
    }
}
>>>>>>> 1ec71635b (sync with main branch)
