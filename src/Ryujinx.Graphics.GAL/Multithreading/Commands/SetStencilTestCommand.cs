<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetStencilTestCommand : IGALCommand, IGALCommand<SetStencilTestCommand>
    {
        public readonly CommandType CommandType => CommandType.SetStencilTest;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetStencilTestCommand : IGALCommand, IGALCommand<SetStencilTestCommand>
    {
        public CommandType CommandType => CommandType.SetStencilTest;
>>>>>>> 1ec71635b (sync with main branch)
        private StencilTestDescriptor _stencilTest;

        public void Set(StencilTestDescriptor stencilTest)
        {
            _stencilTest = stencilTest;
        }

        public static void Run(ref SetStencilTestCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetStencilTest(command._stencilTest);
        }
    }
}
