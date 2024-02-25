<<<<<<< HEAD
using Ryujinx.Horizon.Sdk.Sf.Hipc;
=======
﻿using Ryujinx.Horizon.Sdk.Sf.Hipc;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Horizon.Sdk.Sf
{
    [AttributeUsage(AttributeTargets.Parameter)]
    class BufferAttribute : Attribute
    {
<<<<<<< HEAD
        public HipcBufferFlags Flags { get; }
        public ushort FixedSize { get; }
=======
        public HipcBufferFlags Flags     { get; }
        public ushort          FixedSize { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public BufferAttribute(HipcBufferFlags flags)
        {
            Flags = flags;
        }

        public BufferAttribute(HipcBufferFlags flags, ushort fixedSize)
        {
<<<<<<< HEAD
            Flags = flags | HipcBufferFlags.FixedSize;
=======
            Flags     = flags | HipcBufferFlags.FixedSize;
>>>>>>> 1ec71635b (sync with main branch)
            FixedSize = fixedSize;
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    class ClientProcessIdAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    class CopyHandleAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    class MoveHandleAttribute : Attribute
    {
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
