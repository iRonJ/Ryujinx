<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
=======
﻿using System;
using System.Collections.Generic;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Vulkan
{
    interface IRefEquatable<T>
    {
        bool Equals(ref T other);
    }

<<<<<<< HEAD
    class HashTableSlim<TKey, TValue> where TKey : IRefEquatable<TKey>
=======
    class HashTableSlim<K, V> where K : IRefEquatable<K>
>>>>>>> 1ec71635b (sync with main branch)
    {
        private const int TotalBuckets = 16; // Must be power of 2
        private const int TotalBucketsMask = TotalBuckets - 1;

        private struct Entry
        {
            public int Hash;
<<<<<<< HEAD
            public TKey Key;
            public TValue Value;
        }

        private struct Bucket
        {
            public int Length;
            public Entry[] Entries;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Span<Entry> AsSpan()
            {
                return Entries == null ? Span<Entry>.Empty : Entries.AsSpan(0, Length);
            }
        }

        private readonly Bucket[] _hashTable = new Bucket[TotalBuckets];

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (Bucket bucket in _hashTable)
                {
                    for (int i = 0; i < bucket.Length; i++)
                    {
                        yield return bucket.Entries[i].Key;
=======
            public K Key;
            public V Value;
        }

        private readonly Entry[][] _hashTable = new Entry[TotalBuckets][];

        public IEnumerable<K> Keys
        {
            get
            {
                foreach (Entry[] bucket in _hashTable)
                {
                    if (bucket != null)
                    {
                        foreach (Entry entry in bucket)
                        {
                            yield return entry.Key;
                        }
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }
            }
        }

<<<<<<< HEAD
        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (Bucket bucket in _hashTable)
                {
                    for (int i = 0; i < bucket.Length; i++)
                    {
                        yield return bucket.Entries[i].Value;
=======
        public IEnumerable<V> Values
        {
            get
            {
                foreach (Entry[] bucket in _hashTable)
                {
                    if (bucket != null)
                    {
                        foreach (Entry entry in bucket)
                        {
                            yield return entry.Value;
                        }
>>>>>>> 1ec71635b (sync with main branch)
                    }
                }
            }
        }

<<<<<<< HEAD
        public void Add(ref TKey key, TValue value)
        {
            var entry = new Entry
            {
                Hash = key.GetHashCode(),
                Key = key,
                Value = value,
=======
        public void Add(ref K key, V value)
        {
            var entry = new Entry()
            {
                Hash = key.GetHashCode(),
                Key = key,
                Value = value
>>>>>>> 1ec71635b (sync with main branch)
            };

            int hashCode = key.GetHashCode();
            int bucketIndex = hashCode & TotalBucketsMask;

<<<<<<< HEAD
            ref var bucket = ref _hashTable[bucketIndex];
            if (bucket.Entries != null)
            {
                int index = bucket.Length;

                if (index >= bucket.Entries.Length)
                {
                    Array.Resize(ref bucket.Entries, index + 1);
                }

                bucket.Entries[index] = entry;
            }
            else
            {
                bucket.Entries = new[]
                {
                    entry,
                };
            }

            bucket.Length++;
        }

        public bool Remove(ref TKey key)
        {
            int hashCode = key.GetHashCode();

            ref var bucket = ref _hashTable[hashCode & TotalBucketsMask];
            var entries = bucket.AsSpan();
            for (int i = 0; i < entries.Length; i++)
            {
                ref var entry = ref entries[i];

                if (entry.Hash == hashCode && entry.Key.Equals(ref key))
                {
                    entries[(i + 1)..].CopyTo(entries[i..]);
                    bucket.Length--;

                    return true;
                }
            }

            return false;
        }

        public bool TryGetValue(ref TKey key, out TValue value)
        {
            int hashCode = key.GetHashCode();

            var entries = _hashTable[hashCode & TotalBucketsMask].AsSpan();
            for (int i = 0; i < entries.Length; i++)
            {
                ref var entry = ref entries[i];

                if (entry.Hash == hashCode && entry.Key.Equals(ref key))
                {
                    value = entry.Value;
                    return true;
=======
            var bucket = _hashTable[bucketIndex];
            if (bucket != null)
            {
                int index = bucket.Length;

                Array.Resize(ref _hashTable[bucketIndex], index + 1);

                _hashTable[bucketIndex][index] = entry;
            }
            else
            {
                _hashTable[bucketIndex] = new Entry[]
                {
                    entry
                };
            }
        }

        public bool TryGetValue(ref K key, out V value)
        {
            int hashCode = key.GetHashCode();

            var bucket = _hashTable[hashCode & TotalBucketsMask];
            if (bucket != null)
            {
                for (int i = 0; i < bucket.Length; i++)
                {
                    ref var entry = ref bucket[i];

                    if (entry.Hash == hashCode && entry.Key.Equals(ref key))
                    {
                        value = entry.Value;
                        return true;
                    }
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            value = default;
            return false;
        }
    }
}
