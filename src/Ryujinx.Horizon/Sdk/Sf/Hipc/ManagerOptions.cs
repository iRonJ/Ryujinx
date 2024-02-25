<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    readonly struct ManagerOptions
    {
        public static ManagerOptions Default => new(0, 0, 0, false);

        public int PointerBufferSize { get; }
        public int MaxDomains { get; }
        public int MaxDomainObjects { get; }
=======
﻿namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    struct ManagerOptions
    {
        public static ManagerOptions Default => new(0, 0, 0, false);

        public int PointerBufferSize      { get; }
        public int MaxDomains             { get; }
        public int MaxDomainObjects       { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public bool CanDeferInvokeRequest { get; }

        public ManagerOptions(int pointerBufferSize, int maxDomains, int maxDomainObjects, bool canDeferInvokeRequest)
        {
<<<<<<< HEAD
            PointerBufferSize = pointerBufferSize;
            MaxDomains = maxDomains;
            MaxDomainObjects = maxDomainObjects;
            CanDeferInvokeRequest = canDeferInvokeRequest;
        }
    }
}
=======
            PointerBufferSize     = pointerBufferSize;
            MaxDomains            = maxDomains;
            MaxDomainObjects      = maxDomainObjects;
            CanDeferInvokeRequest = canDeferInvokeRequest;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
