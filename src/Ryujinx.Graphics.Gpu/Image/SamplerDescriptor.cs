using Ryujinx.Graphics.GAL;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Ryujinx.Graphics.Gpu.Image
{
    /// <summary>
    /// Maxwell sampler descriptor structure.
    /// This structure defines the sampler descriptor as it is packed on the GPU sampler pool region.
    /// </summary>
    struct SamplerDescriptor
    {
        private static readonly float[] _f5ToF32ConversionLut = new float[]
        {
            0.0f,
            0.055555556f,
            0.1f,
            0.13636364f,
            0.16666667f,
            0.1923077f,
            0.21428572f,
            0.23333333f,
            0.25f,
            0.2777778f,
            0.3f,
            0.3181818f,
            0.33333334f,
            0.34615386f,
            0.35714287f,
            0.36666667f,
            0.375f,
            0.3888889f,
            0.4f,
            0.4090909f,
            0.41666666f,
            0.42307693f,
            0.42857143f,
            0.43333334f,
            0.4375f,
            0.44444445f,
            0.45f,
            0.45454547f,
            0.45833334f,
            0.46153846f,
            0.4642857f,
<<<<<<< HEAD
            0.46666667f,
=======
            0.46666667f
>>>>>>> 1ec71635b (sync with main branch)
        };

        private static readonly float[] _maxAnisotropyLut = new float[]
        {
<<<<<<< HEAD
            1, 2, 4, 6, 8, 10, 12, 16,
=======
            1, 2, 4, 6, 8, 10, 12, 16
>>>>>>> 1ec71635b (sync with main branch)
        };

        private const float Frac8ToF32 = 1.0f / 256.0f;

<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public uint Word0;
        public uint Word1;
        public uint Word2;
        public uint Word3;
        public float BorderColorR;
        public float BorderColorG;
        public float BorderColorB;
        public float BorderColorA;
#pragma warning restore CS0649

        /// <summary>
        /// Unpacks the texture wrap mode along the X axis.
        /// </summary>
        /// <returns>The texture wrap mode enum</returns>
<<<<<<< HEAD
        public readonly AddressMode UnpackAddressU()
=======
        public AddressMode UnpackAddressU()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (AddressMode)(Word0 & 7);
        }

        // <summary>
        /// Unpacks the texture wrap mode along the Y axis.
        /// </summary>
        /// <returns>The texture wrap mode enum</returns>
<<<<<<< HEAD
        public readonly AddressMode UnpackAddressV()
=======
        public AddressMode UnpackAddressV()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (AddressMode)((Word0 >> 3) & 7);
        }

        // <summary>
        /// Unpacks the texture wrap mode along the Z axis.
        /// </summary>
        /// <returns>The texture wrap mode enum</returns>
<<<<<<< HEAD
        public readonly AddressMode UnpackAddressP()
=======
        public AddressMode UnpackAddressP()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (AddressMode)((Word0 >> 6) & 7);
        }

        /// <summary>
        /// Unpacks the compare mode used for depth comparison on the shader, for
        /// depth buffer texture.
        /// This is only relevant for shaders with shadow samplers.
        /// </summary>
        /// <returns>The depth comparison mode enum</returns>
<<<<<<< HEAD
        public readonly CompareMode UnpackCompareMode()
=======
        public CompareMode UnpackCompareMode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (CompareMode)((Word0 >> 9) & 1);
        }

        /// <summary>
        /// Unpacks the compare operation used for depth comparison on the shader, for
        /// depth buffer texture.
        /// This is only relevant for shaders with shadow samplers.
        /// </summary>
        /// <returns>The depth comparison operation enum</returns>
<<<<<<< HEAD
        public readonly CompareOp UnpackCompareOp()
=======
        public CompareOp UnpackCompareOp()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (CompareOp)(((Word0 >> 10) & 7) + 1);
        }

        /// <summary>
        /// Unpacks and converts the maximum anisotropy value used for texture anisotropic filtering.
        /// </summary>
        /// <returns>The maximum anisotropy</returns>
<<<<<<< HEAD
        public readonly float UnpackMaxAnisotropy()
=======
        public float UnpackMaxAnisotropy()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _maxAnisotropyLut[(Word0 >> 20) & 7];
        }

        /// <summary>
        /// Unpacks the texture magnification filter.
        /// This defines the filtering used when the texture covers an area on the screen
        /// that is larger than the texture size.
        /// </summary>
        /// <returns>The magnification filter</returns>
<<<<<<< HEAD
        public readonly MagFilter UnpackMagFilter()
=======
        public MagFilter UnpackMagFilter()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (MagFilter)(Word1 & 3);
        }

        /// <summary>
        /// Unpacks the texture minification filter.
        /// This defines the filtering used when the texture covers an area on the screen
        /// that is smaller than the texture size.
        /// </summary>
        /// <returns>The minification filter</returns>
<<<<<<< HEAD
        public readonly MinFilter UnpackMinFilter()
=======
        public MinFilter UnpackMinFilter()
