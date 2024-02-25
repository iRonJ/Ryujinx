<<<<<<< HEAD
namespace ARMeilleure.Memory
=======
﻿namespace ARMeilleure.Memory
>>>>>>> 1ec71635b (sync with main branch)
{
    public interface IJitMemoryAllocator
    {
        IJitMemoryBlock Allocate(ulong size);
        IJitMemoryBlock Reserve(ulong size);
<<<<<<< HEAD
=======

        ulong GetPageSize();
>>>>>>> 1ec71635b (sync with main branch)
    }
}
