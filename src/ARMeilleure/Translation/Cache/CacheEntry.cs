using ARMeilleure.CodeGen.Unwinding;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ARMeilleure.Translation.Cache
{
    readonly struct CacheEntry : IComparable<CacheEntry>
    {
        public int Offset { get; }
<<<<<<< HEAD
        public int Size { get; }
=======
        public int Size   { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public UnwindInfo UnwindInfo { get; }

        public CacheEntry(int offset, int size, UnwindInfo unwindInfo)
        {
<<<<<<< HEAD
            Offset = offset;
            Size = size;
=======
            Offset     = offset;
            Size       = size;
>>>>>>> 1ec71635b (sync with main branch)
            UnwindInfo = unwindInfo;
        }

        public int CompareTo([AllowNull] CacheEntry other)
        {
            return Offset.CompareTo(other.Offset);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
