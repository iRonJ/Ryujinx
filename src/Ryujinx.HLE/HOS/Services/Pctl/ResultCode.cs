<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Pctl
{
    enum ResultCode
    {
        ModuleId = 142,
=======
﻿namespace Ryujinx.HLE.HOS.Services.Pctl
{
    enum ResultCode
    {
        ModuleId       = 142,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        FreeCommunicationDisabled = (101 << ErrorCodeShift) | ModuleId,
        StereoVisionDenied = (104 << ErrorCodeShift) | ModuleId,
        InvalidPid = (131 << ErrorCodeShift) | ModuleId,
        PermissionDenied = (133 << ErrorCodeShift) | ModuleId,
=======
        FreeCommunicationDisabled                   = (101 << ErrorCodeShift) | ModuleId,
        StereoVisionDenied                          = (104 << ErrorCodeShift) | ModuleId,
        InvalidPid                                  = (131 << ErrorCodeShift) | ModuleId,
        PermissionDenied                            = (133 << ErrorCodeShift) | ModuleId,
>>>>>>> 1ec71635b (sync with main branch)
        StereoVisionRestrictionConfigurableDisabled = (181 << ErrorCodeShift) | ModuleId,
    }
}
