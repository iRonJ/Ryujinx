using System;

namespace Ryujinx.Audio.Renderer.Server.Upsampler
{
    /// <summary>
    /// Server state for a upsampling.
    /// </summary>
    public class UpsamplerState
    {
        /// <summary>
        /// The output buffer containing the target samples.
        /// </summary>
        public Memory<float> OutputBuffer { get; }

        /// <summary>
        /// The target sample count.
        /// </summary>
        public uint SampleCount { get; }

        /// <summary>
        /// The index of the <see cref="UpsamplerState"/>. (used to free it)
        /// </summary>
<<<<<<< HEAD
        private readonly int _index;
=======
        private int _index;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// The <see cref="UpsamplerManager"/>.
        /// </summary>
<<<<<<< HEAD
        private readonly UpsamplerManager _manager;
=======
        private UpsamplerManager _manager;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// The source sample count.
        /// </summary>
        public uint SourceSampleCount;

        /// <summary>
        /// The input buffer indices of the buffers holding the samples that need upsampling.
        /// </summary>
        public ushort[] InputBufferIndices;

        /// <summary>
        /// State of each input buffer index kept across invocations of the upsampler.
        /// </summary>
        public UpsamplerBufferState[] BufferStates;

        /// <summary>
        /// Create a new <see cref="UpsamplerState"/>.
        /// </summary>
        /// <param name="manager">The upsampler manager.</param>
        /// <param name="index">The index of the <see cref="UpsamplerState"/>. (used to free it)</param>
        /// <param name="outputBuffer">The output buffer used to contain the target samples.</param>
        /// <param name="sampleCount">The target sample count.</param>
        public UpsamplerState(UpsamplerManager manager, int index, Memory<float> outputBuffer, uint sampleCount)
        {
            _manager = manager;
            _index = index;
            OutputBuffer = outputBuffer;
            SampleCount = sampleCount;
        }

        /// <summary>
        /// Release the <see cref="UpsamplerState"/>.
        /// </summary>
        public void Release()
        {
            _manager.Free(_index);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
