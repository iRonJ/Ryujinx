namespace Ryujinx.HLE.HOS.Services.Fs
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 2,
=======
        ModuleId       = 2,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        PathDoesNotExist = (1 << ErrorCodeShift) | ModuleId,
        PathAlreadyExists = (2 << ErrorCodeShift) | ModuleId,
        PathAlreadyInUse = (7 << ErrorCodeShift) | ModuleId,
        PartitionNotFound = (1001 << ErrorCodeShift) | ModuleId,
        InvalidInput = (6001 << ErrorCodeShift) | ModuleId,
    }
}
=======
        PathDoesNotExist  = (1    << ErrorCodeShift) | ModuleId,
        PathAlreadyExists = (2    << ErrorCodeShift) | ModuleId,
        PathAlreadyInUse  = (7    << ErrorCodeShift) | ModuleId,
        PartitionNotFound = (1001 << ErrorCodeShift) | ModuleId,
        InvalidInput      = (6001 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
