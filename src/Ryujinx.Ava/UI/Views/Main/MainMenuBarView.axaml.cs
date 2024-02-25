<<<<<<< HEAD
using Avalonia;
=======
﻿using Avalonia;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Controls;
using Avalonia.Interactivity;
using LibHac.Ncm;
using LibHac.Tools.FsSystem.NcaUtils;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Ava.UI.Windows;
using Ryujinx.Common;
using Ryujinx.Common.Utilities;
<<<<<<< HEAD
using Ryujinx.Modules;
using Ryujinx.UI.Common;
using Ryujinx.UI.Common.Configuration;
using Ryujinx.UI.Common.Helper;
=======
using Ryujinx.HLE.HOS;
using Ryujinx.Modules;
using Ryujinx.Ui.App.Common;
using Ryujinx.Ui.Common;
using Ryujinx.Ui.Common.Configuration;
using Ryujinx.Ui.Common.Helper;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Ava.UI.Views.Main
{
    public partial class MainMenuBarView : UserControl
    {
        public MainWindow Window { get; private set; }
        public MainWindowViewModel ViewModel { get; private set; }

        public MainMenuBarView()
        {
            InitializeComponent();

<<<<<<< HEAD
            ToggleFileTypesMenuItem.ItemsSource = GenerateToggleFileTypeItems();
            ChangeLanguageMenuItem.ItemsSource = GenerateLanguageMenuItems();
=======
            ToggleFileTypesMenuItem.Items = GenerateToggleFileTypeItems();
            ChangeLanguageMenuItem.Items = GenerateLanguageMenuItems();
>>>>>>> 1ec71635b (sync with main branch)
        }

        private CheckBox[] GenerateToggleFileTypeItems()
        {
            List<CheckBox> checkBoxes = new();

<<<<<<< HEAD
            foreach (var item in Enum.GetValues(typeof(FileTypes)))
            {
                string fileName = Enum.GetName(typeof(FileTypes), item);
                checkBoxes.Add(new CheckBox
                {
                    Content = $".{fileName}",
                    IsChecked = ((FileTypes)item).GetConfigValue(ConfigurationState.Instance.UI.ShownFileTypes),
                    Command = MiniCommand.Create(() => Window.ToggleFileType(fileName)),
=======
            foreach (var item in Enum.GetValues(typeof (FileTypes)))
            {
                string fileName = Enum.GetName(typeof (FileTypes), item);
                checkBoxes.Add(new CheckBox()
                {
                    Content = $".{fileName}",
                    IsChecked = ((FileTypes)item).GetConfigValue(ConfigurationState.Instance.Ui.ShownFileTypes),
                    Command = MiniCommand.Create(() => ViewModel.ToggleFileType(fileName))
>>>>>>> 1ec71635b (sync with main branch)
                });
            }

            return checkBoxes.ToArray();
        }

<<<<<<< HEAD
        private static MenuItem[] GenerateLanguageMenuItems()
=======
        private MenuItem[] GenerateLanguageMenuItems()
>>>>>>> 1ec71635b (sync with main branch)
        {
            List<MenuItem> menuItems = new();

            string localePath = "Ryujinx.Ava/Assets/Locales";
<<<<<<< HEAD
            string localeExt = ".json";
=======
            string localeExt  = ".json";
>>>>>>> 1ec71635b (sync with main branch)

            string[] localesPath = EmbeddedResources.GetAllAvailableResources(localePath, localeExt);

            Array.Sort(localesPath);

            foreach (string locale in localesPath)
            {
                string languageCode = Path.GetFileNameWithoutExtension(locale).Split('.').Last();
                string languageJson = EmbeddedResources.ReadAllText($"{localePath}/{languageCode}{localeExt}");
<<<<<<< HEAD
                var strings = JsonHelper.Deserialize(languageJson, CommonJsonContext.Default.StringDictionary);
=======
                var    strings      = JsonHelper.Deserialize(languageJson, CommonJsonContext.Default.StringDictionary);
>>>>>>> 1ec71635b (sync with main branch)

                if (!strings.TryGetValue("Language", out string languageName))
                {
                    languageName = languageCode;
                }

                MenuItem menuItem = new()
                {
<<<<<<< HEAD
                    Header = languageName,
                    Command = MiniCommand.Create(() =>
                    {
                        MainWindowViewModel.ChangeLanguage(languageCode);
                    }),
=======
                    Header  = languageName,
                    Command = MiniCommand.Create(() =>
                    {
                        ViewModel.ChangeLanguage(languageCode);
                    })
>>>>>>> 1ec71635b (sync with main branch)
                };

                menuItems.Add(menuItem);
            }

            return menuItems.ToArray();
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);

            if (VisualRoot is MainWindow window)
            {
                Window = window;
            }

            ViewModel = Window.ViewModel;
            DataContext = ViewModel;
        }

        private async void StopEmulation_Click(object sender, RoutedEventArgs e)
        {
            await Window.ViewModel.AppHost?.ShowExitPrompt();
        }

<<<<<<< HEAD
        private void PauseEmulation_Click(object sender, RoutedEventArgs e)
        {
            Window.ViewModel.AppHost?.Pause();
        }

        private void ResumeEmulation_Click(object sender, RoutedEventArgs e)
        {
            Window.ViewModel.AppHost?.Resume();
=======
        private async void PauseEmulation_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Window.ViewModel.AppHost?.Pause();
            });
        }

        private async void ResumeEmulation_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Window.ViewModel.AppHost?.Resume();
            });
