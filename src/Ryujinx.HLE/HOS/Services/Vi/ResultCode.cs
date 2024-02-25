namespace Ryujinx.HLE.HOS.Services.Vi
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 114,
=======
        ModuleId       = 114,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        InvalidArguments = (1 << ErrorCodeShift) | ModuleId,
        InvalidLayerSize = (4 << ErrorCodeShift) | ModuleId,
        PermissionDenied = (5 << ErrorCodeShift) | ModuleId,
        InvalidScalingMode = (6 << ErrorCodeShift) | ModuleId,
        InvalidValue = (7 << ErrorCodeShift) | ModuleId,
        AlreadyOpened = (9 << ErrorCodeShift) | ModuleId,
    }
}
=======
        InvalidArguments   = (1 << ErrorCodeShift) | ModuleId,
        InvalidLayerSize   = (4 << ErrorCodeShift) | ModuleId,
        PermissionDenied   = (5 << ErrorCodeShift) | ModuleId,
        InvalidScalingMode = (6 << ErrorCodeShift) | ModuleId,
        InvalidValue       = (7 << ErrorCodeShift) | ModuleId,
        AlreadyOpened      = (9 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
