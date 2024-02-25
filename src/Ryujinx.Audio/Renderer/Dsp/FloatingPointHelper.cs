using System;
<<<<<<< HEAD
=======
using System.Reflection.Metadata;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.CompilerServices;

namespace Ryujinx.Audio.Renderer.Dsp
{
    public static class FloatingPointHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MultiplyRoundDown(float a, float b)
        {
            return RoundDown(a * b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RoundDown(float a)
        {
            return MathF.Round(a, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RoundUp(float a)
        {
            return MathF.Round(a);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MultiplyRoundUp(float a, float b)
        {
            return RoundUp(a * b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow10(float x)
        {
            // NOTE: Nintendo implementation uses Q15 and a LUT for this, we don't.
            // As such, we support the same ranges as Nintendo to avoid unexpected behaviours.
            if (x >= 0.0f)
            {
                return 1.0f;
            }
<<<<<<< HEAD

            if (x <= -5.3f)
=======
            else if (x <= -5.3f)
>>>>>>> 1ec71635b (sync with main branch)
            {
                return 0.0f;
            }

            return MathF.Pow(10, x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(float x)
        {
            // NOTE: Nintendo uses an approximation of log10, we don't.
            // As such, we support the same ranges as Nintendo to avoid unexpected behaviours.
<<<<<<< HEAD
            return MathF.Log10(MathF.Max(x, 1.0e-10f));
=======
            return MathF.Pow(10, MathF.Max(x, 1.0e-10f));
>>>>>>> 1ec71635b (sync with main branch)
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float MeanSquare(ReadOnlySpan<float> inputs)
        {
            float res = 0.0f;

            foreach (float input in inputs)
            {
<<<<<<< HEAD
                float normInput = input * (1f / 32768f);
                res += normInput * normInput;
=======
                res += (input * input);
>>>>>>> 1ec71635b (sync with main branch)
            }

            res /= inputs.Length;

            return res;
        }

        /// <summary>
        /// Map decibel to linear.
        /// </summary>
        /// <param name="db">The decibel value to convert</param>
        /// <returns>Converted linear value/returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DecibelToLinear(float db)
        {
            return MathF.Pow(10.0f, db / 20.0f);
        }

<<<<<<< HEAD
=======
        /// <summary>
        /// Map decibel to linear in [0, 2] range.
        /// </summary>
        /// <param name="db">The decibel value to convert</param>
        /// <returns>Converted linear value in [0, 2] range</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DecibelToLinearExtended(float db)
        {
            float tmp = MathF.Log2(DecibelToLinear(db));

            return MathF.Truncate(tmp) + MathF.Pow(2.0f, tmp - MathF.Truncate(tmp));
        }

>>>>>>> 1ec71635b (sync with main branch)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DegreesToRadians(float degrees)
        {
            return degrees * MathF.PI / 180.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float value)
        {
            return MathF.Cos(DegreesToRadians(value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float value)
        {
            return MathF.Sin(DegreesToRadians(value));
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
