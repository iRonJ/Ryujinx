<<<<<<< HEAD
using OpenTK.Graphics.OpenGL;
=======
﻿using OpenTK.Graphics.OpenGL;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.OpenGL;
using SPB.Graphics;
using SPB.Graphics.OpenGL;
using SPB.Platform;
using SPB.Windowing;

namespace Ryujinx.Ava.UI.Renderer
{
    class SPBOpenGLContext : IOpenGLContext
    {
        private readonly OpenGLContextBase _context;
<<<<<<< HEAD
        private readonly NativeWindowBase _window;
=======
        private readonly NativeWindowBase  _window;
>>>>>>> 1ec71635b (sync with main branch)

        private SPBOpenGLContext(OpenGLContextBase context, NativeWindowBase window)
        {
            _context = context;
<<<<<<< HEAD
            _window = window;
=======
            _window  = window;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Dispose()
        {
            _context.Dispose();
            _window.Dispose();
        }

        public void MakeCurrent()
        {
            _context.MakeCurrent(_window);
        }

<<<<<<< HEAD
        public bool HasContext() => _context.IsCurrent;

        public static SPBOpenGLContext CreateBackgroundContext(OpenGLContextBase sharedContext)
        {
            OpenGLContextBase context = PlatformHelper.CreateOpenGLContext(FramebufferFormat.Default, 3, 3, OpenGLContextFlags.Compat, true, sharedContext);
            NativeWindowBase window = PlatformHelper.CreateOpenGLWindow(FramebufferFormat.Default, 0, 0, 100, 100);
=======
        public static SPBOpenGLContext CreateBackgroundContext(OpenGLContextBase sharedContext)
        {
            OpenGLContextBase context = PlatformHelper.CreateOpenGLContext(FramebufferFormat.Default, 3, 3, OpenGLContextFlags.Compat, true, sharedContext);
            NativeWindowBase  window  = PlatformHelper.CreateOpenGLWindow(FramebufferFormat.Default, 0, 0, 100, 100);
>>>>>>> 1ec71635b (sync with main branch)

            context.Initialize(window);
            context.MakeCurrent(window);

            GL.LoadBindings(new OpenTKBindingsContext(context.GetProcAddress));

            context.MakeCurrent(null);

            return new SPBOpenGLContext(context, window);
        }
    }
}
