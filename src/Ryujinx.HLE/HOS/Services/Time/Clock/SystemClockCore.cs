<<<<<<< HEAD
using Ryujinx.Cpu;
=======
﻿using Ryujinx.Cpu;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Kernel.Threading;

namespace Ryujinx.HLE.HOS.Services.Time.Clock
{
    abstract class SystemClockCore
    {
<<<<<<< HEAD
        private readonly SteadyClockCore _steadyClockCore;
        private SystemClockContext _context;
        private bool _isInitialized;
=======
        private SteadyClockCore                  _steadyClockCore;
        private SystemClockContext               _context;
        private bool                             _isInitialized;
>>>>>>> 1ec71635b (sync with main branch)
        private SystemClockContextUpdateCallback _systemClockContextUpdateCallback;

        public SystemClockCore(SteadyClockCore steadyClockCore)
        {
            _steadyClockCore = steadyClockCore;
<<<<<<< HEAD
            _context = new SystemClockContext();
            _isInitialized = false;

            _context.SteadyTimePoint.ClockSourceId = steadyClockCore.GetClockSourceId();
            _systemClockContextUpdateCallback = null;
=======
            _context         = new SystemClockContext();
            _isInitialized   = false;

            _context.SteadyTimePoint.ClockSourceId = steadyClockCore.GetClockSourceId();
            _systemClockContextUpdateCallback      = null;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public virtual SteadyClockCore GetSteadyClockCore()
        {
            return _steadyClockCore;
        }

        public ResultCode GetCurrentTime(ITickSource tickSource, out long posixTime)
        {
            posixTime = 0;

            SteadyClockTimePoint currentTimePoint = _steadyClockCore.GetCurrentTimePoint(tickSource);

            ResultCode result = GetClockContext(tickSource, out SystemClockContext clockContext);

            if (result == ResultCode.Success)
            {
                result = ResultCode.TimeMismatch;

                if (currentTimePoint.ClockSourceId == clockContext.SteadyTimePoint.ClockSourceId)
                {
                    posixTime = clockContext.Offset + currentTimePoint.TimePoint;

                    result = 0;
                }
            }

            return result;
        }

        public ResultCode SetCurrentTime(ITickSource tickSource, long posixTime)
        {
            SteadyClockTimePoint currentTimePoint = _steadyClockCore.GetCurrentTimePoint(tickSource);

<<<<<<< HEAD
            SystemClockContext clockContext = new()
            {
                Offset = posixTime - currentTimePoint.TimePoint,
                SteadyTimePoint = currentTimePoint,
=======
            SystemClockContext clockContext = new SystemClockContext()
            {
                Offset          = posixTime - currentTimePoint.TimePoint,
                SteadyTimePoint = currentTimePoint
>>>>>>> 1ec71635b (sync with main branch)
            };

            ResultCode result = SetClockContext(clockContext);

            if (result == ResultCode.Success)
            {
                result = Flush(clockContext);
            }

            return result;
        }

        public virtual ResultCode GetClockContext(ITickSource tickSource, out SystemClockContext context)
        {
            context = _context;

            return ResultCode.Success;
        }

        public virtual ResultCode SetClockContext(SystemClockContext context)
        {
            _context = context;

            return ResultCode.Success;
        }

        protected virtual ResultCode Flush(SystemClockContext context)
        {
            if (_systemClockContextUpdateCallback == null)
            {
                return ResultCode.Success;
            }

            return _systemClockContextUpdateCallback.Update(context);
        }

        public void SetUpdateCallbackInstance(SystemClockContextUpdateCallback systemClockContextUpdateCallback)
        {
            _systemClockContextUpdateCallback = systemClockContextUpdateCallback;
        }

        public void RegisterOperationEvent(KWritableEvent writableEvent)
        {
<<<<<<< HEAD
            _systemClockContextUpdateCallback?.RegisterOperationEvent(writableEvent);
=======
            if (_systemClockContextUpdateCallback != null)
            {
                _systemClockContextUpdateCallback.RegisterOperationEvent(writableEvent);
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public ResultCode SetSystemClockContext(SystemClockContext context)
        {
            ResultCode result = SetClockContext(context);

            if (result == ResultCode.Success)
            {
                result = Flush(context);
            }

            return result;
        }

        public bool IsInitialized()
        {
            return _isInitialized;
        }

        public void MarkInitialized()
        {
            _isInitialized = true;
        }

        public bool IsClockSetup(ITickSource tickSource)
        {
            ResultCode result = GetClockContext(tickSource, out SystemClockContext context);

            if (result == ResultCode.Success)
            {
                SteadyClockTimePoint steadyClockTimePoint = _steadyClockCore.GetCurrentTimePoint(tickSource);

                return steadyClockTimePoint.ClockSourceId == context.SteadyTimePoint.ClockSourceId;
            }

            return false;
        }
    }
}
