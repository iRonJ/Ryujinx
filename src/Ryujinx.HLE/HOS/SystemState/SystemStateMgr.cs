using System;

namespace Ryujinx.HLE.HOS.SystemState
{
    public class SystemStateMgr
    {
<<<<<<< HEAD
        internal static string[] LanguageCodes = {
=======
        internal static string[] LanguageCodes = new string[]
        {
>>>>>>> 1ec71635b (sync with main branch)
            "ja",
            "en-US",
            "fr",
            "de",
            "it",
            "es",
            "zh-CN",
            "ko",
            "nl",
            "pt",
            "ru",
            "zh-TW",
            "en-GB",
            "fr-CA",
            "es-419",
            "zh-Hans",
            "zh-Hant",
<<<<<<< HEAD
            "pt-BR",
=======
            "pt-BR"
>>>>>>> 1ec71635b (sync with main branch)
        };

        internal long DesiredKeyboardLayout { get; private set; }

        internal SystemLanguage DesiredSystemLanguage { get; private set; }

        internal long DesiredLanguageCode { get; private set; }

        internal uint DesiredRegionCode { get; private set; }

        public TitleLanguage DesiredTitleLanguage { get; private set; }

        public bool DockedMode { get; set; }

        public ColorSet ThemeColor { get; set; }

        public string DeviceNickName { get; set; }

        public SystemStateMgr()
        {
            // TODO: Let user specify fields.
            DesiredKeyboardLayout = (long)KeyboardLayout.Default;
<<<<<<< HEAD
            DeviceNickName = "Ryujinx's Switch";
=======
            DeviceNickName        = "Ryujinx's Switch";
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void SetLanguage(SystemLanguage language)
        {
            DesiredSystemLanguage = language;
<<<<<<< HEAD
            DesiredLanguageCode = GetLanguageCode((int)DesiredSystemLanguage);
=======
            DesiredLanguageCode   = GetLanguageCode((int)DesiredSystemLanguage);
>>>>>>> 1ec71635b (sync with main branch)

            DesiredTitleLanguage = language switch
            {
                SystemLanguage.Taiwanese or
                SystemLanguage.TraditionalChinese => TitleLanguage.TraditionalChinese,
                SystemLanguage.Chinese or
<<<<<<< HEAD
                SystemLanguage.SimplifiedChinese => TitleLanguage.SimplifiedChinese,
                _ => Enum.Parse<TitleLanguage>(Enum.GetName<SystemLanguage>(language)),
=======
                SystemLanguage.SimplifiedChinese  => TitleLanguage.SimplifiedChinese,
                _                                 => Enum.Parse<TitleLanguage>(Enum.GetName<SystemLanguage>(language)),
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public void SetRegion(RegionCode region)
        {
            DesiredRegionCode = (uint)region;
        }

        internal static long GetLanguageCode(int index)
        {
            if ((uint)index >= LanguageCodes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

<<<<<<< HEAD
            long code = 0;
            int shift = 0;
=======
            long code  = 0;
            int  shift = 0;
>>>>>>> 1ec71635b (sync with main branch)

            foreach (char chr in LanguageCodes[index])
            {
                code |= (long)(byte)chr << shift++ * 8;
            }

            return code;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
