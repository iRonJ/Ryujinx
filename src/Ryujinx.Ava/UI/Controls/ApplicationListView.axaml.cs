using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
<<<<<<< HEAD
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.UI.App.Common;
=======
using Avalonia.Markup.Xaml;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Ui.App.Common;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Ava.UI.Controls
{
    public partial class ApplicationListView : UserControl
    {
        public static readonly RoutedEvent<ApplicationOpenedEventArgs> ApplicationOpenedEvent =
            RoutedEvent.Register<ApplicationListView, ApplicationOpenedEventArgs>(nameof(ApplicationOpened), RoutingStrategies.Bubble);

        public event EventHandler<ApplicationOpenedEventArgs> ApplicationOpened
        {
<<<<<<< HEAD
            add { AddHandler(ApplicationOpenedEvent, value); }
=======
            add    { AddHandler(ApplicationOpenedEvent,    value); }
>>>>>>> 1ec71635b (sync with main branch)
            remove { RemoveHandler(ApplicationOpenedEvent, value); }
        }

        public ApplicationListView()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        public void GameList_DoubleTapped(object sender, TappedEventArgs args)
=======
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void GameList_DoubleTapped(object sender, RoutedEventArgs args)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ApplicationData selected)
                {
                    RaiseEvent(new ApplicationOpenedEventArgs(selected, ApplicationOpenedEvent));
                }
            }
        }

        public void GameList_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if (sender is ListBox listBox)
            {
                (DataContext as MainWindowViewModel).ListSelectedApplication = listBox.SelectedItem as ApplicationData;
            }
        }

        private void SearchBox_OnKeyUp(object sender, KeyEventArgs args)
        {
            (DataContext as MainWindowViewModel).SearchText = (sender as TextBox).Text;
        }
    }
}
