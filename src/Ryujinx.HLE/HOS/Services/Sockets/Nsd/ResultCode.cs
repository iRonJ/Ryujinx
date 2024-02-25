namespace Ryujinx.HLE.HOS.Services.Sockets.Nsd
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 141,
=======
        ModuleId       = 141,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        InvalidSettingsValue = (1 << ErrorCodeShift) | ModuleId,
        InvalidObject1 = (3 << ErrorCodeShift) | ModuleId,
        InvalidObject2 = (4 << ErrorCodeShift) | ModuleId,
        NullOutputObject = (5 << ErrorCodeShift) | ModuleId,
        SettingsNotLoaded = (6 << ErrorCodeShift) | ModuleId,
        InvalidArgument = (8 << ErrorCodeShift) | ModuleId,
        SettingsNotInitialized = (10 << ErrorCodeShift) | ModuleId,
        ServiceNotInitialized = (400 << ErrorCodeShift) | ModuleId,
    }
}
=======
        InvalidSettingsValue   = (  1 << ErrorCodeShift) | ModuleId,
        InvalidObject1         = (  3 << ErrorCodeShift) | ModuleId,
        InvalidObject2         = (  4 << ErrorCodeShift) | ModuleId,
        NullOutputObject       = (  5 << ErrorCodeShift) | ModuleId,
        SettingsNotLoaded      = (  6 << ErrorCodeShift) | ModuleId,
        InvalidArgument        = (  8 << ErrorCodeShift) | ModuleId,
        SettingsNotInitialized = ( 10 << ErrorCodeShift) | ModuleId,
        ServiceNotInitialized  = (400 << ErrorCodeShift) | ModuleId,
    }
}
>>>>>>> 1ec71635b (sync with main branch)
