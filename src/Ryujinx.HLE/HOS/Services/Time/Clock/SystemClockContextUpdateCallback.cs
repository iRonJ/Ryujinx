<<<<<<< HEAD
using Ryujinx.HLE.HOS.Kernel.Threading;
=======
﻿using Ryujinx.HLE.HOS.Kernel.Threading;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;
using System.Threading;

namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    abstract class SystemClockContextUpdateCallback
    {
<<<<<<< HEAD
        private readonly List<KWritableEvent> _operationEventList;
        protected SystemClockContext Context;
        private bool _hasContext;
=======
        private   List<KWritableEvent> _operationEventList;
        protected SystemClockContext   _context;
        private   bool                 _hasContext;
>>>>>>> 1ec71635b (sync with main branch)

        public SystemClockContextUpdateCallback()
        {
            _operationEventList = new List<KWritableEvent>();
<<<<<<< HEAD
            Context = new SystemClockContext();
            _hasContext = false;
=======
            _context            = new SystemClockContext();
            _hasContext         = false;
>>>>>>> 1ec71635b (sync with main branch)
        }

        private bool NeedUpdate(SystemClockContext context)
        {
            if (_hasContext)
            {
<<<<<<< HEAD
                return Context.Offset != context.Offset || Context.SteadyTimePoint.ClockSourceId != context.SteadyTimePoint.ClockSourceId;
=======
                return _context.Offset != context.Offset || _context.SteadyTimePoint.ClockSourceId != context.SteadyTimePoint.ClockSourceId;
>>>>>>> 1ec71635b (sync with main branch)
            }

            return true;
        }

        public void RegisterOperationEvent(KWritableEvent writableEvent)
        {
            Monitor.Enter(_operationEventList);
            _operationEventList.Add(writableEvent);
            Monitor.Exit(_operationEventList);
        }

        private void BroadcastOperationEvent()
        {
            Monitor.Enter(_operationEventList);

            foreach (KWritableEvent e in _operationEventList)
            {
                e.Signal();
            }

            Monitor.Exit(_operationEventList);
        }

        protected abstract ResultCode Update();

        public ResultCode Update(SystemClockContext context)
        {
            ResultCode result = ResultCode.Success;

            if (NeedUpdate(context))
            {
<<<<<<< HEAD
                Context = context;
=======
                _context    = context;
>>>>>>> 1ec71635b (sync with main branch)
                _hasContext = true;

                result = Update();

                if (result == ResultCode.Success)
                {
                    BroadcastOperationEvent();
                }
            }

            return result;
        }
    }
}
