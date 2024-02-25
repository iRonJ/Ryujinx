<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Tamper.CodeEmitters
=======
﻿namespace Ryujinx.HLE.HOS.Tamper.CodeEmitters
>>>>>>> 1ec71635b (sync with main branch)
{
    /// <summary>
    /// Marks the begin of a conditional block (started by Code Type 1, Code Type 8 or Code Type C0).
    /// </summary>
    class BeginConditionalBlock
    {
        public static void Emit(byte[] instruction, CompilationContext context)
        {
            // Just start a new compilation block and parse the instruction itself at the end.
            context.BlockStack.Push(new OperationBlock(instruction));
        }
    }
}
