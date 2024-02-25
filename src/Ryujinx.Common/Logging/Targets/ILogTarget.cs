<<<<<<< HEAD
using System;

namespace Ryujinx.Common.Logging.Targets
=======
﻿using System;

namespace Ryujinx.Common.Logging
>>>>>>> 1ec71635b (sync with main branch)
{
    public interface ILogTarget : IDisposable
    {
        void Log(object sender, LogEventArgs args);

        string Name { get; }
    }
}
