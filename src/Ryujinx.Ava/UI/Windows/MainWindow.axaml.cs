using Avalonia;
using Avalonia.Controls;
<<<<<<< HEAD
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
=======
using Avalonia.Input;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Threading;
using FluentAvalonia.UI.Controls;
using Ryujinx.Ava.Common;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.Input;
using Ryujinx.Ava.UI.Applet;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Common.Logging;
using Ryujinx.Graphics.Gpu;
using Ryujinx.HLE.FileSystem;
using Ryujinx.HLE.HOS;
using Ryujinx.HLE.HOS.Services.Account.Acc;
<<<<<<< HEAD
using Ryujinx.Input.HLE;
using Ryujinx.Input.SDL2;
using Ryujinx.Modules;
using Ryujinx.UI.App.Common;
using Ryujinx.UI.Common;
using Ryujinx.UI.Common.Configuration;
using Ryujinx.UI.Common.Helper;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
=======
using Ryujinx.Input.SDL2;
using Ryujinx.Modules;
using Ryujinx.Ui.App.Common;
using Ryujinx.Ui.Common;
using Ryujinx.Ui.Common.Configuration;
using Ryujinx.Ui.Common.Helper;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using InputManager = Ryujinx.Input.HLE.InputManager;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Ava.UI.Windows
{
    public partial class MainWindow : StyleableWindow
    {
        internal static MainWindowViewModel MainWindowViewModel { get; private set; }

        private bool _isLoading;

        private UserChannelPersistence _userChannelPersistence;
        private static bool _deferLoad;
        private static string _launchPath;
        private static bool _startFullscreen;
<<<<<<< HEAD
        internal readonly AvaHostUIHandler UiHandler;
=======
        internal readonly AvaHostUiHandler UiHandler;
>>>>>>> 1ec71635b (sync with main branch)

        public VirtualFileSystem VirtualFileSystem { get; private set; }
        public ContentManager ContentManager { get; private set; }
        public AccountManager AccountManager { get; private set; }

        public LibHacHorizonManager LibHacHorizonManager { get; private set; }

        public InputManager InputManager { get; private set; }

        internal MainWindowViewModel ViewModel { get; private set; }
        public SettingsWindow SettingsWindow { get; set; }

        public static bool ShowKeyErrorOnLoad { get; set; }
        public ApplicationLibrary ApplicationLibrary { get; set; }

        public MainWindow()
        {
            ViewModel = new MainWindowViewModel();

            MainWindowViewModel = ViewModel;

            DataContext = ViewModel;

            SetWindowSizePosition();

            InitializeComponent();
            Load();

<<<<<<< HEAD
            UiHandler = new AvaHostUIHandler(this);
=======
            UiHandler = new AvaHostUiHandler(this);
>>>>>>> 1ec71635b (sync with main branch)

            ViewModel.Title = $"Ryujinx {Program.Version}";

            // NOTE: Height of MenuBar and StatusBar is not usable here, since it would still be 0 at this point.
            double barHeight = MenuBar.MinHeight + StatusBarView.StatusBar.MinHeight;
            Height = ((Height - barHeight) / Program.WindowScaleFactor) + barHeight;
            Width /= Program.WindowScaleFactor;

            if (Program.PreviewerDetached)
            {
<<<<<<< HEAD
                InputManager = new InputManager(new AvaloniaKeyboardDriver(this), new SDL2GamepadDriver());

                this.GetObservable(IsActiveProperty).Subscribe(IsActiveChanged);
                this.ScalingChanged += OnScalingChanged;
            }
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
=======
                Initialize();

                InputManager = new InputManager(new AvaloniaKeyboardDriver(this), new SDL2GamepadDriver());

                ViewModel.Initialize(
                    ContentManager,
                    ApplicationLibrary,
                    VirtualFileSystem,
                    AccountManager,
                    InputManager,
                    _userChannelPersistence,
                    LibHacHorizonManager,
                    UiHandler,
                    ShowLoading,
                    SwitchToGameControl,
                    SetMainContent,
                    this);

                ViewModel.RefreshFirmwareStatus();

                LoadGameList();

                this.GetObservable(IsActiveProperty).Subscribe(IsActiveChanged);
            }

            ApplicationLibrary.ApplicationCountUpdated += ApplicationLibrary_ApplicationCountUpdated;
            ApplicationLibrary.ApplicationAdded += ApplicationLibrary_ApplicationAdded;
            ViewModel.ReloadGameList += ReloadGameList;
>>>>>>> 1ec71635b (sync with main branch)

            NotificationHelper.SetNotificationManager(this);
        }

        private void IsActiveChanged(bool obj)
        {
            ViewModel.IsActive = obj;
        }

<<<<<<< HEAD
        private void OnScalingChanged(object sender, EventArgs e)
        {
            Program.DesktopScaleFactor = this.RenderScaling;
=======
        public void LoadGameList()
        {
            if (_isLoading)
            {
                return;
            }

            _isLoading = true;

            LoadApplications();

            _isLoading = false;
        }

        protected override void HandleScalingChanged(double scale)
        {
            Program.DesktopScaleFactor = scale;
            base.HandleScalingChanged(scale);
        }

        public void AddApplication(ApplicationData applicationData)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                ViewModel.Applications.Add(applicationData);
            });
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void ApplicationLibrary_ApplicationAdded(object sender, ApplicationAddedEventArgs e)
        {
<<<<<<< HEAD
            Dispatcher.UIThread.Post(() =>
            {
                ViewModel.Applications.Add(e.AppData);
            });
=======
            AddApplication(e.AppData);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void ApplicationLibrary_ApplicationCountUpdated(object sender, ApplicationCountUpdatedEventArgs e)
        {
            LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.StatusBarGamesLoaded, e.NumAppsLoaded, e.NumAppsFound);

            Dispatcher.UIThread.Post(() =>
            {
<<<<<<< HEAD
                ViewModel.StatusBarProgressValue = e.NumAppsLoaded;
=======
                ViewModel.StatusBarProgressValue   = e.NumAppsLoaded;
>>>>>>> 1ec71635b (sync with main branch)
                ViewModel.StatusBarProgressMaximum = e.NumAppsFound;

                if (e.NumAppsFound == 0)
                {
                    StatusBarView.LoadProgressBar.IsVisible = false;
                }

                if (e.NumAppsLoaded == e.NumAppsFound)
                {
                    StatusBarView.LoadProgressBar.IsVisible = false;
                }
            });
        }

        public void Application_Opened(object sender, ApplicationOpenedEventArgs args)
        {
            if (args.Application != null)
            {
                ViewModel.SelectedIcon = args.Application.Icon;

                string path = new FileInfo(args.Application.Path).FullName;

<<<<<<< HEAD
                ViewModel.LoadApplication(path).Wait();
=======
                ViewModel.LoadApplication(path);
>>>>>>> 1ec71635b (sync with main branch)
            }

            args.Handled = true;
        }

        internal static void DeferLoadApplication(string launchPathArg, bool startFullscreenArg)
        {
            _deferLoad = true;
            _launchPath = launchPathArg;
            _startFullscreen = startFullscreenArg;
        }

        public void SwitchToGameControl(bool startFullscreen = false)
        {
            ViewModel.ShowLoadProgress = false;
            ViewModel.ShowContent = true;
            ViewModel.IsLoadingIndeterminate = false;

<<<<<<< HEAD
            if (startFullscreen && ViewModel.WindowState != WindowState.FullScreen)
            {
                ViewModel.ToggleFullscreen();
            }
=======
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (startFullscreen && ViewModel.WindowState != WindowState.FullScreen)
                {
                    ViewModel.ToggleFullscreen();
                }
            });
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void ShowLoading(bool startFullscreen = false)
        {
            ViewModel.ShowContent = false;
            ViewModel.ShowLoadProgress = true;
            ViewModel.IsLoadingIndeterminate = true;

<<<<<<< HEAD
            if (startFullscreen && ViewModel.WindowState != WindowState.FullScreen)
            {
                ViewModel.ToggleFullscreen();
=======
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (startFullscreen && ViewModel.WindowState != WindowState.FullScreen)
                {
                    ViewModel.ToggleFullscreen();
                }
            });
        }

        protected override void HandleWindowStateChanged(WindowState state)
        {
            ViewModel.WindowState = state;

            if (state != WindowState.Minimized)
            {
                Renderer.Start();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        private void Initialize()
        {
            _userChannelPersistence = new UserChannelPersistence();
            VirtualFileSystem = VirtualFileSystem.CreateInstance();
            LibHacHorizonManager = new LibHacHorizonManager();
            ContentManager = new ContentManager(VirtualFileSystem);

            LibHacHorizonManager.InitializeFsServer(VirtualFileSystem);
            LibHacHorizonManager.InitializeArpServer();
            LibHacHorizonManager.InitializeBcatServer();
            LibHacHorizonManager.InitializeSystemClients();

            ApplicationLibrary = new ApplicationLibrary(VirtualFileSystem);

            // Save data created before we supported extra data in directory save data will not work properly if
            // given empty extra data. Luckily some of that extra data can be created using the data from the
            // save data indexer, which should be enough to check access permissions for user saves.
            // Every single save data's extra data will be checked and fixed if needed each time the emulator is opened.
            // Consider removing this at some point in the future when we don't need to worry about old saves.
            VirtualFileSystem.FixExtraData(LibHacHorizonManager.RyujinxClient);

            AccountManager = new AccountManager(LibHacHorizonManager.RyujinxClient, CommandLineState.Profile);

            VirtualFileSystem.ReloadKeySet();

<<<<<<< HEAD
            ApplicationHelper.Initialize(VirtualFileSystem, AccountManager, LibHacHorizonManager.RyujinxClient);
        }

        [SupportedOSPlatform("linux")]
        private static async Task ShowVmMaxMapCountWarning()
        {
            LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.LinuxVmMaxMapCountWarningTextSecondary,
                LinuxHelper.VmMaxMapCount, LinuxHelper.RecommendedVmMaxMapCount);

            await ContentDialogHelper.CreateWarningDialog(
                LocaleManager.Instance[LocaleKeys.LinuxVmMaxMapCountWarningTextPrimary],
                LocaleManager.Instance[LocaleKeys.LinuxVmMaxMapCountWarningTextSecondary]
            );
        }

        [SupportedOSPlatform("linux")]
        private static async Task ShowVmMaxMapCountDialog()
        {
            LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.LinuxVmMaxMapCountDialogTextPrimary,
                LinuxHelper.RecommendedVmMaxMapCount);

            UserResult response = await ContentDialogHelper.ShowTextDialog(
                $"Ryujinx - {LocaleManager.Instance[LocaleKeys.LinuxVmMaxMapCountDialogTitle]}",
                LocaleManager.Instance[LocaleKeys.LinuxVmMaxMapCountDialogTextPrimary],
                LocaleManager.Instance[LocaleKeys.LinuxVmMaxMapCountDialogTextSecondary],
                LocaleManager.Instance[LocaleKeys.LinuxVmMaxMapCountDialogButtonUntilRestart],
                LocaleManager.Instance[LocaleKeys.LinuxVmMaxMapCountDialogButtonPersistent],
                LocaleManager.Instance[LocaleKeys.InputDialogNo],
                (int)Symbol.Help
            );

            int rc;

            switch (response)
            {
                case UserResult.Ok:
                    rc = LinuxHelper.RunPkExec($"echo {LinuxHelper.RecommendedVmMaxMapCount} > {LinuxHelper.VmMaxMapCountPath}");
                    if (rc == 0)
                    {
                        Logger.Info?.Print(LogClass.Application, $"vm.max_map_count set to {LinuxHelper.VmMaxMapCount} until the next restart.");
                    }
                    else
                    {
                        Logger.Error?.Print(LogClass.Application, $"Unable to change vm.max_map_count. Process exited with code: {rc}");
                    }
                    break;
                case UserResult.No:
                    rc = LinuxHelper.RunPkExec($"echo \"vm.max_map_count = {LinuxHelper.RecommendedVmMaxMapCount}\" > {LinuxHelper.SysCtlConfigPath} && sysctl -p {LinuxHelper.SysCtlConfigPath}");
                    if (rc == 0)
                    {
                        Logger.Info?.Print(LogClass.Application, $"vm.max_map_count set to {LinuxHelper.VmMaxMapCount}. Written to config: {LinuxHelper.SysCtlConfigPath}");
                    }
                    else
                    {
                        Logger.Error?.Print(LogClass.Application, $"Unable to write new value for vm.max_map_count to config. Process exited with code: {rc}");
                    }
                    break;
            }
        }

        private async Task CheckLaunchState()
        {
            if (OperatingSystem.IsLinux() && LinuxHelper.VmMaxMapCount < LinuxHelper.RecommendedVmMaxMapCount)
            {
                Logger.Warning?.Print(LogClass.Application, $"The value of vm.max_map_count is lower than {LinuxHelper.RecommendedVmMaxMapCount}. ({LinuxHelper.VmMaxMapCount})");

                if (LinuxHelper.PkExecPath is not null)
                {
                    await Dispatcher.UIThread.InvokeAsync(ShowVmMaxMapCountDialog);
                }
                else
                {
                    await Dispatcher.UIThread.InvokeAsync(ShowVmMaxMapCountWarning);
                }
            }

            if (!ShowKeyErrorOnLoad)
            {
                if (_deferLoad)
                {
                    _deferLoad = false;

                    ViewModel.LoadApplication(_launchPath, _startFullscreen).Wait();
                }
            }
            else
            {
                ShowKeyErrorOnLoad = false;

                await Dispatcher.UIThread.InvokeAsync(async () => await UserErrorDialog.ShowUserErrorDialog(UserError.NoKeys));
=======
            ApplicationHelper.Initialize(VirtualFileSystem, AccountManager, LibHacHorizonManager.RyujinxClient, this);
        }

        protected void CheckLaunchState()
        {
            if (ShowKeyErrorOnLoad)
            {
                ShowKeyErrorOnLoad = false;

                Dispatcher.UIThread.Post(async () => await
                    UserErrorDialog.ShowUserErrorDialog(UserError.NoKeys, this));
            }

            if (_deferLoad)
            {
                _deferLoad = false;

                ViewModel.LoadApplication(_launchPath, _startFullscreen);
>>>>>>> 1ec71635b (sync with main branch)
            }

            if (ConfigurationState.Instance.CheckUpdatesOnStart.Value && Updater.CanUpdate(false))
            {
<<<<<<< HEAD
                await Updater.BeginParse(this, false).ContinueWith(task =>
=======
                Updater.BeginParse(this, false).ContinueWith(task =>
>>>>>>> 1ec71635b (sync with main branch)
                {
                    Logger.Error?.Print(LogClass.Application, $"Updater Error: {task.Exception}");
                }, TaskContinuationOptions.OnlyOnFaulted);
            }
        }

        private void Load()
        {
            StatusBarView.VolumeStatus.Click += VolumeStatus_CheckedChanged;

            ApplicationGrid.ApplicationOpened += Application_Opened;

            ApplicationGrid.DataContext = ViewModel;

            ApplicationList.ApplicationOpened += Application_Opened;

            ApplicationList.DataContext = ViewModel;
<<<<<<< HEAD
=======

            LoadHotKeys();
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void SetWindowSizePosition()
        {
<<<<<<< HEAD
            PixelPoint savedPoint = new(ConfigurationState.Instance.UI.WindowStartup.WindowPositionX,
                                        ConfigurationState.Instance.UI.WindowStartup.WindowPositionY);

            ViewModel.WindowHeight = ConfigurationState.Instance.UI.WindowStartup.WindowSizeHeight * Program.WindowScaleFactor;
            ViewModel.WindowWidth = ConfigurationState.Instance.UI.WindowStartup.WindowSizeWidth * Program.WindowScaleFactor;

            ViewModel.WindowState = ConfigurationState.Instance.UI.WindowStartup.WindowMaximized.Value ? WindowState.Maximized : WindowState.Normal;

            if (CheckScreenBounds(savedPoint))
            {
                Position = savedPoint;
            }
            else
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }

        private bool CheckScreenBounds(PixelPoint configPoint)
        {
=======
            PixelPoint SavedPoint = new PixelPoint(ConfigurationState.Instance.Ui.WindowStartup.WindowPositionX, 
                                                   ConfigurationState.Instance.Ui.WindowStartup.WindowPositionY);

            ViewModel.WindowHeight = ConfigurationState.Instance.Ui.WindowStartup.WindowSizeHeight * Program.WindowScaleFactor;
            ViewModel.WindowWidth = ConfigurationState.Instance.Ui.WindowStartup.WindowSizeWidth * Program.WindowScaleFactor;

            ViewModel.WindowState = ConfigurationState.Instance.Ui.WindowStartup.WindowMaximized.Value is true ? WindowState.Maximized : WindowState.Normal;
        
            if (CheckScreenBounds(SavedPoint))
            {
                Position = SavedPoint;
            }

            else WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private bool CheckScreenBounds(PixelPoint configPoint)
        {   
>>>>>>> 1ec71635b (sync with main branch)
            for (int i = 0; i < Screens.ScreenCount; i++)
            {
                if (Screens.All[i].Bounds.Contains(configPoint))
                {
                    return true;
                }
            }

<<<<<<< HEAD
            Logger.Warning?.Print(LogClass.Application, "Failed to find valid start-up coordinates. Defaulting to primary monitor center.");
=======
            Logger.Warning?.Print(LogClass.Application, $"Failed to find valid start-up coordinates. Defaulting to primary monitor center.");
>>>>>>> 1ec71635b (sync with main branch)
            return false;
        }

        private void SaveWindowSizePosition()
        {
<<<<<<< HEAD
            ConfigurationState.Instance.UI.WindowStartup.WindowSizeHeight.Value = (int)Height;
            ConfigurationState.Instance.UI.WindowStartup.WindowSizeWidth.Value = (int)Width;

            ConfigurationState.Instance.UI.WindowStartup.WindowPositionX.Value = Position.X;
            ConfigurationState.Instance.UI.WindowStartup.WindowPositionY.Value = Position.Y;

            ConfigurationState.Instance.UI.WindowStartup.WindowMaximized.Value = WindowState == WindowState.Maximized;
=======
            ConfigurationState.Instance.Ui.WindowStartup.WindowSizeHeight.Value = (int)Height;
            ConfigurationState.Instance.Ui.WindowStartup.WindowSizeWidth.Value = (int)Width;

            ConfigurationState.Instance.Ui.WindowStartup.WindowPositionX.Value = Position.X;
            ConfigurationState.Instance.Ui.WindowStartup.WindowPositionY.Value = Position.Y;

            ConfigurationState.Instance.Ui.WindowStartup.WindowMaximized.Value = WindowState == WindowState.Maximized;
>>>>>>> 1ec71635b (sync with main branch)

            MainWindowViewModel.SaveConfig();
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);

<<<<<<< HEAD
            Initialize();

            ViewModel.Initialize(
                ContentManager,
                StorageProvider,
                ApplicationLibrary,
                VirtualFileSystem,
                AccountManager,
                InputManager,
                _userChannelPersistence,
                LibHacHorizonManager,
                UiHandler,
                ShowLoading,
                SwitchToGameControl,
                SetMainContent,
                this);

            ApplicationLibrary.ApplicationCountUpdated += ApplicationLibrary_ApplicationCountUpdated;
            ApplicationLibrary.ApplicationAdded += ApplicationLibrary_ApplicationAdded;

            ViewModel.RefreshFirmwareStatus();

            LoadApplications();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            CheckLaunchState();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
=======
            CheckLaunchState();
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void SetMainContent(Control content = null)
        {
<<<<<<< HEAD
            content ??= GameLibrary;
=======
            if (content == null)
            {
                content = GameLibrary;
            }
>>>>>>> 1ec71635b (sync with main branch)

            if (MainContent.Content != content)
            {
                MainContent.Content = content;
            }
        }

        public static void UpdateGraphicsConfig()
        {
<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
=======
>>>>>>> 1ec71635b (sync with main branch)
            GraphicsConfig.ResScale                   = ConfigurationState.Instance.Graphics.ResScale == -1 ? ConfigurationState.Instance.Graphics.ResScaleCustom : ConfigurationState.Instance.Graphics.ResScale;
            GraphicsConfig.MaxAnisotropy              = ConfigurationState.Instance.Graphics.MaxAnisotropy;
            GraphicsConfig.ShadersDumpPath            = ConfigurationState.Instance.Graphics.ShadersDumpPath;
            GraphicsConfig.EnableShaderCache          = ConfigurationState.Instance.Graphics.EnableShaderCache;
            GraphicsConfig.EnableTextureRecompression = ConfigurationState.Instance.Graphics.EnableTextureRecompression;
            GraphicsConfig.EnableMacroHLE             = ConfigurationState.Instance.Graphics.EnableMacroHLE;
<<<<<<< HEAD
#pragma warning restore IDE0055
        }

        private void VolumeStatus_CheckedChanged(object sender, RoutedEventArgs e)
=======
        }

        public void LoadHotKeys()
        {
            HotKeyManager.SetHotKey(FullscreenHotKey,      new KeyGesture(Key.Enter, KeyModifiers.Alt));
            HotKeyManager.SetHotKey(FullscreenHotKey2,     new KeyGesture(Key.F11));
            HotKeyManager.SetHotKey(FullscreenHotKeyMacOS, new KeyGesture(Key.F, KeyModifiers.Control | KeyModifiers.Meta));
            HotKeyManager.SetHotKey(DockToggleHotKey,      new KeyGesture(Key.F9));
            HotKeyManager.SetHotKey(ExitHotKey,            new KeyGesture(Key.Escape));
        }

        private void VolumeStatus_CheckedChanged(object sender, SplitButtonClickEventArgs e)
>>>>>>> 1ec71635b (sync with main branch)
        {
            var volumeSplitButton = sender as ToggleSplitButton;
            if (ViewModel.IsGameRunning)
            {
                if (!volumeSplitButton.IsChecked)
                {
<<<<<<< HEAD
                    ViewModel.AppHost.Device.SetVolume(ViewModel.VolumeBeforeMute);
                }
                else
                {
                    ViewModel.VolumeBeforeMute = ViewModel.AppHost.Device.GetVolume();
=======
                    ViewModel.AppHost.Device.SetVolume(ConfigurationState.Instance.System.AudioVolume);
                }
                else
                {
>>>>>>> 1ec71635b (sync with main branch)
                    ViewModel.AppHost.Device.SetVolume(0);
                }

                ViewModel.Volume = ViewModel.AppHost.Device.GetVolume();
            }
        }

<<<<<<< HEAD
        protected override void OnClosing(WindowClosingEventArgs e)
=======
        protected override void OnClosing(CancelEventArgs e)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (!ViewModel.IsClosing && ViewModel.AppHost != null && ConfigurationState.Instance.ShowConfirmExit)
            {
                e.Cancel = true;

                ConfirmExit();

                return;
            }

            ViewModel.IsClosing = true;

            if (ViewModel.AppHost != null)
            {
                ViewModel.AppHost.AppExit -= ViewModel.AppHost_AppExit;
                ViewModel.AppHost.AppExit += (sender, e) =>
                {
                    ViewModel.AppHost = null;

                    Dispatcher.UIThread.Post(() =>
                    {
                        MainContent = null;

                        Close();
                    });
                };
                ViewModel.AppHost?.Stop();

                e.Cancel = true;

                return;
            }

            SaveWindowSizePosition();

            ApplicationLibrary.CancelLoading();
            InputManager.Dispose();
            Program.Exit();

            base.OnClosing(e);
        }

        private void ConfirmExit()
        {
            Dispatcher.UIThread.InvokeAsync(async () =>
<<<<<<< HEAD
            {
                ViewModel.IsClosing = await ContentDialogHelper.CreateExitDialog();

                if (ViewModel.IsClosing)
                {
                    Close();
                }
            });
        }

        public void LoadApplications()
        {
            ViewModel.Applications.Clear();

            StatusBarView.LoadProgressBar.IsVisible = true;
            ViewModel.StatusBarProgressMaximum = 0;
            ViewModel.StatusBarProgressValue = 0;

            LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.StatusBarGamesLoaded, 0, 0);
=======
           {
               ViewModel.IsClosing = await ContentDialogHelper.CreateExitDialog();

               if (ViewModel.IsClosing)
               {
                   Close();
               }
           });
        }

        public async void LoadApplications()
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                ViewModel.Applications.Clear();

                StatusBarView.LoadProgressBar.IsVisible = true;
                ViewModel.StatusBarProgressMaximum      = 0;
                ViewModel.StatusBarProgressValue        = 0;

                LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.StatusBarGamesLoaded, 0, 0);
            });
