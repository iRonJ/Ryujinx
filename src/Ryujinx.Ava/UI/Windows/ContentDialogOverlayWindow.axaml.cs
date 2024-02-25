<<<<<<< HEAD
using Avalonia.Controls;
=======
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Media;

namespace Ryujinx.Ava.UI.Windows
{
    public partial class ContentDialogOverlayWindow : StyleableWindow
    {
        public ContentDialogOverlayWindow()
        {
            InitializeComponent();
<<<<<<< HEAD

            ExtendClientAreaToDecorationsHint = true;
            TransparencyLevelHint = new[] { WindowTransparencyLevel.Transparent };
=======
#if DEBUG
            this.AttachDevTools();
#endif
            ExtendClientAreaToDecorationsHint = true;
            TransparencyLevelHint = WindowTransparencyLevel.Transparent;
>>>>>>> 1ec71635b (sync with main branch)
            WindowStartupLocation = WindowStartupLocation.Manual;
            SystemDecorations = SystemDecorations.None;
            ExtendClientAreaTitleBarHeightHint = 0;
            Background = Brushes.Transparent;
            CanResize = false;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
