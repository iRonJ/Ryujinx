<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Diagnostics.CodeAnalysis;

namespace Spv.Generator
{
<<<<<<< HEAD
    internal readonly struct TypeDeclarationKey : IEquatable<TypeDeclarationKey>
    {
        private readonly Instruction _typeDeclaration;
=======
    internal struct TypeDeclarationKey : IEquatable<TypeDeclarationKey>
    {
        private Instruction _typeDeclaration;
>>>>>>> 1ec71635b (sync with main branch)

        public TypeDeclarationKey(Instruction typeDeclaration)
        {
            _typeDeclaration = typeDeclaration;
        }

        public override int GetHashCode()
        {
            return DeterministicHashCode.Combine(_typeDeclaration.Opcode, _typeDeclaration.GetHashCodeContent());
        }

        public bool Equals(TypeDeclarationKey other)
        {
            return _typeDeclaration.Opcode == other._typeDeclaration.Opcode && _typeDeclaration.EqualsContent(other._typeDeclaration);
        }

        public override bool Equals([NotNullWhen(true)] object obj)
        {
<<<<<<< HEAD
            return obj is TypeDeclarationKey key && Equals(key);
=======
            return obj is TypeDeclarationKey && Equals((TypeDeclarationKey)obj);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
