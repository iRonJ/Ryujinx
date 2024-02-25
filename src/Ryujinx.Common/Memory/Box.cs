<<<<<<< HEAD
namespace Ryujinx.Common.Memory
=======
﻿namespace Ryujinx.Common.Memory
>>>>>>> 1ec71635b (sync with main branch)
{
    public class Box<T> where T : unmanaged
    {
        public T Data;

        public Box()
        {
            Data = new T();
        }
    }
}
