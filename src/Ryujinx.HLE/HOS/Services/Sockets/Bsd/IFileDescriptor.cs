<<<<<<< HEAD
using Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types;
=======
﻿using Ryujinx.HLE.HOS.Services.Sockets.Bsd.Types;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.HLE.HOS.Services.Sockets.Bsd
{
    interface IFileDescriptor : IDisposable
    {
        bool Blocking { get; set; }
        int Refcount { get; set; }

        LinuxError Read(out int readSize, Span<byte> buffer);

        LinuxError Write(out int writeSize, ReadOnlySpan<byte> buffer);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
