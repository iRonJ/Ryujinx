using ARMeilleure.CodeGen.Linking;
using ARMeilleure.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ARMeilleure.IntermediateRepresentation
{
    unsafe struct Operand : IEquatable<Operand>
    {
        internal struct Data
        {
            public byte Kind;
            public byte Type;
            public byte SymbolType;
            public byte Padding; // Unused space.
            public ushort AssignmentsCount;
            public ushort AssignmentsCapacity;
            public uint UsesCount;
            public uint UsesCapacity;
            public Operation* Assignments;
            public Operation* Uses;
            public ulong Value;
            public ulong SymbolValue;
        }

        private Data* _data;

<<<<<<< HEAD
        public readonly OperandKind Kind
=======
        public OperandKind Kind
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => (OperandKind)_data->Kind;
            private set => _data->Kind = (byte)value;
        }

<<<<<<< HEAD
        public readonly OperandType Type
=======
        public OperandType Type
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => (OperandType)_data->Type;
            private set => _data->Type = (byte)value;
        }

<<<<<<< HEAD
        public readonly ulong Value
=======
        public ulong Value
>>>>>>> 1ec71635b (sync with main branch)
        {
            get => _data->Value;
            private set => _data->Value = value;
        }

<<<<<<< HEAD
        public readonly Symbol Symbol
=======
        public Symbol Symbol
>>>>>>> 1ec71635b (sync with main branch)
        {
            get
            {
                Debug.Assert(Kind != OperandKind.Memory);

                return new Symbol((SymbolType)_data->SymbolType, _data->SymbolValue);
            }
            private set
            {
                Debug.Assert(Kind != OperandKind.Memory);

                if (value.Type == SymbolType.None)
                {
                    _data->SymbolType = (byte)SymbolType.None;
                }
                else
                {
                    _data->SymbolType = (byte)value.Type;
                    _data->SymbolValue = value.Value;
                }
            }
        }

<<<<<<< HEAD
        public readonly ReadOnlySpan<Operation> Assignments
=======
        public ReadOnlySpan<Operation> Assignments
>>>>>>> 1ec71635b (sync with main branch)
        {
            get
            {
                Debug.Assert(Kind != OperandKind.Memory);

                return new ReadOnlySpan<Operation>(_data->Assignments, _data->AssignmentsCount);
            }
        }

<<<<<<< HEAD
        public readonly ReadOnlySpan<Operation> Uses
=======
        public ReadOnlySpan<Operation> Uses
>>>>>>> 1ec71635b (sync with main branch)
        {
            get
            {
                Debug.Assert(Kind != OperandKind.Memory);

                return new ReadOnlySpan<Operation>(_data->Uses, (int)_data->UsesCount);
            }
        }

<<<<<<< HEAD
        public readonly int UsesCount => (int)_data->UsesCount;
        public readonly int AssignmentsCount => _data->AssignmentsCount;

        public readonly bool Relocatable => Symbol.Type != SymbolType.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly Register GetRegister()
=======
        public int UsesCount => (int)_data->UsesCount;
        public int AssignmentsCount => _data->AssignmentsCount;

        public bool Relocatable => Symbol.Type != SymbolType.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Register GetRegister()
>>>>>>> 1ec71635b (sync with main branch)
        {
            Debug.Assert(Kind == OperandKind.Register);

            return new Register((int)Value & 0xffffff, (RegisterType)(Value >> 24));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        public readonly MemoryOperand GetMemory()
=======
        public MemoryOperand GetMemory()
>>>>>>> 1ec71635b (sync with main branch)
        {
            Debug.Assert(Kind == OperandKind.Memory);

            return new MemoryOperand(this);
        }

<<<<<<< HEAD
        public readonly int GetLocalNumber()
=======
        public int GetLocalNumber()
>>>>>>> 1ec71635b (sync with main branch)
        {
            Debug.Assert(Kind == OperandKind.LocalVariable);

            return (int)Value;
        }

<<<<<<< HEAD
        public readonly byte AsByte()
=======
        public byte AsByte()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (byte)Value;
        }

<<<<<<< HEAD
        public readonly short AsInt16()
=======
        public short AsInt16()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (short)Value;
        }

<<<<<<< HEAD
        public readonly int AsInt32()
=======
        public int AsInt32()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (int)Value;
        }

<<<<<<< HEAD
        public readonly long AsInt64()
=======
        public long AsInt64()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return (long)Value;
        }

<<<<<<< HEAD
        public readonly float AsFloat()
