using Ryujinx.HLE.HOS.Kernel.Common;

namespace Ryujinx.HLE.HOS.Kernel.Process
{
    class KHandleEntry
    {
        public KHandleEntry Next { get; set; }

        public int Index { get; private set; }

<<<<<<< HEAD
        public ushort HandleId { get; set; }
        public KAutoObject Obj { get; set; }
=======
        public ushort      HandleId { get; set; }
        public KAutoObject Obj      { get; set; }
>>>>>>> 1ec71635b (sync with main branch)

        public KHandleEntry(int index)
        {
            Index = index;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
