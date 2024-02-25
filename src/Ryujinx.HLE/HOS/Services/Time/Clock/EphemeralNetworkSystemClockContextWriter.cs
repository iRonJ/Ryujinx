<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Time.Clock
=======
﻿namespace Ryujinx.HLE.HOS.Services.Time.Clock
>>>>>>> 1ec71635b (sync with main branch)
{
    class EphemeralNetworkSystemClockContextWriter : SystemClockContextUpdateCallback
    {
        protected override ResultCode Update()
        {
            return ResultCode.Success;
        }
    }
}
