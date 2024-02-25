<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct CommandBufferBarrierCommand : IGALCommand, IGALCommand<CommandBufferBarrierCommand>
    {
        public readonly CommandType CommandType => CommandType.CommandBufferBarrier;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct CommandBufferBarrierCommand : IGALCommand, IGALCommand<CommandBufferBarrierCommand>
    {
        public CommandType CommandType => CommandType.CommandBufferBarrier;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref CommandBufferBarrierCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.CommandBufferBarrier();
        }
    }
}
