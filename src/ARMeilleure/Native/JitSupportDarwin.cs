using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace ARMeilleure.Native
{
    [SupportedOSPlatform("macos")]
<<<<<<< HEAD
    static partial class JitSupportDarwin
=======
    public static partial class JitSupportDarwin
>>>>>>> 1ec71635b (sync with main branch)
    {
        [LibraryImport("libarmeilleure-jitsupport", EntryPoint = "armeilleure_jit_memcpy")]
        public static partial void Copy(IntPtr dst, IntPtr src, ulong n);
    }
}
