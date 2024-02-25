<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.IO;
using System.Text;

namespace Spv.Generator
{
<<<<<<< HEAD
    public class LiteralString : IOperand, IEquatable<LiteralString>
    {
        public OperandType Type => OperandType.String;

        private readonly string _value;
=======
    public class LiteralString : Operand, IEquatable<LiteralString>
    {
        public OperandType Type => OperandType.String;

        private string _value;
>>>>>>> 1ec71635b (sync with main branch)

        public LiteralString(string value)
        {
            _value = value;
        }

        public ushort WordCount => (ushort)(_value.Length / 4 + 1);

        public void WriteOperand(BinaryWriter writer)
        {
            writer.Write(_value.AsSpan());

            // String must be padded to the word size (which is 4 bytes).
            int paddingSize = 4 - (Encoding.ASCII.GetByteCount(_value) % 4);

            Span<byte> padding = stackalloc byte[paddingSize];

            writer.Write(padding);
        }

        public override bool Equals(object obj)
        {
            return obj is LiteralString literalString && Equals(literalString);
        }

        public bool Equals(LiteralString cmpObj)
        {
            return Type == cmpObj.Type && _value.Equals(cmpObj._value);
        }

        public override int GetHashCode()
        {
            return DeterministicHashCode.Combine(Type, DeterministicHashCode.GetHashCode(_value));
        }

<<<<<<< HEAD
        public bool Equals(IOperand obj)
=======
        public bool Equals(Operand obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is LiteralString literalString && Equals(literalString);
        }

        public override string ToString() => _value;
    }
}
