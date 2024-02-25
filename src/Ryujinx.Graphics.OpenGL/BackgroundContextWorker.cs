using Ryujinx.Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Ryujinx.Graphics.OpenGL
{
    unsafe class BackgroundContextWorker : IDisposable
    {
        [ThreadStatic]
        public static bool InBackground;
<<<<<<< HEAD
        private readonly Thread _thread;
        private bool _running;

        private readonly AutoResetEvent _signal;
        private readonly Queue<Action> _work;
        private readonly ObjectPool<ManualResetEventSlim> _invokePool;
=======
        private Thread _thread;
        private bool _running;

        private AutoResetEvent _signal;
        private Queue<Action> _work;
        private ObjectPool<ManualResetEventSlim> _invokePool;
>>>>>>> 1ec71635b (sync with main branch)
        private readonly IOpenGLContext _backgroundContext;

        public BackgroundContextWorker(IOpenGLContext backgroundContext)
        {
            _backgroundContext = backgroundContext;
            _running = true;

            _signal = new AutoResetEvent(false);
            _work = new Queue<Action>();
            _invokePool = new ObjectPool<ManualResetEventSlim>(() => new ManualResetEventSlim(), 10);

            _thread = new Thread(Run);
            _thread.Start();
        }

<<<<<<< HEAD
        public bool HasContext() => _backgroundContext.HasContext();

=======
>>>>>>> 1ec71635b (sync with main branch)
        private void Run()
        {
            InBackground = true;

            _backgroundContext.MakeCurrent();

            while (_running)
            {
                Action action;

                lock (_work)
                {
                    _work.TryDequeue(out action);
                }

                if (action != null)
                {
                    action();
                }
                else
                {
                    _signal.WaitOne();
                }
            }

            _backgroundContext.Dispose();
        }

        public void Invoke(Action action)
        {
            ManualResetEventSlim actionComplete = _invokePool.Allocate();

            lock (_work)
            {
                _work.Enqueue(() =>
                {
                    action();
                    actionComplete.Set();
                });
            }

            _signal.Set();

            actionComplete.Wait();
            actionComplete.Reset();

            _invokePool.Release(actionComplete);
        }

        public void Dispose()
        {
            _running = false;
            _signal.Set();

            _thread.Join();
            _signal.Dispose();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
