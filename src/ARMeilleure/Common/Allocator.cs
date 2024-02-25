<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace ARMeilleure.Common
{
    unsafe abstract class Allocator : IDisposable
    {
        public T* Allocate<T>(ulong count = 1) where T : unmanaged
        {
            return (T*)Allocate(count * (uint)sizeof(T));
        }

        public abstract void* Allocate(ulong size);

        public abstract void Free(void* block);

        protected virtual void Dispose(bool disposing) { }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
