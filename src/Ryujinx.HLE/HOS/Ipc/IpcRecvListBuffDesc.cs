<<<<<<< HEAD
=======
using System.IO;

>>>>>>> 1ec71635b (sync with main branch)
namespace Ryujinx.HLE.HOS.Ipc
{
    struct IpcRecvListBuffDesc
    {
        public ulong Position { get; private set; }
<<<<<<< HEAD
        public ulong Size { get; private set; }
=======
        public ulong Size     { get; private set; }
>>>>>>> 1ec71635b (sync with main branch)

        public IpcRecvListBuffDesc(ulong position, ulong size)
        {
            Position = position;
            Size = size;
        }

        public IpcRecvListBuffDesc(ulong packedValue)
        {
            Position = packedValue & 0xffffffffffff;

            Size = (ushort)(packedValue >> 48);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