>>>>>>> 1ec71635b (sync with main branch)

            ReloadGameList();
        }

<<<<<<< HEAD
        public void ToggleFileType(string fileType)
        {
            _ = fileType switch
            {
#pragma warning disable IDE0055 // Disable formatting
                "NSP"  => ConfigurationState.Instance.UI.ShownFileTypes.NSP.Value  = !ConfigurationState.Instance.UI.ShownFileTypes.NSP,
                "PFS0" => ConfigurationState.Instance.UI.ShownFileTypes.PFS0.Value = !ConfigurationState.Instance.UI.ShownFileTypes.PFS0,
                "XCI"  => ConfigurationState.Instance.UI.ShownFileTypes.XCI.Value  = !ConfigurationState.Instance.UI.ShownFileTypes.XCI,
                "NCA"  => ConfigurationState.Instance.UI.ShownFileTypes.NCA.Value  = !ConfigurationState.Instance.UI.ShownFileTypes.NCA,
                "NRO"  => ConfigurationState.Instance.UI.ShownFileTypes.NRO.Value  = !ConfigurationState.Instance.UI.ShownFileTypes.NRO,
                "NSO"  => ConfigurationState.Instance.UI.ShownFileTypes.NSO.Value  = !ConfigurationState.Instance.UI.ShownFileTypes.NSO,
                _  => throw new ArgumentOutOfRangeException(fileType),
#pragma warning restore IDE0055
            };

            ConfigurationState.Instance.ToFileFormat().SaveConfig(Program.ConfigurationPath);
            LoadApplications();
        }

=======
>>>>>>> 1ec71635b (sync with main branch)
        private void ReloadGameList()
        {
            if (_isLoading)
            {
                return;
            }

            _isLoading = true;

<<<<<<< HEAD
            Thread applicationLibraryThread = new(() =>
            {
                ApplicationLibrary.LoadApplications(ConfigurationState.Instance.UI.GameDirs, ConfigurationState.Instance.System.Language);

                _isLoading = false;
            })
            {
                Name = "GUI.ApplicationLibraryThread",
                IsBackground = true,
            };
            applicationLibraryThread.Start();
        }
    }
}
=======
            ApplicationLibrary.LoadApplications(ConfigurationState.Instance.Ui.GameDirs.Value, ConfigurationState.Instance.System.Language);

            _isLoading = false;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
