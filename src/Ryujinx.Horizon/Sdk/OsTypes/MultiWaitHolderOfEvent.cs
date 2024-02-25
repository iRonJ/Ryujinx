using System.Collections.Generic;

namespace Ryujinx.Horizon.Sdk.OsTypes
{
    class MultiWaitHolderOfEvent : MultiWaitHolder
    {
<<<<<<< HEAD
        private readonly Event _event;
=======
        private Event _event;
>>>>>>> 1ec71635b (sync with main branch)
        private LinkedListNode<MultiWaitHolderBase> _node;

        public override TriBool Signaled
        {
            get
            {
                lock (_event.EventLock)
                {
                    return _event.IsSignaledThreadUnsafe();
                }
            }
        }

        public MultiWaitHolderOfEvent(Event evnt)
        {
            _event = evnt;
        }

        public override TriBool LinkToObjectList()
        {
            lock (_event.EventLock)
            {
                _node = _event.MultiWaitHolders.AddLast(this);

                return _event.IsSignaledThreadUnsafe();
            }
        }

        public override void UnlinkFromObjectList()
        {
            lock (_event.EventLock)
            {
                _event.MultiWaitHolders.Remove(_node);
                _node = null;
            }
        }
    }
}
