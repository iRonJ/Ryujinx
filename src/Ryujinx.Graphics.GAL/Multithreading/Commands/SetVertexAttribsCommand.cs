<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetVertexAttribsCommand : IGALCommand, IGALCommand<SetVertexAttribsCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetVertexAttribs;
=======
        public CommandType CommandType => CommandType.SetVertexAttribs;
>>>>>>> 1ec71635b (sync with main branch)
        private SpanRef<VertexAttribDescriptor> _vertexAttribs;

        public void Set(SpanRef<VertexAttribDescriptor> vertexAttribs)
        {
            _vertexAttribs = vertexAttribs;
        }

        public static void Run(ref SetVertexAttribsCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            ReadOnlySpan<VertexAttribDescriptor> vertexAttribs = command._vertexAttribs.Get(threaded);
            renderer.Pipeline.SetVertexAttribs(vertexAttribs);
            command._vertexAttribs.Dispose(threaded);
        }
    }
}
