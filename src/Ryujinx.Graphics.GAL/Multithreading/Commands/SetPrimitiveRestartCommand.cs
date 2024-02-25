<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetPrimitiveRestartCommand : IGALCommand, IGALCommand<SetPrimitiveRestartCommand>
    {
        public readonly CommandType CommandType => CommandType.SetPrimitiveRestart;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetPrimitiveRestartCommand : IGALCommand, IGALCommand<SetPrimitiveRestartCommand>
    {
        public CommandType CommandType => CommandType.SetPrimitiveRestart;
>>>>>>> 1ec71635b (sync with main branch)
        private bool _enable;
        private int _index;

        public void Set(bool enable, int index)
        {
            _enable = enable;
            _index = index;
        }

        public static void Run(ref SetPrimitiveRestartCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetPrimitiveRestart(command._enable, command._index);
        }
    }
}
