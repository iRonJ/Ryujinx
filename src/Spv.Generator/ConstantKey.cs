<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Diagnostics.CodeAnalysis;

namespace Spv.Generator
{
<<<<<<< HEAD
    internal readonly struct ConstantKey : IEquatable<ConstantKey>
    {
        private readonly Instruction _constant;
=======
    internal struct ConstantKey : IEquatable<ConstantKey>
    {
        private Instruction _constant;
>>>>>>> 1ec71635b (sync with main branch)

        public ConstantKey(Instruction constant)
        {
            _constant = constant;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_constant.Opcode, _constant.GetHashCodeContent(), _constant.GetHashCodeResultType());
        }

        public bool Equals(ConstantKey other)
        {
            return _constant.Opcode == other._constant.Opcode && _constant.EqualsContent(other._constant) && _constant.EqualsResultType(other._constant);
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
<<<<<<< HEAD
            return obj is ConstantKey key && Equals(key);
=======
            return obj is ConstantKey && Equals((ConstantKey)obj);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
