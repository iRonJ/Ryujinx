<<<<<<< HEAD
// This file was auto-generated from NVIDIA official Maxwell definitions.
=======
﻿// This file was auto-generated from NVIDIA official Maxwell definitions.
>>>>>>> 1ec71635b (sync with main branch)

namespace Ryujinx.Graphics.Gpu.Engine.GPFifo
{
    enum TertOp
    {
        Grp0IncMethod = 0,
        Grp0SetSubDevMask = 1,
        Grp0StoreSubDevMask = 2,
        Grp0UseSubDevMask = 3,
<<<<<<< HEAD
        Grp2NonIncMethod = Grp0IncMethod,
=======
        Grp2NonIncMethod = 0
>>>>>>> 1ec71635b (sync with main branch)
    }

    enum SecOp
    {
        Grp0UseTert = 0,
        IncMethod = 1,
        Grp2UseTert = 2,
        NonIncMethod = 3,
        ImmdDataMethod = 4,
        OneInc = 5,
        Reserved6 = 6,
<<<<<<< HEAD
        EndPbSegment = 7,
=======
        EndPbSegment = 7
>>>>>>> 1ec71635b (sync with main branch)
    }

    struct CompressedMethod
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
        public uint Method;
#pragma warning restore CS0649
        public readonly int MethodAddressOld => (int)((Method >> 2) & 0x7FF);
        public readonly int MethodAddress => (int)(Method & 0xFFF);
        public readonly int SubdeviceMask => (int)((Method >> 4) & 0xFFF);
        public readonly int MethodSubchannel => (int)((Method >> 13) & 0x7);
        public readonly TertOp TertOp => (TertOp)((Method >> 16) & 0x3);
        public readonly int MethodCountOld => (int)((Method >> 18) & 0x7FF);
        public readonly int MethodCount => (int)((Method >> 16) & 0x1FFF);
        public readonly int ImmdData => (int)((Method >> 16) & 0x1FFF);
        public readonly SecOp SecOp => (SecOp)((Method >> 29) & 0x7);
=======
#pragma warning disable CS0649
        public uint Method;
#pragma warning restore CS0649
        public int MethodAddressOld => (int)((Method >> 2) & 0x7FF);
        public int MethodAddress => (int)((Method >> 0) & 0xFFF);
        public int SubdeviceMask => (int)((Method >> 4) & 0xFFF);
        public int MethodSubchannel => (int)((Method >> 13) & 0x7);
        public TertOp TertOp => (TertOp)((Method >> 16) & 0x3);
        public int MethodCountOld => (int)((Method >> 18) & 0x7FF);
        public int MethodCount => (int)((Method >> 16) & 0x1FFF);
        public int ImmdData => (int)((Method >> 16) & 0x1FFF);
        public SecOp SecOp => (SecOp)((Method >> 29) & 0x7);
>>>>>>> 1ec71635b (sync with main branch)
    }
}
