using Ryujinx.Audio.Renderer.Common;
using System.Runtime.InteropServices;

namespace Ryujinx.Audio.Renderer.Server.Performance
{
    /// <summary>
    /// Implementation of <see cref="IPerformanceEntry"/> for performance metrics version 1.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x10)]
    public struct PerformanceEntryVersion1 : IPerformanceEntry
    {
        /// <summary>
        /// The node id associated to this entry.
        /// </summary>
        public int NodeId;

        /// <summary>
        /// The start time (in microseconds) associated to this entry.
        /// </summary>
        public int StartTime;

        /// <summary>
        /// The processing time (in microseconds) associated to this entry.
        /// </summary>
        public int ProcessingTime;

        /// <summary>
        /// The entry type associated to this entry.
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