=======
        public float AsFloat()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return BitConverter.Int32BitsToSingle((int)Value);
        }

<<<<<<< HEAD
        public readonly double AsDouble()
=======
        public double AsDouble()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return BitConverter.Int64BitsToDouble((long)Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        internal readonly ref ulong GetValueUnsafe()
=======
        internal ref ulong GetValueUnsafe()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return ref _data->Value;
        }

        internal void NumberLocal(int number)
        {
            if (Kind != OperandKind.LocalVariable)
            {
                throw new InvalidOperationException("The operand is not a local variable.");
            }

            Value = (ulong)number;
        }

<<<<<<< HEAD
        public readonly void AddAssignment(Operation operation)
=======
        public void AddAssignment(Operation operation)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (Kind == OperandKind.LocalVariable)
            {
                Add(operation, ref _data->Assignments, ref _data->AssignmentsCount, ref _data->AssignmentsCapacity);
            }
            else if (Kind == OperandKind.Memory)
            {
                MemoryOperand memOp = GetMemory();
                Operand addr = memOp.BaseAddress;
                Operand index = memOp.Index;

                if (addr != default)
                {
                    Add(operation, ref addr._data->Assignments, ref addr._data->AssignmentsCount, ref addr._data->AssignmentsCapacity);
                }

                if (index != default)
                {
                    Add(operation, ref index._data->Assignments, ref index._data->AssignmentsCount, ref index._data->AssignmentsCapacity);
                }
            }
        }

<<<<<<< HEAD
        public readonly void RemoveAssignment(Operation operation)
=======
        public void RemoveAssignment(Operation operation)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (Kind == OperandKind.LocalVariable)
            {
                Remove(operation, ref _data->Assignments, ref _data->AssignmentsCount);
            }
            else if (Kind == OperandKind.Memory)
            {
                MemoryOperand memOp = GetMemory();
                Operand addr = memOp.BaseAddress;
                Operand index = memOp.Index;

                if (addr != default)
                {
                    Remove(operation, ref addr._data->Assignments, ref addr._data->AssignmentsCount);
                }

                if (index != default)
                {
                    Remove(operation, ref index._data->Assignments, ref index._data->AssignmentsCount);
                }
            }
        }

<<<<<<< HEAD
        public readonly void AddUse(Operation operation)
=======
        public void AddUse(Operation operation)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (Kind == OperandKind.LocalVariable)
            {
                Add(operation, ref _data->Uses, ref _data->UsesCount, ref _data->UsesCapacity);
            }
            else if (Kind == OperandKind.Memory)
            {
                MemoryOperand memOp = GetMemory();
                Operand addr = memOp.BaseAddress;
                Operand index = memOp.Index;

                if (addr != default)
                {
                    Add(operation, ref addr._data->Uses, ref addr._data->UsesCount, ref addr._data->UsesCapacity);
                }

                if (index != default)
                {
                    Add(operation, ref index._data->Uses, ref index._data->UsesCount, ref index._data->UsesCapacity);
                }
            }
        }

<<<<<<< HEAD
        public readonly void RemoveUse(Operation operation)
=======
        public void RemoveUse(Operation operation)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if (Kind == OperandKind.LocalVariable)
            {
                Remove(operation, ref _data->Uses, ref _data->UsesCount);
            }
            else if (Kind == OperandKind.Memory)
            {
                MemoryOperand memOp = GetMemory();
                Operand addr = memOp.BaseAddress;
                Operand index = memOp.Index;

                if (addr != default)
                {
                    Remove(operation, ref addr._data->Uses, ref addr._data->UsesCount);
                }

                if (index != default)
                {
                    Remove(operation, ref index._data->Uses, ref index._data->UsesCount);
                }
            }
        }

<<<<<<< HEAD
        public readonly Span<Operation> GetUses(ref Span<Operation> buffer)
=======
        public Span<Operation> GetUses(ref Span<Operation> buffer)
