<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct CreateBufferCommand : IGALCommand, IGALCommand<CreateBufferCommand>
    {
        public readonly CommandType CommandType => CommandType.CreateBuffer;
        private BufferHandle _threadedHandle;
        private int _size;
        private BufferAccess _access;
        private BufferHandle _storageHint;

        public void Set(BufferHandle threadedHandle, int size, BufferAccess access, BufferHandle storageHint)
        {
            _threadedHandle = threadedHandle;
            _size = size;
            _access = access;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct CreateBufferCommand : IGALCommand, IGALCommand<CreateBufferCommand>
    {
        public CommandType CommandType => CommandType.CreateBuffer;
        private BufferHandle _threadedHandle;
        private int _size;
        private BufferHandle _storageHint;

        public void Set(BufferHandle threadedHandle, int size, BufferHandle storageHint)
        {
            _threadedHandle = threadedHandle;
            _size = size;
>>>>>>> 1ec71635b (sync with main branch)
            _storageHint = storageHint;
        }

        public static void Run(ref CreateBufferCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            BufferHandle hint = BufferHandle.Null;

            if (command._storageHint != BufferHandle.Null)
            {
                hint = threaded.Buffers.MapBuffer(command._storageHint);
            }

<<<<<<< HEAD
            threaded.Buffers.AssignBuffer(command._threadedHandle, renderer.CreateBuffer(command._size, command._access, hint));
=======
            threaded.Buffers.AssignBuffer(command._threadedHandle, renderer.CreateBuffer(command._size, hint));
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
