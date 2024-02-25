<<<<<<< HEAD
using System.Runtime.InteropServices;
using System.Threading;
=======
﻿using System.Runtime.InteropServices;
using System.Threading;

>>>>>>> 1ec71635b (sync with main branch)
using static Ryujinx.Common.Memory.PartialUnmaps.PartialUnmapHelpers;

namespace Ryujinx.Common.Memory.PartialUnmaps
{
    /// <summary>
    /// A simple implementation of a ReaderWriterLock which can be used from native code.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct NativeReaderWriterLock
    {
        public int WriteLock;
        public int ReaderCount;

<<<<<<< HEAD
        public static readonly int WriteLockOffset;
        public static readonly int ReaderCountOffset;
=======
        public static int WriteLockOffset;
        public static int ReaderCountOffset;
>>>>>>> 1ec71635b (sync with main branch)

        /// <summary>
        /// Populates the field offsets for use when emitting native code.
        /// </summary>
        static NativeReaderWriterLock()
        {
<<<<<<< HEAD
            NativeReaderWriterLock instance = new();
=======
            NativeReaderWriterLock instance = new NativeReaderWriterLock();
>>>>>>> 1ec71635b (sync with main branch)

            WriteLockOffset = OffsetOf(ref instance, ref instance.WriteLock);
            ReaderCountOffset = OffsetOf(ref instance, ref instance.ReaderCount);
        }

        /// <summary>
        /// Acquires the reader lock.
        /// </summary>
        public void AcquireReaderLock()
        {
            // Must take write lock for a very short time to become a reader.

<<<<<<< HEAD
            while (Interlocked.CompareExchange(ref WriteLock, 1, 0) != 0)
            {
            }
=======
            while (Interlocked.CompareExchange(ref WriteLock, 1, 0) != 0) { }
>>>>>>> 1ec71635b (sync with main branch)

            Interlocked.Increment(ref ReaderCount);

            Interlocked.Exchange(ref WriteLock, 0);
        }

        /// <summary>
        /// Releases the reader lock.
        /// </summary>
        public void ReleaseReaderLock()
        {
            Interlocked.Decrement(ref ReaderCount);
        }

        /// <summary>
        /// Upgrades to a writer lock. The reader lock is temporarily released while obtaining the writer lock.
        /// </summary>
        public void UpgradeToWriterLock()
        {
            // Prevent any more threads from entering reader.
            // If the write lock is already taken, wait for it to not be taken.

            Interlocked.Decrement(ref ReaderCount);

<<<<<<< HEAD
            while (Interlocked.CompareExchange(ref WriteLock, 1, 0) != 0)
            {
            }

            // Wait for reader count to drop to 0, then take the lock again as the only reader.

            while (Interlocked.CompareExchange(ref ReaderCount, 1, 0) != 0)
            {
            }
=======
            while (Interlocked.CompareExchange(ref WriteLock, 1, 0) != 0) { }

            // Wait for reader count to drop to 0, then take the lock again as the only reader.

            while (Interlocked.CompareExchange(ref ReaderCount, 1, 0) != 0) { }
>>>>>>> 1ec71635b (sync with main branch)
        }

        /// <summary>
        /// Downgrades from a writer lock, back to a reader one.
        /// </summary>
        public void DowngradeFromWriterLock()
        {
            // Release the WriteLock.

            Interlocked.Exchange(ref WriteLock, 0);
        }
    }
}
