<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.Types
{
    [Flags]
    enum AppletFooterUiType : byte
    {
        None,
        HandheldNone,
        HandheldJoyConLeftOnly,
        HandheldJoyConRightOnly,
        HandheldJoyConLeftJoyConRight,
        JoyDual,
        JoyDualLeftOnly,
        JoyDualRightOnly,
        JoyLeftHorizontal,
        JoyLeftVertical,
        JoyRightHorizontal,
        JoyRightVertical,
        SwitchProController,
        CompatibleProController,
        CompatibleJoyCon,
        LarkHvc1,
        LarkHvc2,
        LarkNesLeft,
        LarkNesRight,
        Lucia,
<<<<<<< HEAD
        Verification,
    }
}
=======
        Verification
    }
}
>>>>>>> 1ec71635b (sync with main branch)
