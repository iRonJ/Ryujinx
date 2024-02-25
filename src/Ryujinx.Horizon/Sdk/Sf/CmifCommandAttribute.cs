<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.Sf
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    class CmifCommandAttribute : Attribute
    {
        public uint CommandId { get; }

        public CmifCommandAttribute(uint commandId)
        {
            CommandId = commandId;
        }
    }
}
