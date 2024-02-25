namespace Ryujinx.HLE.HOS.Services.Olsc
{
    enum ResultCode
    {
<<<<<<< HEAD
        ModuleId = 179,
=======
        ModuleId       = 179,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        NullArgument = (100 << ErrorCodeShift) | ModuleId,
        NotInitialized = (101 << ErrorCodeShift) | ModuleId,
=======
        NullArgument   = (100 << ErrorCodeShift) | ModuleId,
        NotInitialized = (101 << ErrorCodeShift) | ModuleId
>>>>>>> 1ec71635b (sync with main branch)
    }
}
