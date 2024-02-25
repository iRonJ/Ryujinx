using Avalonia.Interactivity;
<<<<<<< HEAD
using Ryujinx.UI.App.Common;
=======
using Ryujinx.Ui.App.Common;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Ava.UI.Helpers
{
    public class ApplicationOpenedEventArgs : RoutedEventArgs
    {
        public ApplicationData Application { get; }

        public ApplicationOpenedEventArgs(ApplicationData application, RoutedEvent routedEvent)
        {
            Application = application;
            RoutedEvent = routedEvent;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
