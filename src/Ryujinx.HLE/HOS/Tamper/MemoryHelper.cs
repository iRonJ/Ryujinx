<<<<<<< HEAD
using Ryujinx.HLE.Exceptions;
=======
﻿using Ryujinx.HLE.Exceptions;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.HLE.HOS.Tamper.Operations;

namespace Ryujinx.HLE.HOS.Tamper
{
    class MemoryHelper
    {
        public static ulong GetAddressShift(MemoryRegion source, CompilationContext context)
        {
<<<<<<< HEAD
            return source switch
            {
                // Memory address is relative to the code start.
                MemoryRegion.NSO => context.ExeAddress,
                // Memory address is relative to the heap.
                MemoryRegion.Heap => context.HeapAddress,
                // Memory address is relative to the alias region.
                MemoryRegion.Alias => context.AliasAddress,
                // Memory address is relative to the asrl region, which matches the code region.
                MemoryRegion.Asrl => context.AslrAddress,
                _ => throw new TamperCompilationException($"Invalid memory source {source} in Atmosphere cheat"),
            };
=======
            switch (source)
            {
                case MemoryRegion.NSO:
                    // Memory address is relative to the code start.
                    return context.ExeAddress;
                case MemoryRegion.Heap:
                    // Memory address is relative to the heap.
                    return context.HeapAddress;
                case MemoryRegion.Alias:
                    // Memory address is relative to the alias region.
                    return context.AliasAddress;
                case MemoryRegion.Asrl:
                    // Memory address is relative to the asrl region, which matches the code region.
                    return context.AslrAddress;
                default:
                    throw new TamperCompilationException($"Invalid memory source {source} in Atmosphere cheat");
            }
>>>>>>> 1ec71635b (sync with main branch)
        }

        private static void EmitAdd(Value<ulong> finalValue, IOperand firstOperand, IOperand secondOperand, CompilationContext context)
        {
            context.CurrentOperations.Add(new OpAdd<ulong>(finalValue, firstOperand, secondOperand));
        }

        public static Pointer EmitPointer(ulong addressImmediate, CompilationContext context)
        {
<<<<<<< HEAD
            Value<ulong> addressImmediateValue = new(addressImmediate);
=======
            Value<ulong> addressImmediateValue = new Value<ulong>(addressImmediate);
>>>>>>> 1ec71635b (sync with main branch)

            return new Pointer(addressImmediateValue, context.Process);
        }

        public static Pointer EmitPointer(Register addressRegister, CompilationContext context)
        {
            return new Pointer(addressRegister, context.Process);
        }

        public static Pointer EmitPointer(Register addressRegister, ulong offsetImmediate, CompilationContext context)
        {
<<<<<<< HEAD
            Value<ulong> offsetImmediateValue = new(offsetImmediate);
            Value<ulong> finalAddressValue = new(0);
=======
            Value<ulong> offsetImmediateValue = new Value<ulong>(offsetImmediate);
            Value<ulong> finalAddressValue = new Value<ulong>(0);
>>>>>>> 1ec71635b (sync with main branch)
            EmitAdd(finalAddressValue, addressRegister, offsetImmediateValue, context);

            return new Pointer(finalAddressValue, context.Process);
        }

        public static Pointer EmitPointer(Register addressRegister, Register offsetRegister, CompilationContext context)
        {
<<<<<<< HEAD
            Value<ulong> finalAddressValue = new(0);
=======
            Value<ulong> finalAddressValue = new Value<ulong>(0);
>>>>>>> 1ec71635b (sync with main branch)
            EmitAdd(finalAddressValue, addressRegister, offsetRegister, context);

            return new Pointer(finalAddressValue, context.Process);
        }

        public static Pointer EmitPointer(Register addressRegister, Register offsetRegister, ulong offsetImmediate, CompilationContext context)
        {
<<<<<<< HEAD
            Value<ulong> offsetImmediateValue = new(offsetImmediate);
            Value<ulong> finalOffsetValue = new(0);
            EmitAdd(finalOffsetValue, offsetRegister, offsetImmediateValue, context);
            Value<ulong> finalAddressValue = new(0);
=======
            Value<ulong> offsetImmediateValue = new Value<ulong>(offsetImmediate);
            Value<ulong> finalOffsetValue = new Value<ulong>(0);
            EmitAdd(finalOffsetValue, offsetRegister, offsetImmediateValue, context);
            Value<ulong> finalAddressValue = new Value<ulong>(0);
>>>>>>> 1ec71635b (sync with main branch)
            EmitAdd(finalAddressValue, addressRegister, finalOffsetValue, context);

            return new Pointer(finalAddressValue, context.Process);
        }

        public static Pointer EmitPointer(MemoryRegion memoryRegion, ulong offsetImmediate, CompilationContext context)
        {
            offsetImmediate += GetAddressShift(memoryRegion, context);

            return EmitPointer(offsetImmediate, context);
        }

        public static Pointer EmitPointer(MemoryRegion memoryRegion, Register offsetRegister, CompilationContext context)
        {
            ulong offsetImmediate = GetAddressShift(memoryRegion, context);

            return EmitPointer(offsetRegister, offsetImmediate, context);
        }

        public static Pointer EmitPointer(MemoryRegion memoryRegion, Register offsetRegister, ulong offsetImmediate, CompilationContext context)
        {
            offsetImmediate += GetAddressShift(memoryRegion, context);

            return EmitPointer(offsetRegister, offsetImmediate, context);
        }
    }
}
