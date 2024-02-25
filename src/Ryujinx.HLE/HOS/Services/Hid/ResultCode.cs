<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Hid
{
    enum ResultCode
    {
        ModuleId = 202,
=======
﻿namespace Ryujinx.HLE.HOS.Services.Hid
{
    enum ResultCode
    {
        ModuleId       = 202,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

        InvalidNpadDeviceType = (122 << ErrorCodeShift) | ModuleId,
<<<<<<< HEAD
        InvalidNpadIdType = (123 << ErrorCodeShift) | ModuleId,
        InvalidDeviceIndex = (124 << ErrorCodeShift) | ModuleId,
        InvalidBufferSize = (131 << ErrorCodeShift) | ModuleId,
    }
}
=======
        InvalidNpadIdType     = (123 << ErrorCodeShift) | ModuleId,
        InvalidDeviceIndex    = (124 << ErrorCodeShift) | ModuleId,
        InvalidBufferSize     = (131 << ErrorCodeShift) | ModuleId
    }
} 
>>>>>>> 1ec71635b (sync with main branch)
