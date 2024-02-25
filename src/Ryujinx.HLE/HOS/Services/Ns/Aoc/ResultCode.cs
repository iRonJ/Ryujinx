namespace Ryujinx.HLE.HOS.Services.Ns.Aoc
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 166,
=======
        ModuleId       = 166,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

        InvalidBufferSize = (200 << ErrorCodeShift) | ModuleId,
<<<<<<< HEAD
        InvalidPid = (300 << ErrorCodeShift) | ModuleId,
    }
}
=======
        InvalidPid        = (300 << ErrorCodeShift) | ModuleId
    }
}
>>>>>>> 1ec71635b (sync with main branch)
