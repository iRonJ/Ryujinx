<<<<<<< HEAD
using Ryujinx.HLE.UI;

namespace Ryujinx.Headless.SDL2
{
    internal class HeadlessHostUiTheme : IHostUITheme
    {
        public string FontFamily => "sans-serif";

        public ThemeColor DefaultBackgroundColor => new(1, 0, 0, 0);
        public ThemeColor DefaultForegroundColor => new(1, 1, 1, 1);
        public ThemeColor DefaultBorderColor => new(1, 1, 1, 1);
        public ThemeColor SelectionBackgroundColor => new(1, 1, 1, 1);
        public ThemeColor SelectionForegroundColor => new(1, 0, 0, 0);
    }
}
=======
﻿using Ryujinx.HLE.Ui;

namespace Ryujinx.Headless.SDL2
{
    internal class HeadlessHostUiTheme : IHostUiTheme
    {
        public string FontFamily => "sans-serif";

        public ThemeColor DefaultBackgroundColor => new ThemeColor(1, 0, 0, 0);
        public ThemeColor DefaultForegroundColor => new ThemeColor(1, 1, 1, 1);
        public ThemeColor DefaultBorderColor => new ThemeColor(1, 1, 1, 1);
        public ThemeColor SelectionBackgroundColor => new ThemeColor(1, 1, 1, 1);
        public ThemeColor SelectionForegroundColor => new ThemeColor(1, 0, 0, 0);

        public HeadlessHostUiTheme() { }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
