using Ryujinx.Audio.Renderer.Server.Performance;

namespace Ryujinx.Audio.Renderer.Dsp.Command
{
    public class PerformanceCommand : ICommand
    {
        public enum Type
        {
            Invalid,
            Start,
<<<<<<< HEAD
            End,
=======
            End
>>>>>>> 1ec71635b (sync with main branch)
        }

        public bool Enabled { get; set; }

        public int NodeId { get; }

        public CommandType CommandType => CommandType.Performance;

        public uint EstimatedProcessingTime { get; set; }

        public PerformanceEntryAddresses PerformanceEntryAddresses { get; }

        public Type PerformanceType { get; set; }

        public PerformanceCommand(ref PerformanceEntryAddresses performanceEntryAddresses, Type performanceType, int nodeId)
        {
            Enabled = true;
            PerformanceEntryAddresses = performanceEntryAddresses;
            PerformanceType = performanceType;
            NodeId = nodeId;
        }

        public void Process(CommandList context)
        {
            if (PerformanceType == Type.Start)
            {
                PerformanceEntryAddresses.SetStartTime(context.GetTimeElapsedSinceDspStartedProcessing());
            }
            else if (PerformanceType == Type.End)
            {
                PerformanceEntryAddresses.SetProcessingTime(context.GetTimeElapsedSinceDspStartedProcessing());
                PerformanceEntryAddresses.IncrementEntryCount();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
