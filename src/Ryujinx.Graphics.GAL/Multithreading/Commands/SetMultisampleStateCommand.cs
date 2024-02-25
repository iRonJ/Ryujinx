namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetMultisampleStateCommand : IGALCommand, IGALCommand<SetMultisampleStateCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetMultisampleState;
=======
        public CommandType CommandType => CommandType.SetMultisampleState;
>>>>>>> 1ec71635b (sync with main branch)
        private MultisampleDescriptor _multisample;

        public void Set(MultisampleDescriptor multisample)
        {
            _multisample = multisample;
        }

        public static void Run(ref SetMultisampleStateCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetMultisampleState(command._multisample);
        }
    }
}
