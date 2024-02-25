<<<<<<< HEAD
using Ryujinx.Common.Configuration;
=======
﻿using Ryujinx.Common.Configuration;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Memory;
using Ryujinx.Common.Utilities;
using Ryujinx.Cpu;
using Ryujinx.HLE.HOS.Services.Mii;
using Ryujinx.HLE.HOS.Services.Mii.Types;
using Ryujinx.HLE.HOS.Services.Nfc.Nfp.NfpManager;
using System;
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Nfc.Nfp
{
    static class VirtualAmiibo
    {
        private static uint _openedApplicationAreaId;

<<<<<<< HEAD
        private static readonly AmiiboJsonSerializerContext _serializerContext = AmiiboJsonSerializerContext.Default;
=======
        private static readonly AmiiboJsonSerializerContext SerializerContext = AmiiboJsonSerializerContext.Default;
>>>>>>> 1ec71635b (sync with main branch)

        public static byte[] GenerateUuid(string amiiboId, bool useRandomUuid)
        {
            if (useRandomUuid)
            {
                return GenerateRandomUuid();
            }

            VirtualAmiiboFile virtualAmiiboFile = LoadAmiiboFile(amiiboId);

            if (virtualAmiiboFile.TagUuid.Length == 0)
            {
                virtualAmiiboFile.TagUuid = GenerateRandomUuid();

                SaveAmiiboFile(virtualAmiiboFile);
            }

            return virtualAmiiboFile.TagUuid;
        }

        private static byte[] GenerateRandomUuid()
        {
            byte[] uuid = new byte[9];

            Random.Shared.NextBytes(uuid);

<<<<<<< HEAD
            uuid[3] = (byte)(0x88 ^ uuid[0] ^ uuid[1] ^ uuid[2]);
=======
            uuid[3] = (byte)(0x88    ^ uuid[0] ^ uuid[1] ^ uuid[2]);
>>>>>>> 1ec71635b (sync with main branch)
            uuid[8] = (byte)(uuid[3] ^ uuid[4] ^ uuid[5] ^ uuid[6]);

            return uuid;
        }

        public static CommonInfo GetCommonInfo(string amiiboId)
        {
            VirtualAmiiboFile amiiboFile = LoadAmiiboFile(amiiboId);

            return new CommonInfo()
            {
<<<<<<< HEAD
                LastWriteYear = (ushort)amiiboFile.LastWriteDate.Year,
                LastWriteMonth = (byte)amiiboFile.LastWriteDate.Month,
                LastWriteDay = (byte)amiiboFile.LastWriteDate.Day,
                WriteCounter = amiiboFile.WriteCounter,
                Version = 1,
                ApplicationAreaSize = AmiiboConstants.ApplicationAreaSize,
                Reserved = new Array52<byte>(),
=======
                LastWriteYear       = (ushort)amiiboFile.LastWriteDate.Year,
                LastWriteMonth      = (byte)amiiboFile.LastWriteDate.Month,
                LastWriteDay        = (byte)amiiboFile.LastWriteDate.Day,
                WriteCounter        = amiiboFile.WriteCounter,
                Version             = 1,
                ApplicationAreaSize = AmiiboConstants.ApplicationAreaSize,
                Reserved            = new Array52<byte>()
>>>>>>> 1ec71635b (sync with main branch)
            };
        }

        public static RegisterInfo GetRegisterInfo(ITickSource tickSource, string amiiboId, string nickname)
        {
            VirtualAmiiboFile amiiboFile = LoadAmiiboFile(amiiboId);

<<<<<<< HEAD
            UtilityImpl utilityImpl = new(tickSource);
            CharInfo charInfo = new();
=======
            UtilityImpl utilityImpl = new UtilityImpl(tickSource);
            CharInfo    charInfo    = new CharInfo();
>>>>>>> 1ec71635b (sync with main branch)

            charInfo.SetFromStoreData(StoreData.BuildDefault(utilityImpl, 0));

            charInfo.Nickname = Nickname.FromString(nickname);

<<<<<<< HEAD
            RegisterInfo registerInfo = new()
            {
                MiiCharInfo = charInfo,
                FirstWriteYear = (ushort)amiiboFile.FirstWriteDate.Year,
                FirstWriteMonth = (byte)amiiboFile.FirstWriteDate.Month,
                FirstWriteDay = (byte)amiiboFile.FirstWriteDate.Day,
                FontRegion = 0,
                Reserved1 = new Array64<byte>(),
                Reserved2 = new Array58<byte>(),
=======
            RegisterInfo registerInfo = new RegisterInfo()
            {
                MiiCharInfo     = charInfo,
                FirstWriteYear  = (ushort)amiiboFile.FirstWriteDate.Year,
                FirstWriteMonth = (byte)amiiboFile.FirstWriteDate.Month,
                FirstWriteDay   = (byte)amiiboFile.FirstWriteDate.Day,
                FontRegion      = 0,
                Reserved1       = new Array64<byte>(),
                Reserved2       = new Array58<byte>()
>>>>>>> 1ec71635b (sync with main branch)
            };
            "Ryujinx"u8.CopyTo(registerInfo.Nickname.AsSpan());

            return registerInfo;
        }

        public static bool OpenApplicationArea(string amiiboId, uint applicationAreaId)
        {
            VirtualAmiiboFile virtualAmiiboFile = LoadAmiiboFile(amiiboId);

<<<<<<< HEAD
            if (virtualAmiiboFile.ApplicationAreas.Exists(item => item.ApplicationAreaId == applicationAreaId))
=======
            if (virtualAmiiboFile.ApplicationAreas.Any(item => item.ApplicationAreaId == applicationAreaId))
>>>>>>> 1ec71635b (sync with main branch)
            {
                _openedApplicationAreaId = applicationAreaId;

                return true;
            }

            return false;
        }

        public static byte[] GetApplicationArea(string amiiboId)
        {
            VirtualAmiiboFile virtualAmiiboFile = LoadAmiiboFile(amiiboId);

            foreach (VirtualAmiiboApplicationArea applicationArea in virtualAmiiboFile.ApplicationAreas)
            {
                if (applicationArea.ApplicationAreaId == _openedApplicationAreaId)
                {
                    return applicationArea.ApplicationArea;
                }
            }

            return Array.Empty<byte>();
        }

        public static bool CreateApplicationArea(string amiiboId, uint applicationAreaId, byte[] applicationAreaData)
        {
            VirtualAmiiboFile virtualAmiiboFile = LoadAmiiboFile(amiiboId);

<<<<<<< HEAD
            if (virtualAmiiboFile.ApplicationAreas.Exists(item => item.ApplicationAreaId == applicationAreaId))
=======
            if (virtualAmiiboFile.ApplicationAreas.Any(item => item.ApplicationAreaId == applicationAreaId))
>>>>>>> 1ec71635b (sync with main branch)
            {
                return false;
            }

            virtualAmiiboFile.ApplicationAreas.Add(new VirtualAmiiboApplicationArea()
            {
                ApplicationAreaId = applicationAreaId,
<<<<<<< HEAD
                ApplicationArea = applicationAreaData,
=======
                ApplicationArea   = applicationAreaData
>>>>>>> 1ec71635b (sync with main branch)
            });

            SaveAmiiboFile(virtualAmiiboFile);

            return true;
        }

        public static void SetApplicationArea(string amiiboId, byte[] applicationAreaData)
        {
            VirtualAmiiboFile virtualAmiiboFile = LoadAmiiboFile(amiiboId);

<<<<<<< HEAD
            if (virtualAmiiboFile.ApplicationAreas.Exists(item => item.ApplicationAreaId == _openedApplicationAreaId))
=======
            if (virtualAmiiboFile.ApplicationAreas.Any(item => item.ApplicationAreaId == _openedApplicationAreaId))
>>>>>>> 1ec71635b (sync with main branch)
            {
                for (int i = 0; i < virtualAmiiboFile.ApplicationAreas.Count; i++)
                {
                    if (virtualAmiiboFile.ApplicationAreas[i].ApplicationAreaId == _openedApplicationAreaId)
                    {
                        virtualAmiiboFile.ApplicationAreas[i] = new VirtualAmiiboApplicationArea()
                        {
                            ApplicationAreaId = _openedApplicationAreaId,
<<<<<<< HEAD
                            ApplicationArea = applicationAreaData,
=======
                            ApplicationArea   = applicationAreaData
>>>>>>> 1ec71635b (sync with main branch)
                        };

                        break;
                    }
                }

                SaveAmiiboFile(virtualAmiiboFile);
            }
        }

        private static VirtualAmiiboFile LoadAmiiboFile(string amiiboId)
        {
            Directory.CreateDirectory(Path.Join(AppDataManager.BaseDirPath, "system", "amiibo"));

            string filePath = Path.Join(AppDataManager.BaseDirPath, "system", "amiibo", $"{amiiboId}.json");

            VirtualAmiiboFile virtualAmiiboFile;

            if (File.Exists(filePath))
            {
<<<<<<< HEAD
                virtualAmiiboFile = JsonHelper.DeserializeFromFile(filePath, _serializerContext.VirtualAmiiboFile);
=======
                virtualAmiiboFile = JsonHelper.DeserializeFromFile(filePath, SerializerContext.VirtualAmiiboFile);
>>>>>>> 1ec71635b (sync with main branch)
            }
            else
            {
                virtualAmiiboFile = new VirtualAmiiboFile()
                {
<<<<<<< HEAD
                    FileVersion = 0,
                    TagUuid = Array.Empty<byte>(),
                    AmiiboId = amiiboId,
                    FirstWriteDate = DateTime.Now,
                    LastWriteDate = DateTime.Now,
                    WriteCounter = 0,
                    ApplicationAreas = new List<VirtualAmiiboApplicationArea>(),
=======
                    FileVersion      = 0,
                    TagUuid          = Array.Empty<byte>(),
                    AmiiboId         = amiiboId,
                    FirstWriteDate   = DateTime.Now,
                    LastWriteDate    = DateTime.Now,
                    WriteCounter     = 0,
                    ApplicationAreas = new List<VirtualAmiiboApplicationArea>()
>>>>>>> 1ec71635b (sync with main branch)
                };

                SaveAmiiboFile(virtualAmiiboFile);
            }

            return virtualAmiiboFile;
        }

        private static void SaveAmiiboFile(VirtualAmiiboFile virtualAmiiboFile)
        {
            string filePath = Path.Join(AppDataManager.BaseDirPath, "system", "amiibo", $"{virtualAmiiboFile.AmiiboId}.json");
<<<<<<< HEAD
            JsonHelper.SerializeToFile(filePath, virtualAmiiboFile, _serializerContext.VirtualAmiiboFile);
=======
            JsonHelper.SerializeToFile(filePath, virtualAmiiboFile, SerializerContext.VirtualAmiiboFile);
>>>>>>> 1ec71635b (sync with main branch)
        }
    }
}
