<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace ARMeilleure.Memory
{
    public interface IJitMemoryBlock : IDisposable
    {
        IntPtr Pointer { get; }

<<<<<<< HEAD
        void Commit(ulong offset, ulong size);

        void MapAsRw(ulong offset, ulong size);
=======
        bool Commit(ulong offset, ulong size);

>>>>>>> 1ec71635b (sync with main branch)
        void MapAsRx(ulong offset, ulong size);
        void MapAsRwx(ulong offset, ulong size);
    }
}
