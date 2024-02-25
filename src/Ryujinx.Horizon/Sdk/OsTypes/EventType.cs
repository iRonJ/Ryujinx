<<<<<<< HEAD
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.OsTypes
{
    struct EventType
    {
        public LinkedList<MultiWaitHolderBase> MultiWaitHolders;
        public bool Signaled;
        public bool InitiallySignaled;
        public EventClearMode ClearMode;
        public InitializationState State;
        public ulong BroadcastCounter;
        public object Lock;
    }
}
