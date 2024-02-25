using System;

namespace ARMeilleure.IntermediateRepresentation
{
    enum OperandType
    {
        None,
        I32,
        I64,
        FP32,
        FP64,
<<<<<<< HEAD
        V128,
=======
        V128
>>>>>>> 1ec71635b (sync with main branch)
    }

    static class OperandTypeExtensions
    {
        public static bool IsInteger(this OperandType type)
        {
            return type == OperandType.I32 ||
                   type == OperandType.I64;
        }

        public static RegisterType ToRegisterType(this OperandType type)
        {
<<<<<<< HEAD
            return type switch
            {
                OperandType.FP32 => RegisterType.Vector,
                OperandType.FP64 => RegisterType.Vector,
                OperandType.I32 => RegisterType.Integer,
                OperandType.I64 => RegisterType.Integer,
                OperandType.V128 => RegisterType.Vector,
                _ => throw new InvalidOperationException($"Invalid operand type \"{type}\"."),
            };
=======
            switch (type)
            {
                case OperandType.FP32: return RegisterType.Vector;
                case OperandType.FP64: return RegisterType.Vector;
                case OperandType.I32:  return RegisterType.Integer;
                case OperandType.I64:  return RegisterType.Integer;
                case OperandType.V128: return RegisterType.Vector;
            }

            throw new InvalidOperationException($"Invalid operand type \"{type}\".");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static int GetSizeInBytes(this OperandType type)
        {
<<<<<<< HEAD
            return type switch
            {
                OperandType.FP32 => 4,
                OperandType.FP64 => 8,
                OperandType.I32 => 4,
                OperandType.I64 => 8,
                OperandType.V128 => 16,
                _ => throw new InvalidOperationException($"Invalid operand type \"{type}\"."),
            };
=======
            switch (type)
            {
                case OperandType.FP32: return 4;
                case OperandType.FP64: return 8;
                case OperandType.I32:  return 4;
                case OperandType.I64:  return 8;
                case OperandType.V128: return 16;
            }

            throw new InvalidOperationException($"Invalid operand type \"{type}\".");
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static int GetSizeInBytesLog2(this OperandType type)
        {
<<<<<<< HEAD
            return type switch
            {
                OperandType.FP32 => 2,
                OperandType.FP64 => 3,
                OperandType.I32 => 2,
                OperandType.I64 => 3,
                OperandType.V128 => 4,
                _ => throw new InvalidOperationException($"Invalid operand type \"{type}\"."),
            };
        }
    }
}
=======
            switch (type)
            {
                case OperandType.FP32: return 2;
                case OperandType.FP64: return 3;
                case OperandType.I32:  return 2;
                case OperandType.I64:  return 3;
                case OperandType.V128: return 4;
            }

            throw new InvalidOperationException($"Invalid operand type \"{type}\".");
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
