<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Ncm.Lr
{
    enum ResultCode
    {
        ModuleId = 8,
=======
﻿namespace Ryujinx.HLE.HOS.Services.Ncm.Lr
{
    enum ResultCode
    {
        ModuleId       = 8,
>>>>>>> 1ec71635b (sync with main branch)
        ErrorCodeShift = 9,

        Success = 0,

<<<<<<< HEAD
        ProgramLocationEntryNotFound = (2 << ErrorCodeShift) | ModuleId,
        InvalidContextForControlLocation = (3 << ErrorCodeShift) | ModuleId,
        StorageNotFound = (4 << ErrorCodeShift) | ModuleId,
        AccessDenied = (5 << ErrorCodeShift) | ModuleId,
        OfflineManualHTMLLocationEntryNotFound = (6 << ErrorCodeShift) | ModuleId,
        TitleIsNotRegistered = (7 << ErrorCodeShift) | ModuleId,
        ControlLocationEntryForHostNotFound = (8 << ErrorCodeShift) | ModuleId,
        LegalInfoHTMLLocationEntryNotFound = (9 << ErrorCodeShift) | ModuleId,
        ProgramLocationForDebugEntryNotFound = (10 << ErrorCodeShift) | ModuleId,
=======
        ProgramLocationEntryNotFound           = (2  << ErrorCodeShift) | ModuleId,
        InvalidContextForControlLocation       = (3  << ErrorCodeShift) | ModuleId,
        StorageNotFound                        = (4  << ErrorCodeShift) | ModuleId,
        AccessDenied                           = (5  << ErrorCodeShift) | ModuleId,
        OfflineManualHTMLLocationEntryNotFound = (6  << ErrorCodeShift) | ModuleId,
        TitleIsNotRegistered                   = (7  << ErrorCodeShift) | ModuleId,
        ControlLocationEntryForHostNotFound    = (8  << ErrorCodeShift) | ModuleId,
        LegalInfoHTMLLocationEntryNotFound     = (9  << ErrorCodeShift) | ModuleId,
        ProgramLocationForDebugEntryNotFound   = (10 << ErrorCodeShift) | ModuleId
>>>>>>> 1ec71635b (sync with main branch)
    }
}
