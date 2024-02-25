using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ARMeilleure.IntermediateRepresentation
{
    unsafe struct Operation : IEquatable<Operation>, IIntrusiveListNode<Operation>
    {
        internal struct Data
        {
            public ushort Instruction;
            public ushort Intrinsic;
            public ushort SourcesCount;
            public ushort DestinationsCount;
            public Operation ListPrevious;
            public Operation ListNext;
            public Operand* Destinations;
            public Operand* Sources;
        }

        private Data* _data;

<<<<<<< HEAD
        public readonly Instruction Instruction
=======
        public Instruction Instruction
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => (Instruction)_data->Instruction;
            private set => _data->Instruction = (ushort)value;
        }

<<<<<<< HEAD
        public readonly Intrinsic Intrinsic
=======
        public Intrinsic Intrinsic
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => (Intrinsic)_data->Intrinsic;
            private set => _data->Intrinsic = (ushort)value;
        }

<<<<<<< HEAD
        public readonly Operation ListPrevious
=======
        public Operation ListPrevious
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => _data->ListPrevious;
            set => _data->ListPrevious = value;
        }

<<<<<<< HEAD
        public readonly Operation ListNext
=======
        public Operation ListNext
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => _data->ListNext;
            set => _data->ListNext = value;
        }

<<<<<<< HEAD
        public readonly Operand Destination
=======
        public Operand Destination
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => _data->DestinationsCount != 0 ? GetDestination(0) : default;
            set => SetDestination(value);
        }

<<<<<<< HEAD
        public readonly int DestinationsCount => _data->DestinationsCount;
        public readonly int SourcesCount => _data->SourcesCount;

        internal readonly Span<Operand> DestinationsUnsafe => new(_data->Destinations, _data->DestinationsCount);
        internal readonly Span<Operand> SourcesUnsafe => new(_data->Sources, _data->SourcesCount);

        public readonly PhiOperation AsPhi()
=======
        public int DestinationsCount => _data->DestinationsCount;
        public int SourcesCount => _data->SourcesCount;

        internal Span<Operand> DestinationsUnsafe => new(_data->Destinations, _data->DestinationsCount);
        internal Span<Operand> SourcesUnsafe => new(_data->Sources, _data->SourcesCount);

        public PhiOperation AsPhi()
>>>>>>> 1ec71635b (sync with main branch)
        {
            Debug.Assert(Instruction == Instruction.Phi);

            return new PhiOperation(this);
        }

<<<<<<< HEAD
        public readonly Operand GetDestination(int index)
=======
        public Operand GetDestination(int index)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return DestinationsUnsafe[index];
        }

<<<<<<< HEAD
        public readonly Operand GetSource(int index)
=======
        public Operand GetSource(int index)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return SourcesUnsafe[index];
        }

<<<<<<< HEAD
        public readonly void SetDestination(int index, Operand dest)
=======
        public void SetDestination(int index, Operand dest)
>>>>>>> 1ec71635b (sync with main branch)
        {
            ref Operand curDest = ref DestinationsUnsafe[index];

            RemoveAssignment(curDest);
            AddAssignment(dest);

            curDest = dest;
        }

<<<<<<< HEAD
        public readonly void SetSource(int index, Operand src)
=======
        public void SetSource(int index, Operand src)
>>>>>>> 1ec71635b (sync with main branch)
        {
            ref Operand curSrc = ref SourcesUnsafe[index];

            RemoveUse(curSrc);
            AddUse(src);

            curSrc = src;
        }

<<<<<<< HEAD
        private readonly void RemoveOldDestinations()
=======
        private void RemoveOldDestinations()
>>>>>>> 1ec71635b (sync with main branch)
        {
            for (int i = 0; i < _data->DestinationsCount; i++)
            {
                RemoveAssignment(_data->Destinations[i]);
            }
        }

<<<<<<< HEAD
        public readonly void SetDestination(Operand dest)
=======
        public void SetDestination(Operand dest)
>>>>>>> 1ec71635b (sync with main branch)
        {
            RemoveOldDestinations();

            if (dest == default)
            {
                _data->DestinationsCount = 0;
            }
            else
            {
                EnsureCapacity(ref _data->Destinations, ref _data->DestinationsCount, 1);

                _data->Destinations[0] = dest;

                AddAssignment(dest);
            }
        }

<<<<<<< HEAD
        public readonly void SetDestinations(Operand[] dests)
=======
        public void SetDestinations(Operand[] dests)
>>>>>>> 1ec71635b (sync with main branch)
        {
            RemoveOldDestinations();

            EnsureCapacity(ref _data->Destinations, ref _data->DestinationsCount, dests.Length);

            for (int index = 0; index < dests.Length; index++)
            {
                Operand newOp = dests[index];

                _data->Destinations[index] = newOp;

                AddAssignment(newOp);
            }
        }

<<<<<<< HEAD
        private readonly void RemoveOldSources()
=======
        private void RemoveOldSources()
>>>>>>> 1ec71635b (sync with main branch)
        {
            for (int index = 0; index < _data->SourcesCount; index++)
            {
                RemoveUse(_data->Sources[index]);
            }
        }

<<<<<<< HEAD
        public readonly void SetSource(Operand src)
=======
        public void SetSource(Operand src)
>>>>>>> 1ec71635b (sync with main branch)
        {
            RemoveOldSources();

            if (src == default)
            {
                _data->SourcesCount = 0;
            }
            else
            {
                EnsureCapacity(ref _data->Sources, ref _data->SourcesCount, 1);

                _data->Sources[0] = src;

                AddUse(src);
            }
        }

