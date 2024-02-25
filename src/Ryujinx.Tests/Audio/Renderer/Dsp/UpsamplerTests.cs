<<<<<<< HEAD
using NUnit.Framework;
using Ryujinx.Audio.Renderer.Dsp;
using Ryujinx.Audio.Renderer.Server.Upsampler;
using System;
=======
﻿using NUnit.Framework;
using Ryujinx.Audio.Renderer.Dsp;
using Ryujinx.Audio.Renderer.Parameter;
using Ryujinx.Audio.Renderer.Server.Upsampler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Tests.Audio.Renderer.Dsp
{
    class UpsamplerTests
    {
        [Test]
        public void TestUpsamplerConsistency()
        {
<<<<<<< HEAD
            UpsamplerBufferState bufferState = new();
=======
            UpsamplerBufferState bufferState = new UpsamplerBufferState();
>>>>>>> 1ec71635b (sync with main branch)
            int inputBlockSize = 160;
            int numInputSamples = 32000;
            int numOutputSamples = 48000;
            float inputSampleRate = numInputSamples;
            float outputSampleRate = numOutputSamples;
            float[] inputBuffer = new float[numInputSamples + 100];
            float[] outputBuffer = new float[numOutputSamples + 100];
            for (int sample = 0; sample < inputBuffer.Length; sample++)
            {
                // 440 hz sine wave with amplitude = 0.5f at input sample rate
<<<<<<< HEAD
                inputBuffer[sample] = MathF.Sin((440 / inputSampleRate) * sample * MathF.PI * 2f) * 0.5f;
=======
                inputBuffer[sample] = MathF.Sin((440 / inputSampleRate) * (float)sample * MathF.PI * 2f) * 0.5f;
>>>>>>> 1ec71635b (sync with main branch)
            }

            int inputIdx = 0;
            int outputIdx = 0;
            while (inputIdx + inputBlockSize < numInputSamples)
            {
<<<<<<< HEAD
                int outputBufLength = (int)Math.Round((inputIdx + inputBlockSize) * outputSampleRate / inputSampleRate) - outputIdx;
=======
                int outputBufLength = (int)Math.Round((float)(inputIdx + inputBlockSize) * outputSampleRate / inputSampleRate) - outputIdx;
>>>>>>> 1ec71635b (sync with main branch)
                UpsamplerHelper.Upsample(
                    outputBuffer.AsSpan(outputIdx),
                    inputBuffer.AsSpan(inputIdx),
                    outputBufLength,
                    inputBlockSize,
                    ref bufferState);

                inputIdx += inputBlockSize;
                outputIdx += outputBufLength;
            }

            float[] expectedOutput = new float[numOutputSamples];
            float sumDifference = 0;
            for (int sample = 0; sample < numOutputSamples; sample++)
            {
                // 440 hz sine wave with amplitude = 0.5f at output sample rate with an offset of 15
<<<<<<< HEAD
                expectedOutput[sample] = MathF.Sin((440 / outputSampleRate) * (sample - 15) * MathF.PI * 2f) * 0.5f;
                sumDifference += Math.Abs(expectedOutput[sample] - outputBuffer[sample]);
            }

            sumDifference /= expectedOutput.Length;
=======
                expectedOutput[sample] = MathF.Sin((440 / outputSampleRate) * (float)(sample - 15) * MathF.PI * 2f) * 0.5f;
                sumDifference += Math.Abs(expectedOutput[sample] - outputBuffer[sample]);
            }

            sumDifference = sumDifference / (float)expectedOutput.Length;
>>>>>>> 1ec71635b (sync with main branch)
            // Expect the output to be 98% similar to the expected resampled sine wave
            Assert.IsTrue(sumDifference < 0.02f);
        }
    }
}
