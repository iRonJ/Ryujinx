<<<<<<< HEAD
using System;

namespace Ryujinx.Horizon.Common
{
    public readonly struct OnScopeExit : IDisposable
=======
﻿using System;

namespace Ryujinx.Horizon.Common
{
    public struct OnScopeExit : IDisposable
>>>>>>> 1ec71635b (sync with main branch)
    {
        private readonly Action _action;

        public OnScopeExit(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }
    }
}
