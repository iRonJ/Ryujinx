using System.IO;

namespace Ryujinx.HLE.HOS.Ipc
{
    struct IpcBuffDesc
    {
        public ulong Position { get; private set; }
<<<<<<< HEAD
        public ulong Size { get; private set; }
        public byte Flags { get; private set; }
=======
        public ulong Size     { get; private set; }
        public byte  Flags    { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public IpcBuffDesc(BinaryReader reader)
        {
            ulong word0 = reader.ReadUInt32();
            ulong word1 = reader.ReadUInt32();
            ulong word2 = reader.ReadUInt32();

<<<<<<< HEAD
            Position = word1;
            Position |= (word2 << 4) & 0x0f00000000;
            Position |= (word2 << 34) & 0x7000000000;

            Size = word0;
=======
            Position  =  word1;
            Position |= (word2 <<  4) & 0x0f00000000;
            Position |= (word2 << 34) & 0x7000000000;

            Size  =  word0;
>>>>>>> 1ec71635b (sync with main branch)
            Size |= (word2 << 8) & 0xf00000000;

            Flags = (byte)(word2 & 3);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
