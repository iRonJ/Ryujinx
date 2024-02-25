using Ryujinx.Audio.Renderer.Common;
using System.Runtime.InteropServices;

namespace Ryujinx.Audio.Renderer.Server.Performance
{
    /// <summary>
    /// Implementation of <see cref="IPerformanceDetailEntry"/> for performance metrics version 2.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x18)]
    public struct PerformanceDetailVersion2 : IPerformanceDetailEntry
    {
        /// <summary>
        /// The node id associated to this detailed entry.
        /// </summary>
        public int NodeId;

        /// <summary>
        /// The start time (in microseconds) associated to this detailed entry.
        /// </summary>
        public int StartTime;

        /// <summary>
        /// The processing time (in microseconds) associated to this detailed entry.
        /// </summary>
        public int ProcessingTime;

        /// <summary>
        /// The detailed entry type associated to this detailed entry.
        /// </summary>
        public PerformanceDetailType DetailType;

        /// <summary>
        /// The entry type associated to this detailed entry.
        /// </summary>
        public PerformanceEntryType EntryType;

<<<<<<< HEAD
        public readonly int GetProcessingTime()
=======
        public int GetProcessingTime()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return ProcessingTime;
        }

<<<<<<< HEAD
        public readonly int GetProcessingTimeOffset()
=======
        public int GetProcessingTimeOffset()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 8;
        }

<<<<<<< HEAD
        public readonly int GetStartTime()
=======
        public int GetStartTime()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return StartTime;
        }

<<<<<<< HEAD
        public readonly int GetStartTimeOffset()
=======
        public int GetStartTimeOffset()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 4;
        }

        public void SetDetailType(PerformanceDetailType detailType)
        {
            DetailType = detailType;
        }

        public void SetEntryType(PerformanceEntryType type)
        {
            EntryType = type;
        }

        public void SetNodeId(int nodeId)
        {
            NodeId = nodeId;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
