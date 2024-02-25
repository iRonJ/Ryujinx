<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Kernel.Memory
{
    struct KScopedPageList : IDisposable
    {
        private readonly KMemoryManager _manager;
        private KPageList _pageList;

        public KScopedPageList(KMemoryManager manager, KPageList pageList)
        {
            _manager = manager;
            _pageList = pageList;
            pageList.IncrementPagesReferenceCount(manager);
        }

        public void SignalSuccess()
        {
            _pageList = null;
        }

<<<<<<< HEAD
        public readonly void Dispose()
=======
        public void Dispose()
>>>>>>> 1ec71635b (sync with main branch)
        {
            _pageList?.DecrementPagesReferenceCount(_manager);
        }
    }
}
