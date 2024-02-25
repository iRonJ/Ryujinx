<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct TextureBarrierCommand : IGALCommand, IGALCommand<TextureBarrierCommand>
    {
        public readonly CommandType CommandType => CommandType.TextureBarrier;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct TextureBarrierCommand : IGALCommand, IGALCommand<TextureBarrierCommand>
    {
        public CommandType CommandType => CommandType.TextureBarrier;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref TextureBarrierCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.TextureBarrier();
        }
    }
}
