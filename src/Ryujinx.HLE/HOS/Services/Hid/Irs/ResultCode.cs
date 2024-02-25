<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Hid.Irs
{
    public enum ResultCode
    {
        ModuleId = 205,
=======
﻿namespace Ryujinx.HLE.HOS.Services.Hid.Irs
{
    public enum ResultCode
    {
        ModuleId       = 205,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

        InvalidCameraHandle = (204 << ErrorCodeShift) | ModuleId,
<<<<<<< HEAD
        InvalidBufferSize = (207 << ErrorCodeShift) | ModuleId,
        HandlePointerIsNull = (212 << ErrorCodeShift) | ModuleId,
        NpadIdOutOfRange = (709 << ErrorCodeShift) | ModuleId,
    }
}
=======
        InvalidBufferSize   = (207 << ErrorCodeShift) | ModuleId,
        HandlePointerIsNull = (212 << ErrorCodeShift) | ModuleId,
        NpadIdOutOfRange    = (709 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
