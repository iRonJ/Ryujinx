using Ryujinx.HLE.HOS.Kernel.Common;
using Ryujinx.HLE.HOS.Kernel.Process;
using Ryujinx.Horizon.Common;
using System.Threading;

namespace Ryujinx.HLE.HOS.Kernel.Ipc
{
    class KClientPort : KSynchronizationObject
    {
        private int _sessionsCount;
        private readonly int _maxSessions;

        private readonly KPort _parent;

        public bool IsLight => _parent.IsLight;

        public KClientPort(KernelContext context, KPort parent, int maxSessions) : base(context)
        {
            _maxSessions = maxSessions;
<<<<<<< HEAD
            _parent = parent;
=======
            _parent      = parent;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public Result Connect(out KClientSession clientSession)
        {
            clientSession = null;

            KProcess currentProcess = KernelStatic.GetCurrentProcess();

            if (currentProcess.ResourceLimit != null &&
               !currentProcess.ResourceLimit.Reserve(LimitableResource.Session, 1))
            {
                return KernelResult.ResLimitExceeded;
            }

            if (!IncrementSessionsCount())
            {
                currentProcess.ResourceLimit?.Release(LimitableResource.Session, 1);

                return KernelResult.SessionCountExceeded;
            }

<<<<<<< HEAD
            KSession session = new(KernelContext, this);
=======
            KSession session = new KSession(KernelContext, this);
>>>>>>> 1ec71635b (sync with main branch)

            Result result = _parent.EnqueueIncomingSession(session.ServerSession);

            if (result != Result.Success)
            {
                session.ClientSession.DecrementReferenceCount();
                session.ServerSession.DecrementReferenceCount();

                return result;
            }

            clientSession = session.ClientSession;

            return result;
        }

        public Result ConnectLight(out KLightClientSession clientSession)
        {
            clientSession = null;

            KProcess currentProcess = KernelStatic.GetCurrentProcess();

            if (currentProcess.ResourceLimit != null &&
               !currentProcess.ResourceLimit.Reserve(LimitableResource.Session, 1))
            {
                return KernelResult.ResLimitExceeded;
            }

            if (!IncrementSessionsCount())
            {
                currentProcess.ResourceLimit?.Release(LimitableResource.Session, 1);

                return KernelResult.SessionCountExceeded;
            }

<<<<<<< HEAD
            KLightSession session = new(KernelContext);
=======
            KLightSession session = new KLightSession(KernelContext);
>>>>>>> 1ec71635b (sync with main branch)

            Result result = _parent.EnqueueIncomingLightSession(session.ServerSession);

            if (result != Result.Success)
            {
                session.ClientSession.DecrementReferenceCount();
                session.ServerSession.DecrementReferenceCount();

                return result;
            }

            clientSession = session.ClientSession;

            return result;
        }

        private bool IncrementSessionsCount()
        {
            while (true)
            {
                int currentCount = _sessionsCount;

                if (currentCount < _maxSessions)
                {
                    if (Interlocked.CompareExchange(ref _sessionsCount, currentCount + 1, currentCount) == currentCount)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public void Disconnect()
        {
            KernelContext.CriticalSection.Enter();

            SignalIfMaximumReached(Interlocked.Decrement(ref _sessionsCount));

            KernelContext.CriticalSection.Leave();
        }

        private void SignalIfMaximumReached(int value)
        {
            if (value == _maxSessions)
            {
                Signal();
            }
        }

        public new static Result RemoveName(KernelContext context, string name)
        {
            KAutoObject foundObj = FindNamedObject(context, name);

<<<<<<< HEAD
            if (foundObj is not KClientPort)
=======
            if (!(foundObj is KClientPort))
>>>>>>> 1ec71635b (sync with main branch)
            {
                return KernelResult.NotFound;
            }

            return KAutoObject.RemoveName(context, name);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
