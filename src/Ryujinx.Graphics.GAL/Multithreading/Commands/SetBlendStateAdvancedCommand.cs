namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct SetBlendStateAdvancedCommand : IGALCommand, IGALCommand<SetBlendStateAdvancedCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.SetBlendStateAdvanced;
=======
        public CommandType CommandType => CommandType.SetBlendStateAdvanced;
>>>>>>> 1ec71635b (sync with main branch)
        private AdvancedBlendDescriptor _blend;

        public void Set(AdvancedBlendDescriptor blend)
        {
            _blend = blend;
        }

        public static void Run(ref SetBlendStateAdvancedCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.SetBlendState(command._blend);
        }
    }
}
