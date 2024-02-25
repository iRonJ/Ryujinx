using ARMeilleure.State;
using Ryujinx.Memory;
using System;
using System.Runtime.InteropServices;
<<<<<<< HEAD
using System.Runtime.Versioning;

namespace Ryujinx.Cpu.AppleHv
{
    [SupportedOSPlatform("macos")]
    class HvExecutionContextVcpu : IHvExecutionContext
    {
        private static readonly MemoryBlock _setSimdFpRegFuncMem;
        private delegate HvResult SetSimdFpReg(ulong vcpu, HvSimdFPReg reg, in V128 value, IntPtr funcPtr);
        private static readonly SetSimdFpReg _setSimdFpReg;
        private static readonly IntPtr _setSimdFpRegNativePtr;
=======
using System.Threading;

namespace Ryujinx.Cpu.AppleHv
{
    class HvExecutionContextVcpu : IHvExecutionContext
    {
        private static MemoryBlock _setSimdFpRegFuncMem;
        private delegate hv_result_t SetSimdFpReg(ulong vcpu, hv_simd_fp_reg_t reg, in V128 value, IntPtr funcPtr);
        private static SetSimdFpReg _setSimdFpReg;
        private static IntPtr _setSimdFpRegNativePtr;
>>>>>>> 1ec71635b (sync with main branch)

        static HvExecutionContextVcpu()
        {
            // .NET does not support passing vectors by value, so we need to pass a pointer and use a native
            // function to load the value into a vector register.
            _setSimdFpRegFuncMem = new MemoryBlock(MemoryBlock.GetPageSize());
            _setSimdFpRegFuncMem.Write(0, 0x3DC00040u); // LDR Q0, [X2]
            _setSimdFpRegFuncMem.Write(4, 0xD61F0060u); // BR X3
            _setSimdFpRegFuncMem.Reprotect(0, _setSimdFpRegFuncMem.Size, MemoryPermission.ReadAndExecute);

            _setSimdFpReg = Marshal.GetDelegateForFunctionPointer<SetSimdFpReg>(_setSimdFpRegFuncMem.Pointer);

            if (NativeLibrary.TryLoad(HvApi.LibraryName, out IntPtr hvLibHandle))
            {
                _setSimdFpRegNativePtr = NativeLibrary.GetExport(hvLibHandle, nameof(HvApi.hv_vcpu_set_simd_fp_reg));
            }
        }

