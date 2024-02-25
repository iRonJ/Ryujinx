<<<<<<< HEAD
namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct ClearBufferCommand : IGALCommand, IGALCommand<ClearBufferCommand>
    {
        public readonly CommandType CommandType => CommandType.ClearBuffer;
=======
﻿namespace Ryujinx.Graphics.GAL.Multithreading.Commands
{
    struct ClearBufferCommand : IGALCommand, IGALCommand<ClearBufferCommand>
    {
        public CommandType CommandType => CommandType.ClearBuffer;
>>>>>>> 1ec71635b (sync with main branch)
        private BufferHandle _destination;
        private int _offset;
        private int _size;
        private uint _value;

        public void Set(BufferHandle destination, int offset, int size, uint value)
        {
            _destination = destination;
            _offset = offset;
            _size = size;
            _value = value;
        }

        public static void Run(ref ClearBufferCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            renderer.Pipeline.ClearBuffer(threaded.Buffers.MapBuffer(command._destination), command._offset, command._size, command._value);
        }
    }
}
