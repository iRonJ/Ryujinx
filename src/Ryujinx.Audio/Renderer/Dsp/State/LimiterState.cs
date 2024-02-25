using Ryujinx.Audio.Renderer.Dsp.Effect;
using Ryujinx.Audio.Renderer.Parameter.Effect;
using System;

namespace Ryujinx.Audio.Renderer.Dsp.State
{
<<<<<<< HEAD
    public struct LimiterState
=======
    public class LimiterState
>>>>>>> 1ec71635b (sync with main branch)
    {
        public ExponentialMovingAverage[] DetectorAverage;
        public ExponentialMovingAverage[] CompressionGainAverage;
        public float[] DelayedSampleBuffer;
        public int[] DelayedSampleBufferPosition;

        public LimiterState(ref LimiterParameter parameter, ulong workBuffer)
        {
            DetectorAverage = new ExponentialMovingAverage[parameter.ChannelCount];
            CompressionGainAverage = new ExponentialMovingAverage[parameter.ChannelCount];
            DelayedSampleBuffer = new float[parameter.ChannelCount * parameter.DelayBufferSampleCountMax];
            DelayedSampleBufferPosition = new int[parameter.ChannelCount];

            DetectorAverage.AsSpan().Fill(new ExponentialMovingAverage(0.0f));
            CompressionGainAverage.AsSpan().Fill(new ExponentialMovingAverage(1.0f));
<<<<<<< HEAD
            DelayedSampleBufferPosition.AsSpan().Clear();
            DelayedSampleBuffer.AsSpan().Clear();
=======
            DelayedSampleBufferPosition.AsSpan().Fill(0);
            DelayedSampleBuffer.AsSpan().Fill(0.0f);
>>>>>>> 1ec71635b (sync with main branch)

            UpdateParameter(ref parameter);
        }

<<<<<<< HEAD
        public static void UpdateParameter(ref LimiterParameter parameter) { }
    }
}
=======
        public void UpdateParameter(ref LimiterParameter parameter) { }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
