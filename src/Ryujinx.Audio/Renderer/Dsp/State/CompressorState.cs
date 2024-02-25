<<<<<<< HEAD
using Ryujinx.Audio.Renderer.Dsp.Effect;
=======
﻿using Ryujinx.Audio.Renderer.Dsp.Effect;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Audio.Renderer.Parameter.Effect;

namespace Ryujinx.Audio.Renderer.Dsp.State
{
<<<<<<< HEAD
    public struct CompressorState
=======
    public class CompressorState
>>>>>>> 1ec71635b (sync with main branch)
    {
        public ExponentialMovingAverage InputMovingAverage;
        public float Unknown4;
        public ExponentialMovingAverage CompressionGainAverage;
        public float CompressorGainReduction;
        public float Unknown10;
        public float Unknown14;
        public float PreviousCompressionEmaAlpha;
        public float MakeupGain;
        public float OutputGain;

        public CompressorState(ref CompressorParameter parameter)
        {
            InputMovingAverage = new ExponentialMovingAverage(0.0f);
            Unknown4 = 1.0f;
            CompressionGainAverage = new ExponentialMovingAverage(1.0f);

            UpdateParameter(ref parameter);
        }

        public void UpdateParameter(ref CompressorParameter parameter)
        {
            float threshold = parameter.Threshold;
            float ratio = 1.0f / parameter.Ratio;
            float attackCoefficient = parameter.AttackCoefficient;
            float makeupGain;

            if (parameter.MakeupGainEnabled)
            {
                makeupGain = (threshold * 0.5f * (ratio - 1.0f)) - 3.0f;
            }
            else
            {
                makeupGain = 0.0f;
            }

            PreviousCompressionEmaAlpha = attackCoefficient;
            MakeupGain = makeupGain;
            CompressorGainReduction = (1.0f - ratio) / Constants.ChannelCountMax;
            Unknown10 = threshold - 1.5f;
            Unknown14 = threshold + 1.5f;
<<<<<<< HEAD
            OutputGain = FloatingPointHelper.DecibelToLinear(parameter.OutputGain + makeupGain);
=======
            OutputGain = FloatingPointHelper.DecibelToLinearExtended(parameter.OutputGain + makeupGain);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
