<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Ryujinx.Graphics.GAL.Multithreading
{
    /// <summary>
    /// Buffer handles given to the client are not the same as those provided by the backend,
    /// as their handle is created at a later point on the queue.
    /// The handle returned is a unique identifier that will map to the real buffer when it is available.
    /// Note that any uses within the queue should be safe, but outside you must use MapBufferBlocking.
    /// </summary>
    class BufferMap
    {
        private ulong _bufferHandle = 0;

<<<<<<< HEAD
        private readonly Dictionary<BufferHandle, BufferHandle> _bufferMap = new();
        private readonly HashSet<BufferHandle> _inFlight = new();
        private readonly AutoResetEvent _inFlightChanged = new(false);
=======
        private Dictionary<BufferHandle, BufferHandle> _bufferMap = new Dictionary<BufferHandle, BufferHandle>();
        private HashSet<BufferHandle> _inFlight = new HashSet<BufferHandle>();
        private AutoResetEvent _inFlightChanged = new AutoResetEvent(false);
>>>>>>> 1ec71635b (sync with main branch)

        internal BufferHandle CreateBufferHandle()
        {
            ulong handle64 = Interlocked.Increment(ref _bufferHandle);

            BufferHandle threadedHandle = Unsafe.As<ulong, BufferHandle>(ref handle64);

            lock (_inFlight)
            {
                _inFlight.Add(threadedHandle);
            }

            return threadedHandle;
        }

        internal void AssignBuffer(BufferHandle threadedHandle, BufferHandle realHandle)
        {
            lock (_bufferMap)
            {
                _bufferMap[threadedHandle] = realHandle;
            }

            lock (_inFlight)
            {
                _inFlight.Remove(threadedHandle);
            }

            _inFlightChanged.Set();
        }

        internal void UnassignBuffer(BufferHandle threadedHandle)
        {
            lock (_bufferMap)
            {
                _bufferMap.Remove(threadedHandle);
            }
        }

        internal BufferHandle MapBuffer(BufferHandle handle)
        {
            // Maps a threaded buffer to a backend one.
<<<<<<< HEAD
            // Threaded buffers are returned on creation as the buffer
            // isn't actually created until the queue runs the command.

            lock (_bufferMap)
            {
                if (!_bufferMap.TryGetValue(handle, out BufferHandle result))
=======
            // Threaded buffers are returned on creation as the buffer 
            // isn't actually created until the queue runs the command.

            BufferHandle result;

            lock (_bufferMap)
            {
                if (!_bufferMap.TryGetValue(handle, out result))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    result = BufferHandle.Null;
                }

                return result;
            }
        }

        internal BufferHandle MapBufferBlocking(BufferHandle handle)
        {
            // Blocks until the handle is available.

<<<<<<< HEAD

            lock (_bufferMap)
            {
                if (_bufferMap.TryGetValue(handle, out BufferHandle result))
=======
            BufferHandle result;

            lock (_bufferMap)
            {
                if (_bufferMap.TryGetValue(handle, out result))
>>>>>>> 1ec71635b (sync with main branch)
                {
                    return result;
                }
            }

            bool signal = false;

            while (true)
            {
                lock (_inFlight)
                {
                    if (!_inFlight.Contains(handle))
                    {
                        break;
                    }
                }

                _inFlightChanged.WaitOne();
                signal = true;
            }

            if (signal)
            {
                // Signal other threads which might still be waiting.
                _inFlightChanged.Set();
            }

            return MapBuffer(handle);
        }

        internal BufferRange MapBufferRange(BufferRange range)
        {
<<<<<<< HEAD
            return new BufferRange(MapBuffer(range.Handle), range.Offset, range.Size, range.Write);
=======
            return new BufferRange(MapBuffer(range.Handle), range.Offset, range.Size);
>>>>>>> 1ec71635b (sync with main branch)
        }

        internal Span<BufferRange> MapBufferRanges(Span<BufferRange> ranges)
        {
            // Rewrite the buffer ranges to point to the mapped handles.

            lock (_bufferMap)
            {
                for (int i = 0; i < ranges.Length; i++)
                {
                    ref BufferRange range = ref ranges[i];
<<<<<<< HEAD

                    if (!_bufferMap.TryGetValue(range.Handle, out BufferHandle result))
=======
                    BufferHandle result;

                    if (!_bufferMap.TryGetValue(range.Handle, out result))
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        result = BufferHandle.Null;
                    }

<<<<<<< HEAD
                    range = new BufferRange(result, range.Offset, range.Size, range.Write);
=======
                    range = new BufferRange(result, range.Offset, range.Size);
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            return ranges;
        }

        internal Span<BufferAssignment> MapBufferRanges(Span<BufferAssignment> ranges)
        {
            // Rewrite the buffer ranges to point to the mapped handles.

            lock (_bufferMap)
            {
                for (int i = 0; i < ranges.Length; i++)
                {
                    ref BufferAssignment assignment = ref ranges[i];
                    BufferRange range = assignment.Range;
<<<<<<< HEAD

                    if (!_bufferMap.TryGetValue(range.Handle, out BufferHandle result))
=======
                    BufferHandle result;

                    if (!_bufferMap.TryGetValue(range.Handle, out result))
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        result = BufferHandle.Null;
                    }

<<<<<<< HEAD
                    assignment = new BufferAssignment(ranges[i].Binding, new BufferRange(result, range.Offset, range.Size, range.Write));
=======
                    assignment = new BufferAssignment(ranges[i].Binding, new BufferRange(result, range.Offset, range.Size));
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            return ranges;
        }

        internal Span<VertexBufferDescriptor> MapBufferRanges(Span<VertexBufferDescriptor> ranges)
        {
            // Rewrite the buffer ranges to point to the mapped handles.

            lock (_bufferMap)
            {
                for (int i = 0; i < ranges.Length; i++)
                {
                    BufferRange range = ranges[i].Buffer;
<<<<<<< HEAD

                    if (!_bufferMap.TryGetValue(range.Handle, out BufferHandle result))
=======
                    BufferHandle result;

                    if (!_bufferMap.TryGetValue(range.Handle, out result))
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        result = BufferHandle.Null;
                    }

<<<<<<< HEAD
                    range = new BufferRange(result, range.Offset, range.Size, range.Write);
=======
                    range = new BufferRange(result, range.Offset, range.Size);
>>>>>>> 1ec71635b (sync with main branch)

                    ranges[i] = new VertexBufferDescriptor(range, ranges[i].Stride, ranges[i].Divisor);
                }
            }

            return ranges;
        }
    }
}
