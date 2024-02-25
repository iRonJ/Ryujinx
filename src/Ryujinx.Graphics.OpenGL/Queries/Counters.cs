using Ryujinx.Graphics.GAL;
using System;

namespace Ryujinx.Graphics.OpenGL.Queries
{
    class Counters : IDisposable
    {
<<<<<<< HEAD
        private readonly CounterQueue[] _counterQueues;
=======
        private CounterQueue[] _counterQueues;
>>>>>>> 1ec71635b (sync with main branch)

        public Counters()
        {
            int count = Enum.GetNames<CounterType>().Length;

            _counterQueues = new CounterQueue[count];
        }

<<<<<<< HEAD
        public void Initialize()
=======
        public void Initialize(Pipeline pipeline)
>>>>>>> 1ec71635b (sync with main branch)
        {
            for (int index = 0; index < _counterQueues.Length; index++)
            {
                CounterType type = (CounterType)index;
<<<<<<< HEAD
                _counterQueues[index] = new CounterQueue(type);
            }
        }

        public CounterQueueEvent QueueReport(CounterType type, EventHandler<ulong> resultHandler, float divisor, ulong lastDrawIndex, bool hostReserved)
        {
            return _counterQueues[(int)type].QueueReport(resultHandler, divisor, lastDrawIndex, hostReserved);
=======
                _counterQueues[index] = new CounterQueue(pipeline, type);
            }
        }

        public CounterQueueEvent QueueReport(CounterType type, EventHandler<ulong> resultHandler, ulong lastDrawIndex, bool hostReserved)
        {
            return _counterQueues[(int)type].QueueReport(resultHandler, lastDrawIndex, hostReserved);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void QueueReset(CounterType type)
        {
            _counterQueues[(int)type].QueueReset();
        }

        public void Update()
        {
            foreach (var queue in _counterQueues)
            {
                queue.Flush(false);
            }
        }

        public void Flush(CounterType type)
        {
            _counterQueues[(int)type].Flush(true);
        }

        public void Dispose()
        {
            foreach (var queue in _counterQueues)
            {
                queue.Dispose();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
