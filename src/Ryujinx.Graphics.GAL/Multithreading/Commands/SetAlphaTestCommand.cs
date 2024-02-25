<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetAlphaTestCommand : IGALCommand, IGALCommand<SetAlphaTestCommand>
    {
        public readonly CommandType CommandType => CommandType.SetAlphaTest;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetAlphaTestCommand : IGALCommand, IGALCommand<SetAlphaTestCommand>
    {
        public CommandType CommandType => CommandType.SetAlphaTest;
>>>>>>> 1ec71635b (sync with main branch)
        private bool _enable;
        private float _reference;
        private CompareOp _op;

        public void Set(bool enable, float reference, CompareOp op)
        {
            _enable = enable;
            _reference = reference;
            _op = op;
        }

        public static void Run(ref SetAlphaTestCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetAlphaTest(command._enable, command._reference, command._op);
        }
    }
}
