<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Memory
{
    public interface IWritableBlock
    {
        void Write(ulong va, ReadOnlySpan<byte> data);

        void WriteUntracked(ulong va, ReadOnlySpan<byte> data) => Write(va, data);
    }
}
