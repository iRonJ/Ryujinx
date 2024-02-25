<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct BarrierCommand : IGALCommand, IGALCommand<BarrierCommand>
    {
        public readonly CommandType CommandType => CommandType.Barrier;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct BarrierCommand : IGALCommand, IGALCommand<BarrierCommand>
    {
        public CommandType CommandType => CommandType.Barrier;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref BarrierCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.Barrier();
        }
    }
}
