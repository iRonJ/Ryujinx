<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetStorageBuffersCommand : IGALCommand, IGALCommand<SetStorageBuffersCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetStorageBuffers;
=======
        public CommandType CommandType => CommandType.SetStorageBuffers;
>>>>>>> 1ec71635b (sync with main branch)
        private SpanRef<BufferAssignment> _buffers;

        public void Set(SpanRef<BufferAssignment> buffers)
        {
            _buffers = buffers;
        }

        public static void Run(ref SetStorageBuffersCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            Span<BufferAssignment> buffers = command._buffers.Get(threaded);
            renderer.Pipeline.SetStorageBuffers(threaded.Buffers.MapBufferRanges(buffers));
            command._buffers.Dispose(threaded);
        }
    }
}
