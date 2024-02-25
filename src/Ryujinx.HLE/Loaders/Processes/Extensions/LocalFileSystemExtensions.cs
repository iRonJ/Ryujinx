<<<<<<< HEAD
using LibHac.Common;
using LibHac.FsSystem;
using LibHac.Loader;
using LibHac.Ncm;
using LibHac.Ns;
using Ryujinx.HLE.HOS;
using Ryujinx.HLE.Loaders.Processes.Extensions;
=======
﻿using LibHac.Common;
using LibHac.FsSystem;
using LibHac.Loader;
using LibHac.Ns;
using Ryujinx.HLE.HOS;
using Ryujinx.HLE.Loaders.Processes.Extensions;
using ApplicationId = LibHac.Ncm.ApplicationId;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.Loaders.Processes
{
    static class LocalFileSystemExtensions
    {
        public static ProcessResult Load(this LocalFileSystem exeFs, Switch device, string romFsPath = "")
        {
            MetaLoader metaLoader = exeFs.GetNpdm();
<<<<<<< HEAD
            var nacpData = new BlitStruct<ApplicationControlProperty>(1);
            ulong programId = metaLoader.GetProgramId();

            device.Configuration.VirtualFileSystem.ModLoader.CollectMods(new[] { programId });
=======
            var        nacpData   = new BlitStruct<ApplicationControlProperty>(1);
            ulong      programId  = metaLoader.GetProgramId();

            device.Configuration.VirtualFileSystem.ModLoader.CollectMods(
                new[] { programId },
                ModLoader.GetModsBasePath(),
                ModLoader.GetSdModsBasePath());
>>>>>>> 1ec71635b (sync with main branch)

            if (programId != 0)
            {
                ProcessLoaderHelper.EnsureSaveData(device, new ApplicationId(programId), nacpData);
            }

<<<<<<< HEAD
            ProcessResult processResult = exeFs.Load(device, nacpData, metaLoader, 0);
=======
            ProcessResult processResult = exeFs.Load(device, nacpData, metaLoader);
>>>>>>> 1ec71635b (sync with main branch)

            // Load RomFS.
            if (!string.IsNullOrEmpty(romFsPath))
            {
                device.Configuration.VirtualFileSystem.LoadRomFs(processResult.ProcessId, romFsPath);
            }

            return processResult;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
