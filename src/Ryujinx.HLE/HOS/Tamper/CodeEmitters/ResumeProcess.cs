<<<<<<< HEAD
using Ryujinx.HLE.HOS.Tamper.Operations;
=======
﻿using Ryujinx.HLE.HOS.Tamper.Operations;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Tamper.CodeEmitters
{
    /// <summary>
    /// Code type 0xFF1 resumes the current process.
    /// </summary>
    class ResumeProcess
    {
        // FF1?????
<<<<<<< HEAD
=======

>>>>>>> 1ec71635b (sync with main branch)
        public static void Emit(byte[] instruction, CompilationContext context)
        {
            context.CurrentOperations.Add(new OpProcCtrl(context.Process, false));
        }
    }
}
