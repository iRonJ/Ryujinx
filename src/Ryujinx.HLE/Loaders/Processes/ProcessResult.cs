<<<<<<< HEAD
using LibHac.Common;
=======
﻿using LibHac.Common;
>>>>>>> 1ec71635b (sync with main branch)
using LibHac.Loader;
using LibHac.Ns;
using Ryujinx.Common.Logging;
using Ryujinx.Cpu;
using Ryujinx.HLE.HOS.SystemState;
using Ryujinx.HLE.Loaders.Processes.Extensions;
using Ryujinx.Horizon.Common;
<<<<<<< HEAD
using System;
=======
using System.Linq;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.Loaders.Processes
{
    public class ProcessResult
    {
        public static ProcessResult Failed => new(null, new BlitStruct<ApplicationControlProperty>(1), false, false, null, 0, 0, 0, TitleLanguage.AmericanEnglish);

        private readonly byte _mainThreadPriority;
        private readonly uint _mainThreadStackSize;

        public readonly IDiskCacheLoadState DiskCacheLoadState;

<<<<<<< HEAD
        public readonly MetaLoader MetaLoader;
        public readonly ApplicationControlProperty ApplicationControlProperties;

        public readonly ulong ProcessId;
        public readonly string Name;
        public readonly string DisplayVersion;
        public readonly ulong ProgramId;
        public readonly string ProgramIdText;
        public readonly bool Is64Bit;
        public readonly bool DiskCacheEnabled;
        public readonly bool AllowCodeMemoryForJit;

        public ProcessResult(
            MetaLoader metaLoader,
            BlitStruct<ApplicationControlProperty> applicationControlProperties,
            bool diskCacheEnabled,
            bool allowCodeMemoryForJit,
            IDiskCacheLoadState diskCacheLoadState,
            ulong pid,
            byte mainThreadPriority,
            uint mainThreadStackSize,
            TitleLanguage titleLanguage)
        {
            _mainThreadPriority = mainThreadPriority;
            _mainThreadStackSize = mainThreadStackSize;

            DiskCacheLoadState = diskCacheLoadState;
            ProcessId = pid;

            MetaLoader = metaLoader;
=======
        public readonly MetaLoader                 MetaLoader;
        public readonly ApplicationControlProperty ApplicationControlProperties;

        public readonly ulong  ProcessId;
        public readonly string Name;
        public readonly string DisplayVersion;
        public readonly ulong  ProgramId;
        public readonly string ProgramIdText;
        public readonly bool   Is64Bit;
        public readonly bool   DiskCacheEnabled;
        public readonly bool   AllowCodeMemoryForJit;

        public ProcessResult(
            MetaLoader                             metaLoader,
            BlitStruct<ApplicationControlProperty> applicationControlProperties,
            bool                                   diskCacheEnabled,
            bool                                   allowCodeMemoryForJit,
            IDiskCacheLoadState                    diskCacheLoadState,
            ulong                                  pid,
            byte                                   mainThreadPriority,
            uint                                   mainThreadStackSize,
            TitleLanguage                          titleLanguage)
        {
            _mainThreadPriority  = mainThreadPriority;
            _mainThreadStackSize = mainThreadStackSize;

            DiskCacheLoadState = diskCacheLoadState;
            ProcessId          = pid;

            MetaLoader                   = metaLoader;
>>>>>>> 1ec71635b (sync with main branch)
            ApplicationControlProperties = applicationControlProperties.Value;

            if (metaLoader is not null)
            {
                ulong programId = metaLoader.GetProgramId();

                Name = ApplicationControlProperties.Title[(int)titleLanguage].NameString.ToString();

                if (string.IsNullOrWhiteSpace(Name))
                {
<<<<<<< HEAD
                    Name = Array.Find(ApplicationControlProperties.Title.ItemsRo.ToArray(), x => x.Name[0] != 0).NameString.ToString();
                }

                DisplayVersion = ApplicationControlProperties.DisplayVersionString.ToString();
                ProgramId = programId;
                ProgramIdText = $"{programId:x16}";
                Is64Bit = metaLoader.IsProgram64Bit();
            }

            DiskCacheEnabled = diskCacheEnabled;
=======
                    Name = ApplicationControlProperties.Title.ItemsRo.ToArray().FirstOrDefault(x => x.Name[0] != 0).NameString.ToString();
                }

                DisplayVersion = ApplicationControlProperties.DisplayVersionString.ToString();
                ProgramId      = programId;
                ProgramIdText  = $"{programId:x16}";
                Is64Bit        = metaLoader.IsProgram64Bit();
            }

            DiskCacheEnabled      = diskCacheEnabled;
>>>>>>> 1ec71635b (sync with main branch)
            AllowCodeMemoryForJit = allowCodeMemoryForJit;
        }

        public bool Start(Switch device)
        {
            device.Configuration.ContentManager.LoadEntries(device);

            Result result = device.System.KernelContext.Processes[ProcessId].Start(_mainThreadPriority, _mainThreadStackSize);
            if (result != Result.Success)
            {
                Logger.Error?.Print(LogClass.Loader, $"Process start returned error \"{result}\".");

                return false;
            }

            // TODO: LibHac npdm currently doesn't support version field.
            string version = ProgramId > 0x0100000000007FFF ? DisplayVersion : device.System.ContentManager.GetCurrentFirmwareVersion()?.VersionString ?? "?";

            Logger.Info?.Print(LogClass.Loader, $"Application Loaded: {Name} v{version} [{ProgramIdText}] [{(Is64Bit ? "64-bit" : "32-bit")}]");

            return true;
        }
    }
}
