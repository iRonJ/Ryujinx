<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Threading;

namespace Ryujinx.Common
{
    public class ReactiveObject<T>
    {
<<<<<<< HEAD
        private readonly ReaderWriterLockSlim _readerWriterLock = new();
        private bool _isInitialized;
=======
        private ReaderWriterLock _readerWriterLock = new ReaderWriterLock();
        private bool _isInitialized = false;
>>>>>>> 1ec71635b (sync with main branch)
        private T _value;

        public event EventHandler<ReactiveEventArgs<T>> Event;

        public T Value
        {
            get
            {
<<<<<<< HEAD
                _readerWriterLock.EnterReadLock();
                T value = _value;
                _readerWriterLock.ExitReadLock();
=======
                _readerWriterLock.AcquireReaderLock(Timeout.Infinite);
                T value = _value;
                _readerWriterLock.ReleaseReaderLock();
>>>>>>> 1ec71635b (sync with main branch)

                return value;
            }
            set
            {
<<<<<<< HEAD
                _readerWriterLock.EnterWriteLock();
=======
                _readerWriterLock.AcquireWriterLock(Timeout.Infinite);
>>>>>>> 1ec71635b (sync with main branch)

                T oldValue = _value;

                bool oldIsInitialized = _isInitialized;

                _isInitialized = true;
<<<<<<< HEAD
                _value = value;

                _readerWriterLock.ExitWriteLock();
=======
                _value         = value;

                _readerWriterLock.ReleaseWriterLock();
>>>>>>> 1ec71635b (sync with main branch)

                if (!oldIsInitialized || oldValue == null || !oldValue.Equals(_value))
                {
                    Event?.Invoke(this, new ReactiveEventArgs<T>(oldValue, value));
                }
            }
        }

        public static implicit operator T(ReactiveObject<T> obj)
        {
            return obj.Value;
        }
    }

    public class ReactiveEventArgs<T>
    {
        public T OldValue { get; }
        public T NewValue { get; }

        public ReactiveEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
