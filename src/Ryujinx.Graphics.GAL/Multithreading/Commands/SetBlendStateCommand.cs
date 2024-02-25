<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetBlendStateCommand : IGALCommand, IGALCommand<SetBlendStateCommand>
    {
        public readonly CommandType CommandType => CommandType.SetBlendState;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetBlendStateCommand : IGALCommand, IGALCommand<SetBlendStateCommand>
    {
        public CommandType CommandType => CommandType.SetBlendState;
>>>>>>> 1ec71635b (sync with main branch)
        private int _index;
        private BlendDescriptor _blend;

        public void Set(int index, BlendDescriptor blend)
        {
            _index = index;
            _blend = blend;
        }

        public static void Run(ref SetBlendStateCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetBlendState(command._index, command._blend);
        }
    }
}
