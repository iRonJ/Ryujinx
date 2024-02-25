<<<<<<< HEAD
namespace Ryujinx.Horizon.Common
=======
﻿namespace Ryujinx.Horizon.Common
>>>>>>> 1ec71635b (sync with main branch)
{
    public interface IThreadContext
    {
        bool Running { get; }

        ulong TlsAddress { get; }

        ulong GetX(int index);
    }
}
