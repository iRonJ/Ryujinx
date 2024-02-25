using System;
using System.Collections.Generic;
using System.Threading;

namespace ARMeilleure.Translation
{
    internal class TranslatorCache<T>
    {
        private readonly IntervalTree<ulong, T> _tree;
<<<<<<< HEAD
        private readonly ReaderWriterLockSlim _treeLock;
=======
        private readonly ReaderWriterLock _treeLock;
>>>>>>> 1ec71635b (sync with main branch)

        public int Count => _tree.Count;

        public TranslatorCache()
        {
            _tree = new IntervalTree<ulong, T>();
<<<<<<< HEAD
            _treeLock = new ReaderWriterLockSlim();
=======
            _treeLock = new ReaderWriterLock();
>>>>>>> 1ec71635b (sync with main branch)
        }

        public bool TryAdd(ulong address, ulong size, T value)
        {
            return AddOrUpdate(address, size, value, null);
        }

        public bool AddOrUpdate(ulong address, ulong size, T value, Func<ulong, T, T> updateFactoryCallback)
        {
<<<<<<< HEAD
            _treeLock.EnterWriteLock();
            bool result = _tree.AddOrUpdate(address, address + size, value, updateFactoryCallback);
            _treeLock.ExitWriteLock();
=======
            _treeLock.AcquireWriterLock(Timeout.Infinite);
            bool result = _tree.AddOrUpdate(address, address + size, value, updateFactoryCallback);
            _treeLock.ReleaseWriterLock();
>>>>>>> 1ec71635b (sync with main branch)

            return result;
        }

        public T GetOrAdd(ulong address, ulong size, T value)
        {
<<<<<<< HEAD
            _treeLock.EnterWriteLock();
            value = _tree.GetOrAdd(address, address + size, value);
            _treeLock.ExitWriteLock();
=======
            _treeLock.AcquireWriterLock(Timeout.Infinite);
            value = _tree.GetOrAdd(address, address + size, value);
            _treeLock.ReleaseWriterLock();
>>>>>>> 1ec71635b (sync with main branch)

            return value;
        }

        public bool Remove(ulong address)
        {
<<<<<<< HEAD
            _treeLock.EnterWriteLock();
            bool removed = _tree.Remove(address) != 0;
            _treeLock.ExitWriteLock();
=======
            _treeLock.AcquireWriterLock(Timeout.Infinite);
            bool removed = _tree.Remove(address) != 0;
            _treeLock.ReleaseWriterLock();
>>>>>>> 1ec71635b (sync with main branch)

            return removed;
        }

        public void Clear()
        {
<<<<<<< HEAD
            _treeLock.EnterWriteLock();
            _tree.Clear();
            _treeLock.ExitWriteLock();
=======
            _treeLock.AcquireWriterLock(Timeout.Infinite);
            _tree.Clear();
            _treeLock.ReleaseWriterLock();
>>>>>>> 1ec71635b (sync with main branch)
        }

        public bool ContainsKey(ulong address)
        {
<<<<<<< HEAD
            _treeLock.EnterReadLock();
            bool result = _tree.ContainsKey(address);
            _treeLock.ExitReadLock();
=======
            _treeLock.AcquireReaderLock(Timeout.Infinite);
            bool result = _tree.ContainsKey(address);
            _treeLock.ReleaseReaderLock();
>>>>>>> 1ec71635b (sync with main branch)

            return result;
        }

        public bool TryGetValue(ulong address, out T value)
        {
<<<<<<< HEAD
            _treeLock.EnterReadLock();
            bool result = _tree.TryGet(address, out value);
            _treeLock.ExitReadLock();
=======
            _treeLock.AcquireReaderLock(Timeout.Infinite);
            bool result = _tree.TryGet(address, out value);
            _treeLock.ReleaseReaderLock();
>>>>>>> 1ec71635b (sync with main branch)

            return result;
        }

        public int GetOverlaps(ulong address, ulong size, ref ulong[] overlaps)
        {
<<<<<<< HEAD
            _treeLock.EnterReadLock();
            int count = _tree.Get(address, address + size, ref overlaps);
            _treeLock.ExitReadLock();
=======
            _treeLock.AcquireReaderLock(Timeout.Infinite);
            int count = _tree.Get(address, address + size, ref overlaps);
            _treeLock.ReleaseReaderLock();
>>>>>>> 1ec71635b (sync with main branch)

            return count;
        }

        public List<T> AsList()
        {
<<<<<<< HEAD
            _treeLock.EnterReadLock();
            List<T> list = _tree.AsList();
            _treeLock.ExitReadLock();
=======
            _treeLock.AcquireReaderLock(Timeout.Infinite);
            List<T> list = _tree.AsList();
            _treeLock.ReleaseReaderLock();
>>>>>>> 1ec71635b (sync with main branch)

            return list;
        }
    }
}
