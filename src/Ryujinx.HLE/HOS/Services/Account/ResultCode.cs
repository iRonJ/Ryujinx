namespace Ryujinx.HLE.HOS.Services.Account
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 124,
=======
        ModuleId       = 124,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        NullArgument = (20 << ErrorCodeShift) | ModuleId,
        InvalidArgument = (22 << ErrorCodeShift) | ModuleId,
        NullInputBuffer = (30 << ErrorCodeShift) | ModuleId,
        InvalidBufferSize = (31 << ErrorCodeShift) | ModuleId,
        InvalidBuffer = (32 << ErrorCodeShift) | ModuleId,
        AsyncExecutionNotInitialized = (40 << ErrorCodeShift) | ModuleId,
        Unknown41 = (41 << ErrorCodeShift) | ModuleId,
        InternetRequestDenied = (59 << ErrorCodeShift) | ModuleId,
        UserNotFound = (100 << ErrorCodeShift) | ModuleId,
        NullObject = (302 << ErrorCodeShift) | ModuleId,
        Unknown341 = (341 << ErrorCodeShift) | ModuleId,
        MissingNetworkServiceLicenseKind = (400 << ErrorCodeShift) | ModuleId,
        InvalidIdTokenCacheBufferSize = (451 << ErrorCodeShift) | ModuleId,
=======
        NullArgument                     = (20  << ErrorCodeShift) | ModuleId,
        InvalidArgument                  = (22  << ErrorCodeShift) | ModuleId,
        NullInputBuffer                  = (30  << ErrorCodeShift) | ModuleId,
        InvalidBufferSize                = (31  << ErrorCodeShift) | ModuleId,
        InvalidBuffer                    = (32  << ErrorCodeShift) | ModuleId,
        AsyncExecutionNotInitialized     = (40  << ErrorCodeShift) | ModuleId,
        Unknown41                        = (41  << ErrorCodeShift) | ModuleId,
        InternetRequestDenied            = (59  << ErrorCodeShift) | ModuleId,
        UserNotFound                     = (100 << ErrorCodeShift) | ModuleId,
        NullObject                       = (302 << ErrorCodeShift) | ModuleId,
        Unknown341                       = (341 << ErrorCodeShift) | ModuleId,
        MissingNetworkServiceLicenseKind = (400 << ErrorCodeShift) | ModuleId,
        InvalidIdTokenCacheBufferSize    = (451 << ErrorCodeShift) | ModuleId
>>>>>>> 1ec71635b (sync with main branch)
    }
}
