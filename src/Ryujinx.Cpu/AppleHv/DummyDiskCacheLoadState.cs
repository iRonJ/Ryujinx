using System;

namespace Ryujinx.Cpu.AppleHv
{
    public class DummyDiskCacheLoadState : IDiskCacheLoadState
    {
<<<<<<< HEAD
#pragma warning disable CS0067 // The event is never used
=======
#pragma warning disable CS0067
>>>>>>> 1ec71635b (sync with main branch)
        /// <inheritdoc/>
        public event Action<LoadState, int, int> StateChanged;
#pragma warning restore CS0067

        /// <inheritdoc/>
        public void Cancel()
        {
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
