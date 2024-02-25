<<<<<<< HEAD
using System.Threading;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common
{
    struct AtomicStorage<T> where T : unmanaged, ISampledDataStruct
=======
﻿using System.Threading;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common
{
    struct AtomicStorage<T> where T: unmanaged, ISampledDataStruct
>>>>>>> 1ec71635b (sync with main branch)
    {
        public ulong SamplingNumber;
        public T Object;

        public ulong ReadSamplingNumberAtomic()
        {
            return Interlocked.Read(ref SamplingNumber);
        }

        public void SetObject(ref T obj)
        {
            ulong samplingNumber = ISampledDataStruct.GetSamplingNumber(ref obj);

            Interlocked.Exchange(ref SamplingNumber, samplingNumber);

            Thread.MemoryBarrier();

            Object = obj;
        }
    }
}