        public ulong Pc
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_reg(_vcpu, HvReg.PC, out ulong pc).ThrowOnError();
=======
                HvApi.hv_vcpu_get_reg(_vcpu, hv_reg_t.HV_REG_PC, out ulong pc).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return pc;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_reg(_vcpu, HvReg.PC, value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_reg(_vcpu, hv_reg_t.HV_REG_PC, value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public ulong ElrEl1
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_sys_reg(_vcpu, HvSysReg.ELR_EL1, out ulong elr).ThrowOnError();
=======
                HvApi.hv_vcpu_get_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_ELR_EL1, out ulong elr).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return elr;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_sys_reg(_vcpu, HvSysReg.ELR_EL1, value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_ELR_EL1, value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public ulong EsrEl1
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_sys_reg(_vcpu, HvSysReg.ESR_EL1, out ulong esr).ThrowOnError();
=======
                HvApi.hv_vcpu_get_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_ESR_EL1, out ulong esr).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return esr;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_sys_reg(_vcpu, HvSysReg.ESR_EL1, value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_ESR_EL1, value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public long TpidrEl0
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_sys_reg(_vcpu, HvSysReg.TPIDR_EL0, out ulong tpidrEl0).ThrowOnError();
=======
                HvApi.hv_vcpu_get_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_TPIDR_EL0, out ulong tpidrEl0).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return (long)tpidrEl0;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_sys_reg(_vcpu, HvSysReg.TPIDR_EL0, (ulong)value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_TPIDR_EL0, (ulong)value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public long TpidrroEl0
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_sys_reg(_vcpu, HvSysReg.TPIDRRO_EL0, out ulong tpidrroEl0).ThrowOnError();
=======
                HvApi.hv_vcpu_get_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_TPIDRRO_EL0, out ulong tpidrroEl0).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return (long)tpidrroEl0;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_sys_reg(_vcpu, HvSysReg.TPIDRRO_EL0, (ulong)value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_TPIDRRO_EL0, (ulong)value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public uint Pstate
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_reg(_vcpu, HvReg.CPSR, out ulong cpsr).ThrowOnError();
=======
                HvApi.hv_vcpu_get_reg(_vcpu, hv_reg_t.HV_REG_CPSR, out ulong cpsr).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return (uint)cpsr;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_reg(_vcpu, HvReg.CPSR, (ulong)value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_reg(_vcpu, hv_reg_t.HV_REG_CPSR, (ulong)value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public uint Fpcr
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_reg(_vcpu, HvReg.FPCR, out ulong fpcr).ThrowOnError();
=======
                HvApi.hv_vcpu_get_reg(_vcpu, hv_reg_t.HV_REG_FPCR, out ulong fpcr).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return (uint)fpcr;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_reg(_vcpu, HvReg.FPCR, (ulong)value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_reg(_vcpu, hv_reg_t.HV_REG_FPCR, (ulong)value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public uint Fpsr
        {
            get
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_reg(_vcpu, HvReg.FPSR, out ulong fpsr).ThrowOnError();
=======
                HvApi.hv_vcpu_get_reg(_vcpu, hv_reg_t.HV_REG_FPSR, out ulong fpsr).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return (uint)fpsr;
            }
            set
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_reg(_vcpu, HvReg.FPSR, (ulong)value).ThrowOnError();
            }
        }

        private readonly ulong _vcpu;
=======
                HvApi.hv_vcpu_set_reg(_vcpu, hv_reg_t.HV_REG_FPSR, (ulong)value).ThrowOnError();
            }
        }

        private ulong _vcpu;
        private int _interruptRequested;
>>>>>>> 1ec71635b (sync with main branch)

        public HvExecutionContextVcpu(ulong vcpu)
        {
            _vcpu = vcpu;
        }

        public ulong GetX(int index)
        {
            if (index == 31)
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_sys_reg(_vcpu, HvSysReg.SP_EL0, out ulong value).ThrowOnError();
=======
                HvApi.hv_vcpu_get_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_SP_EL0, out ulong value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return value;
            }
            else
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_get_reg(_vcpu, HvReg.X0 + (uint)index, out ulong value).ThrowOnError();
=======
                HvApi.hv_vcpu_get_reg(_vcpu, hv_reg_t.HV_REG_X0 + (uint)index, out ulong value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
                return value;
            }
        }

        public void SetX(int index, ulong value)
        {
            if (index == 31)
            {
<<<<<<< HEAD
                HvApi.hv_vcpu_set_sys_reg(_vcpu, HvSysReg.SP_EL0, value).ThrowOnError();
            }
            else
            {
                HvApi.hv_vcpu_set_reg(_vcpu, HvReg.X0 + (uint)index, value).ThrowOnError();
=======
                HvApi.hv_vcpu_set_sys_reg(_vcpu, hv_sys_reg_t.HV_SYS_REG_SP_EL0, value).ThrowOnError();
            }
            else
            {
                HvApi.hv_vcpu_set_reg(_vcpu, hv_reg_t.HV_REG_X0 + (uint)index, value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            }
        }

        public V128 GetV(int index)
        {
<<<<<<< HEAD
            HvApi.hv_vcpu_get_simd_fp_reg(_vcpu, HvSimdFPReg.Q0 + (uint)index, out HvSimdFPUchar16 value).ThrowOnError();
=======
            HvApi.hv_vcpu_get_simd_fp_reg(_vcpu, hv_simd_fp_reg_t.HV_SIMD_FP_REG_Q0 + (uint)index, out hv_simd_fp_uchar16_t value).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
            return new V128(value.Low, value.High);
        }

        public void SetV(int index, V128 value)
        {
<<<<<<< HEAD
            _setSimdFpReg(_vcpu, HvSimdFPReg.Q0 + (uint)index, value, _setSimdFpRegNativePtr).ThrowOnError();
=======
            _setSimdFpReg(_vcpu, hv_simd_fp_reg_t.HV_SIMD_FP_REG_Q0 + (uint)index, value, _setSimdFpRegNativePtr).ThrowOnError();
>>>>>>> 1ec71635b (sync with main branch)
        }

        public void RequestInterrupt()
        {
<<<<<<< HEAD
            ulong vcpu = _vcpu;
            HvApi.hv_vcpus_exit(ref vcpu, 1);
        }
    }
}
=======
            if (Interlocked.Exchange(ref _interruptRequested, 1) == 0)
            {
                ulong vcpu = _vcpu;
                HvApi.hv_vcpus_exit(ref vcpu, 1);
            }
        }

        public bool GetAndClearInterruptRequested()
        {
            return Interlocked.Exchange(ref _interruptRequested, 0) != 0;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
