<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    class NetworkSystemClockContextWriter : SystemClockContextUpdateCallback
    {
        private readonly TimeSharedMemory _sharedMemory;
=======
﻿namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    class NetworkSystemClockContextWriter : SystemClockContextUpdateCallback
    {
        private TimeSharedMemory _sharedMemory;
>>>>>>> 1ec71635b (sync with main branch)

        public NetworkSystemClockContextWriter(TimeSharedMemory sharedMemory)
        {
            _sharedMemory = sharedMemory;
        }

        protected override ResultCode Update()
        {
<<<<<<< HEAD
            _sharedMemory.UpdateNetworkSystemClockContext(Context);
=======
            _sharedMemory.UpdateNetworkSystemClockContext(_context);
>>>>>>> 1ec71635b (sync with main branch)

            return ResultCode.Success;
        }
    }
}
