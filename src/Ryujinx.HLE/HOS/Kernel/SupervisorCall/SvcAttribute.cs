<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Kernel.SupervisorCall
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    class SvcAttribute : Attribute
    {
        public int Id { get; }

        public SvcAttribute(int id)
        {
            Id = id;
        }
    }
}
