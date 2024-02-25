<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Horizon.Common
{
    public struct Result : IEquatable<Result>
    {
        private const int ModuleBits = 9;
        private const int DescriptionBits = 13;
        private const int ModuleMax = 1 << ModuleBits;
        private const int DescriptionMax = 1 << DescriptionBits;

        public static Result Success { get; } = new Result(0, 0);

        public int ErrorCode { get; }

<<<<<<< HEAD
        public readonly bool IsSuccess => ErrorCode == 0;
        public readonly bool IsFailure => ErrorCode != 0;

        public readonly int Module => ErrorCode & (ModuleMax - 1);
        public readonly int Description => (ErrorCode >> ModuleBits) & (DescriptionMax - 1);

        public readonly string PrintableResult => $"{2000 + Module:D4}-{Description:D4}";
=======
        public bool IsSuccess => ErrorCode == 0;
        public bool IsFailure => ErrorCode != 0;

        public int Module => ErrorCode & (ModuleMax - 1);
        public int Description => (ErrorCode >> ModuleBits) & (DescriptionMax - 1);

        public string PrintableResult => $"{2000 + Module:D4}-{Description:D4}";
>>>>>>> 1ec71635b (sync with main branch)

        public Result(int module, int description)
        {
            if ((uint)module >= ModuleMax)
            {
                throw new ArgumentOutOfRangeException(nameof(module));
            }

            if ((uint)description >= DescriptionMax)
            {
                throw new ArgumentOutOfRangeException(nameof(description));
            }

            ErrorCode = module | (description << ModuleBits);
        }

<<<<<<< HEAD
        public Result(int errorCode)
        {
            ErrorCode = errorCode;
        }

        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is Result result && result.Equals(this);
        }

<<<<<<< HEAD
        public readonly bool Equals(Result other)
=======
        public bool Equals(Result other)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return other.ErrorCode == ErrorCode;
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return ErrorCode;
        }

        public static bool operator ==(Result lhs, Result rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Result lhs, Result rhs)
        {
            return !lhs.Equals(rhs);
        }

<<<<<<< HEAD
        public readonly bool InRange(int minInclusive, int maxInclusive)
=======
        public bool InRange(int minInclusive, int maxInclusive)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (uint)(Description - minInclusive) <= (uint)(maxInclusive - minInclusive);
        }

        public void AbortOnSuccess()
        {
            if (IsSuccess)
            {
                ThrowInvalidResult();
            }
        }

        public void AbortOnFailure()
        {
            if (this == KernelResult.ThreadTerminating)
            {
                throw new ThreadTerminatedException();
            }

            AbortUnless(Success);
        }

        public void AbortUnless(Result result)
        {
            if (this != result)
            {
                ThrowInvalidResult();
            }
        }

        public void AbortUnless(Result result, Result result2)
        {
            if (this != result && this != result2)
            {
                ThrowInvalidResult();
            }
        }

        private void ThrowInvalidResult()
        {
            throw new InvalidResultException(this);
        }

<<<<<<< HEAD
        public readonly override string ToString()
=======
        public override string ToString()
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (ResultNames.TryGet(ErrorCode, out string name))
            {
                return name;
            }

            return PrintableResult;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
