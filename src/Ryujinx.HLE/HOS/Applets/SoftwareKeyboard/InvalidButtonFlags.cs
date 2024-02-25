<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Applets.SoftwareKeyboard
{
    /// <summary>
    /// Identifies prohibited buttons.
    /// </summary>
    [Flags]
    enum InvalidButtonFlags : uint
    {
<<<<<<< HEAD
        None = 0,
        AnalogStickL = 1 << 1,
        AnalogStickR = 1 << 2,
        ZL = 1 << 3,
        ZR = 1 << 4,
=======
        None         = 0,
        AnalogStickL = 1 << 1,
        AnalogStickR = 1 << 2,
        ZL           = 1 << 3,
        ZR           = 1 << 4,
>>>>>>> 1ec71635b (sync with main branch)
    }
}
