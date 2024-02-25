namespace Ryujinx.HLE.HOS.Services.Sm
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 21,
=======
        ModuleId       = 21,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        NotInitialized = (2 << ErrorCodeShift) | ModuleId,
        AlreadyRegistered = (4 << ErrorCodeShift) | ModuleId,
        InvalidName = (6 << ErrorCodeShift) | ModuleId,
        NotRegistered = (7 << ErrorCodeShift) | ModuleId,
    }
}
=======
        NotInitialized    = (2 << ErrorCodeShift) | ModuleId,
        AlreadyRegistered = (4 << ErrorCodeShift) | ModuleId,
        InvalidName       = (6 << ErrorCodeShift) | ModuleId,
        NotRegistered     = (7 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
