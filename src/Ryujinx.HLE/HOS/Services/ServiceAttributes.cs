<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ServiceAttribute : Attribute
    {
        public readonly string Name;
        public readonly object Parameter;

        public ServiceAttribute(string name, object parameter = null)
        {
<<<<<<< HEAD
            Name = name;
            Parameter = parameter;
        }
    }
}
=======
            Name      = name;
            Parameter = parameter;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
