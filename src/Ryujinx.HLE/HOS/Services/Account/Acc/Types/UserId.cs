<<<<<<< HEAD
using LibHac.Account;
=======
﻿using LibHac.Account;
>>>>>>> 1ec71635b (sync with main branch)
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Account.Acc
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct UserId
    {
        public readonly long High;
        public readonly long Low;

        public bool IsNull => (Low | High) == 0;

<<<<<<< HEAD
        public static UserId Null => new(0, 0);

        public UserId(long low, long high)
        {
            Low = low;
=======
        public static UserId Null => new UserId(0, 0);

        public UserId(long low, long high)
        {
            Low  = low;
>>>>>>> 1ec71635b (sync with main branch)
            High = high;
        }

        public UserId(byte[] bytes)
        {
            High = BitConverter.ToInt64(bytes, 0);
<<<<<<< HEAD
            Low = BitConverter.ToInt64(bytes, 8);
=======
            Low  = BitConverter.ToInt64(bytes, 8);
>>>>>>> 1ec71635b (sync with main branch)
        }

        public UserId(string hex)
        {
            if (hex == null || hex.Length != 32 || !hex.All("0123456789abcdefABCDEF".Contains))
            {
                throw new ArgumentException("Invalid Hex value!", nameof(hex));
            }

<<<<<<< HEAD
            Low = long.Parse(hex.AsSpan(16), NumberStyles.HexNumber);
=======
            Low  = long.Parse(hex.AsSpan(16), NumberStyles.HexNumber);
>>>>>>> 1ec71635b (sync with main branch)
            High = long.Parse(hex.AsSpan(0, 16), NumberStyles.HexNumber);
        }

        public void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(High);
            binaryWriter.Write(Low);
        }

        public override string ToString()
        {
            return High.ToString("x16") + Low.ToString("x16");
        }

        public Uid ToLibHacUid()
        {
            return new Uid((ulong)High, (ulong)Low);
        }

        public UInt128 ToUInt128()
        {
            return new UInt128((ulong)High, (ulong)Low);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
