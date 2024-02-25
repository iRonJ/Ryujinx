<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetDepthClampCommand : IGALCommand, IGALCommand<SetDepthClampCommand>
    {
        public readonly CommandType CommandType => CommandType.SetDepthClamp;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetDepthClampCommand : IGALCommand, IGALCommand<SetDepthClampCommand>
    {
        public CommandType CommandType => CommandType.SetDepthClamp;
>>>>>>> 1ec71635b (sync with main branch)
        private bool _clamp;

        public void Set(bool clamp)
        {
            _clamp = clamp;
        }

        public static void Run(ref SetDepthClampCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetDepthClamp(command._clamp);
        }
    }
}
