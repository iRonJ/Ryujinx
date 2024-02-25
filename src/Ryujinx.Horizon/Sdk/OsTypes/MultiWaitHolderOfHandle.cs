<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.OsTypes
{
    class MultiWaitHolderOfHandle : MultiWaitHolder
    {
        private readonly int _handle;
=======
﻿namespace Ryujinx.Horizon.Sdk.OsTypes
{
    class MultiWaitHolderOfHandle : MultiWaitHolder
    {
        private int _handle;
>>>>>>> 1ec71635b (sync with main branch)

        public override int Handle => _handle;

        public MultiWaitHolderOfHandle(int handle)
        {
            _handle = handle;
        }
    }
}
