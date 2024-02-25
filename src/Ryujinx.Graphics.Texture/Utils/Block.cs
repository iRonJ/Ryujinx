namespace Ryujinx.Graphics.Texture.Utils
{
    struct Block
    {
        public ulong Low;
        public ulong High;

        public void Encode(ulong value, ref int offset, int bits)
        {
            if (offset >= 64)
            {
                High |= value << (offset - 64);
            }
            else
            {
                Low |= value << offset;

                if (offset + bits > 64)
                {
                    int remainder = 64 - offset;
                    High |= value >> remainder;
                }
            }

            offset += bits;
        }

<<<<<<< HEAD
        public readonly ulong Decode(ref int offset, int bits)
=======
        public ulong Decode(ref int offset, int bits)
>>>>>>> 1ec71635b (sync with main branch)
        {
            ulong value;
            ulong mask = bits == 64 ? ulong.MaxValue : (1UL << bits) - 1;

            if (offset >= 64)
            {
                value = (High >> (offset - 64)) & mask;
            }
            else
            {
                value = Low >> offset;

                if (offset + bits > 64)
                {
                    int remainder = 64 - offset;
                    value |= High << remainder;
                }

                value &= mask;
            }

            offset += bits;

            return value;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
