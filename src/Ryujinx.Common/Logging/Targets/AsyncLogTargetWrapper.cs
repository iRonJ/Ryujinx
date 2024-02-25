<<<<<<< HEAD
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Ryujinx.Common.Logging.Targets
=======
﻿using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Ryujinx.Common.Logging
>>>>>>> 1ec71635b (sync with main branch)
{
    public enum AsyncLogTargetOverflowAction
    {
        /// <summary>
        /// Block until there's more room in the queue
        /// </summary>
        Block = 0,

        /// <summary>
        /// Discard the overflowing item
        /// </summary>
<<<<<<< HEAD
        Discard = 1,
=======
        Discard = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    public class AsyncLogTargetWrapper : ILogTarget
    {
<<<<<<< HEAD
        private readonly ILogTarget _target;

        private readonly Thread _messageThread;

        private readonly BlockingCollection<LogEventArgs> _messageQueue;
=======
        private ILogTarget _target;

        private Thread _messageThread;

        private BlockingCollection<LogEventArgs> _messageQueue;
>>>>>>> 1ec71635b (sync with main branch)

        private readonly int _overflowTimeout;

        string ILogTarget.Name { get => _target.Name; }

        public AsyncLogTargetWrapper(ILogTarget target)
            : this(target, -1, AsyncLogTargetOverflowAction.Block)
        { }

        public AsyncLogTargetWrapper(ILogTarget target, int queueLimit, AsyncLogTargetOverflowAction overflowAction)
        {
<<<<<<< HEAD
            _target = target;
            _messageQueue = new BlockingCollection<LogEventArgs>(queueLimit);
            _overflowTimeout = overflowAction == AsyncLogTargetOverflowAction.Block ? -1 : 0;

            _messageThread = new Thread(() =>
            {
=======
            _target          = target;
            _messageQueue    = new BlockingCollection<LogEventArgs>(queueLimit);
            _overflowTimeout = overflowAction == AsyncLogTargetOverflowAction.Block ? -1 : 0;

            _messageThread = new Thread(() => {
>>>>>>> 1ec71635b (sync with main branch)
                while (!_messageQueue.IsCompleted)
                {
                    try
                    {
                        _target.Log(this, _messageQueue.Take());
                    }
                    catch (InvalidOperationException)
                    {
                        // IOE means that Take() was called on a completed collection.
                        // Some other thread can call CompleteAdding after we pass the
                        // IsCompleted check but before we call Take.
                        // We can simply catch the exception since the loop will break
                        // on the next iteration.
                    }
                }
<<<<<<< HEAD
            })
            {
                Name = "Logger.MessageThread",
                IsBackground = true,
            };
=======
            });

            _messageThread.Name         = "Logger.MessageThread";
            _messageThread.IsBackground = true;
>>>>>>> 1ec71635b (sync with main branch)
            _messageThread.Start();
        }

        public void Log(object sender, LogEventArgs e)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                _messageQueue.TryAdd(e, _overflowTimeout);
            }
        }

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            _messageQueue.CompleteAdding();
            _messageThread.Join();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
