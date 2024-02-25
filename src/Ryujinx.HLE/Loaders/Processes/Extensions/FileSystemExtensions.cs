<<<<<<< HEAD
using LibHac.Common;
=======
﻿using LibHac.Common;
>>>>>>> 1ec71635b (sync with main branch)
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.Loader;
using LibHac.Ns;
using LibHac.Tools.FsSystem;
using Ryujinx.Common.Configuration;
using Ryujinx.Common.Logging;
using Ryujinx.HLE.Loaders.Executables;
using Ryujinx.Memory;
<<<<<<< HEAD
using System;
=======
>>>>>>> 1ec71635b (sync with main branch)
using System.Linq;
using static Ryujinx.HLE.HOS.ModLoader;

namespace Ryujinx.HLE.Loaders.Processes.Extensions
{
    static class FileSystemExtensions
    {
        public static MetaLoader GetNpdm(this IFileSystem fileSystem)
        {
            MetaLoader metaLoader = new();

            if (fileSystem == null || !fileSystem.FileExists(ProcessConst.MainNpdmPath))
            {
                Logger.Warning?.Print(LogClass.Loader, "NPDM file not found, using default values!");

                metaLoader.LoadDefault();
            }
            else
            {
                metaLoader.LoadFromFile(fileSystem);
            }

            return metaLoader;
        }

<<<<<<< HEAD
        public static ProcessResult Load(this IFileSystem exeFs, Switch device, BlitStruct<ApplicationControlProperty> nacpData, MetaLoader metaLoader, byte programIndex, bool isHomebrew = false)
=======
        public static ProcessResult Load(this IFileSystem exeFs, Switch device, BlitStruct<ApplicationControlProperty> nacpData, MetaLoader metaLoader, bool isHomebrew = false)
>>>>>>> 1ec71635b (sync with main branch)
        {
            ulong programId = metaLoader.GetProgramId();

            // Replace the whole ExeFs partition by the modded one.
            if (device.Configuration.VirtualFileSystem.ModLoader.ReplaceExefsPartition(programId, ref exeFs))
            {
                metaLoader = null;
            }

            // Reload the MetaLoader in case of ExeFs partition replacement.
            metaLoader ??= exeFs.GetNpdm();

            NsoExecutable[] nsoExecutables = new NsoExecutable[ProcessConst.ExeFsPrefixes.Length];

            for (int i = 0; i < nsoExecutables.Length; i++)
            {
                string name = ProcessConst.ExeFsPrefixes[i];

                if (!exeFs.FileExists($"/{name}"))
                {
                    continue; // File doesn't exist, skip.
                }

                Logger.Info?.Print(LogClass.Loader, $"Loading {name}...");

                using var nsoFile = new UniqueRef<IFile>();

                exeFs.OpenFile(ref nsoFile.Ref, $"/{name}".ToU8Span(), OpenMode.Read).ThrowIfFailure();

                nsoExecutables[i] = new NsoExecutable(nsoFile.Release().AsStorage(), name);
            }

            // ExeFs file replacements.
            ModLoadResult modLoadResult = device.Configuration.VirtualFileSystem.ModLoader.ApplyExefsMods(programId, nsoExecutables);

            // Take the Npdm from mods if present.
            if (modLoadResult.Npdm != null)
            {
                metaLoader = modLoadResult.Npdm;
            }

            // Collect the Nsos, ignoring ones that aren't used.
            nsoExecutables = nsoExecutables.Where(x => x != null).ToArray();

            // Apply Nsos patches.
            device.Configuration.VirtualFileSystem.ModLoader.ApplyNsoPatches(programId, nsoExecutables);

            // Don't use PTC if ExeFS files have been replaced.
            bool enablePtc = device.System.EnablePtc && !modLoadResult.Modified;
            if (!enablePtc)
            {
<<<<<<< HEAD
                Logger.Warning?.Print(LogClass.Ptc, "Detected unsupported ExeFs modifications. PTC disabled.");
            }

=======
                Logger.Warning?.Print(LogClass.Ptc, $"Detected unsupported ExeFs modifications. PTC disabled.");
            }

            // We allow it for nx-hbloader because it can be used to launch homebrew.
            bool allowCodeMemoryForJit = programId == 0x010000000000100DUL || isHomebrew;

>>>>>>> 1ec71635b (sync with main branch)
            string programName = "";

            if (!isHomebrew && programId > 0x010000000000FFFF)
            {
                programName = nacpData.Value.Title[(int)device.System.State.DesiredTitleLanguage].NameString.ToString();

                if (string.IsNullOrWhiteSpace(programName))
                {
<<<<<<< HEAD
                    programName = Array.Find(nacpData.Value.Title.ItemsRo.ToArray(), x => x.Name[0] != 0).NameString.ToString();
=======
                    programName = nacpData.Value.Title.ItemsRo.ToArray().FirstOrDefault(x => x.Name[0] != 0).NameString.ToString();
>>>>>>> 1ec71635b (sync with main branch)
                }
            }

            // Initialize GPU.
            Graphics.Gpu.GraphicsConfig.TitleId = $"{programId:x16}";
            device.Gpu.HostInitalized.Set();

            if (!MemoryBlock.SupportsFlags(MemoryAllocationFlags.ViewCompatible))
            {
                device.Configuration.MemoryManagerMode = MemoryManagerMode.SoftwarePageTable;
            }

            ProcessResult processResult = ProcessLoaderHelper.LoadNsos(
                device,
                device.System.KernelContext,
                metaLoader,
                nacpData,
                enablePtc,
<<<<<<< HEAD
                true,
                programName,
                metaLoader.GetProgramId(),
                programIndex,
=======
                allowCodeMemoryForJit,
                programName,
                metaLoader.GetProgramId(),
>>>>>>> 1ec71635b (sync with main branch)
                null,
                nsoExecutables);

            // TODO: This should be stored using ProcessId instead.
            device.System.LibHacHorizonManager.ArpIReader.ApplicationId = new LibHac.ApplicationId(metaLoader.GetProgramId());

            return processResult;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
