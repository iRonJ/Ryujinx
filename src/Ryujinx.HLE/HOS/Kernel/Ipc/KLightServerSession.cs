using Ryujinx.HLE.HOS.Kernel.Common;

namespace Ryujinx.HLE.HOS.Kernel.Ipc
{
    class KLightServerSession : KAutoObject
    {
<<<<<<< HEAD
#pragma warning disable IDE0052 // Remove unread private member
        private readonly KLightSession _parent;
#pragma warning restore IDE0052
=======
        private readonly KLightSession _parent;
>>>>>>> 1ec71635b (sync with main branch)

        public KLightServerSession(KernelContext context, KLightSession parent) : base(context)
        {
            _parent = parent;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
