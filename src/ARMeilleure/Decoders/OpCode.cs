using ARMeilleure.IntermediateRepresentation;
using System;

namespace ARMeilleure.Decoders
{
    class OpCode : IOpCode
    {
<<<<<<< HEAD
        public ulong Address { get; }
        public int RawOpCode { get; }
=======
        public ulong Address   { get; }
        public int   RawOpCode { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public int OpCodeSizeInBytes { get; protected set; } = 4;

        public InstDescriptor Instruction { get; protected set; }

        public RegisterSize RegisterSize { get; protected set; }

<<<<<<< HEAD
        public static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new(inst, address, opCode);
=======
        public static OpCode Create(InstDescriptor inst, ulong address, int opCode) => new OpCode(inst, address, opCode);
>>>>>>> 1ec71635b (sync with main branch)

        public OpCode(InstDescriptor inst, ulong address, int opCode)
        {
            Instruction = inst;
<<<<<<< HEAD
            Address = address;
            RawOpCode = opCode;
=======
            Address     = address;
            RawOpCode   = opCode;
>>>>>>> 1ec71635b (sync with main branch)

            RegisterSize = RegisterSize.Int64;
        }

        public int GetPairsCount() => GetBitsCount() / 16;
        public int GetBytesCount() => GetBitsCount() / 8;

        public int GetBitsCount()
        {
<<<<<<< HEAD
            return RegisterSize switch
            {
                RegisterSize.Int32 => 32,
                RegisterSize.Int64 => 64,
                RegisterSize.Simd64 => 64,
                RegisterSize.Simd128 => 128,
                _ => throw new InvalidOperationException(),
            };
=======
            switch (RegisterSize)
            {
                case RegisterSize.Int32:   return 32;
                case RegisterSize.Int64:   return 64;
                case RegisterSize.Simd64:  return 64;
                case RegisterSize.Simd128: return 128;
            }

            throw new InvalidOperationException();
>>>>>>> 1ec71635b (sync with main branch)
        }

        public OperandType GetOperandType()
        {
            return RegisterSize == RegisterSize.Int32 ? OperandType.I32 : OperandType.I64;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
