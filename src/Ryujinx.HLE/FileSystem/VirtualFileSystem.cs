using LibHac;
using LibHac.Common;
using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.Fs.Shim;
using LibHac.FsSrv;
using LibHac.FsSystem;
using LibHac.Ncm;
<<<<<<< HEAD
using LibHac.Sdmmc;
=======
>>>>>>> 1ec71635b (sync with main branch)
using LibHac.Spl;
using LibHac.Tools.Es;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using Ryujinx.Common.Configuration;
using Ryujinx.Common.Logging;
using Ryujinx.HLE.HOS;
using System;
using System.Buffers.Text;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Path = System.IO.Path;
<<<<<<< HEAD
=======
using RightsId = LibHac.Fs.RightsId;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.FileSystem
{
    public class VirtualFileSystem : IDisposable
    {
<<<<<<< HEAD
        public static readonly string SafeNandPath = Path.Combine(AppDataManager.DefaultNandDir, "safe");
        public static readonly string SystemNandPath = Path.Combine(AppDataManager.DefaultNandDir, "system");
        public static readonly string UserNandPath = Path.Combine(AppDataManager.DefaultNandDir, "user");

        public KeySet KeySet { get; private set; }
        public EmulatedGameCard GameCard { get; private set; }
        public SdmmcApi SdCard { get; private set; }
        public ModLoader ModLoader { get; private set; }
=======
        public static string SafeNandPath   = Path.Combine(AppDataManager.DefaultNandDir, "safe");
        public static string SystemNandPath = Path.Combine(AppDataManager.DefaultNandDir, "system");
        public static string UserNandPath   = Path.Combine(AppDataManager.DefaultNandDir, "user");

        public KeySet           KeySet    { get; private set; }
        public EmulatedGameCard GameCard  { get; private set; }
        public EmulatedSdCard   SdCard    { get; private set; }
        public ModLoader        ModLoader { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        private readonly ConcurrentDictionary<ulong, Stream> _romFsByPid;

        private static bool _isInitialized = false;

        public static VirtualFileSystem CreateInstance()
        {
            if (_isInitialized)
            {
                throw new InvalidOperationException("VirtualFileSystem can only be instantiated once!");
            }

            _isInitialized = true;

            return new VirtualFileSystem();
        }

        private VirtualFileSystem()
        {
            ReloadKeySet();
            ModLoader = new ModLoader(); // Should only be created once
            _romFsByPid = new ConcurrentDictionary<ulong, Stream>();
        }

        public void LoadRomFs(ulong pid, string fileName)
        {
            var romfsStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            _romFsByPid.AddOrUpdate(pid, romfsStream, (pid, oldStream) =>
            {
                oldStream.Close();

                return romfsStream;
            });
        }

        public void SetRomFs(ulong pid, Stream romfsStream)
        {
            _romFsByPid.AddOrUpdate(pid, romfsStream, (pid, oldStream) =>
            {
                oldStream.Close();

                return romfsStream;
            });
        }

        public Stream GetRomFs(ulong pid)
        {
            return _romFsByPid[pid];
        }

<<<<<<< HEAD
        public static string GetFullPath(string basePath, string fileName)
        {
            if (fileName.StartsWith("//"))
            {
                fileName = fileName[2..];
            }
            else if (fileName.StartsWith('/'))
            {
                fileName = fileName[1..];
=======
        public string GetFullPath(string basePath, string fileName)
        {
            if (fileName.StartsWith("//"))
            {
                fileName = fileName.Substring(2);
            }
            else if (fileName.StartsWith('/'))
            {
                fileName = fileName.Substring(1);
>>>>>>> 1ec71635b (sync with main branch)
            }
            else
            {
                return null;
            }

            string fullPath = Path.GetFullPath(Path.Combine(basePath, fileName));

            if (!fullPath.StartsWith(AppDataManager.BaseDirPath))
            {
                return null;
            }

            return fullPath;
        }

<<<<<<< HEAD
        internal static string GetSdCardPath() => MakeFullPath(AppDataManager.DefaultSdcardDir);
        public static string GetNandPath() => MakeFullPath(AppDataManager.DefaultNandDir);

        public static string SwitchPathToSystemPath(string switchPath)
=======
        internal string GetSdCardPath() => MakeFullPath(AppDataManager.DefaultSdcardDir);
        public string GetNandPath() => MakeFullPath(AppDataManager.DefaultNandDir);

        public string SwitchPathToSystemPath(string switchPath)
>>>>>>> 1ec71635b (sync with main branch)
        {
            string[] parts = switchPath.Split(":");

            if (parts.Length != 2)
            {
                return null;
            }

            return GetFullPath(MakeFullPath(parts[0]), parts[1]);
        }

<<<<<<< HEAD
        public static string SystemPathToSwitchPath(string systemPath)
=======
        public string SystemPathToSwitchPath(string systemPath)
>>>>>>> 1ec71635b (sync with main branch)
        {
            string baseSystemPath = AppDataManager.BaseDirPath + Path.DirectorySeparatorChar;

            if (systemPath.StartsWith(baseSystemPath))
            {
                string rawPath = systemPath.Replace(baseSystemPath, "");
                int firstSeparatorOffset = rawPath.IndexOf(Path.DirectorySeparatorChar);

                if (firstSeparatorOffset == -1)
                {
                    return $"{rawPath}:/";
                }

                var basePath = rawPath.AsSpan(0, firstSeparatorOffset);
                var fileName = rawPath.AsSpan(firstSeparatorOffset + 1);

                return $"{basePath}:/{fileName}";
            }

            return null;
        }

<<<<<<< HEAD
        private static string MakeFullPath(string path, bool isDirectory = true)
=======
        private string MakeFullPath(string path, bool isDirectory = true)
>>>>>>> 1ec71635b (sync with main branch)
        {
            // Handles Common Switch Content Paths
            switch (path)
            {
                case ContentPath.SdCard:
                    path = AppDataManager.DefaultSdcardDir;
                    break;
                case ContentPath.User:
                    path = UserNandPath;
                    break;
                case ContentPath.System:
                    path = SystemNandPath;
                    break;
                case ContentPath.SdCardContent:
                    path = Path.Combine(AppDataManager.DefaultSdcardDir, "Nintendo", "Contents");
                    break;
                case ContentPath.UserContent:
                    path = Path.Combine(UserNandPath, "Contents");
                    break;
                case ContentPath.SystemContent:
                    path = Path.Combine(SystemNandPath, "Contents");
                    break;
            }

            string fullPath = Path.Combine(AppDataManager.BaseDirPath, path);

            if (isDirectory && !Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }

        public void InitializeFsServer(LibHac.Horizon horizon, out HorizonClient fsServerClient)
        {
<<<<<<< HEAD
            LocalFileSystem serverBaseFs = new(useUnixTimeStamps: true);
            Result result = serverBaseFs.Initialize(AppDataManager.BaseDirPath, LocalFileSystem.PathMode.DefaultCaseSensitivity, ensurePathExists: true);
            if (result.IsFailure())
            {
                throw new HorizonResultException(result, "Error creating LocalFileSystem.");
            }
=======
            LocalFileSystem serverBaseFs = new LocalFileSystem(AppDataManager.BaseDirPath);
>>>>>>> 1ec71635b (sync with main branch)

            fsServerClient = horizon.CreatePrivilegedHorizonClient();
            var fsServer = new FileSystemServer(fsServerClient);

            RandomDataGenerator randomGenerator = Random.Shared.NextBytes;

            DefaultFsServerObjects fsServerObjects = DefaultFsServerObjects.GetDefaultEmulatedCreators(serverBaseFs, KeySet, fsServer, randomGenerator);

            // Use our own encrypted fs creator that doesn't actually do any encryption
            fsServerObjects.FsCreators.EncryptedFileSystemCreator = new EncryptedFileSystemCreator();

            GameCard = fsServerObjects.GameCard;
<<<<<<< HEAD
            SdCard = fsServerObjects.Sdmmc;

            SdCard.SetSdCardInserted(true);

            var fsServerConfig = new FileSystemServerConfig
            {
                ExternalKeySet = KeySet.ExternalKeySet,
                FsCreators = fsServerObjects.FsCreators,
                StorageDeviceManagerFactory = fsServerObjects.StorageDeviceManagerFactory,
                RandomGenerator = randomGenerator,
=======
            SdCard = fsServerObjects.SdCard;

            SdCard.SetSdCardInsertionStatus(true);

            var fsServerConfig = new FileSystemServerConfig
            {
                DeviceOperator = fsServerObjects.DeviceOperator,
                ExternalKeySet = KeySet.ExternalKeySet,
                FsCreators = fsServerObjects.FsCreators,
                RandomGenerator = randomGenerator
>>>>>>> 1ec71635b (sync with main branch)
            };

            FileSystemServerInitializer.InitializeWithConfig(fsServerClient, fsServer, fsServerConfig);
        }

        public void ReloadKeySet()
        {
            KeySet ??= KeySet.CreateDefaultKeySet();

            string keyFile = null;
            string titleKeyFile = null;
            string consoleKeyFile = null;

            if (AppDataManager.Mode == AppDataManager.LaunchMode.UserProfile)
            {
                LoadSetAtPath(AppDataManager.KeysDirPathUser);
            }

            LoadSetAtPath(AppDataManager.KeysDirPath);

            void LoadSetAtPath(string basePath)
            {
                string localKeyFile = Path.Combine(basePath, "prod.keys");
                string localTitleKeyFile = Path.Combine(basePath, "title.keys");
                string localConsoleKeyFile = Path.Combine(basePath, "console.keys");

                if (File.Exists(localKeyFile))
                {
                    keyFile = localKeyFile;
                }

                if (File.Exists(localTitleKeyFile))
                {
                    titleKeyFile = localTitleKeyFile;
                }

                if (File.Exists(localConsoleKeyFile))
                {
                    consoleKeyFile = localConsoleKeyFile;
                }
            }

            ExternalKeyReader.ReadKeyFile(KeySet, keyFile, titleKeyFile, consoleKeyFile, null);
        }

        public void ImportTickets(IFileSystem fs)
        {
            foreach (DirectoryEntryEx ticketEntry in fs.EnumerateEntries("/", "*.tik"))
            {
                using var ticketFile = new UniqueRef<IFile>();

                Result result = fs.OpenFile(ref ticketFile.Ref, ticketEntry.FullPath.ToU8Span(), OpenMode.Read);

                if (result.IsSuccess())
                {
<<<<<<< HEAD
                    // When reading a file from a Sha256PartitionFileSystem, you can't start a read in the middle
                    // of the hashed portion (usually the first 0x200 bytes) of the file and end the read after
                    // the end of the hashed portion, so we read the ticket file using a single read.
                    byte[] ticketData = new byte[0x2C0];
                    result = ticketFile.Get.Read(out long bytesRead, 0, ticketData);

                    if (result.IsFailure() || bytesRead != ticketData.Length)
                        continue;

                    Ticket ticket = new(new MemoryStream(ticketData));
=======
                    Ticket ticket = new(ticketFile.Get.AsStream());
>>>>>>> 1ec71635b (sync with main branch)
                    var titleKey = ticket.GetTitleKey(KeySet);

                    if (titleKey != null)
                    {
                        KeySet.ExternalKeySet.Add(new RightsId(ticket.RightsId), new AccessKey(titleKey));
                    }
                }
            }
        }

        // Save data created before we supported extra data in directory save data will not work properly if
        // given empty extra data. Luckily some of that extra data can be created using the data from the
        // save data indexer, which should be enough to check access permissions for user saves.
        // Every single save data's extra data will be checked and fixed if needed each time the emulator is opened.
        // Consider removing this at some point in the future when we don't need to worry about old saves.
        public static Result FixExtraData(HorizonClient hos)
        {
            Result rc = GetSystemSaveList(hos, out List<ulong> systemSaveIds);
<<<<<<< HEAD
            if (rc.IsFailure())
            {
                return rc;
            }

            rc = FixUnindexedSystemSaves(hos, systemSaveIds);
            if (rc.IsFailure())
            {
                return rc;
            }

            rc = FixExtraDataInSpaceId(hos, SaveDataSpaceId.System);
            if (rc.IsFailure())
            {
                return rc;
            }

            rc = FixExtraDataInSpaceId(hos, SaveDataSpaceId.User);
            if (rc.IsFailure())
            {
                return rc;
            }
=======
            if (rc.IsFailure()) return rc;

            rc = FixUnindexedSystemSaves(hos, systemSaveIds);
            if (rc.IsFailure()) return rc;

            rc = FixExtraDataInSpaceId(hos, SaveDataSpaceId.System);
            if (rc.IsFailure()) return rc;

            rc = FixExtraDataInSpaceId(hos, SaveDataSpaceId.User);
            if (rc.IsFailure()) return rc;
>>>>>>> 1ec71635b (sync with main branch)

            return Result.Success;
        }

        private static Result FixExtraDataInSpaceId(HorizonClient hos, SaveDataSpaceId spaceId)
        {
            Span<SaveDataInfo> info = stackalloc SaveDataInfo[8];

            using var iterator = new UniqueRef<SaveDataIterator>();

            Result rc = hos.Fs.OpenSaveDataIterator(ref iterator.Ref, spaceId);
<<<<<<< HEAD
            if (rc.IsFailure())
            {
                return rc;
            }
=======
            if (rc.IsFailure()) return rc;
>>>>>>> 1ec71635b (sync with main branch)

            while (true)
            {
                rc = iterator.Get.ReadSaveDataInfo(out long count, info);
<<<<<<< HEAD
                if (rc.IsFailure())
                {
                    return rc;
                }

                if (count == 0)
                {
                    return Result.Success;
                }
=======
                if (rc.IsFailure()) return rc;

                if (count == 0)
                    return Result.Success;
>>>>>>> 1ec71635b (sync with main branch)

                for (int i = 0; i < count; i++)
                {
                    rc = FixExtraData(out bool wasFixNeeded, hos, in info[i]);

                    if (ResultFs.TargetNotFound.Includes(rc))
                    {
                        // If the save wasn't found, try to create the directory for its save data ID
                        rc = CreateSaveDataDirectory(hos, in info[i]);

                        if (rc.IsFailure())
                        {
                            Logger.Warning?.Print(LogClass.Application, $"Error {rc.ToStringWithName()} when creating save data 0x{info[i].SaveDataId:x} in the {spaceId} save data space");

                            // Don't bother fixing the extra data if we couldn't create the directory
                            continue;
                        }

                        Logger.Info?.Print(LogClass.Application, $"Recreated directory for save data 0x{info[i].SaveDataId:x} in the {spaceId} save data space");

                        // Try to fix the extra data in the new directory
                        rc = FixExtraData(out wasFixNeeded, hos, in info[i]);
                    }

                    if (rc.IsFailure())
                    {
                        Logger.Warning?.Print(LogClass.Application, $"Error {rc.ToStringWithName()} when fixing extra data for save data 0x{info[i].SaveDataId:x} in the {spaceId} save data space");
                    }
                    else if (wasFixNeeded)
                    {
                        Logger.Info?.Print(LogClass.Application, $"Fixed extra data for save data 0x{info[i].SaveDataId:x} in the {spaceId} save data space");
                    }
                }
            }
        }

        private static Result CreateSaveDataDirectory(HorizonClient hos, in SaveDataInfo info)
        {
            if (info.SpaceId != SaveDataSpaceId.User && info.SpaceId != SaveDataSpaceId.System)
<<<<<<< HEAD
            {
                return Result.Success;
            }

            const string MountName = "SaveDir";
            var mountNameU8 = MountName.ToU8Span();
=======
                return Result.Success;

            const string mountName = "SaveDir";
            var mountNameU8 = mountName.ToU8Span();
>>>>>>> 1ec71635b (sync with main branch)

            BisPartitionId partitionId = info.SpaceId switch
            {
                SaveDataSpaceId.System => BisPartitionId.System,
                SaveDataSpaceId.User => BisPartitionId.User,
<<<<<<< HEAD
                _ => throw new ArgumentOutOfRangeException(nameof(info), info.SpaceId, null),
            };

            Result rc = hos.Fs.MountBis(mountNameU8, partitionId);
            if (rc.IsFailure())
            {
                return rc;
            }

            try
            {
                var path = $"{MountName}:/save/{info.SaveDataId:x16}".ToU8Span();
=======
                _ => throw new ArgumentOutOfRangeException()
            };

            Result rc = hos.Fs.MountBis(mountNameU8, partitionId);
            if (rc.IsFailure()) return rc;
            try
            {
                var path = $"{mountName}:/save/{info.SaveDataId:x16}".ToU8Span();
>>>>>>> 1ec71635b (sync with main branch)

                rc = hos.Fs.GetEntryType(out _, path);

                if (ResultFs.PathNotFound.Includes(rc))
                {
                    rc = hos.Fs.CreateDirectory(path);
                }

                return rc;
            }
            finally
            {
                hos.Fs.Unmount(mountNameU8);
            }
        }

        // Gets a list of all the save data files or directories in the system partition.
        private static Result GetSystemSaveList(HorizonClient hos, out List<ulong> list)
        {
            list = null;

            var mountName = "system".ToU8Span();
            DirectoryHandle handle = default;
<<<<<<< HEAD
            List<ulong> localList = new();
=======
            List<ulong> localList = new List<ulong>();
>>>>>>> 1ec71635b (sync with main branch)

            try
            {
                Result rc = hos.Fs.MountBis(mountName, BisPartitionId.System);
<<<<<<< HEAD
                if (rc.IsFailure())
                {
                    return rc;
                }

                rc = hos.Fs.OpenDirectory(out handle, "system:/save".ToU8Span(), OpenDirectoryMode.All);
                if (rc.IsFailure())
                {
                    return rc;
                }

                DirectoryEntry entry = new();
=======
                if (rc.IsFailure()) return rc;

                rc = hos.Fs.OpenDirectory(out handle, "system:/save".ToU8Span(), OpenDirectoryMode.All);
                if (rc.IsFailure()) return rc;

                DirectoryEntry entry = new DirectoryEntry();
>>>>>>> 1ec71635b (sync with main branch)

                while (true)
                {
                    rc = hos.Fs.ReadDirectory(out long readCount, SpanHelpers.AsSpan(ref entry), handle);
<<<<<<< HEAD
                    if (rc.IsFailure())
                    {
                        return rc;
                    }

                    if (readCount == 0)
                    {
                        break;
                    }

                    if (Utf8Parser.TryParse(entry.Name, out ulong saveDataId, out int bytesRead, 'x') && bytesRead == 16 && (long)saveDataId < 0)
=======
                    if (rc.IsFailure()) return rc;

                    if (readCount == 0)
                        break;

                    if (Utf8Parser.TryParse(entry.Name, out ulong saveDataId, out int bytesRead, 'x') &&
                        bytesRead == 16 && (long)saveDataId < 0)
>>>>>>> 1ec71635b (sync with main branch)
                    {
                        localList.Add(saveDataId);
                    }
                }

                list = localList;

                return Result.Success;
            }
            finally
            {
                if (handle.IsValid)
                {
                    hos.Fs.CloseDirectory(handle);
                }

                if (hos.Fs.IsMounted(mountName))
                {
                    hos.Fs.Unmount(mountName);
                }
            }
        }

        // Adds system save data that isn't in the save data indexer to the indexer and creates extra data for it.
        // Only save data IDs added to SystemExtraDataFixInfo will be fixed.
        private static Result FixUnindexedSystemSaves(HorizonClient hos, List<ulong> existingSaveIds)
        {
<<<<<<< HEAD
            foreach (var fixInfo in _systemExtraDataFixInfo)
=======
            foreach (var fixInfo in SystemExtraDataFixInfo)
>>>>>>> 1ec71635b (sync with main branch)
            {
                if (!existingSaveIds.Contains(fixInfo.StaticSaveDataId))
                {
                    continue;
                }

                Result rc = FixSystemExtraData(out bool wasFixNeeded, hos, in fixInfo);

                if (rc.IsFailure())
                {
                    Logger.Warning?.Print(LogClass.Application,
                        $"Error {rc.ToStringWithName()} when fixing extra data for system save data 0x{fixInfo.StaticSaveDataId:x}");
                }
                else if (wasFixNeeded)
                {
                    Logger.Info?.Print(LogClass.Application,
                        $"Tried to rebuild extra data for system save data 0x{fixInfo.StaticSaveDataId:x}");
                }
            }

            return Result.Success;
        }

        private static Result FixSystemExtraData(out bool wasFixNeeded, HorizonClient hos, in ExtraDataFixInfo info)
        {
            wasFixNeeded = true;

            Result rc = hos.Fs.Impl.ReadSaveDataFileSystemExtraData(out SaveDataExtraData extraData, info.StaticSaveDataId);
            if (!rc.IsSuccess())
            {
                if (!ResultFs.TargetNotFound.Includes(rc))
<<<<<<< HEAD
                {
                    return rc;
                }
=======
                    return rc;
>>>>>>> 1ec71635b (sync with main branch)

                // We'll reach this point only if the save data directory exists but it's not in the save data indexer.
                // Creating the save will add it to the indexer while leaving its existing contents intact.
                return hos.Fs.CreateSystemSaveData(info.StaticSaveDataId, UserId.InvalidId, info.OwnerId, info.DataSize,
                    info.JournalSize, info.Flags);
            }

            if (extraData.Attribute.StaticSaveDataId != 0 && extraData.OwnerId != 0)
            {
                wasFixNeeded = false;
                return Result.Success;
            }

            extraData = new SaveDataExtraData
            {
                Attribute = { StaticSaveDataId = info.StaticSaveDataId },
                OwnerId = info.OwnerId,
                Flags = info.Flags,
                DataSize = info.DataSize,
<<<<<<< HEAD
                JournalSize = info.JournalSize,
=======
                JournalSize = info.JournalSize
>>>>>>> 1ec71635b (sync with main branch)
            };

            // Make a mask for writing the entire extra data
            Unsafe.SkipInit(out SaveDataExtraData extraDataMask);
            SpanHelpers.AsByteSpan(ref extraDataMask).Fill(0xFF);

            return hos.Fs.Impl.WriteSaveDataFileSystemExtraData(SaveDataSpaceId.System, info.StaticSaveDataId,
                in extraData, in extraDataMask);
        }

        private static Result FixExtraData(out bool wasFixNeeded, HorizonClient hos, in SaveDataInfo info)
        {
            wasFixNeeded = true;

<<<<<<< HEAD
            Result rc = hos.Fs.Impl.ReadSaveDataFileSystemExtraData(out SaveDataExtraData extraData, info.SpaceId, info.SaveDataId);
            if (rc.IsFailure())
            {
                return rc;
            }
=======
            Result rc = hos.Fs.Impl.ReadSaveDataFileSystemExtraData(out SaveDataExtraData extraData, info.SpaceId,
                info.SaveDataId);
            if (rc.IsFailure()) return rc;
>>>>>>> 1ec71635b (sync with main branch)

            // The extra data should have program ID or static save data ID set if it's valid.
            // We only try to fix the extra data if the info from the save data indexer has a program ID or static save data ID.
            bool canFixByProgramId = extraData.Attribute.ProgramId == ProgramId.InvalidId &&
                                       info.ProgramId != ProgramId.InvalidId;

            bool canFixBySaveDataId = extraData.Attribute.StaticSaveDataId == 0 && info.StaticSaveDataId != 0;

            bool hasEmptyOwnerId = extraData.OwnerId == 0 && info.Type != SaveDataType.System;

            if (!canFixByProgramId && !canFixBySaveDataId && !hasEmptyOwnerId)
            {
                wasFixNeeded = false;
                return Result.Success;
            }

            // The save data attribute struct can be completely created from the save data info.
            extraData.Attribute.ProgramId = info.ProgramId;
            extraData.Attribute.UserId = info.UserId;
            extraData.Attribute.StaticSaveDataId = info.StaticSaveDataId;
            extraData.Attribute.Type = info.Type;
            extraData.Attribute.Rank = info.Rank;
            extraData.Attribute.Index = info.Index;

            // The rest of the extra data can't be created from the save data info.
            // On user saves the owner ID will almost certainly be the same as the program ID.
            if (info.Type != SaveDataType.System)
            {
                extraData.OwnerId = info.ProgramId.Value;
            }
            else
            {
                // Try to match the system save with one of the known saves
<<<<<<< HEAD
                foreach (ExtraDataFixInfo fixInfo in _systemExtraDataFixInfo)
=======
                foreach (ExtraDataFixInfo fixInfo in SystemExtraDataFixInfo)
>>>>>>> 1ec71635b (sync with main branch)
                {
                    if (extraData.Attribute.StaticSaveDataId == fixInfo.StaticSaveDataId)
                    {
                        extraData.OwnerId = fixInfo.OwnerId;
                        extraData.Flags = fixInfo.Flags;
                        extraData.DataSize = fixInfo.DataSize;
                        extraData.JournalSize = fixInfo.JournalSize;

                        break;
                    }
                }
            }

            // Make a mask for writing the entire extra data
            Unsafe.SkipInit(out SaveDataExtraData extraDataMask);
            SpanHelpers.AsByteSpan(ref extraDataMask).Fill(0xFF);

            return hos.Fs.Impl.WriteSaveDataFileSystemExtraData(info.SpaceId, info.SaveDataId, in extraData, in extraDataMask);
        }

        struct ExtraDataFixInfo
        {
            public ulong StaticSaveDataId;
            public ulong OwnerId;
            public SaveDataFlags Flags;
            public long DataSize;
            public long JournalSize;
        }

<<<<<<< HEAD
        private static readonly ExtraDataFixInfo[] _systemExtraDataFixInfo =
=======
        private static readonly ExtraDataFixInfo[] SystemExtraDataFixInfo =
>>>>>>> 1ec71635b (sync with main branch)
        {
            new ExtraDataFixInfo()
            {
                StaticSaveDataId = 0x8000000000000030,
                OwnerId = 0x010000000000001F,
                Flags = SaveDataFlags.KeepAfterResettingSystemSaveDataWithoutUserSaveData,
                DataSize = 0x10000,
<<<<<<< HEAD
                JournalSize = 0x10000,
=======
                JournalSize = 0x10000
>>>>>>> 1ec71635b (sync with main branch)
            },
            new ExtraDataFixInfo()
            {
                StaticSaveDataId = 0x8000000000001040,
                OwnerId = 0x0100000000001009,
                Flags = SaveDataFlags.None,
                DataSize = 0xC000,
<<<<<<< HEAD
                JournalSize = 0xC000,
            },
=======
                JournalSize = 0xC000
            }
>>>>>>> 1ec71635b (sync with main branch)
        };

        public void Dispose()
        {
<<<<<<< HEAD
            GC.SuppressFinalize(this);
=======
>>>>>>> 1ec71635b (sync with main branch)
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var stream in _romFsByPid.Values)
                {
                    stream.Close();
                }

                _romFsByPid.Clear();
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