>>>>>>> 1ec71635b (sync with main branch)
        }

        public async void OpenSettings(object sender, RoutedEventArgs e)
        {
            Window.SettingsWindow = new(Window.VirtualFileSystem, Window.ContentManager);

            await Window.SettingsWindow.ShowDialog(Window);

<<<<<<< HEAD
            Window.SettingsWindow = null;

            ViewModel.LoadConfigurableHotKeys();
        }

        public async void OpenMiiApplet(object sender, RoutedEventArgs e)
=======
            ViewModel.LoadConfigurableHotKeys();
        }

        public void OpenMiiApplet(object sender, RoutedEventArgs e)
>>>>>>> 1ec71635b (sync with main branch)
        {
            string contentPath = ViewModel.ContentManager.GetInstalledContentPath(0x0100000000001009, StorageId.BuiltInSystem, NcaContentType.Program);

            if (!string.IsNullOrEmpty(contentPath))
            {
<<<<<<< HEAD
                await ViewModel.LoadApplication(contentPath, false, "Mii Applet");
=======
                ViewModel.LoadApplication(contentPath, false, "Mii Applet");
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public async void OpenAmiiboWindow(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.IsAmiiboRequested)
            {
                return;
            }

            if (ViewModel.AppHost.Device.System.SearchingForAmiibo(out int deviceId))
            {
                string titleId = ViewModel.AppHost.Device.Processes.ActiveApplication.ProgramIdText.ToUpper();
                AmiiboWindow window = new(ViewModel.ShowAll, ViewModel.LastScannedAmiiboId, titleId);

                await window.ShowDialog(Window);

                if (window.IsScanned)
                {
                    ViewModel.ShowAll = window.ViewModel.ShowAllAmiibo;
                    ViewModel.LastScannedAmiiboId = window.ScannedAmiibo.GetId();

                    ViewModel.AppHost.Device.System.ScanAmiibo(deviceId, ViewModel.LastScannedAmiiboId, window.ViewModel.UseRandomUuid);
                }
            }
        }

        public async void OpenCheatManagerForCurrentApp(object sender, RoutedEventArgs e)
        {
            if (!ViewModel.IsGameRunning)
            {
                return;
            }

            string name = ViewModel.AppHost.Device.Processes.ActiveApplication.ApplicationControlProperties.Title[(int)ViewModel.AppHost.Device.System.State.DesiredTitleLanguage].NameString.ToString();

            await new CheatWindow(
                Window.VirtualFileSystem,
                ViewModel.AppHost.Device.Processes.ActiveApplication.ProgramIdText,
                name,
                Window.ViewModel.SelectedApplication.Path).ShowDialog(Window);

            ViewModel.AppHost.Device.EnableCheats();
        }

        private void ScanAmiiboMenuItem_AttachedToVisualTree(object sender, VisualTreeAttachmentEventArgs e)
        {
            if (sender is MenuItem)
            {
                ViewModel.IsAmiiboRequested = Window.ViewModel.AppHost.Device.System.SearchingForAmiibo(out _);
            }
        }

        private async void InstallFileTypes_Click(object sender, RoutedEventArgs e)
        {
            if (FileAssociationHelper.Install())
            {
<<<<<<< HEAD
                await ContentDialogHelper.CreateInfoDialog(LocaleManager.Instance[LocaleKeys.DialogInstallFileTypesSuccessMessage], string.Empty, LocaleManager.Instance[LocaleKeys.InputDialogOk], string.Empty, string.Empty);
=======
                await ContentDialogHelper.CreateInfoDialog(LocaleManager.Instance[LocaleKeys.DialogInstallFileTypesSuccessMessage],
                    string.Empty, LocaleManager.Instance[LocaleKeys.InputDialogOk], string.Empty, string.Empty);
>>>>>>> 1ec71635b (sync with main branch)
            }
            else
            {
                await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogInstallFileTypesErrorMessage]);
            }
        }

        private async void UninstallFileTypes_Click(object sender, RoutedEventArgs e)
        {
            if (FileAssociationHelper.Uninstall())
            {
<<<<<<< HEAD
                await ContentDialogHelper.CreateInfoDialog(LocaleManager.Instance[LocaleKeys.DialogUninstallFileTypesSuccessMessage], string.Empty, LocaleManager.Instance[LocaleKeys.InputDialogOk], string.Empty, string.Empty);
=======
                await ContentDialogHelper.CreateInfoDialog(LocaleManager.Instance[LocaleKeys.DialogUninstallFileTypesSuccessMessage],
                    string.Empty, LocaleManager.Instance[LocaleKeys.InputDialogOk], string.Empty, string.Empty);
>>>>>>> 1ec71635b (sync with main branch)
            }
            else
            {
                await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogUninstallFileTypesErrorMessage]);
            }
        }

        public async void CheckForUpdates(object sender, RoutedEventArgs e)
        {
            if (Updater.CanUpdate(true))
            {
                await Updater.BeginParse(Window, true);
            }
        }

        public async void OpenAboutWindow(object sender, RoutedEventArgs e)
        {
            await AboutWindow.Show();
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            Window.Close();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
