<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Input
{
    /// <summary>
    /// Represent features supported by a <see cref="IGamepad"/>.
    /// </summary>
    [Flags]
    public enum GamepadFeaturesFlag
    {
        /// <summary>
        /// No features are supported
        /// </summary>
        None,

        /// <summary>
        /// Rumble
        /// </summary>
        /// <remarks>Also named haptic</remarks>
        Rumble,

        /// <summary>
        /// Motion
        /// <remarks>Also named sixaxis</remarks>
        /// </summary>
<<<<<<< HEAD
        Motion,
=======
        Motion
>>>>>>> 1ec71635b (sync with main branch)
    }
}
