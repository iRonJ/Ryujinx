<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct TextureBarrierTiledCommand : IGALCommand, IGALCommand<TextureBarrierTiledCommand>
    {
        public readonly CommandType CommandType => CommandType.TextureBarrierTiled;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct TextureBarrierTiledCommand : IGALCommand, IGALCommand<TextureBarrierTiledCommand>
    {
        public CommandType CommandType => CommandType.TextureBarrierTiled;
>>>>>>> 1ec71635b (sync with main branch)

        public static void Run(ref TextureBarrierTiledCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.TextureBarrierTiled();
        }
    }
}
