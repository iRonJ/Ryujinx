<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
=======
﻿namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Identifies the software keyboard state.
    /// </summary>
    enum SoftwareKeyboardState
    {
        /// <summary>
        /// swkbd is uninitialized.
        /// </summary>
        Uninitialized,

        /// <summary>
        /// swkbd is ready to process data.
        /// </summary>
        Ready,

        /// <summary>
        /// swkbd is awaiting an interactive reply with a validation status.
        /// </summary>
        ValidationPending,

        /// <summary>
        /// swkbd has completed.
        /// </summary>
<<<<<<< HEAD
        Complete,
    }
}
=======
        Complete
    }
}
>>>>>>> 1ec71635b (sync with main branch)
