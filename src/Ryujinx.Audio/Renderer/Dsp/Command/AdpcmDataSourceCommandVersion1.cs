using Ryujinx.Audio.Common;
using Ryujinx.Audio.Renderer.Common;
<<<<<<< HEAD
using Ryujinx.Audio.Renderer.Server.Voice;
using System;
using static Ryujinx.Audio.Renderer.Parameter.VoiceInParameter;
using WaveBuffer = Ryujinx.Audio.Renderer.Common.WaveBuffer;
=======
using System;
using static Ryujinx.Audio.Renderer.Parameter.VoiceInParameter;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Audio.Renderer.Dsp.Command
{
    public class AdpcmDataSourceCommandVersion1 : ICommand
    {
        public bool Enabled { get; set; }

        public int NodeId { get; }

        public CommandType CommandType => CommandType.AdpcmDataSourceVersion1;

        public uint EstimatedProcessingTime { get; set; }

        public ushort OutputBufferIndex { get; }
        public uint SampleRate { get; }

        public float Pitch { get; }

        public WaveBuffer[] WaveBuffers { get; }

        public Memory<VoiceUpdateState> State { get; }

        public ulong AdpcmParameter { get; }
        public ulong AdpcmParameterSize { get; }

        public DecodingBehaviour DecodingBehaviour { get; }

<<<<<<< HEAD
        public AdpcmDataSourceCommandVersion1(ref VoiceState serverState, Memory<VoiceUpdateState> state, ushort outputBufferIndex, int nodeId)
=======
        public AdpcmDataSourceCommandVersion1(ref Server.Voice.VoiceState serverState, Memory<VoiceUpdateState> state, ushort outputBufferIndex, int nodeId)
>>>>>>> 1ec71635b (sync with main branch)
        {
            Enabled = true;
            NodeId = nodeId;

            OutputBufferIndex = outputBufferIndex;
            SampleRate = serverState.SampleRate;
            Pitch = serverState.Pitch;

            WaveBuffers = new WaveBuffer[Constants.VoiceWaveBufferCount];

            for (int i = 0; i < WaveBuffers.Length; i++)
            {
                ref Server.Voice.WaveBuffer voiceWaveBuffer = ref serverState.WaveBuffers[i];

                WaveBuffers[i] = voiceWaveBuffer.ToCommon(1);
            }

            AdpcmParameter = serverState.DataSourceStateAddressInfo.GetReference(true);
            AdpcmParameterSize = serverState.DataSourceStateAddressInfo.Size;
            State = state;
            DecodingBehaviour = serverState.DecodingBehaviour;
        }

        public void Process(CommandList context)
        {
            Span<float> outputBuffer = context.GetBuffer(OutputBufferIndex);

<<<<<<< HEAD
            DataSourceHelper.WaveBufferInformation info = new()
=======
            DataSourceHelper.WaveBufferInformation info = new DataSourceHelper.WaveBufferInformation
>>>>>>> 1ec71635b (sync with main branch)
            {
                SourceSampleRate = SampleRate,
                SampleFormat = SampleFormat.Adpcm,
                Pitch = Pitch,
                DecodingBehaviour = DecodingBehaviour,
                ExtraParameter = AdpcmParameter,
                ExtraParameterSize = AdpcmParameterSize,
                ChannelIndex = 0,
                ChannelCount = 1,
            };

            DataSourceHelper.ProcessWaveBuffers(context.MemoryManager, outputBuffer, ref info, WaveBuffers, ref State.Span[0], context.SampleRate, (int)context.SampleCount);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
