using OpenTK.Graphics.OpenGL;
using Ryujinx.Common.Configuration;
<<<<<<< HEAD
using Ryujinx.Common.Logging;
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.OpenGL;
using Ryujinx.UI.Common.Configuration;
using SPB.Graphics;
using SPB.Graphics.Exceptions;
=======
using Ryujinx.Graphics.GAL;
using Ryujinx.Graphics.OpenGL;
using Ryujinx.Ui.Common.Configuration;
using SPB.Graphics;
>>>>>>> 1ec71635b (sync with main branch)
using SPB.Graphics.OpenGL;
using SPB.Platform;
using SPB.Platform.WGL;
using SPB.Windowing;
using System;

namespace Ryujinx.Ava.UI.Renderer
{
    public class EmbeddedWindowOpenGL : EmbeddedWindow
    {
        private SwappableNativeWindowBase _window;

        public OpenGLContextBase Context { get; set; }

<<<<<<< HEAD
=======
        public EmbeddedWindowOpenGL() { }

>>>>>>> 1ec71635b (sync with main branch)
        protected override void OnWindowDestroying()
        {
            Context.Dispose();

            base.OnWindowDestroying();
        }

        public override void OnWindowCreated()
        {
            base.OnWindowCreated();

            if (OperatingSystem.IsWindows())
            {
                _window = new WGLWindow(new NativeHandle(WindowHandle));
            }
            else if (OperatingSystem.IsLinux())
            {
                _window = X11Window;
            }
            else
            {
                throw new PlatformNotSupportedException();
            }

            var flags = OpenGLContextFlags.Compat;
            if (ConfigurationState.Instance.Logger.GraphicsDebugLevel != GraphicsDebugLevel.None)
            {
                flags |= OpenGLContextFlags.Debug;
            }

            var graphicsMode = Environment.OSVersion.Platform == PlatformID.Unix ? new FramebufferFormat(new ColorFormat(8, 8, 8, 0), 16, 0, ColorFormat.Zero, 0, 2, false) : FramebufferFormat.Default;

            Context = PlatformHelper.CreateOpenGLContext(graphicsMode, 3, 3, flags);

            Context.Initialize(_window);
            Context.MakeCurrent(_window);

            GL.LoadBindings(new OpenTKBindingsContext(Context.GetProcAddress));

            Context.MakeCurrent(null);
        }

<<<<<<< HEAD
        public void MakeCurrent(bool unbind = false, bool shouldThrow = true)
        {
            try
            {
                Context?.MakeCurrent(!unbind ? _window : null);
            }
            catch (ContextException e)
            {
                if (shouldThrow)
                {
                    throw;
                }

                Logger.Warning?.Print(LogClass.UI, $"Failed to {(!unbind ? "bind" : "unbind")} OpenGL context: {e}");
            }
=======
        public void MakeCurrent()
        {
            Context?.MakeCurrent(_window);
        }

        public void MakeCurrent(NativeWindowBase window)
        {
            Context?.MakeCurrent(window);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void SwapBuffers()
        {
            _window?.SwapBuffers();
        }

        public void InitializeBackgroundContext(IRenderer renderer)
        {
            (renderer as OpenGLRenderer)?.InitializeBackgroundContext(SPBOpenGLContext.CreateBackgroundContext(Context));

            MakeCurrent();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
