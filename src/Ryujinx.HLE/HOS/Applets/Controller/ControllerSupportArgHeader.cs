using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Applets
{
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ControllerSupportArgHeader
    {
        public sbyte PlayerCountMin;
        public sbyte PlayerCountMax;
        public byte EnableTakeOverConnection;
        public byte EnableLeftJustify;
        public byte EnablePermitJoyDual;
        public byte EnableSingleMode;
        public byte EnableIdentificationColor;
    }
#pragma warning restore CS0649
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
