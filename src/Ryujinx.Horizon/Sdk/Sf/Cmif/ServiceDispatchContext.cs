<<<<<<< HEAD
using Ryujinx.Horizon.Sdk.Sf.Hipc;
=======
﻿using Ryujinx.Horizon.Sdk.Sf.Hipc;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    ref struct ServiceDispatchContext
    {
<<<<<<< HEAD
        public IServiceObject ServiceObject;
        public ServerSessionManager Manager;
        public ServerSession Session;
        public ServerMessageProcessor Processor;
        public HandlesToClose HandlesToClose;
        public PointerAndSize PointerBuffer;
        public ReadOnlySpan<byte> InMessageBuffer;
        public Span<byte> OutMessageBuffer;
        public HipcMessage Request;
    }
}
=======
        public IServiceObject         ServiceObject;
        public ServerSessionManager   Manager;
        public ServerSession          Session;
        public ServerMessageProcessor Processor;
        public HandlesToClose         HandlesToClose;
        public PointerAndSize         PointerBuffer;
        public ReadOnlySpan<byte>     InMessageBuffer;
        public Span<byte>             OutMessageBuffer;
        public HipcMessage            Request;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
