<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.OsTypes
=======
﻿namespace Ryujinx.Horizon.Sdk.OsTypes
>>>>>>> 1ec71635b (sync with main branch)
{
    class MultiWaitHolder : MultiWaitHolderBase
    {
        public object UserData { get; set; }

        public void UnlinkFromMultiWaitHolder()
        {
            DebugUtil.Assert(IsLinked);

            MultiWait.UnlinkMultiWaitHolder(this);

            SetMultiWait(null);
        }
    }
}
