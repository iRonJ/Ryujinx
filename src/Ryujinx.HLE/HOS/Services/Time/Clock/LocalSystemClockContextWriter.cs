<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    class LocalSystemClockContextWriter : SystemClockContextUpdateCallback
    {
        private readonly TimeSharedMemory _sharedMemory;
=======
﻿namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    class LocalSystemClockContextWriter : SystemClockContextUpdateCallback
    {
        private TimeSharedMemory _sharedMemory;
>>>>>>> 1ec71635b (sync with main branch)

        public LocalSystemClockContextWriter(TimeSharedMemory sharedMemory)
        {
            _sharedMemory = sharedMemory;
        }

        protected override ResultCode Update()
        {
<<<<<<< HEAD
            _sharedMemory.UpdateLocalSystemClockContext(Context);
=======
            _sharedMemory.UpdateLocalSystemClockContext(_context);
>>>>>>> 1ec71635b (sync with main branch)

            return ResultCode.Success;
        }
    }
}
