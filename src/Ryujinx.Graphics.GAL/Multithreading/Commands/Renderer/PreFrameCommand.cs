<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct PreFrameCommand : IGALCommand, IGALCommand<PreFrameCommand>
    {
        public readonly CommandType CommandType => CommandType.PreFrame;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct PreFrameCommand : IGALCommand, IGALCommand<PreFrameCommand>
    {
        public CommandType CommandType => CommandType.PreFrame;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref PreFrameCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.PreFrame();
        }
    }
}
