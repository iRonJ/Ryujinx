<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    [Flags]
<<<<<<< HEAD
    enum SourceFlag
    {
        Database = 1 << Source.Database,
        Default = 1 << Source.Default,
        All = Database | Default,
=======
    enum SourceFlag : int
    {
        Database = 1 << Source.Database,
        Default  = 1 << Source.Default,
        All      = Database | Default
>>>>>>> 1ec71635b (sync with main branch)
    }
}
