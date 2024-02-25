using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ARMeilleure.IntermediateRepresentation
{
<<<<<<< HEAD
    readonly unsafe struct MemoryOperand
    {
        private struct Data
        {
#pragma warning disable CS0649 // Field is never assigned to
=======
    unsafe struct MemoryOperand
    {
        private struct Data
        {
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
            public byte Kind;
            public byte Type;
#pragma warning restore CS0649
            public byte Scale;
            public Operand BaseAddress;
            public Operand Index;
            public int Displacement;
        }

<<<<<<< HEAD
        private readonly Data* _data;
=======
        private Data* _data;
>>>>>>> 1ec71635b (sync with main branch)

        public MemoryOperand(Operand operand)
        {
            Debug.Assert(operand.Kind == OperandKind.Memory);

            _data = (Data*)Unsafe.As<Operand, IntPtr>(ref operand);
        }

        public Operand BaseAddress
        {
            get => _data->BaseAddress;
<<<<<<< HEAD
            set => _data->BaseAddress = value;
=======
            set => _data->BaseAddress = value; 
>>>>>>> 1ec71635b (sync with main branch)
        }

        public Operand Index
        {
            get => _data->Index;
<<<<<<< HEAD
            set => _data->Index = value;
=======
            set => _data->Index = value; 
>>>>>>> 1ec71635b (sync with main branch)
        }

        public Multiplier Scale
        {
            get => (Multiplier)_data->Scale;
            set => _data->Scale = (byte)value;
        }

        public int Displacement
        {
            get => _data->Displacement;
            set => _data->Displacement = value;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
