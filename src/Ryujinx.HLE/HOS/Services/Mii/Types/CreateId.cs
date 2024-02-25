<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 0x10)]
<<<<<<< HEAD
    readonly struct CreateId : IEquatable<CreateId>
    {
        public readonly UInt128 Raw;

        public readonly bool IsNull => Raw == UInt128.Zero;
        public readonly bool IsValid => !IsNull && ((Raw >> 64) & 0xC0) == 0x80;
=======
    struct CreateId : IEquatable<CreateId>
    {
        public UInt128 Raw;

        public bool IsNull => Raw == UInt128.Zero;
        public bool IsValid => !IsNull && ((Raw >> 64) & 0xC0) == 0x80;
>>>>>>> 1ec71635b (sync with main branch)

        public CreateId(UInt128 raw)
        {
            Raw = raw;
        }

        public static bool operator ==(CreateId x, CreateId y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(CreateId x, CreateId y)
        {
            return !x.Equals(y);
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is CreateId createId && Equals(createId);
        }

<<<<<<< HEAD
        public readonly bool Equals(CreateId cmpObj)
=======
        public bool Equals(CreateId cmpObj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // Nintendo additionally check that the CreatorId is valid before doing the actual comparison.
            return IsValid && Raw == cmpObj.Raw;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return Raw.GetHashCode();
        }
    }
}
