<<<<<<< HEAD
using LibHac.Ns;
=======
﻿using LibHac.Ns;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Ava.Common.Locale;

namespace Ryujinx.Ava.UI.Models
{
    public class TitleUpdateModel
    {
        public ApplicationControlProperty Control { get; }
        public string Path { get; }

        public string Label => LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.TitleUpdateVersionLabel, Control.DisplayVersionString.ToString());

        public TitleUpdateModel(ApplicationControlProperty control, string path)
        {
            Control = control;
            Path = path;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
