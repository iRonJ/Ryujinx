<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
=======
﻿namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Identifies the variant of keyboard displayed on screen.
    /// </summary>
<<<<<<< HEAD
    public enum KeyboardMode : uint
    {
        /// <summary>
        /// All UTF-16 characters allowed.
=======
    enum KeyboardMode : uint
    {
        /// <summary>
        /// A full alpha-numeric keyboard.
>>>>>>> 1ec71635b (sync with main branch)
        /// </summary>
        Default = 0,

        /// <summary>
<<<<<<< HEAD
        /// Only 0-9 or '.' allowed.
        /// </summary>
        Numeric = 1,

        /// <summary>
        /// Only ASCII characters allowed.
        /// </summary>
        ASCII = 2,

        /// <summary>
        /// Synonymous with default.
        /// </summary>
        FullLatin = 3,

        /// <summary>
        /// All UTF-16 characters except CJK characters allowed.
        /// </summary>
        Alphabet = 4,

        SimplifiedChinese = 5,
        TraditionalChinese = 6,
        Korean = 7,
        LanguageSet2 = 8,
        LanguageSet2Latin = 9,
=======
        /// Number pad.
        /// </summary>
        NumbersOnly = 1,

        /// <summary>
        /// ASCII characters keyboard.
        /// </summary>
        ASCII = 2,

        FullLatin          = 3,
        Alphabet           = 4,
        SimplifiedChinese  = 5,
        TraditionalChinese = 6,
        Korean             = 7,
        LanguageSet2       = 8,
        LanguageSet2Latin  = 9,
>>>>>>> 1ec71635b (sync with main branch)
    }
}
