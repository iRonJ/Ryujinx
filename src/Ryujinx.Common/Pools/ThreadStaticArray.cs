<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Common.Pools
{
    public static class ThreadStaticArray<T>
    {
        [ThreadStatic]
        private static T[] _array;

        public static ref T[] Get()
        {
<<<<<<< HEAD
            _array ??= new T[1];
=======
            if (_array == null)
            {
                _array = new T[1];
            }
>>>>>>> 1ec71635b (sync with main branch)

            return ref _array;
        }
    }
}