>>>>>>> 1ec71635b (sync with main branch)
        {
            ReadOnlySpan<Operation> uses = Uses;

            if (buffer.Length < uses.Length)
            {
                buffer = Allocators.Default.AllocateSpan<Operation>((uint)uses.Length);
            }

            uses.CopyTo(buffer);

<<<<<<< HEAD
            return buffer[..uses.Length];
=======
            return buffer.Slice(0, uses.Length);
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static void New<T>(ref T* data, ref ushort count, ref ushort capacity, ushort initialCapacity) where T : unmanaged
        {
            count = 0;
            capacity = initialCapacity;
            data = Allocators.References.Allocate<T>(initialCapacity);
        }

        private static void New<T>(ref T* data, ref uint count, ref uint capacity, uint initialCapacity) where T : unmanaged
        {
            count = 0;
            capacity = initialCapacity;
            data = Allocators.References.Allocate<T>(initialCapacity);
        }

        private static void Add<T>(T item, ref T* data, ref ushort count, ref ushort capacity) where T : unmanaged
        {
            if (count < capacity)
            {
                data[(uint)count++] = item;

                return;
            }

            // Could not add item in the fast path, fallback onto the slow path.
            ExpandAdd(item, ref data, ref count, ref capacity);

            static void ExpandAdd(T item, ref T* data, ref ushort count, ref ushort capacity)
            {
                ushort newCount = checked((ushort)(count + 1));
                ushort newCapacity = (ushort)Math.Min(capacity * 2, ushort.MaxValue);

                var oldSpan = new Span<T>(data, count);

                capacity = newCapacity;
                data = Allocators.References.Allocate<T>(capacity);

                oldSpan.CopyTo(new Span<T>(data, count));

                data[count] = item;
                count = newCount;
            }
        }

        private static void Add<T>(T item, ref T* data, ref uint count, ref uint capacity) where T : unmanaged
        {
            if (count < capacity)
            {
                data[count++] = item;

                return;
            }

            // Could not add item in the fast path, fallback onto the slow path.
            ExpandAdd(item, ref data, ref count, ref capacity);

            static void ExpandAdd(T item, ref T* data, ref uint count, ref uint capacity)
            {
                uint newCount = checked(count + 1);
                uint newCapacity = (uint)Math.Min(capacity * 2, int.MaxValue);

                if (newCapacity <= capacity)
                {
                    throw new OverflowException();
                }

                var oldSpan = new Span<T>(data, (int)count);

                capacity = newCapacity;
                data = Allocators.References.Allocate<T>(capacity);

                oldSpan.CopyTo(new Span<T>(data, (int)count));

                data[count] = item;
                count = newCount;
            }
        }

        private static void Remove<T>(in T item, ref T* data, ref ushort count) where T : unmanaged
        {
            var span = new Span<T>(data, count);

            for (int i = 0; i < span.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(span[i], item))
                {
                    if (i + 1 < count)
                    {
<<<<<<< HEAD
                        span[(i + 1)..].CopyTo(span[i..]);
=======
                        span.Slice(i + 1).CopyTo(span.Slice(i));
>>>>>>> 1ec71635b (sync with main branch)
                    }

                    count--;

                    return;
                }
            }
        }

        private static void Remove<T>(in T item, ref T* data, ref uint count) where T : unmanaged
        {
            var span = new Span<T>(data, (int)count);

            for (int i = 0; i < span.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(span[i], item))
                {
                    if (i + 1 < count)
                    {
<<<<<<< HEAD
                        span[(i + 1)..].CopyTo(span[i..]);
=======
                        span.Slice(i + 1).CopyTo(span.Slice(i));
>>>>>>> 1ec71635b (sync with main branch)
                    }

                    count--;

                    return;
                }
            }
        }

<<<<<<< HEAD
        public readonly override int GetHashCode()
=======
        public override int GetHashCode()
>>>>>>> 1ec71635b (sync with main branch)
        {
            return ((ulong)_data).GetHashCode();
        }

<<<<<<< HEAD
        public readonly bool Equals(Operand operand)
=======
        public bool Equals(Operand operand)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return operand._data == _data;
        }

<<<<<<< HEAD
        public readonly override bool Equals(object obj)
