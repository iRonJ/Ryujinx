<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Device
{
    public readonly struct RwCallback
    {
        public Action<int> Write { get; }
        public Func<int> Read { get; }

        public RwCallback(Action<int> write, Func<int> read)
        {
            Write = write;
            Read = read;
        }
    }
}
