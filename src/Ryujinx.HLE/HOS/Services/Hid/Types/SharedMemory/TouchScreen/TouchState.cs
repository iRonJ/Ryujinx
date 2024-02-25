<<<<<<< HEAD
namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.TouchScreen
=======
﻿namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.TouchScreen
>>>>>>> 1ec71635b (sync with main branch)
{
    struct TouchState
    {
        public ulong DeltaTime;
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
=======
#pragma warning disable CS0649
>>>>>>> 1ec71635b (sync with main branch)
        public TouchAttribute Attribute;
#pragma warning restore CS0649
        public uint FingerId;
        public uint X;
        public uint Y;
        public uint DiameterX;
        public uint DiameterY;
        public uint RotationAngle;
<<<<<<< HEAD
#pragma warning disable CS0169, IDE0051 // Remove unused private member
        private readonly uint _reserved;
#pragma warning restore CS0169, IDE0051
=======
#pragma warning disable CS0169
        private uint _reserved;
#pragma warning restore CS0169
>>>>>>> 1ec71635b (sync with main branch)
    }
}
