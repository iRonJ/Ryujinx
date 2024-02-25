<<<<<<< HEAD
namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    readonly struct ServerMessageRuntimeMetadata
    {
        public ushort InDataSize { get; }
        public ushort OutDataSize { get; }
        public byte InHeadersSize { get; }
        public byte OutHeadersSize { get; }
        public byte InObjectsCount { get; }
        public byte OutObjectsCount { get; }
=======
﻿namespace Ryujinx.Horizon.Sdk.Sf.Cmif
{
    struct ServerMessageRuntimeMetadata
    {
        public ushort InDataSize      { get; }
        public ushort OutDataSize     { get; }
        public byte   InHeadersSize   { get; }
        public byte   OutHeadersSize  { get; }
        public byte   InObjectsCount  { get; }
        public byte   OutObjectsCount { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public int UnfixedOutPointerSizeOffset => InDataSize + InHeadersSize + 0x10;

        public ServerMessageRuntimeMetadata(
            ushort inDataSize,
            ushort outDataSize,
<<<<<<< HEAD
            byte inHeadersSize,
            byte outHeadersSize,
            byte inObjectsCount,
            byte outObjectsCount)
        {
            InDataSize = inDataSize;
            OutDataSize = outDataSize;
            InHeadersSize = inHeadersSize;
            OutHeadersSize = outHeadersSize;
            InObjectsCount = inObjectsCount;
            OutObjectsCount = outObjectsCount;
        }
    }
}
=======
            byte   inHeadersSize,
            byte   outHeadersSize,
            byte   inObjectsCount,
            byte   outObjectsCount)
        {
            InDataSize      = inDataSize;
            OutDataSize     = outDataSize;
            InHeadersSize   = inHeadersSize;
            OutHeadersSize  = outHeadersSize;
            InObjectsCount  = inObjectsCount;
            OutObjectsCount = outObjectsCount;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
