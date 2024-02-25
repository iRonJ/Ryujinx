<<<<<<< HEAD
using Ryujinx.Ava.Common.Locale;
using Ryujinx.UI.Common;
using Ryujinx.UI.Common.Helper;
=======
﻿using Ryujinx.Ava.Common.Locale;
using Ryujinx.Ava.UI.Windows;
using Ryujinx.Ui.Common;
using Ryujinx.Ui.Common.Helper;
>>>>>>> 1ec71635b (sync with main branch)
using System.Threading.Tasks;

namespace Ryujinx.Ava.UI.Helpers
{
    internal class UserErrorDialog
    {
        private const string SetupGuideUrl = "https://github.com/Ryujinx/Ryujinx/wiki/Ryujinx-Setup-&-Configuration-Guide";

        private static string GetErrorCode(UserError error)
        {
            return $"RYU-{(uint)error:X4}";
        }

        private static string GetErrorTitle(UserError error)
        {
            return error switch
            {
                UserError.NoKeys => LocaleManager.Instance[LocaleKeys.UserErrorNoKeys],
                UserError.NoFirmware => LocaleManager.Instance[LocaleKeys.UserErrorNoFirmware],
                UserError.FirmwareParsingFailed => LocaleManager.Instance[LocaleKeys.UserErrorFirmwareParsingFailed],
                UserError.ApplicationNotFound => LocaleManager.Instance[LocaleKeys.UserErrorApplicationNotFound],
                UserError.Unknown => LocaleManager.Instance[LocaleKeys.UserErrorUnknown],
<<<<<<< HEAD
                _ => LocaleManager.Instance[LocaleKeys.UserErrorUndefined],
=======
                _ => LocaleManager.Instance[LocaleKeys.UserErrorUndefined]
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static string GetErrorDescription(UserError error)
        {
            return error switch
            {
                UserError.NoKeys => LocaleManager.Instance[LocaleKeys.UserErrorNoKeysDescription],
                UserError.NoFirmware => LocaleManager.Instance[LocaleKeys.UserErrorNoFirmwareDescription],
                UserError.FirmwareParsingFailed => LocaleManager.Instance[LocaleKeys.UserErrorFirmwareParsingFailedDescription],
                UserError.ApplicationNotFound => LocaleManager.Instance[LocaleKeys.UserErrorApplicationNotFoundDescription],
                UserError.Unknown => LocaleManager.Instance[LocaleKeys.UserErrorUnknownDescription],
<<<<<<< HEAD
                _ => LocaleManager.Instance[LocaleKeys.UserErrorUndefinedDescription],
=======
                _ => LocaleManager.Instance[LocaleKeys.UserErrorUndefinedDescription]
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static bool IsCoveredBySetupGuide(UserError error)
        {
            return error switch
            {
                UserError.NoKeys or
                    UserError.NoFirmware or
                    UserError.FirmwareParsingFailed => true,
<<<<<<< HEAD
                _ => false,
=======
                _ => false
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        private static string GetSetupGuideUrl(UserError error)
        {
            if (!IsCoveredBySetupGuide(error))
            {
                return null;
            }

            return error switch
            {
                UserError.NoKeys => SetupGuideUrl + "#initial-setup---placement-of-prodkeys",
                UserError.NoFirmware => SetupGuideUrl + "#initial-setup-continued---installation-of-firmware",
<<<<<<< HEAD
                _ => SetupGuideUrl,
            };
        }

        public static async Task ShowUserErrorDialog(UserError error)
=======
                _ => SetupGuideUrl
            };
        }

        public static async Task ShowUserErrorDialog(UserError error, StyleableWindow owner)
>>>>>>> 1ec71635b (sync with main branch)
        {
            string errorCode = GetErrorCode(error);

            bool isInSetupGuide = IsCoveredBySetupGuide(error);

            string setupButtonLabel = isInSetupGuide ? LocaleManager.Instance[LocaleKeys.OpenSetupGuideMessage] : "";

            var result = await ContentDialogHelper.CreateInfoDialog(
                LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogUserErrorDialogMessage, errorCode, GetErrorTitle(error)),
                GetErrorDescription(error) + (isInSetupGuide
                    ? LocaleManager.Instance[LocaleKeys.DialogUserErrorDialogInfoMessage]
                    : ""), setupButtonLabel, LocaleManager.Instance[LocaleKeys.InputDialogOk],
                LocaleManager.Instance.UpdateAndGetDynamicValue(LocaleKeys.DialogUserErrorDialogTitle, errorCode));

            if (result == UserResult.Ok)
            {
                OpenHelper.OpenUrl(GetSetupGuideUrl(error));
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
