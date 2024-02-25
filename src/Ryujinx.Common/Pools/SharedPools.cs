<<<<<<< HEAD
namespace Ryujinx.Common
=======
﻿namespace Ryujinx.Common
>>>>>>> 1ec71635b (sync with main branch)
{
    public static class SharedPools
    {
        private static class DefaultPool<T>
            where T : class, new()
        {
<<<<<<< HEAD
            public static readonly ObjectPool<T> Instance = new(() => new T(), 20);
=======
            public static readonly ObjectPool<T> Instance = new ObjectPool<T>(() => new T(), 20);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static ObjectPool<T> Default<T>()
            where T : class, new()
        {
            return DefaultPool<T>.Instance;
        }
    }
}
