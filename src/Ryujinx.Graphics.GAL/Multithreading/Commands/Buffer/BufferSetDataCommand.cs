<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Buffer
{
    struct BufferSetDataCommand : IGALCommand, IGALCommand<BufferSetDataCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.BufferSetData;
=======
        public CommandType CommandType => CommandType.BufferSetData;
>>>>>>> 1ec71635b (sync with main branch)
        private BufferHandle _buffer;
        private int _offset;
        private SpanRef<byte> _data;

        public void Set(BufferHandle buffer, int offset, SpanRef<byte> data)
        {
            _buffer = buffer;
            _offset = offset;
            _data = data;
        }

        public static void Run(ref BufferSetDataCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            ReadOnlySpan<byte> data = command._data.Get(threaded);
            renderer.SetBufferData(threaded.Buffers.MapBuffer(command._buffer), command._offset, data);
            command._data.Dispose(threaded);
        }
    }
}
