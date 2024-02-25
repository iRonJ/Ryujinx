<<<<<<< HEAD
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
=======
﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
>>>>>>> 1ec71635b (sync with main branch)
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Helpers;
using Ryujinx.Ava.UI.ViewModels;
<<<<<<< HEAD
using Ryujinx.UI.Common.Helper;
=======
using Ryujinx.Ui.Common.Helper;
>>>>>>> 1ec71635b (sync with main branch)
using System.Threading.Tasks;
using Button = Avalonia.Controls.Button;

namespace Ryujinx.Ava.UI.Windows
{
    public partial class AboutWindow : UserControl
    {
        public AboutWindow()
        {
            DataContext = new AboutWindowViewModel();

            InitializeComponent();
        }

        public static async Task Show()
        {
            ContentDialog contentDialog = new()
            {
<<<<<<< HEAD
                PrimaryButtonText = "",
                SecondaryButtonText = "",
                CloseButtonText = LocaleManager.Instance[LocaleKeys.UserProfilesClose],
                Content = new AboutWindow(),
=======
                PrimaryButtonText   = "",
                SecondaryButtonText = "",
                CloseButtonText     = LocaleManager.Instance[LocaleKeys.UserProfilesClose],
                Content             = new AboutWindow()
>>>>>>> 1ec71635b (sync with main branch)
            };

            Style closeButton = new(x => x.Name("CloseButton"));
            closeButton.Setters.Add(new Setter(WidthProperty, 80d));

            Style closeButtonParent = new(x => x.Name("CommandSpace"));
<<<<<<< HEAD
            closeButtonParent.Setters.Add(new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Right));
=======
            closeButtonParent.Setters.Add(new Setter(HorizontalAlignmentProperty, Avalonia.Layout.HorizontalAlignment.Right));
>>>>>>> 1ec71635b (sync with main branch)

            contentDialog.Styles.Add(closeButton);
            contentDialog.Styles.Add(closeButtonParent);

            await ContentDialogHelper.ShowAsync(contentDialog);
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                OpenHelper.OpenUrl(button.Tag.ToString());
            }
        }

        private void AmiiboLabel_OnPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (sender is TextBlock)
            {
                OpenHelper.OpenUrl("https://amiiboapi.com");
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
