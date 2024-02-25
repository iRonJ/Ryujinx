using Avalonia;
using Avalonia.Controls;
using Ryujinx.Common.Configuration;
<<<<<<< HEAD
using Ryujinx.UI.Common.Configuration;
=======
using Ryujinx.Ui.Common.Configuration;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Ava.UI.Renderer
{
    public partial class RendererHost : UserControl, IDisposable
    {
        public readonly EmbeddedWindow EmbeddedWindow;

        public event EventHandler<EventArgs> WindowCreated;
<<<<<<< HEAD
        public event Action<object, Size> BoundsChanged;
=======
        public event Action<object, Size>    SizeChanged;
>>>>>>> 1ec71635b (sync with main branch)

        public RendererHost()
        {
            InitializeComponent();

            if (ConfigurationState.Instance.Graphics.GraphicsBackend.Value == GraphicsBackend.OpenGl)
            {
                EmbeddedWindow = new EmbeddedWindowOpenGL();
            }
            else
            {
                EmbeddedWindow = new EmbeddedWindowVulkan();
            }

            Initialize();
        }

        private void Initialize()
        {
            EmbeddedWindow.WindowCreated += CurrentWindow_WindowCreated;
<<<<<<< HEAD
            EmbeddedWindow.BoundsChanged += CurrentWindow_BoundsChanged;
=======
            EmbeddedWindow.SizeChanged   += CurrentWindow_SizeChanged;
>>>>>>> 1ec71635b (sync with main branch)

            Content = EmbeddedWindow;
        }

        public void Dispose()
        {
            if (EmbeddedWindow != null)
            {
                EmbeddedWindow.WindowCreated -= CurrentWindow_WindowCreated;
<<<<<<< HEAD
                EmbeddedWindow.BoundsChanged -= CurrentWindow_BoundsChanged;
=======
                EmbeddedWindow.SizeChanged   -= CurrentWindow_SizeChanged;
>>>>>>> 1ec71635b (sync with main branch)
            }

            GC.SuppressFinalize(this);
        }

        protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnDetachedFromVisualTree(e);

            Dispose();
        }

<<<<<<< HEAD
        private void CurrentWindow_BoundsChanged(object sender, Size e)
        {
            BoundsChanged?.Invoke(sender, e);
=======
        private void CurrentWindow_SizeChanged(object sender, Size e)
        {
            SizeChanged?.Invoke(sender, e);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void CurrentWindow_WindowCreated(object sender, IntPtr e)
        {
            WindowCreated?.Invoke(this, EventArgs.Empty);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
