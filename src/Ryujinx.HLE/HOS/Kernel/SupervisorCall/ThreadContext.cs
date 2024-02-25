<<<<<<< HEAD
using ARMeilleure.State;
=======
﻿using ARMeilleure.State;
>>>>>>> 1ec71635b (sync with main branch)
using Ryujinx.Common.Memory;

namespace Ryujinx.HLE.HOS.Kernel.SupervisorCall
{
    struct ThreadContext
    {
        public Array29<ulong> Registers;
        public ulong Fp;
        public ulong Lr;
        public ulong Sp;
        public ulong Pc;
        public uint Pstate;
<<<<<<< HEAD
#pragma warning disable CS0169, IDE0051 // Remove unused private member
        private readonly uint _padding;
#pragma warning restore CS0169, IDE0051
=======
#pragma warning disable CS0169
        private uint _padding;
#pragma warning restore CS0169
>>>>>>> 1ec71635b (sync with main branch)
        public Array32<V128> FpuRegisters;
        public uint Fpcr;
        public uint Fpsr;
        public ulong Tpidr;
    }
}
