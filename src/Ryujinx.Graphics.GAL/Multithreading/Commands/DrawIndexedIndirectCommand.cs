namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct DrawIndexedIndirectCommand : IGALCommand, IGALCommand<DrawIndexedIndirectCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.DrawIndexedIndirect;
=======
        public CommandType CommandType => CommandType.DrawIndexedIndirect;
>>>>>>> 1ec71635b (sync with main branch)
        private BufferRange _indirectBuffer;

        public void Set(BufferRange indirectBuffer)
        {
            _indirectBuffer = indirectBuffer;
        }

        public static void Run(ref DrawIndexedIndirectCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.DrawIndexedIndirect(threaded.Buffers.MapBufferRange(command._indirectBuffer));
        }
    }
}
