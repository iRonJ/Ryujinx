using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using LibHac.Fs;
using LibHac.Tools.FsSystem.NcaUtils;
using Ryujinx.Ava.Common;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Ava.UI.Windows;
using Ryujinx.Common.Configuration;
<<<<<<< HEAD
using Ryujinx.HLE.HOS;
using Ryujinx.UI.App.Common;
using Ryujinx.UI.Common.Helper;
=======
using Ryujinx.Ui.App.Common;
using Ryujinx.HLE.HOS;
using Ryujinx.Ui.Common.Helper;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Path = System.IO.Path;
<<<<<<< HEAD
=======
using UserId = LibHac.Fs.UserId;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Ava.UI.Controls
{
    public class ApplicationContextMenu : MenuFlyout
    {
        public ApplicationContextMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void ToggleFavorite_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                viewModel.SelectedApplication.Favorite = !viewModel.SelectedApplication.Favorite;

<<<<<<< HEAD
                ApplicationLibrary.LoadAndSaveMetaData(viewModel.SelectedApplication.TitleId, appMetadata =>
=======
                viewModel.ApplicationLibrary.LoadAndSaveMetaData(viewModel.SelectedApplication.TitleId, appMetadata =>
>>>>>>> 1ec71635b (sync with main branch)
                {
                    appMetadata.Favorite = viewModel.SelectedApplication.Favorite;
                });

                viewModel.RefreshView();
            }
        }

        public void OpenUserSaveDirectory_Click(object sender, RoutedEventArgs args)
        {
<<<<<<< HEAD
            if (sender is MenuItem { DataContext: MainWindowViewModel viewModel })
            {
                OpenSaveDirectory(viewModel, SaveDataType.Account, new UserId((ulong)viewModel.AccountManager.LastOpenedUser.UserId.High, (ulong)viewModel.AccountManager.LastOpenedUser.UserId.Low));
=======
            if ((sender as MenuItem)?.DataContext is MainWindowViewModel viewModel)
            {
                OpenSaveDirectory(viewModel, SaveDataType.Account, userId: new UserId((ulong)viewModel.AccountManager.LastOpenedUser.UserId.High, (ulong)viewModel.AccountManager.LastOpenedUser.UserId.Low));
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public void OpenDeviceSaveDirectory_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

<<<<<<< HEAD
            OpenSaveDirectory(viewModel, SaveDataType.Device, default);
=======
            OpenSaveDirectory(viewModel, SaveDataType.Device, userId: default);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void OpenBcatSaveDirectory_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

<<<<<<< HEAD
            OpenSaveDirectory(viewModel, SaveDataType.Bcat, default);
=======
            OpenSaveDirectory(viewModel, SaveDataType.Bcat, userId: default);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static void OpenSaveDirectory(MainWindowViewModel viewModel, SaveDataType saveDataType, UserId userId)
        {
            if (viewModel?.SelectedApplication != null)
            {
                if (!ulong.TryParse(viewModel.SelectedApplication.TitleId, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out ulong titleIdNumber))
                {
                    Dispatcher.UIThread.InvokeAsync(async () =>
                    {
                        await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance[LocaleKeys.DialogRyujinxErrorMessage], LocaleManager.Instance[LocaleKeys.DialogInvalidTitleIdErrorMessage]);
                    });

                    return;
                }

                var saveDataFilter = SaveDataFilter.Make(titleIdNumber, saveDataType, userId, saveDataId: default, index: default);

                ApplicationHelper.OpenSaveDir(in saveDataFilter, titleIdNumber, viewModel.SelectedApplication.ControlHolder, viewModel.SelectedApplication.TitleName);
            }
        }

        public async void OpenTitleUpdateManager_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                await TitleUpdateWindow.Show(viewModel.VirtualFileSystem, ulong.Parse(viewModel.SelectedApplication.TitleId, NumberStyles.HexNumber), viewModel.SelectedApplication.TitleName);
            }
        }

        public async void OpenDownloadableContentManager_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                await DownloadableContentManagerWindow.Show(viewModel.VirtualFileSystem, ulong.Parse(viewModel.SelectedApplication.TitleId, NumberStyles.HexNumber), viewModel.SelectedApplication.TitleName);
            }
        }

        public async void OpenCheatManager_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                await new CheatWindow(
                    viewModel.VirtualFileSystem,
                    viewModel.SelectedApplication.TitleId,
                    viewModel.SelectedApplication.TitleName,
                    viewModel.SelectedApplication.Path).ShowDialog(viewModel.TopLevel as Window);
            }
        }

        public void OpenModsDirectory_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                string modsBasePath = ModLoader.GetModsBasePath();
