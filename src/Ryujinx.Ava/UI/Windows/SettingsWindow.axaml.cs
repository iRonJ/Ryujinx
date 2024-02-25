<<<<<<< HEAD
using Avalonia.Controls;
=======
>>>>>>> 1ec71635b (sync with main branch)
using FluentAvalonia.Core;
using FluentAvalonia.UI.Controls;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.HLE.FileSystem;
using System;
<<<<<<< HEAD
=======
using System.ComponentModel;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Ava.UI.Windows
{
    public partial class SettingsWindow : StyleableWindow
    {
        internal SettingsViewModel ViewModel { get; set; }

        public SettingsWindow(VirtualFileSystem virtualFileSystem, ContentManager contentManager)
        {
            Title = $"Ryujinx {Program.Version} - {LocaleManager.Instance[LocaleKeys.Settings]}";

<<<<<<< HEAD
            ViewModel = new SettingsViewModel(virtualFileSystem, contentManager);
=======
            ViewModel   = new SettingsViewModel(virtualFileSystem, contentManager);
>>>>>>> 1ec71635b (sync with main branch)
            DataContext = ViewModel;

            ViewModel.CloseWindow += Close;
            ViewModel.SaveSettingsEvent += SaveSettings;

            InitializeComponent();
            Load();
        }

        public SettingsWindow()
        {
<<<<<<< HEAD
            ViewModel = new SettingsViewModel();
=======
            ViewModel   = new SettingsViewModel();
>>>>>>> 1ec71635b (sync with main branch)
            DataContext = ViewModel;

            InitializeComponent();
            Load();
        }

        public void SaveSettings()
        {
            InputPage.ControllerSettings?.SaveCurrentProfile();

            if (Owner is MainWindow window && ViewModel.DirectoryChanged)
            {
<<<<<<< HEAD
                window.LoadApplications();
=======
                window.ViewModel.LoadApplications();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private void Load()
        {
            Pages.Children.Clear();
            NavPanel.SelectionChanged += NavPanelOnSelectionChanged;
            NavPanel.SelectedItem = NavPanel.MenuItems.ElementAt(0);
        }

        private void NavPanelOnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
        {
            if (e.SelectedItem is NavigationViewItem navItem && navItem.Tag is not null)
            {
                switch (navItem.Tag.ToString())
                {
                    case "UiPage":
                        UiPage.ViewModel = ViewModel;
                        NavPanel.Content = UiPage;
                        break;
                    case "InputPage":
                        NavPanel.Content = InputPage;
                        break;
                    case "HotkeysPage":
                        NavPanel.Content = HotkeysPage;
                        break;
                    case "SystemPage":
                        SystemPage.ViewModel = ViewModel;
                        NavPanel.Content = SystemPage;
                        break;
                    case "CpuPage":
                        NavPanel.Content = CpuPage;
                        break;
                    case "GraphicsPage":
                        NavPanel.Content = GraphicsPage;
                        break;
                    case "AudioPage":
                        NavPanel.Content = AudioPage;
                        break;
                    case "NetworkPage":
                        NavPanel.Content = NetworkPage;
                        break;
                    case "LoggingPage":
                        NavPanel.Content = LoggingPage;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

<<<<<<< HEAD
        protected override void OnClosing(WindowClosingEventArgs e)
=======
        protected override void OnClosing(CancelEventArgs e)
>>>>>>> 1ec71635b (sync with main branch)
        {
            HotkeysPage.Dispose();
            InputPage.Dispose();
            base.OnClosing(e);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
