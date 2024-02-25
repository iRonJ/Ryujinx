<<<<<<< HEAD
using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Ryujinx.Cpu.AppleHv
{
    struct HvVcpuExitException
    {
#pragma warning disable CS0649 // Field is never assigned to
        public ulong Syndrome;
        public ulong VirtualAddress;
        public ulong PhysicalAddress;
#pragma warning restore CS0649
    }

    enum HvExitReason : uint
    {
        Canceled,
        Exception,
        VTimerActivated,
        Unknown,
    }

    struct HvVcpuExit
    {
#pragma warning disable CS0649 // Field is never assigned to
        public HvExitReason Reason;
        public HvVcpuExitException Exception;
#pragma warning restore CS0649
    }

    enum HvReg : uint
    {
        X0,
        X1,
        X2,
        X3,
        X4,
        X5,
        X6,
        X7,
        X8,
        X9,
        X10,
        X11,
        X12,
        X13,
        X14,
        X15,
        X16,
        X17,
        X18,
        X19,
        X20,
        X21,
        X22,
        X23,
        X24,
        X25,
        X26,
        X27,
        X28,
        X29,
        FP = X29,
        X30,
        LR = X30,
        PC,
        FPCR,
        FPSR,
        CPSR,
    }

    enum HvSimdFPReg : uint
    {
        Q0,
        Q1,
        Q2,
        Q3,
        Q4,
        Q5,
        Q6,
        Q7,
        Q8,
        Q9,
        Q10,
        Q11,
        Q12,
        Q13,
        Q14,
        Q15,
        Q16,
        Q17,
        Q18,
        Q19,
        Q20,
        Q21,
        Q22,
        Q23,
        Q24,
        Q25,
        Q26,
        Q27,
        Q28,
        Q29,
        Q30,
        Q31,
    }

    enum HvSysReg : ushort
    {
        DBGBVR0_EL1 = 0x8004,
        DBGBCR0_EL1 = 0x8005,
        DBGWVR0_EL1 = 0x8006,
        DBGWCR0_EL1 = 0x8007,
        DBGBVR1_EL1 = 0x800c,
        DBGBCR1_EL1 = 0x800d,
        DBGWVR1_EL1 = 0x800e,
        DBGWCR1_EL1 = 0x800f,
        MDCCINT_EL1 = 0x8010,
        MDSCR_EL1 = 0x8012,
        DBGBVR2_EL1 = 0x8014,
        DBGBCR2_EL1 = 0x8015,
        DBGWVR2_EL1 = 0x8016,
        DBGWCR2_EL1 = 0x8017,
        DBGBVR3_EL1 = 0x801c,
        DBGBCR3_EL1 = 0x801d,
        DBGWVR3_EL1 = 0x801e,
        DBGWCR3_EL1 = 0x801f,
        DBGBVR4_EL1 = 0x8024,
        DBGBCR4_EL1 = 0x8025,
        DBGWVR4_EL1 = 0x8026,
        DBGWCR4_EL1 = 0x8027,
        DBGBVR5_EL1 = 0x802c,
        DBGBCR5_EL1 = 0x802d,
        DBGWVR5_EL1 = 0x802e,
        DBGWCR5_EL1 = 0x802f,
        DBGBVR6_EL1 = 0x8034,
        DBGBCR6_EL1 = 0x8035,
        DBGWVR6_EL1 = 0x8036,
        DBGWCR6_EL1 = 0x8037,
        DBGBVR7_EL1 = 0x803c,
        DBGBCR7_EL1 = 0x803d,
        DBGWVR7_EL1 = 0x803e,
        DBGWCR7_EL1 = 0x803f,
        DBGBVR8_EL1 = 0x8044,
        DBGBCR8_EL1 = 0x8045,
        DBGWVR8_EL1 = 0x8046,
        DBGWCR8_EL1 = 0x8047,
        DBGBVR9_EL1 = 0x804c,
        DBGBCR9_EL1 = 0x804d,
        DBGWVR9_EL1 = 0x804e,
        DBGWCR9_EL1 = 0x804f,
        DBGBVR10_EL1 = 0x8054,
        DBGBCR10_EL1 = 0x8055,
        DBGWVR10_EL1 = 0x8056,
        DBGWCR10_EL1 = 0x8057,
        DBGBVR11_EL1 = 0x805c,
        DBGBCR11_EL1 = 0x805d,
        DBGWVR11_EL1 = 0x805e,
        DBGWCR11_EL1 = 0x805f,
        DBGBVR12_EL1 = 0x8064,
        DBGBCR12_EL1 = 0x8065,
        DBGWVR12_EL1 = 0x8066,
        DBGWCR12_EL1 = 0x8067,
        DBGBVR13_EL1 = 0x806c,
        DBGBCR13_EL1 = 0x806d,
        DBGWVR13_EL1 = 0x806e,
        DBGWCR13_EL1 = 0x806f,
        DBGBVR14_EL1 = 0x8074,
        DBGBCR14_EL1 = 0x8075,
        DBGWVR14_EL1 = 0x8076,
        DBGWCR14_EL1 = 0x8077,
        DBGBVR15_EL1 = 0x807c,
        DBGBCR15_EL1 = 0x807d,
        DBGWVR15_EL1 = 0x807e,
        DBGWCR15_EL1 = 0x807f,
        MIDR_EL1 = 0xc000,
        MPIDR_EL1 = 0xc005,
        ID_AA64PFR0_EL1 = 0xc020,
        ID_AA64PFR1_EL1 = 0xc021,
        ID_AA64DFR0_EL1 = 0xc028,
        ID_AA64DFR1_EL1 = 0xc029,
        ID_AA64ISAR0_EL1 = 0xc030,
        ID_AA64ISAR1_EL1 = 0xc031,
        ID_AA64MMFR0_EL1 = 0xc038,
        ID_AA64MMFR1_EL1 = 0xc039,
        ID_AA64MMFR2_EL1 = 0xc03a,
        SCTLR_EL1 = 0xc080,
        CPACR_EL1 = 0xc082,
        TTBR0_EL1 = 0xc100,
        TTBR1_EL1 = 0xc101,
        TCR_EL1 = 0xc102,
        APIAKEYLO_EL1 = 0xc108,
        APIAKEYHI_EL1 = 0xc109,
        APIBKEYLO_EL1 = 0xc10a,
        APIBKEYHI_EL1 = 0xc10b,
        APDAKEYLO_EL1 = 0xc110,
        APDAKEYHI_EL1 = 0xc111,
        APDBKEYLO_EL1 = 0xc112,
        APDBKEYHI_EL1 = 0xc113,
        APGAKEYLO_EL1 = 0xc118,
        APGAKEYHI_EL1 = 0xc119,
        SPSR_EL1 = 0xc200,
        ELR_EL1 = 0xc201,
        SP_EL0 = 0xc208,
        AFSR0_EL1 = 0xc288,
        AFSR1_EL1 = 0xc289,
        ESR_EL1 = 0xc290,
        FAR_EL1 = 0xc300,
        PAR_EL1 = 0xc3a0,
        MAIR_EL1 = 0xc510,
        AMAIR_EL1 = 0xc518,
        VBAR_EL1 = 0xc600,
        CONTEXTIDR_EL1 = 0xc681,
        TPIDR_EL1 = 0xc684,
        CNTKCTL_EL1 = 0xc708,
        CSSELR_EL1 = 0xd000,
        TPIDR_EL0 = 0xde82,
        TPIDRRO_EL0 = 0xde83,
        CNTV_CTL_EL0 = 0xdf19,
        CNTV_CVAL_EL0 = 0xdf1a,
        SP_EL1 = 0xe208,
    }

    enum HvMemoryFlags : ulong
    {
        Read = 1UL << 0,
        Write = 1UL << 1,
        Exec = 1UL << 2,
    }

    enum HvResult : uint
    {
        Success = 0,
        Error = 0xfae94001,
        Busy = 0xfae94002,
        BadArgument = 0xfae94003,
        NoResources = 0xfae94005,
        NoDevice = 0xfae94006,
        Denied = 0xfae94007,
        Unsupported = 0xfae9400f,
    }

    enum HvInterruptType : uint
    {
        IRQ,
        FIQ,
    }

    struct HvSimdFPUchar16
=======
using ARMeilleure.State;
using System;
using System.Runtime.InteropServices;

namespace Ryujinx.Cpu.AppleHv
{
    struct hv_vcpu_exit_exception_t
    {
#pragma warning disable CS0649
        public ulong syndrome;
        public ulong virtual_address;
        public ulong physical_address;
#pragma warning restore CS0649
    }

    struct hv_vcpu_exit_t
    {
#pragma warning disable CS0649
        public uint reason;
        public hv_vcpu_exit_exception_t exception;
#pragma warning restore CS0649
    }

    enum hv_reg_t : uint
    {
        HV_REG_X0,
        HV_REG_X1,
        HV_REG_X2,
        HV_REG_X3,
        HV_REG_X4,
        HV_REG_X5,
        HV_REG_X6,
        HV_REG_X7,
        HV_REG_X8,
        HV_REG_X9,
        HV_REG_X10,
        HV_REG_X11,
        HV_REG_X12,
        HV_REG_X13,
        HV_REG_X14,
        HV_REG_X15,
        HV_REG_X16,
        HV_REG_X17,
        HV_REG_X18,
        HV_REG_X19,
        HV_REG_X20,
        HV_REG_X21,
        HV_REG_X22,
        HV_REG_X23,
        HV_REG_X24,
        HV_REG_X25,
        HV_REG_X26,
        HV_REG_X27,
        HV_REG_X28,
        HV_REG_X29,
        HV_REG_FP = HV_REG_X29,
        HV_REG_X30,
        HV_REG_LR = HV_REG_X30,
        HV_REG_PC,
        HV_REG_FPCR,
        HV_REG_FPSR,
        HV_REG_CPSR,
    }

    enum hv_simd_fp_reg_t : uint
    {
        HV_SIMD_FP_REG_Q0,
        HV_SIMD_FP_REG_Q1,
        HV_SIMD_FP_REG_Q2,
        HV_SIMD_FP_REG_Q3,
        HV_SIMD_FP_REG_Q4,
        HV_SIMD_FP_REG_Q5,
        HV_SIMD_FP_REG_Q6,
        HV_SIMD_FP_REG_Q7,
        HV_SIMD_FP_REG_Q8,
        HV_SIMD_FP_REG_Q9,
        HV_SIMD_FP_REG_Q10,
        HV_SIMD_FP_REG_Q11,
        HV_SIMD_FP_REG_Q12,
        HV_SIMD_FP_REG_Q13,
        HV_SIMD_FP_REG_Q14,
        HV_SIMD_FP_REG_Q15,
        HV_SIMD_FP_REG_Q16,
        HV_SIMD_FP_REG_Q17,
        HV_SIMD_FP_REG_Q18,
        HV_SIMD_FP_REG_Q19,
        HV_SIMD_FP_REG_Q20,
        HV_SIMD_FP_REG_Q21,
        HV_SIMD_FP_REG_Q22,
        HV_SIMD_FP_REG_Q23,
        HV_SIMD_FP_REG_Q24,
        HV_SIMD_FP_REG_Q25,
        HV_SIMD_FP_REG_Q26,
        HV_SIMD_FP_REG_Q27,
        HV_SIMD_FP_REG_Q28,
        HV_SIMD_FP_REG_Q29,
        HV_SIMD_FP_REG_Q30,
        HV_SIMD_FP_REG_Q31,
    }

    enum hv_sys_reg_t : ushort
    {
        HV_SYS_REG_DBGBVR0_EL1 = 0x8004,
        HV_SYS_REG_DBGBCR0_EL1 = 0x8005,
        HV_SYS_REG_DBGWVR0_EL1 = 0x8006,
        HV_SYS_REG_DBGWCR0_EL1 = 0x8007,
        HV_SYS_REG_DBGBVR1_EL1 = 0x800c,
        HV_SYS_REG_DBGBCR1_EL1 = 0x800d,
        HV_SYS_REG_DBGWVR1_EL1 = 0x800e,
        HV_SYS_REG_DBGWCR1_EL1 = 0x800f,
        HV_SYS_REG_MDCCINT_EL1 = 0x8010,
        HV_SYS_REG_MDSCR_EL1 = 0x8012,
        HV_SYS_REG_DBGBVR2_EL1 = 0x8014,
        HV_SYS_REG_DBGBCR2_EL1 = 0x8015,
        HV_SYS_REG_DBGWVR2_EL1 = 0x8016,
        HV_SYS_REG_DBGWCR2_EL1 = 0x8017,
        HV_SYS_REG_DBGBVR3_EL1 = 0x801c,
        HV_SYS_REG_DBGBCR3_EL1 = 0x801d,
        HV_SYS_REG_DBGWVR3_EL1 = 0x801e,
        HV_SYS_REG_DBGWCR3_EL1 = 0x801f,
        HV_SYS_REG_DBGBVR4_EL1 = 0x8024,
        HV_SYS_REG_DBGBCR4_EL1 = 0x8025,
        HV_SYS_REG_DBGWVR4_EL1 = 0x8026,
        HV_SYS_REG_DBGWCR4_EL1 = 0x8027,
        HV_SYS_REG_DBGBVR5_EL1 = 0x802c,
        HV_SYS_REG_DBGBCR5_EL1 = 0x802d,
        HV_SYS_REG_DBGWVR5_EL1 = 0x802e,
        HV_SYS_REG_DBGWCR5_EL1 = 0x802f,
        HV_SYS_REG_DBGBVR6_EL1 = 0x8034,
        HV_SYS_REG_DBGBCR6_EL1 = 0x8035,
        HV_SYS_REG_DBGWVR6_EL1 = 0x8036,
        HV_SYS_REG_DBGWCR6_EL1 = 0x8037,
        HV_SYS_REG_DBGBVR7_EL1 = 0x803c,
        HV_SYS_REG_DBGBCR7_EL1 = 0x803d,
        HV_SYS_REG_DBGWVR7_EL1 = 0x803e,
        HV_SYS_REG_DBGWCR7_EL1 = 0x803f,
        HV_SYS_REG_DBGBVR8_EL1 = 0x8044,
        HV_SYS_REG_DBGBCR8_EL1 = 0x8045,
        HV_SYS_REG_DBGWVR8_EL1 = 0x8046,
        HV_SYS_REG_DBGWCR8_EL1 = 0x8047,
        HV_SYS_REG_DBGBVR9_EL1 = 0x804c,
        HV_SYS_REG_DBGBCR9_EL1 = 0x804d,
        HV_SYS_REG_DBGWVR9_EL1 = 0x804e,
        HV_SYS_REG_DBGWCR9_EL1 = 0x804f,
        HV_SYS_REG_DBGBVR10_EL1 = 0x8054,
        HV_SYS_REG_DBGBCR10_EL1 = 0x8055,
        HV_SYS_REG_DBGWVR10_EL1 = 0x8056,
        HV_SYS_REG_DBGWCR10_EL1 = 0x8057,
        HV_SYS_REG_DBGBVR11_EL1 = 0x805c,
        HV_SYS_REG_DBGBCR11_EL1 = 0x805d,
        HV_SYS_REG_DBGWVR11_EL1 = 0x805e,
        HV_SYS_REG_DBGWCR11_EL1 = 0x805f,
        HV_SYS_REG_DBGBVR12_EL1 = 0x8064,
        HV_SYS_REG_DBGBCR12_EL1 = 0x8065,
        HV_SYS_REG_DBGWVR12_EL1 = 0x8066,
        HV_SYS_REG_DBGWCR12_EL1 = 0x8067,
        HV_SYS_REG_DBGBVR13_EL1 = 0x806c,
        HV_SYS_REG_DBGBCR13_EL1 = 0x806d,
        HV_SYS_REG_DBGWVR13_EL1 = 0x806e,
        HV_SYS_REG_DBGWCR13_EL1 = 0x806f,
        HV_SYS_REG_DBGBVR14_EL1 = 0x8074,
        HV_SYS_REG_DBGBCR14_EL1 = 0x8075,
        HV_SYS_REG_DBGWVR14_EL1 = 0x8076,
        HV_SYS_REG_DBGWCR14_EL1 = 0x8077,
        HV_SYS_REG_DBGBVR15_EL1 = 0x807c,
        HV_SYS_REG_DBGBCR15_EL1 = 0x807d,
        HV_SYS_REG_DBGWVR15_EL1 = 0x807e,
        HV_SYS_REG_DBGWCR15_EL1 = 0x807f,
        HV_SYS_REG_MIDR_EL1 = 0xc000,
        HV_SYS_REG_MPIDR_EL1 = 0xc005,
        HV_SYS_REG_ID_AA64PFR0_EL1 = 0xc020,
        HV_SYS_REG_ID_AA64PFR1_EL1 = 0xc021,
        HV_SYS_REG_ID_AA64DFR0_EL1 = 0xc028,
        HV_SYS_REG_ID_AA64DFR1_EL1 = 0xc029,
        HV_SYS_REG_ID_AA64ISAR0_EL1 = 0xc030,
        HV_SYS_REG_ID_AA64ISAR1_EL1 = 0xc031,
        HV_SYS_REG_ID_AA64MMFR0_EL1 = 0xc038,
        HV_SYS_REG_ID_AA64MMFR1_EL1 = 0xc039,
        HV_SYS_REG_ID_AA64MMFR2_EL1 = 0xc03a,
        HV_SYS_REG_SCTLR_EL1 = 0xc080,
        HV_SYS_REG_CPACR_EL1 = 0xc082,
        HV_SYS_REG_TTBR0_EL1 = 0xc100,
        HV_SYS_REG_TTBR1_EL1 = 0xc101,
        HV_SYS_REG_TCR_EL1 = 0xc102,
        HV_SYS_REG_APIAKEYLO_EL1 = 0xc108,
        HV_SYS_REG_APIAKEYHI_EL1 = 0xc109,
        HV_SYS_REG_APIBKEYLO_EL1 = 0xc10a,
        HV_SYS_REG_APIBKEYHI_EL1 = 0xc10b,
        HV_SYS_REG_APDAKEYLO_EL1 = 0xc110,
        HV_SYS_REG_APDAKEYHI_EL1 = 0xc111,
        HV_SYS_REG_APDBKEYLO_EL1 = 0xc112,
        HV_SYS_REG_APDBKEYHI_EL1 = 0xc113,
        HV_SYS_REG_APGAKEYLO_EL1 = 0xc118,
        HV_SYS_REG_APGAKEYHI_EL1 = 0xc119,
        HV_SYS_REG_SPSR_EL1 = 0xc200,
        HV_SYS_REG_ELR_EL1 = 0xc201,
        HV_SYS_REG_SP_EL0 = 0xc208,
        HV_SYS_REG_AFSR0_EL1 = 0xc288,
        HV_SYS_REG_AFSR1_EL1 = 0xc289,
        HV_SYS_REG_ESR_EL1 = 0xc290,
        HV_SYS_REG_FAR_EL1 = 0xc300,
        HV_SYS_REG_PAR_EL1 = 0xc3a0,
        HV_SYS_REG_MAIR_EL1 = 0xc510,
        HV_SYS_REG_AMAIR_EL1 = 0xc518,
        HV_SYS_REG_VBAR_EL1 = 0xc600,
        HV_SYS_REG_CONTEXTIDR_EL1 = 0xc681,
        HV_SYS_REG_TPIDR_EL1 = 0xc684,
        HV_SYS_REG_CNTKCTL_EL1 = 0xc708,
        HV_SYS_REG_CSSELR_EL1 = 0xd000,
        HV_SYS_REG_TPIDR_EL0 = 0xde82,
        HV_SYS_REG_TPIDRRO_EL0 = 0xde83,
        HV_SYS_REG_CNTV_CTL_EL0 = 0xdf19,
        HV_SYS_REG_CNTV_CVAL_EL0 = 0xdf1a,
        HV_SYS_REG_SP_EL1 = 0xe208,
    }

    enum hv_memory_flags_t : ulong
    {
        HV_MEMORY_READ = 1UL << 0,
        HV_MEMORY_WRITE = 1UL << 1,
        HV_MEMORY_EXEC = 1UL << 2
    }

    enum hv_result_t : uint
    {
        HV_SUCCESS = 0,
        HV_ERROR = 0xfae94001,
        HV_BUSY = 0xfae94002,
        HV_BAD_ARGUMENT = 0xfae94003,
        HV_NO_RESOURCES = 0xfae94005,
        HV_NO_DEVICE = 0xfae94006,
        HV_DENIED = 0xfae94007,
        HV_UNSUPPORTED = 0xfae9400f
    }

    enum hv_interrupt_type_t : uint
    {
        HV_INTERRUPT_TYPE_IRQ,
        HV_INTERRUPT_TYPE_FIQ
    }

    struct hv_simd_fp_uchar16_t
>>>>>>> 1ec71635b (sync with main branch)
    {
        public ulong Low;
        public ulong High;
    }

    static class HvResultExtensions
    {
<<<<<<< HEAD
        public static void ThrowOnError(this HvResult result)
        {
            if (result != HvResult.Success)
=======
        public static void ThrowOnError(this hv_result_t result)
        {
            if (result != hv_result_t.HV_SUCCESS)
>>>>>>> 1ec71635b (sync with main branch)
            {
                throw new Exception($"Unexpected result \"{result}\".");
            }
        }
    }

<<<<<<< HEAD
    [SupportedOSPlatform("macos")]
=======
>>>>>>> 1ec71635b (sync with main branch)
    static partial class HvApi
    {
        public const string LibraryName = "/System/Library/Frameworks/Hypervisor.framework/Hypervisor";

        [LibraryImport(LibraryName, SetLastError = true)]
<<<<<<< HEAD
        public static partial HvResult hv_vm_get_max_vcpu_count(out uint max_vcpu_count);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vm_create(IntPtr config);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vm_destroy();

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vm_map(ulong addr, ulong ipa, ulong size, HvMemoryFlags flags);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vm_unmap(ulong ipa, ulong size);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vm_protect(ulong ipa, ulong size, HvMemoryFlags flags);

        [LibraryImport(LibraryName, SetLastError = true)]
        public unsafe static partial HvResult hv_vcpu_create(out ulong vcpu, ref HvVcpuExit* exit, IntPtr config);

        [LibraryImport(LibraryName, SetLastError = true)]
        public unsafe static partial HvResult hv_vcpu_destroy(ulong vcpu);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_run(ulong vcpu);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpus_exit(ref ulong vcpus, uint vcpu_count);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_set_vtimer_mask(ulong vcpu, [MarshalAs(UnmanagedType.Bool)] bool vtimer_is_masked);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_get_reg(ulong vcpu, HvReg reg, out ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_set_reg(ulong vcpu, HvReg reg, ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_get_simd_fp_reg(ulong vcpu, HvSimdFPReg reg, out HvSimdFPUchar16 value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_set_simd_fp_reg(ulong vcpu, HvSimdFPReg reg, HvSimdFPUchar16 value); // DO NOT USE DIRECTLY!

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_get_sys_reg(ulong vcpu, HvSysReg reg, out ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_set_sys_reg(ulong vcpu, HvSysReg reg, ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_get_pending_interrupt(ulong vcpu, HvInterruptType type, [MarshalAs(UnmanagedType.Bool)] out bool pending);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial HvResult hv_vcpu_set_pending_interrupt(ulong vcpu, HvInterruptType type, [MarshalAs(UnmanagedType.Bool)] bool pending);
    }
}
=======
        public static partial hv_result_t hv_vm_get_max_vcpu_count(out uint max_vcpu_count);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vm_create(IntPtr config);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vm_destroy();

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vm_map(ulong addr, ulong ipa, ulong size, hv_memory_flags_t flags);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vm_unmap(ulong ipa, ulong size);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vm_protect(ulong ipa, ulong size, hv_memory_flags_t flags);

        [LibraryImport(LibraryName, SetLastError = true)]
        public unsafe static partial hv_result_t hv_vcpu_create(out ulong vcpu, ref hv_vcpu_exit_t* exit, IntPtr config);

        [LibraryImport(LibraryName, SetLastError = true)]
        public unsafe static partial hv_result_t hv_vcpu_destroy(ulong vcpu);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_run(ulong vcpu);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpus_exit(ref ulong vcpus, uint vcpu_count);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_set_vtimer_mask(ulong vcpu, [MarshalAs(UnmanagedType.Bool)] bool vtimer_is_masked);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_get_reg(ulong vcpu, hv_reg_t reg, out ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_set_reg(ulong vcpu, hv_reg_t reg, ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_get_simd_fp_reg(ulong vcpu, hv_simd_fp_reg_t reg, out hv_simd_fp_uchar16_t value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_set_simd_fp_reg(ulong vcpu, hv_simd_fp_reg_t reg, hv_simd_fp_uchar16_t value); // DO NOT USE DIRECTLY!

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_get_sys_reg(ulong vcpu, hv_sys_reg_t reg, out ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_set_sys_reg(ulong vcpu, hv_sys_reg_t reg, ulong value);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_get_pending_interrupt(ulong vcpu, hv_interrupt_type_t type, [MarshalAs(UnmanagedType.Bool)] out bool pending);

        [LibraryImport(LibraryName, SetLastError = true)]
        public static partial hv_result_t hv_vcpu_set_pending_interrupt(ulong vcpu, hv_interrupt_type_t type, [MarshalAs(UnmanagedType.Bool)] bool pending);
    }
}
>>>>>>> 1ec71635b (sync with main branch)
