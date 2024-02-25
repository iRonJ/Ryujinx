<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ryujinx.Common.Memory
{
    public ref struct SpanWriter
    {
        private Span<byte> _output;

<<<<<<< HEAD
        public readonly int Length => _output.Length;
=======
        public int Length => _output.Length;
>>>>>>> 1ec71635b (sync with main branch)

        public SpanWriter(Span<byte> output)
        {
            _output = output;
        }

        public void Write<T>(T value) where T : unmanaged
        {
            MemoryMarshal.Cast<byte, T>(_output)[0] = value;
<<<<<<< HEAD
            _output = _output[Unsafe.SizeOf<T>()..];
=======
            _output = _output.Slice(Unsafe.SizeOf<T>());
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void Write(ReadOnlySpan<byte> data)
        {
<<<<<<< HEAD
            data.CopyTo(_output[..data.Length]);
            _output = _output[data.Length..];
        }

        public readonly void WriteAt<T>(int offset, T value) where T : unmanaged
        {
            MemoryMarshal.Cast<byte, T>(_output[offset..])[0] = value;
        }

        public readonly void WriteAt(int offset, ReadOnlySpan<byte> data)
=======
            data.CopyTo(_output.Slice(0, data.Length));
            _output = _output.Slice(data.Length);
        }

        public void WriteAt<T>(int offset, T value) where T : unmanaged
        {
            MemoryMarshal.Cast<byte, T>(_output.Slice(offset))[0] = value;
        }

        public void WriteAt(int offset, ReadOnlySpan<byte> data)
>>>>>>> 1ec71635b (sync with main branch)
        {
            data.CopyTo(_output.Slice(offset, data.Length));
        }

        public void Skip(int size)
        {
<<<<<<< HEAD
            _output = _output[size..];
=======
            _output = _output.Slice(size);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
