<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace ARMeilleure.Translation
{
    delegate void DispatcherFunction(IntPtr nativeContext, ulong startAddress);
    delegate ulong WrapperFunction(IntPtr nativeContext, ulong startAddress);
}
