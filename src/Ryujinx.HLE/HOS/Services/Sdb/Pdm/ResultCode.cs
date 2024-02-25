<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Sdb.Pdm
{
    enum ResultCode
    {
        ModuleId = 178,
=======
﻿namespace Ryujinx.HLE.HOS.Services.Sdb.Pdm
{
    enum ResultCode
    {
        ModuleId       = 178,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        InvalidUserID = (100 << ErrorCodeShift) | ModuleId,
        UserNotFound = (101 << ErrorCodeShift) | ModuleId,
        ServiceUnavailable = (150 << ErrorCodeShift) | ModuleId,
        FileStorageFailure = (200 << ErrorCodeShift) | ModuleId,
=======
        InvalidUserID      = (100 << ErrorCodeShift) | ModuleId,
        UserNotFound       = (101 << ErrorCodeShift) | ModuleId,
        ServiceUnavailable = (150 << ErrorCodeShift) | ModuleId,
        FileStorageFailure = (200 << ErrorCodeShift) | ModuleId
>>>>>>> 1ec71635b (sync with main branch)
    }
}
