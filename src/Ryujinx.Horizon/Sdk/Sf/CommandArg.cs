<<<<<<< HEAD
using Ryujinx.Horizon.Sdk.Sf.Hipc;
=======
﻿using Ryujinx.Horizon.Sdk.Sf.Hipc;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Sdk.Sf
{
    enum CommandArgType : byte
    {
        Invalid,

        Buffer,
        InArgument,
        InCopyHandle,
        InMoveHandle,
        InObject,
        OutArgument,
        OutCopyHandle,
        OutMoveHandle,
        OutObject,
<<<<<<< HEAD
        ProcessId,
    }

    readonly struct CommandArg
    {
        public CommandArgType Type { get; }
        public HipcBufferFlags BufferFlags { get; }
        public ushort BufferFixedSize { get; }
        public int ArgSize { get; }
        public int ArgAlignment { get; }

        public CommandArg(CommandArgType type)
        {
            Type = type;
            BufferFlags = default;
            BufferFixedSize = 0;
            ArgSize = 0;
            ArgAlignment = 0;
=======
        ProcessId
    }

    struct CommandArg
    {
        public CommandArgType  Type            { get; }
        public HipcBufferFlags BufferFlags     { get; }
        public ushort          BufferFixedSize { get; }
        public int             ArgSize         { get; }
        public int             ArgAlignment    { get; }

        public CommandArg(CommandArgType type)
        {
            Type            = type;
            BufferFlags     = default;
            BufferFixedSize = 0;
            ArgSize         = 0;
            ArgAlignment    = 0;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public CommandArg(CommandArgType type, int argSize, int argAlignment)
        {
<<<<<<< HEAD
            Type = type;
            BufferFlags = default;
            BufferFixedSize = 0;
            ArgSize = argSize;
            ArgAlignment = argAlignment;
=======
            Type            = type;
            BufferFlags     = default;
            BufferFixedSize = 0;
            ArgSize         = argSize;
            ArgAlignment    = argAlignment;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public CommandArg(HipcBufferFlags flags, ushort fixedSize = 0)
        {
<<<<<<< HEAD
            Type = CommandArgType.Buffer;
            BufferFlags = flags;
            BufferFixedSize = fixedSize;
            ArgSize = 0;
            ArgAlignment = 0;
        }
    }
}
=======
            Type            = CommandArgType.Buffer;
            BufferFlags     = flags;
            BufferFixedSize = fixedSize;
            ArgSize         = 0;
            ArgAlignment    = 0;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
