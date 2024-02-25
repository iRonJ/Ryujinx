namespace Ryujinx.HLE.HOS.Services.Pm
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 15,
=======
        ModuleId       = 15,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        ProcessNotFound = (1 << ErrorCodeShift) | ModuleId,
        AlreadyStarted = (2 << ErrorCodeShift) | ModuleId,
        NotTerminated = (3 << ErrorCodeShift) | ModuleId,
        DebugHookInUse = (4 << ErrorCodeShift) | ModuleId,
        ApplicationRunning = (5 << ErrorCodeShift) | ModuleId,
        InvalidSize = (6 << ErrorCodeShift) | ModuleId,
    }
}
=======
        ProcessNotFound    = (1 << ErrorCodeShift) | ModuleId,
        AlreadyStarted     = (2 << ErrorCodeShift) | ModuleId,
        NotTerminated      = (3 << ErrorCodeShift) | ModuleId,
        DebugHookInUse     = (4 << ErrorCodeShift) | ModuleId,
        ApplicationRunning = (5 << ErrorCodeShift) | ModuleId,
        InvalidSize        = (6 << ErrorCodeShift) | ModuleId,
    }
}
>>>>>>> 1ec71635b (sync with main branch)
