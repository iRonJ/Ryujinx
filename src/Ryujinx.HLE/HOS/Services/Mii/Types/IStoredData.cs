<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    interface IStoredData<T> : IElement, IEquatable<T> where T : notnull
    {
        byte Type { get; }

        CreateId CreateId { get; }

        ResultCode InvalidData { get; }

        bool IsValid();
    }
}
