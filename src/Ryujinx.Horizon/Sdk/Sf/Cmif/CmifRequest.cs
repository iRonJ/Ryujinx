<<<<<<< HEAD
using Ryujinx.Horizon.Sdk.Sf.Hipc;
=======
﻿using Ryujinx.Horizon.Sdk.Sf.Hipc;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    ref struct CmifRequest
    {
        public HipcMessageData Hipc;
<<<<<<< HEAD
        public Span<byte> Data;
        public Span<ushort> OutPointerSizes;
        public Span<uint> Objects;
        public int ServerPointerSize;
        public int CurrentInPointerId;
        public int SendBufferIndex;
        public int RecvBufferIndex;
        public int ExchBufferIndex;
        public int SendStaticIndex;
        public int RecvListIndex;
        public int OutPointerSizeIndex;
=======
        public Span<byte>      Data;
        public Span<ushort>    OutPointerSizes;
        public Span<uint>      Objects;
        public int             ServerPointerSize;
>>>>>>> 1ec71635b (sync with main branch)
    }
}
