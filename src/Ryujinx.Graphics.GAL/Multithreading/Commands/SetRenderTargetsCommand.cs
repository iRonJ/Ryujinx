<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using System.Linq;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetRenderTargetsCommand : IGALCommand, IGALCommand<SetRenderTargetsCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetRenderTargets;
=======
        public CommandType CommandType => CommandType.SetRenderTargets;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ITexture[]> _colors;
        private TableRef<ITexture> _depthStencil;

        public void Set(TableRef<ITexture[]> colors, TableRef<ITexture> depthStencil)
        {
            _colors = colors;
            _depthStencil = depthStencil;
        }

        public static void Run(ref SetRenderTargetsCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetRenderTargets(command._colors.Get(threaded).Select(color => ((ThreadedTexture)color)?.Base).ToArray(), command._depthStencil.GetAs<ThreadedTexture>(threaded)?.Base);
        }
    }
}
