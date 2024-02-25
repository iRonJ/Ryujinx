using System.Runtime.InteropServices;

namespace Ryujinx.Audio.Renderer.Server.Performance
{
    /// <summary>
    /// Implementation of <see cref="IPerformanceHeader"/> for performance metrics version 1.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x18)]
    public struct PerformanceFrameHeaderVersion1 : IPerformanceHeader
    {
        /// <summary>
        /// The magic of the performance header.
        /// </summary>
        public uint Magic;

        /// <summary>
        /// The total count of entries in this frame.
        /// </summary>
        public int EntryCount;

        /// <summary>
        /// The total count of detailed entries in this frame.
        /// </summary>
        public int EntryDetailCount;

        /// <summary>
        /// The offset of the next performance header.
        /// </summary>
        public int NextOffset;

        /// <summary>
        /// The total time taken by all the commands profiled.
        /// </summary>
        public int TotalProcessingTime;

        /// <summary>
        /// The count of voices that were dropped.
        /// </summary>
        public uint VoiceDropCount;

<<<<<<< HEAD
        public readonly int GetEntryCount()
=======
        public int GetEntryCount()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return EntryCount;
        }

<<<<<<< HEAD
        public readonly int GetEntryCountOffset()
=======
        public int GetEntryCountOffset()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return 4;
        }

<<<<<<< HEAD
        public readonly int GetEntryDetailCount()
=======
        public int GetEntryDetailCount()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return EntryDetailCount;
        }

<<<<<<< HEAD
        public readonly void SetDspRunningBehind(bool isRunningBehind)
=======
        public void SetDspRunningBehind(bool isRunningBehind)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // NOTE: Not present in version 1
        }

        public void SetEntryCount(int entryCount)
        {
            EntryCount = entryCount;
        }

        public void SetEntryDetailCount(int entryDetailCount)
        {
            EntryDetailCount = entryDetailCount;
        }

<<<<<<< HEAD
        public readonly void SetIndex(uint index)
=======
        public void SetIndex(uint index)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // NOTE: Not present in version 1
        }

        public void SetMagic(uint magic)
        {
            Magic = magic;
        }

        public void SetNextOffset(int nextOffset)
        {
            NextOffset = nextOffset;
        }

<<<<<<< HEAD
        public readonly void SetStartRenderingTicks(ulong startTicks)
=======
        public void SetStartRenderingTicks(ulong startTicks)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // NOTE: not present in version 1
        }

        public void SetTotalProcessingTime(int totalProcessingTime)
        {
            TotalProcessingTime = totalProcessingTime;
        }

        public void SetVoiceDropCount(uint voiceCount)
        {
            VoiceDropCount = voiceCount;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