>>>>>>> 1ec71635b (sync with main branch)
        {
            SamplerMinFilter minFilter = (SamplerMinFilter)((Word1 >> 4) & 3);
            SamplerMipFilter mipFilter = (SamplerMipFilter)((Word1 >> 6) & 3);

            return ConvertFilter(minFilter, mipFilter);
        }

        /// <summary>
        /// Converts two minification and filter enum, to a single minification enum,
        /// including mipmap filtering information, as expected from the host API.
        /// </summary>
        /// <param name="minFilter">The minification filter</param>
        /// <param name="mipFilter">The mipmap level filter</param>
        /// <returns>The combined, host API compatible filter enum</returns>
        private static MinFilter ConvertFilter(SamplerMinFilter minFilter, SamplerMipFilter mipFilter)
        {
            switch (mipFilter)
            {
                case SamplerMipFilter.None:
                    switch (minFilter)
                    {
<<<<<<< HEAD
                        case SamplerMinFilter.Nearest:
                            return MinFilter.Nearest;
                        case SamplerMinFilter.Linear:
                            return MinFilter.Linear;
=======
                        case SamplerMinFilter.Nearest: return MinFilter.Nearest;
                        case SamplerMinFilter.Linear:  return MinFilter.Linear;
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    break;

                case SamplerMipFilter.Nearest:
                    switch (minFilter)
                    {
<<<<<<< HEAD
                        case SamplerMinFilter.Nearest:
                            return MinFilter.NearestMipmapNearest;
                        case SamplerMinFilter.Linear:
                            return MinFilter.LinearMipmapNearest;
=======
                        case SamplerMinFilter.Nearest: return MinFilter.NearestMipmapNearest;
                        case SamplerMinFilter.Linear:  return MinFilter.LinearMipmapNearest;
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    break;

                case SamplerMipFilter.Linear:
                    switch (minFilter)
                    {
<<<<<<< HEAD
                        case SamplerMinFilter.Nearest:
                            return MinFilter.NearestMipmapLinear;
                        case SamplerMinFilter.Linear:
                            return MinFilter.LinearMipmapLinear;
=======
                        case SamplerMinFilter.Nearest: return MinFilter.NearestMipmapLinear;
                        case SamplerMinFilter.Linear:  return MinFilter.LinearMipmapLinear;
>>>>>>> 1ec71635b (sync with main branch)
                    }
                    break;
            }

            return MinFilter.Nearest;
        }

        /// <summary>
        /// Unpacks the seamless cubemap flag.
        /// </summary>
        /// <returns>The seamless cubemap flag</returns>
<<<<<<< HEAD
        public readonly bool UnpackSeamlessCubemap()
=======
        public bool UnpackSeamlessCubemap()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (Word1 & (1 << 9)) != 0;
        }

        /// <summary>
        /// Unpacks the reduction filter, used with texture minification linear filtering.
        /// This describes how the final value will be computed from neighbouring pixels.
        /// </summary>
        /// <returns>The reduction filter</returns>
<<<<<<< HEAD
        public readonly ReductionFilter UnpackReductionFilter()
=======
        public ReductionFilter UnpackReductionFilter()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (ReductionFilter)((Word1 >> 10) & 3);
        }

        /// <summary>
        /// Unpacks the level-of-detail bias value.
        /// This is a bias added to the level-of-detail value as computed by the GPU, used to select
        /// which mipmap level to use from a given texture.
        /// </summary>
        /// <returns>The level-of-detail bias value</returns>
<<<<<<< HEAD
        public readonly float UnpackMipLodBias()
=======
        public float UnpackMipLodBias()
>>>>>>> 1ec71635b (sync with main branch)
        {
            int fixedValue = (int)(Word1 >> 12) & 0x1fff;

            fixedValue = (fixedValue << 19) >> 19;

            return fixedValue * Frac8ToF32;
        }

        /// <summary>
        /// Unpacks the level-of-detail snap value.
        /// </summary>
        /// <returns>The level-of-detail snap value</returns>
<<<<<<< HEAD
        public readonly float UnpackLodSnap()
=======
        public float UnpackLodSnap()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return _f5ToF32ConversionLut[(Word1 >> 26) & 0x1f];
        }

        /// <summary>
        /// Unpacks the minimum level-of-detail value.
        /// </summary>
        /// <returns>The minimum level-of-detail value</returns>
<<<<<<< HEAD
        public readonly float UnpackMinLod()
=======
        public float UnpackMinLod()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (Word2 & 0xfff) * Frac8ToF32;
        }

        /// <summary>
        /// Unpacks the maximum level-of-detail value.
        /// </summary>
        /// <returns>The maximum level-of-detail value</returns>
<<<<<<< HEAD
        public readonly float UnpackMaxLod()
=======
        public float UnpackMaxLod()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return ((Word2 >> 12) & 0xfff) * Frac8ToF32;
        }

        /// <summary>
        /// Check if two descriptors are equal.
        /// </summary>
        /// <param name="other">The descriptor to compare against</param>
        /// <returns>True if they are equal, false otherwise</returns>
        public bool Equals(ref SamplerDescriptor other)
        {
            return Unsafe.As<SamplerDescriptor, Vector256<byte>>(ref this).Equals(Unsafe.As<SamplerDescriptor, Vector256<byte>>(ref other));
        }
    }
}
