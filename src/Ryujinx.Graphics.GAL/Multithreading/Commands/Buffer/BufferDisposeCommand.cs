<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Buffer
{
    struct BufferDisposeCommand : IGALCommand, IGALCommand<BufferDisposeCommand>
    {
        public readonly CommandType CommandType => CommandType.BufferDispose;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Buffer
{
    struct BufferDisposeCommand : IGALCommand, IGALCommand<BufferDisposeCommand>
    {
        public CommandType CommandType => CommandType.BufferDispose;
>>>>>>> 1ec71635b (sync with main branch)
        private BufferHandle _buffer;

        public void Set(BufferHandle buffer)
        {
            _buffer = buffer;
        }

        public static void Run(ref BufferDisposeCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.DeleteBuffer(threaded.Buffers.MapBuffer(command._buffer));
            threaded.Buffers.UnassignBuffer(command._buffer);
        }
    }
}
