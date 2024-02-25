<<<<<<< HEAD
using Ryujinx.Graphics.OpenGL.Helper;
=======
﻿using Ryujinx.Graphics.OpenGL.Helper;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.OpenGL
{
    public interface IOpenGLContext : IDisposable
    {
        void MakeCurrent();

<<<<<<< HEAD
        bool HasContext();
=======
        // TODO: Support more APIs per platform.
        static bool HasContext()
        {
            if (OperatingSystem.IsWindows())
            {
                return WGLHelper.GetCurrentContext() != IntPtr.Zero;
            }
            else if (OperatingSystem.IsLinux())
            {
                return GLXHelper.GetCurrentContext() != IntPtr.Zero;
            }
            else
            {
                return false;
            }
        }
>>>>>>> 1ec71635b (sync with main branch)
    }
}
