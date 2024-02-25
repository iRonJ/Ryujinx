<<<<<<< HEAD
using Ryujinx.Graphics.GAL;
=======
﻿using Ryujinx.Graphics.GAL;
using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Gpu.Engine.Threed
{
    /// <summary>
    /// Semaphore updater.
    /// </summary>
    class SemaphoreUpdater
    {
        /// <summary>
        /// GPU semaphore operation.
        /// </summary>
        private enum SemaphoreOperation
        {
            Release = 0,
            Acquire = 1,
<<<<<<< HEAD
            Counter = 2,
=======
            Counter = 2
>>>>>>> 1ec71635b (sync with main branch)
        }

        /// <summary>
        /// Counter type for GPU counter reset.
        /// </summary>
        private enum ResetCounterType
        {
            SamplesPassed = 1,
            ZcullStats = 2,
            TransformFeedbackPrimitivesWritten = 0x10,
            InputVertices = 0x12,
            InputPrimitives = 0x13,
            VertexShaderInvocations = 0x15,
            TessControlShaderInvocations = 0x16,
            TessEvaluationShaderInvocations = 0x17,
            TessEvaluationShaderPrimitives = 0x18,
            GeometryShaderInvocations = 0x1a,
            GeometryShaderPrimitives = 0x1b,
            ClipperInputPrimitives = 0x1c,
            ClipperOutputPrimitives = 0x1d,
            FragmentShaderInvocations = 0x1e,
<<<<<<< HEAD
            PrimitivesGenerated = 0x1f,
=======
            PrimitivesGenerated = 0x1f
>>>>>>> 1ec71635b (sync with main branch)
        }

        /// <summary>
        /// Counter type for GPU counter reporting.
        /// </summary>
        private enum ReportCounterType
        {
            Payload = 0,
            InputVertices = 1,
            InputPrimitives = 3,
            VertexShaderInvocations = 5,
            GeometryShaderInvocations = 7,
            GeometryShaderPrimitives = 9,
            ZcullStats0 = 0xa,
            TransformFeedbackPrimitivesWritten = 0xb,
            ZcullStats1 = 0xc,
            ZcullStats2 = 0xe,
            ClipperInputPrimitives = 0xf,
            ZcullStats3 = 0x10,
            ClipperOutputPrimitives = 0x11,
            PrimitivesGenerated = 0x12,
            FragmentShaderInvocations = 0x13,
            SamplesPassed = 0x15,
            TransformFeedbackOffset = 0x1a,
            TessControlShaderInvocations = 0x1b,
            TessEvaluationShaderInvocations = 0x1d,
<<<<<<< HEAD
            TessEvaluationShaderPrimitives = 0x1f,
=======
            TessEvaluationShaderPrimitives = 0x1f
>>>>>>> 1ec71635b (sync with main branch)
        }

        private readonly GpuContext _context;
        private readonly GpuChannel _channel;
        private readonly DeviceStateWithShadow<ThreedClassState> _state;

        /// <summary>
        /// Creates a new instance of the semaphore updater.
        /// </summary>
        /// <param name="context">GPU context</param>
        /// <param name="channel">GPU channel</param>
        /// <param name="state">Channel state</param>
        public SemaphoreUpdater(GpuContext context, GpuChannel channel, DeviceStateWithShadow<ThreedClassState> state)
        {
            _context = context;
            _channel = channel;
            _state = state;
        }

        /// <summary>
        /// Resets the value of an internal GPU counter back to zero.
        /// </summary>
        /// <param name="argument">Method call argument</param>
        public void ResetCounter(int argument)
        {
            ResetCounterType type = (ResetCounterType)argument;

            switch (type)
            {
                case ResetCounterType.SamplesPassed:
                    _context.Renderer.ResetCounter(CounterType.SamplesPassed);
                    break;
                case ResetCounterType.PrimitivesGenerated:
                    _context.Renderer.ResetCounter(CounterType.PrimitivesGenerated);
                    break;
                case ResetCounterType.TransformFeedbackPrimitivesWritten:
                    _context.Renderer.ResetCounter(CounterType.TransformFeedbackPrimitivesWritten);
                    break;
            }
        }

        /// <summary>
        /// Writes a GPU counter to guest memory.
        /// </summary>
        /// <param name="argument">Method call argument</param>
        public void Report(int argument)
        {
            SemaphoreOperation op = (SemaphoreOperation)(argument & 3);
            ReportCounterType type = (ReportCounterType)((argument >> 23) & 0x1f);

            switch (op)
            {
<<<<<<< HEAD
                case SemaphoreOperation.Release:
                    ReleaseSemaphore();
                    break;
                case SemaphoreOperation.Counter:
                    ReportCounter(type);
                    break;
=======
                case SemaphoreOperation.Release: ReleaseSemaphore(); break;
                case SemaphoreOperation.Counter: ReportCounter(type); break;
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        /// <summary>
        /// Writes (or Releases) a GPU semaphore value to guest memory.
        /// </summary>
        private void ReleaseSemaphore()
        {
            _channel.MemoryManager.Write(_state.State.SemaphoreAddress.Pack(), _state.State.SemaphorePayload);

            _context.AdvanceSequence();
        }

        /// <summary>
        /// Packed GPU counter data (including GPU timestamp) in memory.
        /// </summary>
        private struct CounterData
        {
            public ulong Counter;
            public ulong Timestamp;
        }

        /// <summary>
        /// Writes a GPU counter to guest memory.
        /// This also writes the current timestamp value.
        /// </summary>
        /// <param name="type">Counter to be written to memory</param>
        private void ReportCounter(ReportCounterType type)
        {
            ulong gpuVa = _state.State.SemaphoreAddress.Pack();

            ulong ticks = _context.GetTimestamp();

            ICounterEvent counter = null;

            void resultHandler(object evt, ulong result)
            {
<<<<<<< HEAD
                CounterData counterData = new()
                {
                    Counter = result,
                    Timestamp = ticks,
=======
                CounterData counterData = new CounterData
                {
                    Counter = result,
                    Timestamp = ticks
>>>>>>> 1ec71635b (sync with main branch)
                };

                if (counter?.Invalid != true)
                {
                    _channel.MemoryManager.Write(gpuVa, counterData);
                }
            }

            switch (type)
            {
                case ReportCounterType.Payload:
                    resultHandler(null, (ulong)_state.State.SemaphorePayload);
                    break;
                case ReportCounterType.SamplesPassed:
<<<<<<< HEAD
                    float scale = _channel.TextureManager.RenderTargetScale;
                    float divisor = scale * scale;
                    counter = _context.Renderer.ReportCounter(CounterType.SamplesPassed, resultHandler, divisor, false);
                    break;
                case ReportCounterType.PrimitivesGenerated:
                    counter = _context.Renderer.ReportCounter(CounterType.PrimitivesGenerated, resultHandler, 1f, false);
                    break;
                case ReportCounterType.TransformFeedbackPrimitivesWritten:
                    counter = _context.Renderer.ReportCounter(CounterType.TransformFeedbackPrimitivesWritten, resultHandler, 1f, false);
=======
                    counter = _context.Renderer.ReportCounter(CounterType.SamplesPassed, resultHandler, false);
                    break;
                case ReportCounterType.PrimitivesGenerated:
                    counter = _context.Renderer.ReportCounter(CounterType.PrimitivesGenerated, resultHandler, false);
                    break;
                case ReportCounterType.TransformFeedbackPrimitivesWritten:
                    counter = _context.Renderer.ReportCounter(CounterType.TransformFeedbackPrimitivesWritten, resultHandler, false);
>>>>>>> 1ec71635b (sync with main branch)
                    break;
            }

            _channel.MemoryManager.CounterCache.AddOrUpdate(gpuVa, counter);
        }
    }
}
