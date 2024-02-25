<<<<<<< HEAD
using Ryujinx.Graphics.GAL.Multithreading.Model;
=======
﻿using Ryujinx.Graphics.GAL.Multithreading.Model;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Graphics.GAL.Multithreading.Resources;
using System;

namespace Ryujinx.Graphics.GAL.Multithreading.Commands.Renderer
{
    struct ReportCounterCommand : IGALCommand, IGALCommand<ReportCounterCommand>
    {
<<<<<<< HEAD
        public readonly CommandType CommandType => CommandType.ReportCounter;
        private TableRef<ThreadedCounterEvent> _event;
        private CounterType _type;
        private TableRef<EventHandler<ulong>> _resultHandler;
        private float _divisor;
        private bool _hostReserved;

        public void Set(TableRef<ThreadedCounterEvent> evt, CounterType type, TableRef<EventHandler<ulong>> resultHandler, float divisor, bool hostReserved)
=======
        public CommandType CommandType => CommandType.ReportCounter;
        private TableRef<ThreadedCounterEvent> _event;
        private CounterType _type;
        private TableRef<EventHandler<ulong>> _resultHandler;
        private bool _hostReserved;

        public void Set(TableRef<ThreadedCounterEvent> evt, CounterType type, TableRef<EventHandler<ulong>> resultHandler, bool hostReserved)
>>>>>>> 1ec71635b (sync with main branch)
        {
            _event = evt;
            _type = type;
            _resultHandler = resultHandler;
<<<<<<< HEAD
            _divisor = divisor;
=======
>>>>>>> 1ec71635b (sync with main branch)
            _hostReserved = hostReserved;
        }

        public static void Run(ref ReportCounterCommand command, ThreadedRenderer threaded, IRenderer renderer)
        {
            ThreadedCounterEvent evt = command._event.Get(threaded);

<<<<<<< HEAD
            evt.Create(renderer, command._type, command._resultHandler.Get(threaded), command._divisor, command._hostReserved);
=======
            evt.Create(renderer, command._type, command._resultHandler.Get(threaded), command._hostReserved);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
