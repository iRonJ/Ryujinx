<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetUniformBuffersCommand : IGALCommand, IGALCommand<SetUniformBuffersCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetUniformBuffers;
=======
        public CommandType CommandType => CommandType.SetUniformBuffers;
>>>>>>> 1ec71635b (sync with main branch)
        private SpanRef<BufferAssignment> _buffers;

        public void Set(SpanRef<BufferAssignment> buffers)
        {
            _buffers = buffers;
        }

        public static void Run(ref SetUniformBuffersCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            Span<BufferAssignment> buffers = command._buffers.Get(threaded);
            renderer.Pipeline.SetUniformBuffers(threaded.Buffers.MapBufferRanges(buffers));
            command._buffers.Dispose(threaded);
        }
    }
}
