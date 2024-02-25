<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetVertexBuffersCommand : IGALCommand, IGALCommand<SetVertexBuffersCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetVertexBuffers;
=======
        public CommandType CommandType => CommandType.SetVertexBuffers;
>>>>>>> 1ec71635b (sync with main branch)
        private SpanRef<VertexBufferDescriptor> _vertexBuffers;

        public void Set(SpanRef<VertexBufferDescriptor> vertexBuffers)
        {
            _vertexBuffers = vertexBuffers;
        }

        public static void Run(ref SetVertexBuffersCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            Span<VertexBufferDescriptor> vertexBuffers = command._vertexBuffers.Get(threaded);
            renderer.Pipeline.SetVertexBuffers(threaded.Buffers.MapBufferRanges(vertexBuffers));
            command._vertexBuffers.Dispose(threaded);
        }
    }
}
