<<<<<<< HEAD
using LibHac.Ncm;
=======
﻿using LibHac.Ncm;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Arp
{
    class ApplicationLaunchProperty
    {
        public ulong TitleId;
<<<<<<< HEAD
        public int Version;
        public byte BaseGameStorageId;
        public byte UpdateGameStorageId;
#pragma warning disable CS0649 // Field is never assigned to
=======
        public int   Version;
        public byte  BaseGameStorageId;
        public byte  UpdateGameStorageId;
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public short Padding;
#pragma warning restore CS0649

        public static ApplicationLaunchProperty Default
        {
            get
            {
                return new ApplicationLaunchProperty
                {
<<<<<<< HEAD
                    TitleId = 0x00,
                    Version = 0x00,
                    BaseGameStorageId = (byte)StorageId.BuiltInSystem,
                    UpdateGameStorageId = (byte)StorageId.None,
=======
                    TitleId             = 0x00,
                    Version             = 0x00,
                    BaseGameStorageId   = (byte)StorageId.BuiltInSystem,
                    UpdateGameStorageId = (byte)StorageId.None
>>>>>>> 1ec71635b (sync with main branch)
                };
            }
        }

        public static ApplicationLaunchProperty GetByPid(ServiceCtx context)
        {
            // TODO: Handle ApplicationLaunchProperty as array when pid will be supported and return the right item.
            //       For now we can hardcode values, and fix it after GetApplicationLaunchProperty is implemented.

            return new ApplicationLaunchProperty
            {
<<<<<<< HEAD
                TitleId = context.Device.Processes.ActiveApplication.ProgramId,
                Version = 0x00,
                BaseGameStorageId = (byte)StorageId.BuiltInSystem,
                UpdateGameStorageId = (byte)StorageId.None,
            };
        }
    }
}
=======
                TitleId             = context.Device.Processes.ActiveApplication.ProgramId,
                Version             = 0x00,
                BaseGameStorageId   = (byte)StorageId.BuiltInSystem,
                UpdateGameStorageId = (byte)StorageId.None
            };
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