<<<<<<< HEAD
        public readonly void SetSources(Operand[] srcs)
=======
        public void SetSources(Operand[] srcs)
>>>>>>> 1ec71635b (sync with main branch)
        {
            RemoveOldSources();

            EnsureCapacity(ref _data->Sources, ref _data->SourcesCount, srcs.Length);

            for (int index = 0; index < srcs.Length; index++)
            {
                Operand newOp = srcs[index];

                _data->Sources[index] = newOp;

                AddUse(newOp);
            }
        }

        public void TurnIntoCopy(Operand source)
        {
            Instruction = Instruction.Copy;

            SetSource(source);
        }

<<<<<<< HEAD
        private readonly void AddAssignment(Operand op)
=======
        private void AddAssignment(Operand op)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (op != default)
            {
                op.AddAssignment(this);
            }
        }

<<<<<<< HEAD
        private readonly void RemoveAssignment(Operand op)
=======
        private void RemoveAssignment(Operand op)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (op != default)
            {
                op.RemoveAssignment(this);
            }
        }

<<<<<<< HEAD
        private readonly void AddUse(Operand op)
=======
        private void AddUse(Operand op)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (op != default)
            {
                op.AddUse(this);
            }
        }

<<<<<<< HEAD
        private readonly void RemoveUse(Operand op)
=======
        private void RemoveUse(Operand op)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (op != default)
            {
                op.RemoveUse(this);
            }
        }

<<<<<<< HEAD
        public readonly bool Equals(Operation operation)
=======
        public bool Equals(Operation operation)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return operation._data == _data;
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is Operation operation && Equals(operation);
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return HashCode.Combine((IntPtr)_data);
        }

        public static bool operator ==(Operation a, Operation b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Operation a, Operation b)
        {
            return !a.Equals(b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void EnsureCapacity(ref Operand* list, ref ushort capacity, int newCapacity)
        {
            if (newCapacity > ushort.MaxValue)
            {
                ThrowOverflow(newCapacity);
            }
            // We only need to allocate a new buffer if we're increasing the size.
            else if (newCapacity > capacity)
            {
                list = Allocators.References.Allocate<Operand>((uint)newCapacity);
            }

            capacity = (ushort)newCapacity;
        }

        private static void ThrowOverflow(int count) =>
            throw new OverflowException($"Exceeded maximum size for Source or Destinations. Required {count}.");

        public static class Factory
        {
            private static Operation Make(Instruction inst, int destCount, int srcCount)
            {
                Data* data = Allocators.Operations.Allocate<Data>();
                *data = default;

<<<<<<< HEAD
                Operation result = new()
                {
                    _data = data,
                    Instruction = inst,
                };
=======
                Operation result = new();
                result._data = data;
                result.Instruction = inst;
>>>>>>> 1ec71635b (sync with main branch)

                EnsureCapacity(ref result._data->Destinations, ref result._data->DestinationsCount, destCount);
                EnsureCapacity(ref result._data->Sources, ref result._data->SourcesCount, srcCount);

                result.DestinationsUnsafe.Clear();
                result.SourcesUnsafe.Clear();

                return result;
            }

            public static Operation Operation(Instruction inst, Operand dest)
            {
                Operation result = Make(inst, 0, 0);
                result.SetDestination(dest);
                return result;
            }

            public static Operation Operation(Instruction inst, Operand dest, Operand src0)
            {
                Operation result = Make(inst, 0, 1);
                result.SetDestination(dest);
                result.SetSource(0, src0);
                return result;
            }

            public static Operation Operation(Instruction inst, Operand dest, Operand src0, Operand src1)
            {
                Operation result = Make(inst, 0, 2);
                result.SetDestination(dest);
                result.SetSource(0, src0);
                result.SetSource(1, src1);
                return result;
            }

            public static Operation Operation(Instruction inst, Operand dest, Operand src0, Operand src1, Operand src2)
            {
                Operation result = Make(inst, 0, 3);
                result.SetDestination(dest);
                result.SetSource(0, src0);
                result.SetSource(1, src1);
                result.SetSource(2, src2);
                return result;
            }

            public static Operation Operation(Instruction inst, Operand dest, int srcCount)
            {
                Operation result = Make(inst, 0, srcCount);
                result.SetDestination(dest);
                return result;
            }

            public static Operation Operation(Instruction inst, Operand dest, Operand[] srcs)
            {
                Operation result = Make(inst, 0, srcs.Length);

                result.SetDestination(dest);

                for (int index = 0; index < srcs.Length; index++)
                {
                    result.SetSource(index, srcs[index]);
                }

                return result;
            }

            public static Operation Operation(Intrinsic intrin, Operand dest, params Operand[] srcs)
            {
                Operation result = Make(Instruction.Extended, 0, srcs.Length);

                result.Intrinsic = intrin;
                result.SetDestination(dest);

                for (int index = 0; index < srcs.Length; index++)
                {
                    result.SetSource(index, srcs[index]);
                }

                return result;
            }

            public static Operation Operation(Instruction inst, Operand[] dests, Operand[] srcs)
            {
                Operation result = Make(inst, dests.Length, srcs.Length);

                for (int index = 0; index < dests.Length; index++)
                {
                    result.SetDestination(index, dests[index]);
                }

                for (int index = 0; index < srcs.Length; index++)
                {
                    result.SetSource(index, srcs[index]);
                }

                return result;
            }

            public static Operation PhiOperation(Operand dest, int srcCount)
            {
                return Operation(Instruction.Phi, dest, srcCount * 2);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
