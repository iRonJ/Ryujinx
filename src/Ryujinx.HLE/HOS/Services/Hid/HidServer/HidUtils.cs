<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.HLE.HOS.Services.Hid.HidServer
{
    static class HidUtils
    {
        public static PlayerIndex GetIndexFromNpadIdType(NpadIdType npadIdType)
        => npadIdType switch
        {
<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
=======
>>>>>>> 1ec71635b (sync with main branch)
            NpadIdType.Player1  => PlayerIndex.Player1,
            NpadIdType.Player2  => PlayerIndex.Player2,
            NpadIdType.Player3  => PlayerIndex.Player3,
            NpadIdType.Player4  => PlayerIndex.Player4,
            NpadIdType.Player5  => PlayerIndex.Player5,
            NpadIdType.Player6  => PlayerIndex.Player6,
            NpadIdType.Player7  => PlayerIndex.Player7,
            NpadIdType.Player8  => PlayerIndex.Player8,
            NpadIdType.Handheld => PlayerIndex.Handheld,
            NpadIdType.Unknown  => PlayerIndex.Unknown,
<<<<<<< HEAD
            _                   => throw new ArgumentOutOfRangeException(nameof(npadIdType)),
#pragma warning restore IDE0055
=======
            _                   => throw new ArgumentOutOfRangeException(nameof(npadIdType))
>>>>>>> 1ec71635b (sync with main branch)
        };

        public static NpadIdType GetNpadIdTypeFromIndex(PlayerIndex index)
        => index switch
        {
<<<<<<< HEAD
#pragma warning disable IDE0055 // Disable formatting
=======
>>>>>>> 1ec71635b (sync with main branch)
            PlayerIndex.Player1  => NpadIdType.Player1,
            PlayerIndex.Player2  => NpadIdType.Player2,
            PlayerIndex.Player3  => NpadIdType.Player3,
            PlayerIndex.Player4  => NpadIdType.Player4,
            PlayerIndex.Player5  => NpadIdType.Player5,
            PlayerIndex.Player6  => NpadIdType.Player6,
            PlayerIndex.Player7  => NpadIdType.Player7,
            PlayerIndex.Player8  => NpadIdType.Player8,
            PlayerIndex.Handheld => NpadIdType.Handheld,
            PlayerIndex.Unknown  => NpadIdType.Unknown,
<<<<<<< HEAD
            _                    => throw new ArgumentOutOfRangeException(nameof(index)),
#pragma warning restore IDE0055
=======
            _                    => throw new ArgumentOutOfRangeException(nameof(index))
>>>>>>> 1ec71635b (sync with main branch)
        };

        public static bool IsValidNpadIdType(NpadIdType npadIdType)
        {
            return (npadIdType >= NpadIdType.Player1 && npadIdType <= NpadIdType.Player8) ||
                npadIdType == NpadIdType.Handheld ||
                npadIdType == NpadIdType.Unknown;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
