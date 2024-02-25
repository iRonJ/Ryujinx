using System;

namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
<<<<<<< HEAD
    readonly struct ScopedInlineContextChange : IDisposable
=======
    struct ScopedInlineContextChange : IDisposable
>>>>>>> 1ec71635b (sync with main branch)
    {
        private readonly int _previousContext;

        public ScopedInlineContextChange(int newContext)
        {
            _previousContext = InlineContext.Set(newContext);
        }

        public void Dispose()
        {
            InlineContext.Set(_previousContext);
        }
    }
}
