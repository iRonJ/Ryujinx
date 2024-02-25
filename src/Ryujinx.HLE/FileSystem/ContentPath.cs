<<<<<<< HEAD
using LibHac.Fs;
using LibHac.Ncm;
using Ryujinx.Common.Configuration;
using System;
=======
﻿using LibHac.Fs;
using LibHac.Ncm;
using Ryujinx.Common.Configuration;
using System;

>>>>>>> 1ec71635b (sync with main branch)
using static Ryujinx.HLE.FileSystem.VirtualFileSystem;
using Path = System.IO.Path;

namespace Ryujinx.HLE.FileSystem
{
    internal static class ContentPath
    {
<<<<<<< HEAD
        public const string SystemContent = "@SystemContent";
        public const string UserContent = "@UserContent";
        public const string SdCardContent = "@SdCardContent";
        public const string SdCard = "@Sdcard";
        public const string CalibFile = "@CalibFile";
        public const string Safe = "@Safe";
        public const string User = "@User";
        public const string System = "@System";
        public const string Host = "@Host";
        public const string GamecardApp = "@GcApp";
        public const string GamecardContents = "@GcS00000001";
        public const string GamecardUpdate = "@upp";
=======
        public const string SystemContent    = "@SystemContent";
        public const string UserContent      = "@UserContent";
        public const string SdCardContent    = "@SdCardContent";
        public const string SdCard           = "@Sdcard";
        public const string CalibFile        = "@CalibFile";
        public const string Safe             = "@Safe";
        public const string User             = "@User";
        public const string System           = "@System";
        public const string Host             = "@Host";
        public const string GamecardApp      = "@GcApp";
        public const string GamecardContents = "@GcS00000001";
        public const string GamecardUpdate   = "@upp";
>>>>>>> 1ec71635b (sync with main branch)
        public const string RegisteredUpdate = "@RegUpdate";

        public const string Nintendo = "Nintendo";
        public const string Contents = "Contents";

<<<<<<< HEAD
        public static string GetRealPath(string switchContentPath)
=======
        public static string GetRealPath(VirtualFileSystem fileSystem, string switchContentPath)
>>>>>>> 1ec71635b (sync with main branch)
        {
            return switchContentPath switch
            {
                SystemContent => Path.Combine(AppDataManager.BaseDirPath, SystemNandPath, Contents),
<<<<<<< HEAD
                UserContent => Path.Combine(AppDataManager.BaseDirPath, UserNandPath, Contents),
                SdCardContent => Path.Combine(GetSdCardPath(), Nintendo, Contents),
                System => Path.Combine(AppDataManager.BaseDirPath, SystemNandPath),
                User => Path.Combine(AppDataManager.BaseDirPath, UserNandPath),
                _ => throw new NotSupportedException($"Content Path \"`{switchContentPath}`\" is not supported."),
=======
                UserContent   => Path.Combine(AppDataManager.BaseDirPath, UserNandPath,   Contents),
                SdCardContent => Path.Combine(fileSystem.GetSdCardPath(), Nintendo,       Contents),
                System        => Path.Combine(AppDataManager.BaseDirPath, SystemNandPath),
                User          => Path.Combine(AppDataManager.BaseDirPath, UserNandPath),
                _ => throw new NotSupportedException($"Content Path \"`{switchContentPath}`\" is not supported.")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static string GetContentPath(ContentStorageId contentStorageId)
        {
            return contentStorageId switch
            {
                ContentStorageId.System => SystemContent,
<<<<<<< HEAD
                ContentStorageId.User => UserContent,
                ContentStorageId.SdCard => SdCardContent,
                _ => throw new NotSupportedException($"Content Storage Id \"`{contentStorageId}`\" is not supported."),
=======
                ContentStorageId.User   => UserContent,
                ContentStorageId.SdCard => SdCardContent,
                _ => throw new NotSupportedException($"Content Storage Id \"`{contentStorageId}`\" is not supported.")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static string GetContentPath(StorageId storageId)
        {
            return storageId switch
            {
                StorageId.BuiltInSystem => SystemContent,
<<<<<<< HEAD
                StorageId.BuiltInUser => UserContent,
                StorageId.SdCard => SdCardContent,
                _ => throw new NotSupportedException($"Storage Id \"`{storageId}`\" is not supported."),
=======
                StorageId.BuiltInUser   => UserContent,
                StorageId.SdCard        => SdCardContent,
                _ => throw new NotSupportedException($"Storage Id \"`{storageId}`\" is not supported.")
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static StorageId GetStorageId(string contentPathString)
        {
            return contentPathString.Split(':')[0] switch
            {
                SystemContent or
<<<<<<< HEAD
                System => StorageId.BuiltInSystem,
                UserContent or
                User => StorageId.BuiltInUser,
                SdCardContent => StorageId.SdCard,
                Host => StorageId.Host,
                GamecardApp or
                GamecardContents or
                GamecardUpdate => StorageId.GameCard,
                _ => StorageId.None,
            };
        }
    }
}
=======
                System         => StorageId.BuiltInSystem,
                UserContent or
                User           => StorageId.BuiltInUser,
                SdCardContent  => StorageId.SdCard,
                Host           => StorageId.Host,
                GamecardApp or
                GamecardContents or
                GamecardUpdate => StorageId.GameCard,
                _              => StorageId.None
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
