<<<<<<< HEAD
using Ryujinx.HLE.Exceptions;
=======
﻿using Ryujinx.HLE.Exceptions;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Tamper.Conditions;
using Ryujinx.HLE.HOS.Tamper.Operations;
using System;
using System.Globalization;

namespace Ryujinx.HLE.HOS.Tamper
{
    class InstructionHelper
    {
        private const int CodeTypeIndex = 0;

        public static void Emit(IOperation operation, CompilationContext context)
        {
            context.CurrentOperations.Add(operation);
        }

        public static void Emit(Type instruction, byte width, CompilationContext context, params Object[] operands)
        {
            Emit((IOperation)Create(instruction, width, operands), context);
        }

        public static void EmitMov(byte width, CompilationContext context, IOperand destination, IOperand source)
        {
            Emit(typeof(OpMov<>), width, context, destination, source);
        }

        public static ICondition CreateCondition(Comparison comparison, byte width, IOperand lhs, IOperand rhs)
        {
            ICondition Create(Type conditionType)
            {
                return (ICondition)InstructionHelper.Create(conditionType, width, lhs, rhs);
            }

<<<<<<< HEAD
            return comparison switch
            {
                Comparison.Greater => Create(typeof(CondGT<>)),
                Comparison.GreaterOrEqual => Create(typeof(CondGE<>)),
                Comparison.Less => Create(typeof(CondLT<>)),
                Comparison.LessOrEqual => Create(typeof(CondLE<>)),
                Comparison.Equal => Create(typeof(CondEQ<>)),
                Comparison.NotEqual => Create(typeof(CondNE<>)),
                _ => throw new TamperCompilationException($"Invalid comparison {comparison} in Atmosphere cheat"),
            };
=======
            switch (comparison)
            {
                case Comparison.Greater       : return Create(typeof(CondGT<>));
                case Comparison.GreaterOrEqual: return Create(typeof(CondGE<>));
                case Comparison.Less          : return Create(typeof(CondLT<>));
                case Comparison.LessOrEqual   : return Create(typeof(CondLE<>));
                case Comparison.Equal         : return Create(typeof(CondEQ<>));
                case Comparison.NotEqual      : return Create(typeof(CondNE<>));
                default:
                    throw new TamperCompilationException($"Invalid comparison {comparison} in Atmosphere cheat");
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        public static Object Create(Type instruction, byte width, params Object[] operands)
        {
<<<<<<< HEAD
            Type realType = width switch
            {
                1 => instruction.MakeGenericType(typeof(byte)),
                2 => instruction.MakeGenericType(typeof(ushort)),
                4 => instruction.MakeGenericType(typeof(uint)),
                8 => instruction.MakeGenericType(typeof(ulong)),
                _ => throw new TamperCompilationException($"Invalid instruction width {width} in Atmosphere cheat"),
            };
=======
            Type realType;

            switch (width)
            {
                case 1: realType = instruction.MakeGenericType(typeof(byte)); break;
                case 2: realType = instruction.MakeGenericType(typeof(ushort)); break;
                case 4: realType = instruction.MakeGenericType(typeof(uint)); break;
                case 8: realType = instruction.MakeGenericType(typeof(ulong)); break;
                default:
                    throw new TamperCompilationException($"Invalid instruction width {width} in Atmosphere cheat");
            }

>>>>>>> 1ec71635b (sync with main branch)
            return Activator.CreateInstance(realType, operands);
        }

        public static ulong GetImmediate(byte[] instruction, int index, int nybbleCount)
        {
            ulong value = 0;

            for (int i = 0; i < nybbleCount; i++)
            {
                value <<= 4;
                value |= instruction[index + i];
            }

            return value;
        }

        public static CodeType GetCodeType(byte[] instruction)
        {
            int codeType = instruction[CodeTypeIndex];

            if (codeType >= 0xC)
            {
                byte extension = instruction[CodeTypeIndex + 1];
                codeType = (codeType << 4) | extension;

                if (extension == 0xF)
                {
                    extension = instruction[CodeTypeIndex + 2];
                    codeType = (codeType << 4) | extension;
                }
            }

            return (CodeType)codeType;
        }

        public static byte[] ParseRawInstruction(string rawInstruction)
        {
<<<<<<< HEAD
            const int WordSize = 2 * sizeof(uint);
=======
            const int wordSize = 2 * sizeof(uint);
>>>>>>> 1ec71635b (sync with main branch)

            // Instructions are multi-word, with 32bit words. Split the raw instruction
            // and parse each word into individual nybbles of bits.

            var words = rawInstruction.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

<<<<<<< HEAD
            byte[] instruction = new byte[WordSize * words.Length];
=======
            byte[] instruction = new byte[wordSize * words.Length];
>>>>>>> 1ec71635b (sync with main branch)

            if (words.Length == 0)
            {
                throw new TamperCompilationException("Empty instruction in Atmosphere cheat");
            }

            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
                string word = words[wordIndex];

<<<<<<< HEAD
                if (word.Length != WordSize)
=======
                if (word.Length != wordSize)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    throw new TamperCompilationException($"Invalid word length for {word} in Atmosphere cheat");
                }

<<<<<<< HEAD
                for (int nybbleIndex = 0; nybbleIndex < WordSize; nybbleIndex++)
                {
                    int index = wordIndex * WordSize + nybbleIndex;
=======
                for (int nybbleIndex = 0; nybbleIndex < wordSize; nybbleIndex++)
                {
                    int index = wordIndex * wordSize + nybbleIndex;
>>>>>>> 1ec71635b (sync with main branch)

                    instruction[index] = byte.Parse(word.AsSpan(nybbleIndex, 1), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }
            }

            return instruction;
        }
    }
}
