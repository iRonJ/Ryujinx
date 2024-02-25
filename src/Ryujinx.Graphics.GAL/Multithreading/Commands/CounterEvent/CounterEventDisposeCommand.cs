<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.CounterEvent
{
    struct CounterEventDisposeCommand : IGALCommand, IGALCommand<CounterEventDisposeCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.CounterEventDispose;
=======
        public CommandType CommandType => CommandType.CounterEventDispose;
>>>>>>> 1ec71635b (sync with main branch)
        private TableRef<ThreadedCounterEvent> _event;

        public void Set(TableRef<ThreadedCounterEvent> evt)
        {
            _event = evt;
        }

        public static void Run(ref CounterEventDisposeCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            command._event.Get(threaded).Base.Dispose();
        }
    }
}