=======
        public override bool Equals(object obj)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return obj is Operand operand && Equals(operand);
        }

        public static bool operator ==(Operand a, Operand b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Operand a, Operand b)
        {
            return !a.Equals(b);
        }

        public static class Factory
        {
            private const int InternTableSize = 256;
            private const int InternTableProbeLength = 8;

            [ThreadStatic]
            private static Data* _internTable;

            private static Data* InternTable
            {
                get
                {
                    if (_internTable == null)
                    {
                        _internTable = (Data*)NativeAllocator.Instance.Allocate((uint)sizeof(Data) * InternTableSize);

                        // Make sure the table is zeroed.
                        new Span<Data>(_internTable, InternTableSize).Clear();
                    }

                    return _internTable;
                }
            }

            private static Operand Make(OperandKind kind, OperandType type, ulong value, Symbol symbol = default)
            {
                Debug.Assert(kind != OperandKind.None);

                Data* data = null;

                // If constant or register, then try to look up in the intern table before allocating.
                if (kind == OperandKind.Constant || kind == OperandKind.Register)
                {
                    uint hash = (uint)HashCode.Combine(kind, type, value);

                    // Look in the next InternTableProbeLength slots for a match.
                    for (uint i = 0; i < InternTableProbeLength; i++)
                    {
<<<<<<< HEAD
                        Operand interned = new()
                        {
                            _data = &InternTable[(hash + i) % InternTableSize],
                        };
=======
                        Operand interned = new();
                        interned._data = &InternTable[(hash + i) % InternTableSize];
>>>>>>> 1ec71635b (sync with main branch)

                        // If slot matches the allocation request then return that slot.
                        if (interned.Kind == kind && interned.Type == type && interned.Value == value && interned.Symbol == symbol)
                        {
                            return interned;
                        }
                        // Otherwise if the slot is not occupied, we store in that slot.
                        else if (interned.Kind == OperandKind.None)
                        {
                            data = interned._data;

                            break;
                        }
                    }
                }

                // If we could not get a slot from the intern table, we allocate somewhere else and store there.
                if (data == null)
                {
                    data = Allocators.Operands.Allocate<Data>();
                }

                *data = default;

<<<<<<< HEAD
                Operand result = new()
                {
                    _data = data,
                    Value = value,
                    Kind = kind,
                    Type = type,
                };
=======
                Operand result = new();
                result._data = data;
                result.Value = value;
                result.Kind = kind;
                result.Type = type;
>>>>>>> 1ec71635b (sync with main branch)

                if (kind != OperandKind.Memory)
                {
                    result.Symbol = symbol;
                }

                // If local variable, then the use and def list is initialized with default sizes.
                if (kind == OperandKind.LocalVariable)
                {
                    New(ref result._data->Assignments, ref result._data->AssignmentsCount, ref result._data->AssignmentsCapacity, 1);
                    New(ref result._data->Uses, ref result._data->UsesCount, ref result._data->UsesCapacity, 4);
                }

                return result;
            }

            public static Operand Const(OperandType type, long value)
            {
                Debug.Assert(type is OperandType.I32 or OperandType.I64);

                return type == OperandType.I32 ? Const((int)value) : Const(value);
            }

            public static Operand Const(bool value)
            {
                return Const(value ? 1 : 0);
            }

            public static Operand Const(int value)
            {
                return Const((uint)value);
            }

            public static Operand Const(uint value)
            {
                return Make(OperandKind.Constant, OperandType.I32, value);
            }

            public static Operand Const(long value)
            {
                return Const(value, symbol: default);
            }

            public static Operand Const<T>(ref T reference, Symbol symbol = default)
            {
                return Const((long)Unsafe.AsPointer(ref reference), symbol);
            }

            public static Operand Const(long value, Symbol symbol)
            {
                return Make(OperandKind.Constant, OperandType.I64, (ulong)value, symbol);
            }

            public static Operand Const(ulong value)
            {
                return Make(OperandKind.Constant, OperandType.I64, value);
            }

            public static Operand ConstF(float value)
            {
                return Make(OperandKind.Constant, OperandType.FP32, (ulong)BitConverter.SingleToInt32Bits(value));
            }

            public static Operand ConstF(double value)
            {
                return Make(OperandKind.Constant, OperandType.FP64, (ulong)BitConverter.DoubleToInt64Bits(value));
            }

            public static Operand Label()
            {
                return Make(OperandKind.Label, OperandType.None, 0);
            }

            public static Operand Local(OperandType type)
            {
                return Make(OperandKind.LocalVariable, type, 0);
            }

            public static Operand Register(int index, RegisterType regType, OperandType type)
            {
                return Make(OperandKind.Register, type, (ulong)((int)regType << 24 | index));
            }

            public static Operand Undef()
            {
                return Make(OperandKind.Undefined, OperandType.None, 0);
            }

            public static Operand MemoryOp(
                OperandType type,
                Operand baseAddress,
                Operand index = default,
                Multiplier scale = Multiplier.x1,
                int displacement = 0)
            {
                Operand result = Make(OperandKind.Memory, type, 0);

                MemoryOperand memory = result.GetMemory();
                memory.BaseAddress = baseAddress;
                memory.Index = index;
                memory.Scale = scale;
                memory.Displacement = displacement;

                return result;
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
