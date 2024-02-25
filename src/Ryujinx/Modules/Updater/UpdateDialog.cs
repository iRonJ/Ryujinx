using Gdk;
using Gtk;
using Ryujinx.Common;
<<<<<<< HEAD
using Ryujinx.Common.Configuration;
using Ryujinx.UI;
using Ryujinx.UI.Common.Configuration;
using Ryujinx.UI.Common.Helper;
=======
using Ryujinx.Ui;
using Ryujinx.Ui.Common.Configuration;
using Ryujinx.Ui.Common.Helper;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Diagnostics;
using System.Reflection;

namespace Ryujinx.Modules
{
    public class UpdateDialog : Gtk.Window
    {
<<<<<<< HEAD
#pragma warning disable CS0649, IDE0044 // Field is never assigned to, Add readonly modifier
        [Builder.Object] public Label MainText;
        [Builder.Object] public Label SecondaryText;
        [Builder.Object] public LevelBar ProgressBar;
        [Builder.Object] public Button YesButton;
        [Builder.Object] public Button NoButton;
#pragma warning restore CS0649, IDE0044

        private readonly MainWindow _mainWindow;
        private readonly string _buildUrl;
        private bool _restartQuery;
=======
#pragma warning disable CS0649, IDE0044
        [Builder.Object] public Label    MainText;
        [Builder.Object] public Label    SecondaryText;
        [Builder.Object] public LevelBar ProgressBar;
        [Builder.Object] public Button   YesButton;
        [Builder.Object] public Button   NoButton;
#pragma warning restore CS0649, IDE0044

        private readonly MainWindow _mainWindow;
        private readonly string     _buildUrl;
        private          bool       _restartQuery;
>>>>>>> 1ec71635b (sync with main branch)

        public UpdateDialog(MainWindow mainWindow, Version newVersion, string buildUrl) : this(new Builder("Ryujinx.Modules.Updater.UpdateDialog.glade"), mainWindow, newVersion, buildUrl) { }

        private UpdateDialog(Builder builder, MainWindow mainWindow, Version newVersion, string buildUrl) : base(builder.GetRawOwnedObject("UpdateDialog"))
        {
            builder.Autoconnect(this);

            _mainWindow = mainWindow;
<<<<<<< HEAD
            _buildUrl = buildUrl;

            Icon = new Pixbuf(Assembly.GetAssembly(typeof(ConfigurationState)), "Ryujinx.UI.Common.Resources.Logo_Ryujinx.png");
            MainText.Text = "Do you want to update Ryujinx to the latest version?";
=======
            _buildUrl   = buildUrl;

            Icon = new Pixbuf(Assembly.GetAssembly(typeof(ConfigurationState)), "Ryujinx.Ui.Common.Resources.Logo_Ryujinx.png");
            MainText.Text      = "Do you want to update Ryujinx to the latest version?";
>>>>>>> 1ec71635b (sync with main branch)
            SecondaryText.Text = $"{Program.Version} -> {newVersion}";

            ProgressBar.Hide();

            YesButton.Clicked += YesButton_Clicked;
<<<<<<< HEAD
            NoButton.Clicked += NoButton_Clicked;
=======
            NoButton.Clicked  += NoButton_Clicked;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private void YesButton_Clicked(object sender, EventArgs args)
        {
            if (_restartQuery)
            {
                string ryuName = OperatingSystem.IsWindows() ? "Ryujinx.exe" : "Ryujinx";

                ProcessStartInfo processStart = new(ryuName)
                {
                    UseShellExecute = true,
<<<<<<< HEAD
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
=======
                    WorkingDirectory = ReleaseInformation.GetBaseApplicationDirectory()
>>>>>>> 1ec71635b (sync with main branch)
                };

                foreach (string argument in CommandLineState.Arguments)
                {
                    processStart.ArgumentList.Add(argument);
                }

                Process.Start(processStart);

                Environment.Exit(0);
            }
            else
            {
                Window.Functions = _mainWindow.Window.Functions = WMFunction.All & WMFunction.Close;
                _mainWindow.ExitMenuItem.Sensitive = false;

                YesButton.Hide();
                NoButton.Hide();
                ProgressBar.Show();

                SecondaryText.Text = "";
<<<<<<< HEAD
                _restartQuery = true;
=======
                _restartQuery      = true;
>>>>>>> 1ec71635b (sync with main branch)

                Updater.UpdateRyujinx(this, _buildUrl);
            }
        }

        private void NoButton_Clicked(object sender, EventArgs args)
        {
            Updater.Running = false;
            _mainWindow.Window.Functions = WMFunction.All;

<<<<<<< HEAD
            _mainWindow.ExitMenuItem.Sensitive = true;
=======
            _mainWindow.ExitMenuItem.Sensitive   = true;
>>>>>>> 1ec71635b (sync with main branch)
            _mainWindow.UpdateMenuItem.Sensitive = true;

            Dispose();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
