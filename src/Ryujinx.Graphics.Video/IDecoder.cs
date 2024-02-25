<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Video
{
    public interface IDecoder : IDisposable
    {
        bool IsHardwareAccelerated { get; }

        ISurface CreateSurface(int width, int height);
    }
}
