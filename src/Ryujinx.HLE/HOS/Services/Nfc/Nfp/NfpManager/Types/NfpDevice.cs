<<<<<<< HEAD
using Ryujinx.HLE.HOS.Kernel.Threading;
=======
﻿using Ryujinx.HLE.HOS.Kernel.Threading;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Services.Hid;

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager
{
    class NfpDevice
    {
        public KEvent ActivateEvent;
        public KEvent DeactivateEvent;

<<<<<<< HEAD
        public void SignalActivate() => ActivateEvent.ReadableEvent.Signal();
=======
        public void SignalActivate()   => ActivateEvent.ReadableEvent.Signal();
>>>>>>> 1ec71635b (sync with main branch)
        public void SignalDeactivate() => DeactivateEvent.ReadableEvent.Signal();

        public NfpDeviceState State = NfpDeviceState.Unavailable;

        public PlayerIndex Handle;
<<<<<<< HEAD
        public NpadIdType NpadIdType;
=======
        public NpadIdType  NpadIdType;
>>>>>>> 1ec71635b (sync with main branch)

        public string AmiiboId;

        public bool UseRandomUuid;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
