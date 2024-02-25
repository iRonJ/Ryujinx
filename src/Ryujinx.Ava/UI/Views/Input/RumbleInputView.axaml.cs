using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Models;
using Ryujinx.Ava.UI.ViewModels;
using Ryujinx.Common.Configuration.Hid.Controller;
using System.Threading.Tasks;

namespace Ryujinx.Ava.UI.Views.Input
{
    public partial class RumbleInputView : UserControl
    {
<<<<<<< HEAD
        private readonly RumbleInputViewModel _viewModel;
=======
        private RumbleInputViewModel _viewModel;
>>>>>>> 1ec71635b (sync with main branch)

        public RumbleInputView()
        {
            InitializeComponent();
        }

        public RumbleInputView(ControllerInputViewModel viewModel)
        {
            var config = viewModel.Configuration as InputConfiguration<GamepadInputId, StickInputId>;

            _viewModel = new RumbleInputViewModel
            {
                StrongRumble = config.StrongRumble,
<<<<<<< HEAD
                WeakRumble = config.WeakRumble,
            };

            InitializeComponent();

=======
                WeakRumble = config.WeakRumble
            };

            InitializeComponent();
            
>>>>>>> 1ec71635b (sync with main branch)
            DataContext = _viewModel;
        }

        public static async Task Show(ControllerInputViewModel viewModel)
        {
            RumbleInputView content = new(viewModel);

            ContentDialog contentDialog = new()
            {
                Title = LocaleManager.Instance[LocaleKeys.ControllerRumbleTitle],
                PrimaryButtonText = LocaleManager.Instance[LocaleKeys.ControllerSettingsSave],
                SecondaryButtonText = "",
                CloseButtonText = LocaleManager.Instance[LocaleKeys.ControllerSettingsClose],
                Content = content,
            };

            contentDialog.PrimaryButtonClick += (sender, args) =>
            {
                var config = viewModel.Configuration as InputConfiguration<GamepadInputId, StickInputId>;
                config.StrongRumble = content._viewModel.StrongRumble;
                config.WeakRumble = content._viewModel.WeakRumble;
            };

            await contentDialog.ShowAsync();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
