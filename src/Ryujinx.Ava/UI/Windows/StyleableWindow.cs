<<<<<<< HEAD
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Ryujinx.Ava.Common.Locale;
using Ryujinx.UI.Common.Configuration;
=======
﻿using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.IO;
using System.Reflection;

namespace Ryujinx.Ava.UI.Windows
{
    public class StyleableWindow : Window
    {
<<<<<<< HEAD
        public Bitmap IconImage { get; set; }
=======
        public IBitmap IconImage { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        public StyleableWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
<<<<<<< HEAD
            TransparencyLevelHint = new[] { WindowTransparencyLevel.None };

            using Stream stream = Assembly.GetAssembly(typeof(ConfigurationState)).GetManifestResourceStream("Ryujinx.UI.Common.Resources.Logo_Ryujinx.png");
=======
            TransparencyLevelHint = WindowTransparencyLevel.None;

            using Stream stream = Assembly.GetAssembly(typeof(Ryujinx.Ui.Common.Configuration.ConfigurationState)).GetManifestResourceStream("Ryujinx.Ui.Common.Resources.Logo_Ryujinx.png");
>>>>>>> 1ec71635b (sync with main branch)

            Icon = new WindowIcon(stream);
            stream.Position = 0;
            IconImage = new Bitmap(stream);
<<<<<<< HEAD

            LocaleManager.Instance.LocaleChanged += LocaleChanged;
            LocaleChanged();
        }

        private void LocaleChanged()
        {
            FlowDirection = LocaleManager.Instance.IsRTL() ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
=======
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);
>>>>>>> 1ec71635b (sync with main branch)
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.SystemChrome | ExtendClientAreaChromeHints.OSXThickTitleBar;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
