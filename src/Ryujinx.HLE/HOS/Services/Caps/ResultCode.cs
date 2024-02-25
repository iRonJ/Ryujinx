<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Caps
{
    enum ResultCode
    {
        ModuleId = 206,
=======
﻿namespace Ryujinx.HLE.HOS.Services.Caps
{
    enum ResultCode
    {
        ModuleId       = 206,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        InvalidArgument = (2 << ErrorCodeShift) | ModuleId,
        ShimLibraryVersionAlreadySet = (7 << ErrorCodeShift) | ModuleId,
        OutOfRange = (8 << ErrorCodeShift) | ModuleId,
        InvalidContentType = (14 << ErrorCodeShift) | ModuleId,
        NullOutputBuffer = (141 << ErrorCodeShift) | ModuleId,
        NullInputBuffer = (142 << ErrorCodeShift) | ModuleId,
        BlacklistedPid = (822 << ErrorCodeShift) | ModuleId,
    }
}
=======
        InvalidArgument              = (2   << ErrorCodeShift) | ModuleId,
        ShimLibraryVersionAlreadySet = (7   << ErrorCodeShift) | ModuleId,
        OutOfRange                   = (8   << ErrorCodeShift) | ModuleId,
        InvalidContentType           = (14  << ErrorCodeShift) | ModuleId,
        NullOutputBuffer             = (141 << ErrorCodeShift) | ModuleId,
        NullInputBuffer              = (142 << ErrorCodeShift) | ModuleId,
        BlacklistedPid               = (822 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
