using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
<<<<<<< HEAD
using Avalonia.Layout;
=======
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Media;
using Avalonia.Threading;
using FluentAvalonia.Core;
using FluentAvalonia.UI.Controls;
using Ryujinx.Ava.Common.Locale;
<<<<<<< HEAD
=======
using Ryujinx.Ava.UI.Controls;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Ava.UI.Windows;
using Ryujinx.Common.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ryujinx.Ava.UI.Helpers
{
    public static class ContentDialogHelper
    {
        private static bool _isChoiceDialogOpen;
<<<<<<< HEAD
        private static ContentDialogOverlayWindow _contentDialogOverlayWindow;

        private async static Task<UserResult> ShowContentDialog(
=======

        public async static Task<UserResult> ShowContentDialog(
>>>>>>> 1ec71635b (sync with main branch)
             string title,
             object content,
             string primaryButton,
             string secondaryButton,
             string closeButton,
             UserResult primaryButtonResult = UserResult.Ok,
             ManualResetEvent deferResetEvent = null,
             TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> deferCloseAction = null)
        {
            UserResult result = UserResult.None;

            ContentDialog contentDialog = new()
            {
<<<<<<< HEAD
                Title = title,
                PrimaryButtonText = primaryButton,
                SecondaryButtonText = secondaryButton,
                CloseButtonText = closeButton,
                Content = content,
                PrimaryButtonCommand = MiniCommand.Create(() =>
                {
                    result = primaryButtonResult;
                }),
            };

=======
                Title               = title,
                PrimaryButtonText   = primaryButton,
                SecondaryButtonText = secondaryButton,
                CloseButtonText     = closeButton,
                Content             = content
            };

            contentDialog.PrimaryButtonCommand = MiniCommand.Create(() =>
            {
                result = primaryButtonResult;
            });

>>>>>>> 1ec71635b (sync with main branch)
            contentDialog.SecondaryButtonCommand = MiniCommand.Create(() =>
            {
                result = UserResult.No;
                contentDialog.PrimaryButtonClick -= deferCloseAction;
            });

            contentDialog.CloseButtonCommand = MiniCommand.Create(() =>
            {
                result = UserResult.Cancel;
                contentDialog.PrimaryButtonClick -= deferCloseAction;
            });

            if (deferResetEvent != null)
            {
                contentDialog.PrimaryButtonClick += deferCloseAction;
            }

            await ShowAsync(contentDialog);

            return result;
        }

<<<<<<< HEAD
        public async static Task<UserResult> ShowTextDialog(
=======
        private async static Task<UserResult> ShowTextDialog(
>>>>>>> 1ec71635b (sync with main branch)
            string title,
            string primaryText,
            string secondaryText,
            string primaryButton,
            string secondaryButton,
            string closeButton,
            int iconSymbol,
            UserResult primaryButtonResult = UserResult.Ok,
            ManualResetEvent deferResetEvent = null,
            TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> deferCloseAction = null)
        {
            Grid content = CreateTextDialogContent(primaryText, secondaryText, iconSymbol);

            return await ShowContentDialog(title, content, primaryButton, secondaryButton, closeButton, primaryButtonResult, deferResetEvent, deferCloseAction);
        }

        public async static Task<UserResult> ShowDeferredContentDialog(
            StyleableWindow window,
            string title,
            string primaryText,
            string secondaryText,
            string primaryButton,
            string secondaryButton,
            string closeButton,
            int iconSymbol,
            ManualResetEvent deferResetEvent,
            Func<Window, Task> doWhileDeferred = null)
        {
            bool startedDeferring = false;
<<<<<<< HEAD
=======
            UserResult result = UserResult.None;
>>>>>>> 1ec71635b (sync with main branch)

            return await ShowTextDialog(
                title,
                primaryText,
                secondaryText,
                primaryButton,
                secondaryButton,
                closeButton,
                iconSymbol,
                primaryButton == LocaleManager.Instance[LocaleKeys.InputDialogYes] ? UserResult.Yes : UserResult.Ok,
                deferResetEvent,
                DeferClose);

            async void DeferClose(ContentDialog sender, ContentDialogButtonClickEventArgs args)
            {
                if (startedDeferring)
                {
                    return;
                }

                sender.PrimaryButtonClick -= DeferClose;

                startedDeferring = true;

                var deferral = args.GetDeferral();

<<<<<<< HEAD
=======
                result = primaryButton == LocaleManager.Instance[LocaleKeys.InputDialogYes] ? UserResult.Yes : UserResult.Ok;

>>>>>>> 1ec71635b (sync with main branch)
                sender.PrimaryButtonClick -= DeferClose;

                _ = Task.Run(() =>
                {
                    deferResetEvent.WaitOne();

                    Dispatcher.UIThread.Post(() =>
                    {
                        deferral.Complete();
                    });
                });

                if (doWhileDeferred != null)
                {
                    await doWhileDeferred(window);

                    deferResetEvent.Set();
                }
            }
        }

        private static Grid CreateTextDialogContent(string primaryText, string secondaryText, int symbol)
        {
            Grid content = new()
            {
<<<<<<< HEAD
                RowDefinitions = new RowDefinitions { new(), new() },
                ColumnDefinitions = new ColumnDefinitions { new(GridLength.Auto), new() },

                MinHeight = 80,
=======
                RowDefinitions    = new RowDefinitions()    { new RowDefinition(), new RowDefinition() },
                ColumnDefinitions = new ColumnDefinitions() { new ColumnDefinition(GridLength.Auto), new ColumnDefinition() },

                MinHeight = 80
>>>>>>> 1ec71635b (sync with main branch)
            };

            SymbolIcon icon = new()
            {
<<<<<<< HEAD
                Symbol = (Symbol)symbol,
                Margin = new Thickness(10),
                FontSize = 40,
                VerticalAlignment = VerticalAlignment.Center,
=======
                Symbol            = (Symbol)symbol,
                Margin            = new Thickness(10),
                FontSize          = 40,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center
>>>>>>> 1ec71635b (sync with main branch)
            };

            Grid.SetColumn(icon, 0);
            Grid.SetRowSpan(icon, 2);
            Grid.SetRow(icon, 0);

            TextBlock primaryLabel = new()
            {
<<<<<<< HEAD
                Text = primaryText,
                Margin = new Thickness(5),
                TextWrapping = TextWrapping.Wrap,
                MaxWidth = 450,
=======
                Text         = primaryText,
                Margin       = new Thickness(5),
                TextWrapping = TextWrapping.Wrap,
                MaxWidth     = 450
>>>>>>> 1ec71635b (sync with main branch)
            };

            TextBlock secondaryLabel = new()
            {
<<<<<<< HEAD
                Text = secondaryText,
                Margin = new Thickness(5),
                TextWrapping = TextWrapping.Wrap,
                MaxWidth = 450,
=======
                Text         = secondaryText,
                Margin       = new Thickness(5),
                TextWrapping = TextWrapping.Wrap,
                MaxWidth     = 450
>>>>>>> 1ec71635b (sync with main branch)
            };

            Grid.SetColumn(primaryLabel, 1);
            Grid.SetColumn(secondaryLabel, 1);
            Grid.SetRow(primaryLabel, 0);
            Grid.SetRow(secondaryLabel, 1);

            content.Children.Add(icon);
            content.Children.Add(primaryLabel);
            content.Children.Add(secondaryLabel);

            return content;
        }

        public static async Task<UserResult> CreateInfoDialog(
            string primary,
            string secondaryText,
            string acceptButton,
            string closeButton,
            string title)
        {
            return await ShowTextDialog(
                title,
                primary,
                secondaryText,
                acceptButton,
                "",
                closeButton,
                (int)Symbol.Important);
        }

        internal static async Task<UserResult> CreateConfirmationDialog(
            string primaryText,
            string secondaryText,
            string acceptButtonText,
            string cancelButtonText,
            string title,
            UserResult primaryButtonResult = UserResult.Yes)
        {
            return await ShowTextDialog(
                string.IsNullOrWhiteSpace(title) ? LocaleManager.Instance[LocaleKeys.DialogConfirmationTitle] : title,
                primaryText,
                secondaryText,
                acceptButtonText,
                "",
                cancelButtonText,
                (int)Symbol.Help,
                primaryButtonResult);
        }

        internal static async Task CreateUpdaterInfoDialog(string primary, string secondaryText)
        {
            await ShowTextDialog(
                LocaleManager.Instance[LocaleKeys.DialogUpdaterTitle],
                primary,
                secondaryText,
                "",
                "",
                LocaleManager.Instance[LocaleKeys.InputDialogOk],
                (int)Symbol.Important);
        }

        internal static async Task CreateWarningDialog(string primary, string secondaryText)
        {
            await ShowTextDialog(
                LocaleManager.Instance[LocaleKeys.DialogWarningTitle],
                primary,
                secondaryText,
                "",
                "",
                LocaleManager.Instance[LocaleKeys.InputDialogOk],
                (int)Symbol.Important);
        }

        internal static async Task CreateErrorDialog(string errorMessage, string secondaryErrorMessage = "")
        {
            Logger.Error?.Print(LogClass.Application, errorMessage);

            await ShowTextDialog(
                LocaleManager.Instance[LocaleKeys.DialogErrorTitle],
                LocaleManager.Instance[LocaleKeys.DialogErrorMessage],
                errorMessage,
                secondaryErrorMessage,
                "",
                LocaleManager.Instance[LocaleKeys.InputDialogOk],
                (int)Symbol.Dismiss);
        }

        internal static async Task<bool> CreateChoiceDialog(string title, string primary, string secondaryText)
        {
            if (_isChoiceDialogOpen)
            {
                return false;
            }

            _isChoiceDialogOpen = true;

            UserResult response = await ShowTextDialog(
                title,
                primary,
                secondaryText,
                LocaleManager.Instance[LocaleKeys.InputDialogYes],
                "",
                LocaleManager.Instance[LocaleKeys.InputDialogNo],
                (int)Symbol.Help,
                UserResult.Yes);

            _isChoiceDialogOpen = false;

            return response == UserResult.Yes;
        }

        internal static async Task<bool> CreateExitDialog()
        {
            return await CreateChoiceDialog(
                LocaleManager.Instance[LocaleKeys.DialogExitTitle],
                LocaleManager.Instance[LocaleKeys.DialogExitMessage],
                LocaleManager.Instance[LocaleKeys.DialogExitSubMessage]);
        }

        internal static async Task<bool> CreateStopEmulationDialog()
        {
            return await CreateChoiceDialog(
                LocaleManager.Instance[LocaleKeys.DialogStopEmulationTitle],
                LocaleManager.Instance[LocaleKeys.DialogStopEmulationMessage],
                LocaleManager.Instance[LocaleKeys.DialogExitSubMessage]);
        }

        public static async Task<ContentDialogResult> ShowAsync(ContentDialog contentDialog)
        {
            ContentDialogResult result;
<<<<<<< HEAD
            bool isTopDialog = true;

            Window parent = GetMainWindow();

            if (_contentDialogOverlayWindow != null)
            {
                isTopDialog = false;
            }

            if (parent is MainWindow window)
            {
                parent.Activate();

                _contentDialogOverlayWindow = new ContentDialogOverlayWindow
                {
                    Height = parent.Bounds.Height,
                    Width = parent.Bounds.Width,
                    Position = parent.PointToScreen(new Point()),
                    ShowInTaskbar = false,
=======

            ContentDialogOverlayWindow contentDialogOverlayWindow = null;

            Window parent = GetMainWindow();

            if (parent != null && parent.IsActive && parent is MainWindow window && window.ViewModel.IsGameRunning)
            {
                contentDialogOverlayWindow = new()
                {
                    Height        = parent.Bounds.Height,
                    Width         = parent.Bounds.Width,
                    Position      = parent.PointToScreen(new Point()),
                    ShowInTaskbar = false
>>>>>>> 1ec71635b (sync with main branch)
                };

                parent.PositionChanged += OverlayOnPositionChanged;

                void OverlayOnPositionChanged(object sender, PixelPointEventArgs e)
                {
<<<<<<< HEAD
                    if (_contentDialogOverlayWindow is null)
                    {
                        return;
                    }

                    _contentDialogOverlayWindow.Position = parent.PointToScreen(new Point());
                }

                _contentDialogOverlayWindow.ContentDialog = contentDialog;

                bool opened = false;

                _contentDialogOverlayWindow.Opened += OverlayOnActivated;
=======
                    contentDialogOverlayWindow.Position = parent.PointToScreen(new Point());
                }

                contentDialogOverlayWindow.ContentDialog = contentDialog;

                bool opened = false;

                contentDialogOverlayWindow.Opened += OverlayOnActivated;
>>>>>>> 1ec71635b (sync with main branch)

                async void OverlayOnActivated(object sender, EventArgs e)
                {
                    if (opened)
                    {
                        return;
                    }

                    opened = true;

<<<<<<< HEAD
                    _contentDialogOverlayWindow.Position = parent.PointToScreen(new Point());
=======
                    contentDialogOverlayWindow.Position = parent.PointToScreen(new Point());
>>>>>>> 1ec71635b (sync with main branch)

                    result = await ShowDialog();
                }

<<<<<<< HEAD
                result = await _contentDialogOverlayWindow.ShowDialog<ContentDialogResult>(parent);
=======
                result = await contentDialogOverlayWindow.ShowDialog<ContentDialogResult>(parent);
>>>>>>> 1ec71635b (sync with main branch)
            }
            else
            {
                result = await ShowDialog();
            }

            async Task<ContentDialogResult> ShowDialog()
            {
<<<<<<< HEAD
                if (_contentDialogOverlayWindow is not null)
                {
                    result = await contentDialog.ShowAsync(_contentDialogOverlayWindow);

                    _contentDialogOverlayWindow!.Close();
                }
                else
                {
                    result = ContentDialogResult.None;

                    Logger.Warning?.Print(LogClass.UI, "Content dialog overlay failed to populate. Default value has been returned.");
=======
                if (contentDialogOverlayWindow is not null)
                {
                    result = await contentDialog.ShowAsync(contentDialogOverlayWindow);

                    contentDialogOverlayWindow!.Close();
                }
                else
                {
                    result = await contentDialog.ShowAsync();
>>>>>>> 1ec71635b (sync with main branch)
                }

                return result;
            }

<<<<<<< HEAD
            if (isTopDialog && _contentDialogOverlayWindow is not null)
            {
                _contentDialogOverlayWindow.Content = null;
                _contentDialogOverlayWindow.Close();
                _contentDialogOverlayWindow = null;
=======
            if (contentDialogOverlayWindow is not null)
            {
                contentDialogOverlayWindow.Content = null;
                contentDialogOverlayWindow.Close();
>>>>>>> 1ec71635b (sync with main branch)
            }

            return result;
        }

<<<<<<< HEAD
        public static Task ShowWindowAsync(Window dialogWindow, Window mainWindow = null)
        {
            mainWindow ??= GetMainWindow();

            return dialogWindow.ShowDialog(_contentDialogOverlayWindow ?? mainWindow);
        }

        private static Window GetMainWindow()
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime al)
            {
                foreach (Window item in al.Windows)
                {
                    if (item is MainWindow window)
=======
        private static Window GetMainWindow()
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime al)
            {
                foreach (Window item in al.Windows)
                {
                    if (item.IsActive && item is MainWindow window)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        return window;
                    }
                }
            }

            return null;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