<<<<<<< HEAD
                string titleModsPath = ModLoader.GetApplicationDir(modsBasePath, viewModel.SelectedApplication.TitleId);
=======
                string titleModsPath = ModLoader.GetTitleDir(modsBasePath, viewModel.SelectedApplication.TitleId);
>>>>>>> 1ec71635b (sync with main branch)

                OpenHelper.OpenFolder(titleModsPath);
            }
        }

        public void OpenSdModsDirectory_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                string sdModsBasePath = ModLoader.GetSdModsBasePath();
<<<<<<< HEAD
                string titleModsPath = ModLoader.GetApplicationDir(sdModsBasePath, viewModel.SelectedApplication.TitleId);
=======
                string titleModsPath = ModLoader.GetTitleDir(sdModsBasePath, viewModel.SelectedApplication.TitleId);
>>>>>>> 1ec71635b (sync with main branch)

                OpenHelper.OpenFolder(titleModsPath);
            }
        }

<<<<<<< HEAD
        public async void OpenModManager_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                await ModManagerWindow.Show(ulong.Parse(viewModel.SelectedApplication.TitleId, NumberStyles.HexNumber), viewModel.SelectedApplication.TitleName);
            }
        }

=======
>>>>>>> 1ec71635b (sync with main branch)
        public async void PurgePtcCache_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
<<<<<<< HEAD
                UserResult result = await ContentDialogHelper.CreateConfirmationDialog(
                    LocaleManager.Instance[LocaleKeys.DialogWarning],
                    LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogPPTCDeletionMessage, viewModel.SelectedApplication.TitleName),
                    LocaleManager.Instance[LocaleKeys.InputDialogYes],
                    LocaleManager.Instance[LocaleKeys.InputDialogNo],
                    LocaleManager.Instance[LocaleKeys.RyujinxConfirm]);
=======
                UserResult result = await ContentDialogHelper.CreateConfirmationDialog(LocaleManager.Instance[LocaleKeys.DialogWarning],
                                                                                       LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogPPTCDeletionMessage, viewModel.SelectedApplication.TitleName),
                                                                                       LocaleManager.Instance[LocaleKeys.InputDialogYes],
                                                                                       LocaleManager.Instance[LocaleKeys.InputDialogNo],
                                                                                       LocaleManager.Instance[LocaleKeys.RyujinxConfirm]);
>>>>>>> 1ec71635b (sync with main branch)

                if (result == UserResult.Yes)
                {
                    DirectoryInfo mainDir = new(Path.Combine(AppDataManager.GamesDirPath, viewModel.SelectedApplication.TitleId, "cache", "cpu", "0"));
                    DirectoryInfo backupDir = new(Path.Combine(AppDataManager.GamesDirPath, viewModel.SelectedApplication.TitleId, "cache", "cpu", "1"));

                    List<FileInfo> cacheFiles = new();

                    if (mainDir.Exists)
                    {
                        cacheFiles.AddRange(mainDir.EnumerateFiles("*.cache"));
                    }

                    if (backupDir.Exists)
                    {
                        cacheFiles.AddRange(backupDir.EnumerateFiles("*.cache"));
                    }

                    if (cacheFiles.Count > 0)
                    {
                        foreach (FileInfo file in cacheFiles)
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch (Exception ex)
                            {
                                await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogPPTCDeletionErrorMessage, file.Name, ex));
                            }
                        }
                    }
                }
            }
        }

        public async void PurgeShaderCache_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
<<<<<<< HEAD
                UserResult result = await ContentDialogHelper.CreateConfirmationDialog(
                    LocaleManager.Instance[LocaleKeys.DialogWarning],
                    LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogShaderDeletionMessage, viewModel.SelectedApplication.TitleName),
                    LocaleManager.Instance[LocaleKeys.InputDialogYes],
                    LocaleManager.Instance[LocaleKeys.InputDialogNo],
                    LocaleManager.Instance[LocaleKeys.RyujinxConfirm]);
=======
                UserResult result = await ContentDialogHelper.CreateConfirmationDialog(LocaleManager.Instance[LocaleKeys.DialogWarning],
                                                                                       LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogShaderDeletionMessage, viewModel.SelectedApplication.TitleName),
                                                                                       LocaleManager.Instance[LocaleKeys.InputDialogYes],
                                                                                       LocaleManager.Instance[LocaleKeys.InputDialogNo],
                                                                                       LocaleManager.Instance[LocaleKeys.RyujinxConfirm]);
