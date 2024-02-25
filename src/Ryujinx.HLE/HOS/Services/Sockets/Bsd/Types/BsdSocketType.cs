<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
=======
﻿namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types
>>>>>>> 1ec71635b (sync with main branch)
{
    enum BsdSocketType
    {
        Stream = 1,
        Dgram,
        Raw,
        Rdm,
        Seqpacket,

        TypeMask = 0xFFFFFFF,
    }
}
