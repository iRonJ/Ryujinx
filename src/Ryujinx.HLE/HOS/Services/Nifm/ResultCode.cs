namespace Ryujinx.HLE.HOS.Services.Nifm
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 110,
=======
        ModuleId       = 110,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        Unknown112 = (112 << ErrorCodeShift) | ModuleId, // IRequest::GetResult
        Unknown180 = (180 << ErrorCodeShift) | ModuleId, // IRequest::GetAppletInfo
        NoInternetConnection = (300 << ErrorCodeShift) | ModuleId,
        ObjectIsNull = (350 << ErrorCodeShift) | ModuleId,
    }
}
=======
        Unknown112           = (112 << ErrorCodeShift) | ModuleId, // IRequest::GetResult
        Unknown180           = (180 << ErrorCodeShift) | ModuleId, // IRequest::GetAppletInfo
        NoInternetConnection = (300 << ErrorCodeShift) | ModuleId,
        ObjectIsNull         = (350 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