>>>>>>> 1ec71635b (sync with main branch)

                if (result == UserResult.Yes)
                {
                    DirectoryInfo shaderCacheDir = new(Path.Combine(AppDataManager.GamesDirPath, viewModel.SelectedApplication.TitleId, "cache", "shader"));

                    List<DirectoryInfo> oldCacheDirectories = new();
                    List<FileInfo> newCacheFiles = new();

                    if (shaderCacheDir.Exists)
                    {
                        oldCacheDirectories.AddRange(shaderCacheDir.EnumerateDirectories("*"));
                        newCacheFiles.AddRange(shaderCacheDir.GetFiles("*.toc"));
                        newCacheFiles.AddRange(shaderCacheDir.GetFiles("*.data"));
                    }

                    if ((oldCacheDirectories.Count > 0 || newCacheFiles.Count > 0))
                    {
                        foreach (DirectoryInfo directory in oldCacheDirectories)
                        {
                            try
                            {
                                directory.Delete(true);
                            }
                            catch (Exception ex)
                            {
                                await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogPPTCDeletionErrorMessage, directory.Name, ex));
                            }
                        }

                        foreach (FileInfo file in newCacheFiles)
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch (Exception ex)
                            {
                                await ContentDialogHelper.CreateErrorDialog(LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.ShaderCachePurgeError, file.Name, ex));
                            }
                        }
                    }
                }
            }
        }

        public void OpenPtcDirectory_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                string ptcDir = Path.Combine(AppDataManager.GamesDirPath, viewModel.SelectedApplication.TitleId, "cache", "cpu");
                string mainDir = Path.Combine(ptcDir, "0");
                string backupDir = Path.Combine(ptcDir, "1");

                if (!Directory.Exists(ptcDir))
                {
                    Directory.CreateDirectory(ptcDir);
                    Directory.CreateDirectory(mainDir);
                    Directory.CreateDirectory(backupDir);
                }

                OpenHelper.OpenFolder(ptcDir);
            }
        }

        public void OpenShaderCacheDirectory_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                string shaderCacheDir = Path.Combine(AppDataManager.GamesDirPath, viewModel.SelectedApplication.TitleId, "cache", "shader");

                if (!Directory.Exists(shaderCacheDir))
                {
                    Directory.CreateDirectory(shaderCacheDir);
                }

                OpenHelper.OpenFolder(shaderCacheDir);
            }
        }

        public async void ExtractApplicationExeFs_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
<<<<<<< HEAD
                await ApplicationHelper.ExtractSection(
                    viewModel.StorageProvider,
                    NcaSectionType.Code,
                    viewModel.SelectedApplication.Path,
                    viewModel.SelectedApplication.TitleName);
=======
                await ApplicationHelper.ExtractSection(NcaSectionType.Code, viewModel.SelectedApplication.Path, viewModel.SelectedApplication.TitleName);
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public async void ExtractApplicationRomFs_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
<<<<<<< HEAD
                await ApplicationHelper.ExtractSection(
                    viewModel.StorageProvider,
                    NcaSectionType.Data,
                    viewModel.SelectedApplication.Path,
                    viewModel.SelectedApplication.TitleName);
=======
                await ApplicationHelper.ExtractSection(NcaSectionType.Data, viewModel.SelectedApplication.Path, viewModel.SelectedApplication.TitleName);
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public async void ExtractApplicationLogo_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
<<<<<<< HEAD
                await ApplicationHelper.ExtractSection(
                    viewModel.StorageProvider,
                    NcaSectionType.Logo,
                    viewModel.SelectedApplication.Path,
                    viewModel.SelectedApplication.TitleName);
            }
        }

        public void CreateApplicationShortcut_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                ApplicationData selectedApplication = viewModel.SelectedApplication;
                ShortcutHelper.CreateAppShortcut(selectedApplication.Path, selectedApplication.TitleName, selectedApplication.TitleId, selectedApplication.Icon);
            }
        }

        public async void RunApplication_Click(object sender, RoutedEventArgs args)
        {
            var viewModel = (sender as MenuItem)?.DataContext as MainWindowViewModel;

            if (viewModel?.SelectedApplication != null)
            {
                await viewModel.LoadApplication(viewModel.SelectedApplication.Path);
            }
        }
    }
}
=======
                await ApplicationHelper.ExtractSection(NcaSectionType.Logo, viewModel.SelectedApplication.Path, viewModel.SelectedApplication.TitleName);
            }
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
