namespace Ryujinx.HLE.HOS.Services.Mnpp
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 239,
=======
        ModuleId       = 239,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        InvalidArgument = (100 << ErrorCodeShift) | ModuleId,
        InvalidBufferSize = (101 << ErrorCodeShift) | ModuleId,
    }
}
=======
        InvalidArgument   = (100 << ErrorCodeShift) | ModuleId,
        InvalidBufferSize = (101 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
