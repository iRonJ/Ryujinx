<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Spv.Generator
{
    public struct InstructionOperands
    {
        private const int InternalCount = 5;

        public int Count;
<<<<<<< HEAD
        public IOperand Operand1;
        public IOperand Operand2;
        public IOperand Operand3;
        public IOperand Operand4;
        public IOperand Operand5;
        public IOperand[] Overflow;

        public Span<IOperand> AsSpan()
=======
        public Operand Operand1;
        public Operand Operand2;
        public Operand Operand3;
        public Operand Operand4;
        public Operand Operand5;
        public Operand[] Overflow;

        public Span<Operand> AsSpan()
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (Count > InternalCount)
            {
                return MemoryMarshal.CreateSpan(ref this.Overflow[0], Count);
            }
            else
            {
                return MemoryMarshal.CreateSpan(ref this.Operand1, Count);
            }
        }

<<<<<<< HEAD
        public void Add(IOperand operand)
=======
        public void Add(Operand operand)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (Count < InternalCount)
            {
                MemoryMarshal.CreateSpan(ref this.Operand1, Count + 1)[Count] = operand;
                Count++;
            }
            else
            {
                if (Overflow == null)
                {
<<<<<<< HEAD
                    Overflow = new IOperand[InternalCount * 2];
=======
                    Overflow = new Operand[InternalCount * 2];
>>>>>>> 1ec71635b (sync with main branch)
                    MemoryMarshal.CreateSpan(ref this.Operand1, InternalCount).CopyTo(Overflow.AsSpan());
                }
                else if (Count == Overflow.Length)
                {
                    Array.Resize(ref Overflow, Overflow.Length * 2);
                }

                Overflow[Count++] = operand;
            }
        }

<<<<<<< HEAD
        private readonly IEnumerable<IOperand> AllOperands => new[] { Operand1, Operand2, Operand3, Operand4, Operand5 }
            .Concat(Overflow ?? Array.Empty<IOperand>())
            .Take(Count);

        public readonly override string ToString()
=======
        private IEnumerable<Operand> AllOperands => new[] { Operand1, Operand2, Operand3, Operand4, Operand5 }
            .Concat(Overflow ?? Array.Empty<Operand>())
            .Take(Count);

        public override string ToString()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return $"({string.Join(", ", AllOperands)})";
        }

<<<<<<< HEAD
        public readonly string ToString(string[] labels)
=======
        public string ToString(string[] labels)
>>>>>>> 1ec71635b (sync with main branch)
        {
            var labeledParams = AllOperands.Zip(labels, (op, label) => $"{label}: {op}");
            var unlabeledParams = AllOperands.Skip(labels.Length).Select(op => op.ToString());
            var paramsToPrint = labeledParams.Concat(unlabeledParams);
            return $"({string.Join(", ", paramsToPrint)})";
        }
    }
}
