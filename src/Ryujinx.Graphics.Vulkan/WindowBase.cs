<<<<<<< HEAD
using Ryujinx.Graphics.GAL;
=======
﻿using Ryujinx.Graphics.GAL;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.Vulkan
{
<<<<<<< HEAD
    internal abstract class WindowBase : IWindow
=======
    internal abstract class WindowBase: IWindow
>>>>>>> 1ec71635b (sync with main branch)
    {
        public bool ScreenCaptureRequested { get; set; }

        public abstract void Dispose();
        public abstract void Present(ITexture texture, ImageCrop crop, Action swapBuffersCallback);
        public abstract void SetSize(int width, int height);
        public abstract void ChangeVSyncMode(bool vsyncEnabled);
        public abstract void SetAntiAliasing(AntiAliasing effect);
        public abstract void SetScalingFilter(ScalingFilter scalerType);
        public abstract void SetScalingFilterLevel(float scale);
<<<<<<< HEAD
        public abstract void SetColorSpacePassthrough(bool colorSpacePassthroughEnabled);
    }
}
=======
    }
}
>>>>>>> 1ec71635b (sync with main branch)
