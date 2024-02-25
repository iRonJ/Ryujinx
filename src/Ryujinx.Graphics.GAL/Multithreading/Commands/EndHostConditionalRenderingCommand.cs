<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct EndHostConditionalRenderingCommand : IGALCommand, IGALCommand<EndHostConditionalRenderingCommand>
    {
        public readonly CommandType CommandType => CommandType.EndHostConditionalRendering;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct EndHostConditionalRenderingCommand : IGALCommand, IGALCommand<EndHostConditionalRenderingCommand>
    {
        public CommandType CommandType => CommandType.EndHostConditionalRendering;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref EndHostConditionalRenderingCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.EndHostConditionalRendering();
        }
    }
}
