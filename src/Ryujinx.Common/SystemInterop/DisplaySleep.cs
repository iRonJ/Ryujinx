using System;
using System.Runtime.InteropServices;

namespace Ryujinx.Common.SystemInterop
{
    public partial class DisplaySleep
    {
        [Flags]
        enum EXECUTION_STATE : uint
        {
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
<<<<<<< HEAD
            ES_SYSTEM_REQUIRED = 0x00000001,
=======
            ES_SYSTEM_REQUIRED = 0x00000001
>>>>>>> 1ec71635b (sync with main branch)
        }

        [LibraryImport("kernel32.dll", SetLastError = true)]
        private static partial EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        static public void Prevent()
        {
            if (OperatingSystem.IsWindows())
            {
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_SYSTEM_REQUIRED | EXECUTION_STATE.ES_DISPLAY_REQUIRED);
            }
        }
<<<<<<< HEAD

=======
        
>>>>>>> 1ec71635b (sync with main branch)
        static public void Restore()
        {
            if (OperatingSystem.IsWindows())
            {
<<<<<<< HEAD
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
=======
                SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);  
>>>>>>> 1ec71635b (sync with main branch)
            }
        }
    }
}
