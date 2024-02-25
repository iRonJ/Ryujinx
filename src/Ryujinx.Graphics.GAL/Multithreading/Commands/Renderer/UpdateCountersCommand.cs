<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct UpdateCountersCommand : IGALCommand, IGALCommand<UpdateCountersCommand>
    {
        public readonly CommandType CommandType => CommandType.UpdateCounters;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct UpdateCountersCommand : IGALCommand, IGALCommand<UpdateCountersCommand>
    {
        public CommandType CommandType => CommandType.UpdateCounters;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref UpdateCountersCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.UpdateCounters();
        }
    }
}
