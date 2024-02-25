<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct DrawIndirectCountCommand : IGALCommand, IGALCommand<DrawIndirectCountCommand>
    {
        public readonly CommandType CommandType => CommandType.DrawIndirectCount;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct DrawIndirectCountCommand : IGALCommand, IGALCommand<DrawIndirectCountCommand>
    {
        public CommandType CommandType => CommandType.DrawIndirectCount;
>>>>>>> 1ec71635b (sync with main branch)
        private BufferRange _indirectBuffer;
        private BufferRange _parameterBuffer;
        private int _maxDrawCount;
        private int _stride;

        public void Set(BufferRange indirectBuffer, BufferRange parameterBuffer, int maxDrawCount, int stride)
        {
            _indirectBuffer = indirectBuffer;
            _parameterBuffer = parameterBuffer;
            _maxDrawCount = maxDrawCount;
            _stride = stride;
        }

        public static void Run(ref DrawIndirectCountCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.DrawIndirectCount(
                threaded.Buffers.MapBufferRange(command._indirectBuffer),
                threaded.Buffers.MapBufferRange(command._parameterBuffer),
                command._maxDrawCount,
                command._stride
                );
        }
    }
}
