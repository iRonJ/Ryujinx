<<<<<<< HEAD
using System.Diagnostics.Tracing;
=======
﻿using System.Diagnostics.Tracing;
>>>>>>> 1ec71635b (sync with main branch)
using System.Threading;

namespace ARMeilleure.Diagnostics
{
    [EventSource(Name = "ARMeilleure")]
    class TranslatorEventSource : EventSource
    {
        public static readonly TranslatorEventSource Log = new();

        private int _rejitQueue;
        private ulong _funcTabSize;
        private ulong _funcTabLeafSize;
        private PollingCounter _rejitQueueCounter;
        private PollingCounter _funcTabSizeCounter;
        private PollingCounter _funcTabLeafSizeCounter;

        public TranslatorEventSource()
        {
            _rejitQueueCounter = new PollingCounter("rejit-queue-length", this, () => _rejitQueue)
            {
<<<<<<< HEAD
                DisplayName = "Rejit Queue Length",
=======
                DisplayName = "Rejit Queue Length"
>>>>>>> 1ec71635b (sync with main branch)
            };

            _funcTabSizeCounter = new PollingCounter("addr-tab-alloc", this, () => _funcTabSize / 1024d / 1024d)
            {
                DisplayName = "AddressTable Total Bytes Allocated",
<<<<<<< HEAD
                DisplayUnits = "MiB",
=======
                DisplayUnits = "MiB"
>>>>>>> 1ec71635b (sync with main branch)
            };

            _funcTabLeafSizeCounter = new PollingCounter("addr-tab-leaf-alloc", this, () => _funcTabLeafSize / 1024d / 1024d)
            {
                DisplayName = "AddressTable Total Leaf Bytes Allocated",
<<<<<<< HEAD
                DisplayUnits = "MiB",
=======
                DisplayUnits = "MiB"
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public void RejitQueueAdd(int count)
        {
            Interlocked.Add(ref _rejitQueue, count);
        }

        public void AddressTableAllocated(int bytes, bool leaf)
        {
            _funcTabSize += (uint)bytes;

            if (leaf)
            {
                _funcTabLeafSize += (uint)bytes;
            }
        }

        protected override void Dispose(bool disposing)
        {
            _rejitQueueCounter.Dispose();
            _rejitQueueCounter = null;

            _funcTabLeafSizeCounter.Dispose();
            _funcTabLeafSizeCounter = null;

            _funcTabSizeCounter.Dispose();
            _funcTabSizeCounter = null;

            base.Dispose(disposing);
        }
    }
}
