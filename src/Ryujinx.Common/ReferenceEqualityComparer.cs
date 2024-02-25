<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)
using System.Diagnostics.CodeAnalysis;

namespace Ryujinx.Common
{
    public class ReferenceEqualityComparer<T> : IEqualityComparer<T>
        where T : class
    {
        public bool Equals(T x, T y)
        {
            return x == y;
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return obj.GetHashCode();
        }
    }
}
