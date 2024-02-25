<<<<<<< HEAD
using Ryujinx.Common.Memory;
using System;
=======
﻿using System;
>>>>>>> 1ec71635b (sync with main branch)
using System.Runtime.InteropServices;
using System.Text;

namespace Ryujinx.HLE.HOS.Services.Mii.Types
{
    [StructLayout(LayoutKind.Sequential, Pack = 2, Size = SizeConst)]
    struct Nickname : IEquatable<Nickname>
    {
        public const int CharCount = 10;
        private const int SizeConst = (CharCount + 1) * 2;

<<<<<<< HEAD
        private Array22<byte> _storage;
=======
        private byte _storage;
>>>>>>> 1ec71635b (sync with main branch)

        public static Nickname Default => FromString("no name");
        public static Nickname Question => FromString("???");

<<<<<<< HEAD
        public Span<byte> Raw => _storage.AsSpan();
=======
        public Span<byte> Raw => MemoryMarshal.CreateSpan(ref _storage, SizeConst);
>>>>>>> 1ec71635b (sync with main branch)

        private ReadOnlySpan<ushort> Characters => MemoryMarshal.Cast<byte, ushort>(Raw);

        private int GetEndCharacterIndex()
        {
            for (int i = 0; i < Characters.Length; i++)
            {
                if (Characters[i] == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool IsEmpty()
        {
            for (int i = 0; i < Characters.Length - 1; i++)
            {
                if (Characters[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsValid()
        {
            // Create a new unicode encoding instance with error checking enabled
<<<<<<< HEAD
            UnicodeEncoding unicodeEncoding = new(false, false, true);
=======
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding(false, false, true);
>>>>>>> 1ec71635b (sync with main branch)

            try
            {
                unicodeEncoding.GetString(Raw);

                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public bool IsValidForFontRegion(FontRegion fontRegion)
        {
            // TODO: We need to extract the character tables used here, for now just assume that if it's valid Unicode, it will be valid for any font.
            return IsValid();
        }

        public override string ToString()
        {
            return Encoding.Unicode.GetString(Raw);
        }

        public static Nickname FromBytes(ReadOnlySpan<byte> data)
        {
            if (data.Length > SizeConst)
            {
<<<<<<< HEAD
                data = data[..SizeConst];
            }

            Nickname result = new();
=======
                data = data.Slice(0, SizeConst);
            }

            Nickname result = new Nickname();
>>>>>>> 1ec71635b (sync with main branch)

            data.CopyTo(result.Raw);

            return result;
        }

        public static Nickname FromString(string nickname)
        {
            return FromBytes(Encoding.Unicode.GetBytes(nickname));
        }

        public static bool operator ==(Nickname x, Nickname y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Nickname x, Nickname y)
        {
            return !x.Equals(y);
        }

        public override bool Equals(object obj)
        {
            return obj is Nickname nickname && Equals(nickname);
        }

        public bool Equals(Nickname cmpObj)
        {
            return Raw.SequenceEqual(cmpObj.Raw);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Raw.ToArray());
        }
    }
}
