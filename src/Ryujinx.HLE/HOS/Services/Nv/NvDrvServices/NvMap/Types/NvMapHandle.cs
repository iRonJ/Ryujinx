using System.Threading;

namespace Ryujinx.HLE.HOS.Services.Nv.NvDrvServices.NvMap
{
    class NvMapHandle
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
        public int Handle;
        public int Id;
#pragma warning restore CS0649
        public uint Size;
        public int Align;
        public int Kind;
        public ulong Address;
        public bool Allocated;
=======
#pragma warning disable CS0649
        public int   Handle;
        public int   Id;
#pragma warning restore CS0649
        public int   Size;
        public int   Align;
        public int   Kind;
        public ulong Address;
        public bool  Allocated;
>>>>>>> 1ec71635b (sync with main branch)
        public ulong DmaMapAddress;

        private long _dupes;

        public NvMapHandle()
        {
            _dupes = 1;
        }

<<<<<<< HEAD
        public NvMapHandle(uint size) : this()
=======
        public NvMapHandle(int size) : this()
>>>>>>> 1ec71635b (sync with main branch)
        {
            Size = size;
        }

        public void IncrementRefCount()
        {
            Interlocked.Increment(ref _dupes);
        }

        public long DecrementRefCount()
        {
            return Interlocked.Decrement(ref _dupes);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
