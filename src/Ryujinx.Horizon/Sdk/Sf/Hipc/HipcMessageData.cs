<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.Sf.Hipc
{
    ref struct HipcMessageData
    {
        public Span<HipcStaticDescriptor> SendStatics;
        public Span<HipcBufferDescriptor> SendBuffers;
        public Span<HipcBufferDescriptor> ReceiveBuffers;
        public Span<HipcBufferDescriptor> ExchangeBuffers;
<<<<<<< HEAD
        public Span<uint> DataWords;
        public Span<uint> DataWordsPadded;
        public Span<HipcReceiveListEntry> ReceiveList;
        public Span<int> CopyHandles;
        public Span<int> MoveHandles;
    }
}
=======
        public Span<uint>                 DataWords;
        public Span<HipcReceiveListEntry> ReceiveList;
        public Span<int>                  CopyHandles;
        public Span<int>                  MoveHandles;
    }
}
>>>>>>> 1ec71635b (sync with main branch)
