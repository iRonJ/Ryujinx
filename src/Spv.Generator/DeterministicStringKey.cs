<<<<<<< HEAD
using System;
=======
﻿using System;
using System.Diagnostics.CodeAnalysis;
>>>>>>> 1ec71635b (sync with main branch)

namespace Spv.Generator
{
    internal class DeterministicStringKey : IEquatable<DeterministicStringKey>
    {
<<<<<<< HEAD
        private readonly string _value;
=======
        private string _value;
>>>>>>> 1ec71635b (sync with main branch)

        public DeterministicStringKey(string value)
        {
            _value = value;
        }

        public override int GetHashCode()
        {
            return DeterministicHashCode.GetHashCode(_value);
        }

        public bool Equals(DeterministicStringKey other)
        {
<<<<<<< HEAD
            return _value == other?._value;
        }

        public override bool Equals(object obj)
        {
            return obj is DeterministicStringKey key && Equals(key);
=======
            return _value == other._value;
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
            return obj is DeterministicStringKey && Equals((DeterministicStringKey)obj);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
