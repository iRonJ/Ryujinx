<<<<<<< HEAD
using Ryujinx.HLE.HOS.Tamper.Operations;
=======
﻿using Ryujinx.HLE.HOS.Tamper.Operations;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Tamper.CodeEmitters
{
    /// <summary>
    /// Code type 4 allows setting a register to a constant value.
    /// </summary>
    class LoadRegisterWithConstant
    {
        const int RegisterIndex = 3;
        const int ValueImmediateIndex = 8;

        const int ValueImmediateSize = 16;

        public static void Emit(byte[] instruction, CompilationContext context)
        {
            // 400R0000 VVVVVVVV VVVVVVVV
            // R: Register to use.
            // V: Value to load.

            Register destinationRegister = context.GetRegister(instruction[RegisterIndex]);
            ulong immediate = InstructionHelper.GetImmediate(instruction, ValueImmediateIndex, ValueImmediateSize);
<<<<<<< HEAD
            Value<ulong> sourceValue = new(immediate);
=======
            Value<ulong> sourceValue = new Value<ulong>(immediate);
>>>>>>> 1ec71635b (sync with main branch)

            context.CurrentOperations.Add(new OpMov<ulong>(destinationRegister, sourceValue));
        }
    }
}
