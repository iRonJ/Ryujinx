<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.Common
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Hash128 : IEquatable<Hash128>
    {
        public ulong Low;
        public ulong High;

        public Hash128(ulong low, ulong high)
        {
            Low = low;
            High = high;
        }

<<<<<<< HEAD
        public readonly override string ToString()
=======
        public override string ToString()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return $"{High:x16}{Low:x16}";
        }

        public static bool operator ==(Hash128 x, Hash128 y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Hash128 x, Hash128 y)
        {
            return !x.Equals(y);
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is Hash128 hash128 && Equals(hash128);
        }

<<<<<<< HEAD
        public readonly bool Equals(Hash128 cmpObj)
=======
        public bool Equals(Hash128 cmpObj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Low == cmpObj.Low && High == cmpObj.High;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return HashCode.Combine(Low, High);
        }
    }
}
