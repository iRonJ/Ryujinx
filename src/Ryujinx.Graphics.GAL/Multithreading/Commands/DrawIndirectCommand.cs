namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct DrawIndirectCommand : IGALCommand, IGALCommand<DrawIndirectCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.DrawIndirect;
=======
        public CommandType CommandType => CommandType.DrawIndirect;
>>>>>>> 1ec71635b (sync with main branch)
        private BufferRange _indirectBuffer;

        public void Set(BufferRange indirectBuffer)
        {
            _indirectBuffer = indirectBuffer;
        }

        public static void Run(ref DrawIndirectCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.DrawIndirect(threaded.Buffers.MapBufferRange(command._indirectBuffer));
        }
    }
}
