<<<<<<< HEAD
namespace Ryujinx.HLE.HOS
{
    public enum ResultCode
    {
        OsModuleId = 3,
=======
﻿namespace Ryujinx.HLE.HOS
{
    public enum ResultCode
    {
        OsModuleId     = 3,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        NotAllocated = (1023 << ErrorCodeShift) | OsModuleId,
    }
}
=======
        NotAllocated = (1023 << ErrorCodeShift) | OsModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
