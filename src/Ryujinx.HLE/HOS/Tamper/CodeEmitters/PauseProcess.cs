<<<<<<< HEAD
using Ryujinx.HLE.HOS.Tamper.Operations;
=======
﻿using Ryujinx.HLE.HOS.Tamper.Operations;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Tamper.CodeEmitters
{
    /// <summary>
    /// Code type 0xFF0 pauses the current process.
    /// </summary>
    class PauseProcess
    {
        // FF0?????

        public static void Emit(byte[] instruction, CompilationContext context)
        {
            context.CurrentOperations.Add(new OpProcCtrl(context.Process, true));
        }
    }
}
