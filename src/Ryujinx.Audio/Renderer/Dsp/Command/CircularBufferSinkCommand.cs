using Ryujinx.Audio.Renderer.Parameter.Sink;
using Ryujinx.Audio.Renderer.Server.MemoryPool;
using System.Diagnostics;

namespace Ryujinx.Audio.Renderer.Dsp.Command
{
    public class CircularBufferSinkCommand : ICommand
    {
        public bool Enabled { get; set; }

        public int NodeId { get; }

        public CommandType CommandType => CommandType.CircularBufferSink;

        public uint EstimatedProcessingTime { get; set; }

        public ushort[] Input { get; }
        public uint InputCount { get; }

        public ulong CircularBuffer { get; }
        public ulong CircularBufferSize { get; }
        public ulong CurrentOffset { get; }

        public CircularBufferSinkCommand(uint bufferOffset, ref CircularBufferParameter parameter, ref AddressInfo circularBufferAddressInfo, uint currentOffset, int nodeId)
        {
            Enabled = true;
            NodeId = nodeId;

            Input = new ushort[Constants.ChannelCountMax];
            InputCount = parameter.InputCount;

            for (int i = 0; i < InputCount; i++)
            {
                Input[i] = (ushort)(bufferOffset + parameter.Input[i]);
            }

            CircularBuffer = circularBufferAddressInfo.GetReference(true);
            CircularBufferSize = parameter.BufferSize;
            CurrentOffset = currentOffset;

            Debug.Assert(CircularBuffer != 0);
        }

        public void Process(CommandList context)
        {
<<<<<<< HEAD
            const int TargetChannelCount = 2;
=======
            const int targetChannelCount = 2;
>>>>>>> 1ec71635b (sync with main branch)

            ulong currentOffset = CurrentOffset;

            if (CircularBufferSize > 0)
            {
                for (int i = 0; i < InputCount; i++)
                {
                    unsafe
                    {
                        float* inputBuffer = (float*)context.GetBufferPointer(Input[i]);

                        ulong targetOffset = CircularBuffer + currentOffset;

                        for (int y = 0; y < context.SampleCount; y++)
                        {
<<<<<<< HEAD
                            context.MemoryManager.Write(targetOffset + (ulong)y * TargetChannelCount, PcmHelper.Saturate(inputBuffer[y]));
                        }

                        currentOffset += context.SampleCount * TargetChannelCount;
=======
                            context.MemoryManager.Write(targetOffset + (ulong)y * targetChannelCount, PcmHelper.Saturate(inputBuffer[y]));
                        }

                        currentOffset += context.SampleCount * targetChannelCount;
>>>>>>> 1ec71635b (sync with main branch)

                        if (currentOffset >= CircularBufferSize)
                        {
                            currentOffset = 0;
                        }
                    }
                }
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
