<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetViewportsCommand : IGALCommand, IGALCommand<SetViewportsCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetViewports;
        private SpanRef<Viewport> _viewports;

        public void Set(SpanRef<Viewport> viewports)
        {
            _viewports = viewports;
=======
        public CommandType CommandType => CommandType.SetViewports;
        private SpanRef<Viewport> _viewports;
        private bool _disableTransform;

        public void Set(SpanRef<Viewport> viewports, bool disableTransform)
        {
            _viewports = viewports;
            _disableTransform = disableTransform;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static void Run(ref SetViewportsCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            ReadOnlySpan<Viewport> viewports = command._viewports.Get(threaded);
<<<<<<< HEAD
            renderer.Pipeline.SetViewports(viewports);
=======
            renderer.Pipeline.SetViewports(viewports, command._disableTransform);
>>>>>>> 1ec71635b (sync with main branch)
            command._viewports.Dispose(threaded);
        }
    }
}
