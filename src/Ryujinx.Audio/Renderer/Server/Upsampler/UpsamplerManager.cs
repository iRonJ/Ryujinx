using System;
using System.Diagnostics;

namespace Ryujinx.Audio.Renderer.Server.Upsampler
{
    /// <summary>
    /// Upsampler manager.
    /// </summary>
    public class UpsamplerManager
    {
        /// <summary>
        /// Work buffer for upsampler.
        /// </summary>
<<<<<<< HEAD
        private readonly Memory<float> _upSamplerWorkBuffer;
=======
        private Memory<float> _upSamplerWorkBuffer;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Global lock of the object.
        /// </summary>
<<<<<<< HEAD
        private readonly object _lock = new();
=======
        private object Lock = new object();
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// The upsamplers instances.
        /// </summary>
<<<<<<< HEAD
        private readonly UpsamplerState[] _upsamplers;
=======
        private UpsamplerState[] _upsamplers;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// The count of upsamplers.
        /// </summary>
<<<<<<< HEAD
        private readonly uint _count;
=======
        private uint _count;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Create a new <see cref="UpsamplerManager"/>.
        /// </summary>
        /// <param name="upSamplerWorkBuffer">Work buffer for upsampler.</param>
        /// <param name="count">The count of upsamplers.</param>
        public UpsamplerManager(Memory<float> upSamplerWorkBuffer, uint count)
        {
            _upSamplerWorkBuffer = upSamplerWorkBuffer;
            _count = count;

            _upsamplers = new UpsamplerState[_count];
        }

        /// <summary>
        /// Allocate a new <see cref="UpsamplerState"/>.
        /// </summary>
        /// <returns>A new <see cref="UpsamplerState"/> or null if out of memory.</returns>
        public UpsamplerState Allocate()
        {
            int workBufferOffset = 0;

<<<<<<< HEAD
            lock (_lock)
=======
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_upsamplers[i] == null)
                    {
                        _upsamplers[i] = new UpsamplerState(this, i, _upSamplerWorkBuffer.Slice(workBufferOffset, Constants.UpSampleEntrySize), Constants.TargetSampleCount);

                        return _upsamplers[i];
                    }

                    workBufferOffset += Constants.UpSampleEntrySize;
                }
            }

            return null;
        }

        /// <summary>
        /// Free a <see cref="UpsamplerState"/> at the given index.
        /// </summary>
        /// <param name="index">The index of the <see cref="UpsamplerState"/> to free.</param>
        public void Free(int index)
        {
<<<<<<< HEAD
            lock (_lock)
=======
            lock (Lock)
>>>>>>> 1ec71635b (sync with main branch)
            {
                Debug.Assert(_upsamplers[index] != null);

                _upsamplers[index] = null;
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
