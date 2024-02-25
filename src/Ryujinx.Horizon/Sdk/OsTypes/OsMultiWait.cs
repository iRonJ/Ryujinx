<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.OsTypes
=======
﻿namespace Ryujinx.Horizon.Sdk.OsTypes
>>>>>>> 1ec71635b (sync with main branch)
{
    static partial class Os
    {
        public static void FinalizeMultiWaitHolder(MultiWaitHolderBase holder)
        {
            DebugUtil.Assert(!holder.IsLinked);
        }
    }
}
