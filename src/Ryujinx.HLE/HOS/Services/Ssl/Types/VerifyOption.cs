<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Ssl.Types
{
    [Flags]
    enum VerifyOption : uint
    {
<<<<<<< HEAD
        PeerCa = 1 << 0,
        HostName = 1 << 1,
        DateCheck = 1 << 2,
        EvCertPartial = 1 << 3,
        EvPolicyOid = 1 << 4, // 6.0.0+
        EvCertFingerprint = 1 << 5, // 6.0.0+
    }
}
=======
        PeerCa            = 1 << 0,
        HostName          = 1 << 1,
        DateCheck         = 1 << 2,
        EvCertPartial     = 1 << 3,
        EvPolicyOid       = 1 << 4, // 6.0.0+
        EvCertFingerprint = 1 << 5  // 6.0.0+
    }
}
>>>>>>> 1ec71635b (sync with main branch)
