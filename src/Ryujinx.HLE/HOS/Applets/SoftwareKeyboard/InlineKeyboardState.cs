<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
=======
﻿namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Possible states for the software keyboard when running in inline mode.
    /// </summary>
    enum InlineKeyboardState : uint
    {
        /// <summary>
        /// The software keyboard has just been created or finalized and is uninitialized.
        /// </summary>
        Uninitialized = 0x0,

        /// <summary>
        /// The software keyboard is initialized, but it is not visible and not processing input.
        /// </summary>
        Initialized = 0x1,

        /// <summary>
        /// The software keyboard is transitioning to a visible state.
        /// </summary>
        Appearing = 0x2,

        /// <summary>
        /// The software keyboard is visible and receiving processing input.
        /// </summary>
        Shown = 0x3,

        /// <summary>
        /// software keyboard is transitioning to a hidden state because the user pressed either OK or Cancel.
        /// </summary>
<<<<<<< HEAD
        Disappearing = 0x4,
=======
        Disappearing = 0x4
>>>>>>> 1ec71635b (sync with main branch)
    }
}
