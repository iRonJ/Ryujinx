using Ryujinx.Graphics.Gpu.Engine.Types;
using System;
using System.Runtime.CompilerServices;

namespace Ryujinx.Graphics.Gpu.Engine.Compute
{
    /// <summary>
    /// Type of the dependent Queue Meta Data.
    /// </summary>
    enum DependentQmdType
    {
        Queue,
<<<<<<< HEAD
        Grid,
=======
        Grid
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Type of the release memory barrier.
    /// </summary>
    enum ReleaseMembarType
    {
        FeNone,
<<<<<<< HEAD
        FeSysmembar,
=======
        FeSysmembar
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Type of the CWD memory barrier.
    /// </summary>
    enum CwdMembarType
    {
        L1None,
        L1Sysmembar,
<<<<<<< HEAD
        L1Membar,
=======
        L1Membar
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// NaN behavior of 32-bits float operations on the shader.
    /// </summary>
    enum Fp32NanBehavior
    {
        Legacy,
<<<<<<< HEAD
        Fp64Compatible,
=======
        Fp64Compatible
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// NaN behavior of 32-bits float to integer conversion on the shader.
    /// </summary>
    enum Fp32F2iNanBehavior
    {
        PassZero,
<<<<<<< HEAD
        PassIndefinite,
=======
        PassIndefinite
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Limit of calls.
    /// </summary>
    enum ApiVisibleCallLimit
    {
        _32,
<<<<<<< HEAD
        NoCheck,
=======
        NoCheck
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Shared memory bank mapping mode.
    /// </summary>
    enum SharedMemoryBankMapping
    {
        FourBytesPerBank,
<<<<<<< HEAD
        EightBytesPerBank,
=======
        EightBytesPerBank
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Denormal behavior of 32-bits float narrowing instructions.
    /// </summary>
    enum Fp32NarrowInstruction
    {
        KeepDenorms,
<<<<<<< HEAD
        FlushDenorms,
=======
        FlushDenorms
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Configuration of the L1 cache.
    /// </summary>
    enum L1Configuration
    {
        DirectlyAddressableMemorySize16kb,
        DirectlyAddressableMemorySize32kb,
<<<<<<< HEAD
        DirectlyAddressableMemorySize48kb,
=======
        DirectlyAddressableMemorySize48kb
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Reduction operation.
    /// </summary>
    enum ReductionOp
    {
        RedAdd,
        RedMin,
        RedMax,
        RedInc,
        RedDec,
        RedAnd,
        RedOr,
<<<<<<< HEAD
        RedXor,
=======
        RedXor
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Reduction format.
    /// </summary>
    enum ReductionFormat
    {
        Unsigned32,
<<<<<<< HEAD
        Signed32,
=======
        Signed32
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Size of a structure in words.
    /// </summary>
    enum StructureSize
    {
        FourWords,
<<<<<<< HEAD
        OneWord,
=======
        OneWord
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Compute Queue Meta Data.
    /// </summary>
    unsafe struct ComputeQmd
    {
        private fixed int _words[64];

<<<<<<< HEAD
        public readonly int OuterPut => BitRange(30, 0);
        public readonly bool OuterOverflow => Bit(31);
        public readonly int OuterGet => BitRange(62, 32);
        public readonly bool OuterStickyOverflow => Bit(63);
        public readonly int InnerGet => BitRange(94, 64);
        public readonly bool InnerOverflow => Bit(95);
        public readonly int InnerPut => BitRange(126, 96);
        public readonly bool InnerStickyOverflow => Bit(127);
        public readonly int QmdReservedAA => BitRange(159, 128);
        public readonly int DependentQmdPointer => BitRange(191, 160);
        public readonly int QmdGroupId => BitRange(197, 192);
        public readonly bool SmGlobalCachingEnable => Bit(198);
        public readonly bool RunCtaInOneSmPartition => Bit(199);
        public readonly bool IsQueue => Bit(200);
        public readonly bool AddToHeadOfQmdGroupLinkedList => Bit(201);
        public readonly bool SemaphoreReleaseEnable0 => Bit(202);
        public readonly bool SemaphoreReleaseEnable1 => Bit(203);
        public readonly bool RequireSchedulingPcas => Bit(204);
        public readonly bool DependentQmdScheduleEnable => Bit(205);
        public readonly DependentQmdType DependentQmdType => (DependentQmdType)BitRange(206, 206);
        public readonly bool DependentQmdFieldCopy => Bit(207);
        public readonly int QmdReservedB => BitRange(223, 208);
        public readonly int CircularQueueSize => BitRange(248, 224);
        public readonly bool QmdReservedC => Bit(249);
        public readonly bool InvalidateTextureHeaderCache => Bit(250);
        public readonly bool InvalidateTextureSamplerCache => Bit(251);
        public readonly bool InvalidateTextureDataCache => Bit(252);
        public readonly bool InvalidateShaderDataCache => Bit(253);
        public readonly bool InvalidateInstructionCache => Bit(254);
        public readonly bool InvalidateShaderConstantCache => Bit(255);
        public readonly int ProgramOffset => BitRange(287, 256);
        public readonly int CircularQueueAddrLower => BitRange(319, 288);
        public readonly int CircularQueueAddrUpper => BitRange(327, 320);
        public readonly int QmdReservedD => BitRange(335, 328);
        public readonly int CircularQueueEntrySize => BitRange(351, 336);
        public readonly int CwdReferenceCountId => BitRange(357, 352);
        public readonly int CwdReferenceCountDeltaMinusOne => BitRange(365, 358);
        public readonly ReleaseMembarType ReleaseMembarType => (ReleaseMembarType)BitRange(366, 366);
        public readonly bool CwdReferenceCountIncrEnable => Bit(367);
        public readonly CwdMembarType CwdMembarType => (CwdMembarType)BitRange(369, 368);
        public readonly bool SequentiallyRunCtas => Bit(370);
        public readonly bool CwdReferenceCountDecrEnable => Bit(371);
        public readonly bool Throttled => Bit(372);
        public readonly Fp32NanBehavior Fp32NanBehavior => (Fp32NanBehavior)BitRange(376, 376);
        public readonly Fp32F2iNanBehavior Fp32F2iNanBehavior => (Fp32F2iNanBehavior)BitRange(377, 377);
        public readonly ApiVisibleCallLimit ApiVisibleCallLimit => (ApiVisibleCallLimit)BitRange(378, 378);
        public readonly SharedMemoryBankMapping SharedMemoryBankMapping => (SharedMemoryBankMapping)BitRange(379, 379);
        public readonly SamplerIndex SamplerIndex => (SamplerIndex)BitRange(382, 382);
        public readonly Fp32NarrowInstruction Fp32NarrowInstruction => (Fp32NarrowInstruction)BitRange(383, 383);
        public readonly int CtaRasterWidth => BitRange(415, 384);
        public readonly int CtaRasterHeight => BitRange(431, 416);
        public readonly int CtaRasterDepth => BitRange(447, 432);
        public readonly int CtaRasterWidthResume => BitRange(479, 448);
        public readonly int CtaRasterHeightResume => BitRange(495, 480);
        public readonly int CtaRasterDepthResume => BitRange(511, 496);
        public readonly int QueueEntriesPerCtaMinusOne => BitRange(518, 512);
        public readonly int CoalesceWaitingPeriod => BitRange(529, 522);
        public readonly int SharedMemorySize => BitRange(561, 544);
        public readonly int QmdReservedG => BitRange(575, 562);
        public readonly int QmdVersion => BitRange(579, 576);
        public readonly int QmdMajorVersion => BitRange(583, 580);
        public readonly int QmdReservedH => BitRange(591, 584);
        public readonly int CtaThreadDimension0 => BitRange(607, 592);
        public readonly int CtaThreadDimension1 => BitRange(623, 608);
        public readonly int CtaThreadDimension2 => BitRange(639, 624);
        public readonly bool ConstantBufferValid(int i) => Bit(640 + i * 1);
        public readonly int QmdReservedI => BitRange(668, 648);
        public readonly L1Configuration L1Configuration => (L1Configuration)BitRange(671, 669);
        public readonly int SmDisableMaskLower => BitRange(703, 672);
        public readonly int SmDisableMaskUpper => BitRange(735, 704);
        public readonly int Release0AddressLower => BitRange(767, 736);
        public readonly int Release0AddressUpper => BitRange(775, 768);
        public readonly int QmdReservedJ => BitRange(783, 776);
        public readonly ReductionOp Release0ReductionOp => (ReductionOp)BitRange(790, 788);
        public readonly bool QmdReservedK => Bit(791);
        public readonly ReductionFormat Release0ReductionFormat => (ReductionFormat)BitRange(793, 792);
        public readonly bool Release0ReductionEnable => Bit(794);
        public readonly StructureSize Release0StructureSize => (StructureSize)BitRange(799, 799);
        public readonly int Release0Payload => BitRange(831, 800);
        public readonly int Release1AddressLower => BitRange(863, 832);
        public readonly int Release1AddressUpper => BitRange(871, 864);
        public readonly int QmdReservedL => BitRange(879, 872);
        public readonly ReductionOp Release1ReductionOp => (ReductionOp)BitRange(886, 884);
        public readonly bool QmdReservedM => Bit(887);
        public readonly ReductionFormat Release1ReductionFormat => (ReductionFormat)BitRange(889, 888);
        public readonly bool Release1ReductionEnable => Bit(890);
        public readonly StructureSize Release1StructureSize => (StructureSize)BitRange(895, 895);
        public readonly int Release1Payload => BitRange(927, 896);
        public readonly int ConstantBufferAddrLower(int i) => BitRange(959 + i * 64, 928 + i * 64);
        public readonly int ConstantBufferAddrUpper(int i) => BitRange(967 + i * 64, 960 + i * 64);
        public readonly int ConstantBufferReservedAddr(int i) => BitRange(973 + i * 64, 968 + i * 64);
        public readonly bool ConstantBufferInvalidate(int i) => Bit(974 + i * 64);
        public readonly int ConstantBufferSize(int i) => BitRange(991 + i * 64, 975 + i * 64);
        public readonly int ShaderLocalMemoryLowSize => BitRange(1463, 1440);
        public readonly int QmdReservedN => BitRange(1466, 1464);
        public readonly int BarrierCount => BitRange(1471, 1467);
        public readonly int ShaderLocalMemoryHighSize => BitRange(1495, 1472);
        public readonly int RegisterCount => BitRange(1503, 1496);
        public readonly int ShaderLocalMemoryCrsSize => BitRange(1527, 1504);
        public readonly int SassVersion => BitRange(1535, 1528);
        public readonly int HwOnlyInnerGet => BitRange(1566, 1536);
        public readonly bool HwOnlyRequireSchedulingPcas => Bit(1567);
        public readonly int HwOnlyInnerPut => BitRange(1598, 1568);
        public readonly bool HwOnlyScgType => Bit(1599);
        public readonly int HwOnlySpanListHeadIndex => BitRange(1629, 1600);
        public readonly bool QmdReservedQ => Bit(1630);
        public readonly bool HwOnlySpanListHeadIndexValid => Bit(1631);
        public readonly int HwOnlySkedNextQmdPointer => BitRange(1663, 1632);
        public readonly int QmdSpareE => BitRange(1695, 1664);
        public readonly int QmdSpareF => BitRange(1727, 1696);
        public readonly int QmdSpareG => BitRange(1759, 1728);
        public readonly int QmdSpareH => BitRange(1791, 1760);
        public readonly int QmdSpareI => BitRange(1823, 1792);
        public readonly int QmdSpareJ => BitRange(1855, 1824);
        public readonly int QmdSpareK => BitRange(1887, 1856);
        public readonly int QmdSpareL => BitRange(1919, 1888);
        public readonly int QmdSpareM => BitRange(1951, 1920);
        public readonly int QmdSpareN => BitRange(1983, 1952);
        public readonly int DebugIdUpper => BitRange(2015, 1984);
        public readonly int DebugIdLower => BitRange(2047, 2016);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly bool Bit(int bit)
=======
        public int OuterPut => BitRange(30, 0);
        public bool OuterOverflow => Bit(31);
        public int OuterGet => BitRange(62, 32);
        public bool OuterStickyOverflow => Bit(63);
        public int InnerGet => BitRange(94, 64);
        public bool InnerOverflow => Bit(95);
        public int InnerPut => BitRange(126, 96);
        public bool InnerStickyOverflow => Bit(127);
        public int QmdReservedAA => BitRange(159, 128);
        public int DependentQmdPointer => BitRange(191, 160);
        public int QmdGroupId => BitRange(197, 192);
        public bool SmGlobalCachingEnable => Bit(198);
        public bool RunCtaInOneSmPartition => Bit(199);
        public bool IsQueue => Bit(200);
        public bool AddToHeadOfQmdGroupLinkedList => Bit(201);
        public bool SemaphoreReleaseEnable0 => Bit(202);
        public bool SemaphoreReleaseEnable1 => Bit(203);
        public bool RequireSchedulingPcas => Bit(204);
        public bool DependentQmdScheduleEnable => Bit(205);
        public DependentQmdType DependentQmdType => (DependentQmdType)BitRange(206, 206);
        public bool DependentQmdFieldCopy => Bit(207);
        public int QmdReservedB => BitRange(223, 208);
        public int CircularQueueSize => BitRange(248, 224);
        public bool QmdReservedC => Bit(249);
        public bool InvalidateTextureHeaderCache => Bit(250);
        public bool InvalidateTextureSamplerCache => Bit(251);
        public bool InvalidateTextureDataCache => Bit(252);
        public bool InvalidateShaderDataCache => Bit(253);
        public bool InvalidateInstructionCache => Bit(254);
        public bool InvalidateShaderConstantCache => Bit(255);
        public int ProgramOffset => BitRange(287, 256);
        public int CircularQueueAddrLower => BitRange(319, 288);
        public int CircularQueueAddrUpper => BitRange(327, 320);
        public int QmdReservedD => BitRange(335, 328);
        public int CircularQueueEntrySize => BitRange(351, 336);
        public int CwdReferenceCountId => BitRange(357, 352);
        public int CwdReferenceCountDeltaMinusOne => BitRange(365, 358);
        public ReleaseMembarType ReleaseMembarType => (ReleaseMembarType)BitRange(366, 366);
        public bool CwdReferenceCountIncrEnable => Bit(367);
        public CwdMembarType CwdMembarType => (CwdMembarType)BitRange(369, 368);
        public bool SequentiallyRunCtas => Bit(370);
        public bool CwdReferenceCountDecrEnable => Bit(371);
        public bool Throttled => Bit(372);
        public Fp32NanBehavior Fp32NanBehavior => (Fp32NanBehavior)BitRange(376, 376);
        public Fp32F2iNanBehavior Fp32F2iNanBehavior => (Fp32F2iNanBehavior)BitRange(377, 377);
        public ApiVisibleCallLimit ApiVisibleCallLimit => (ApiVisibleCallLimit)BitRange(378, 378);
        public SharedMemoryBankMapping SharedMemoryBankMapping => (SharedMemoryBankMapping)BitRange(379, 379);
        public SamplerIndex SamplerIndex => (SamplerIndex)BitRange(382, 382);
        public Fp32NarrowInstruction Fp32NarrowInstruction => (Fp32NarrowInstruction)BitRange(383, 383);
        public int CtaRasterWidth => BitRange(415, 384);
        public int CtaRasterHeight => BitRange(431, 416);
        public int CtaRasterDepth => BitRange(447, 432);
        public int CtaRasterWidthResume => BitRange(479, 448);
        public int CtaRasterHeightResume => BitRange(495, 480);
        public int CtaRasterDepthResume => BitRange(511, 496);
        public int QueueEntriesPerCtaMinusOne => BitRange(518, 512);
        public int CoalesceWaitingPeriod => BitRange(529, 522);
        public int SharedMemorySize => BitRange(561, 544);
        public int QmdReservedG => BitRange(575, 562);
        public int QmdVersion => BitRange(579, 576);
        public int QmdMajorVersion => BitRange(583, 580);
        public int QmdReservedH => BitRange(591, 584);
        public int CtaThreadDimension0 => BitRange(607, 592);
        public int CtaThreadDimension1 => BitRange(623, 608);
        public int CtaThreadDimension2 => BitRange(639, 624);
        public bool ConstantBufferValid(int i) => Bit(640 + i * 1);
        public int QmdReservedI => BitRange(668, 648);
        public L1Configuration L1Configuration => (L1Configuration)BitRange(671, 669);
        public int SmDisableMaskLower => BitRange(703, 672);
        public int SmDisableMaskUpper => BitRange(735, 704);
        public int Release0AddressLower => BitRange(767, 736);
        public int Release0AddressUpper => BitRange(775, 768);
        public int QmdReservedJ => BitRange(783, 776);
        public ReductionOp Release0ReductionOp => (ReductionOp)BitRange(790, 788);
        public bool QmdReservedK => Bit(791);
        public ReductionFormat Release0ReductionFormat => (ReductionFormat)BitRange(793, 792);
        public bool Release0ReductionEnable => Bit(794);
        public StructureSize Release0StructureSize => (StructureSize)BitRange(799, 799);
        public int Release0Payload => BitRange(831, 800);
        public int Release1AddressLower => BitRange(863, 832);
        public int Release1AddressUpper => BitRange(871, 864);
        public int QmdReservedL => BitRange(879, 872);
        public ReductionOp Release1ReductionOp => (ReductionOp)BitRange(886, 884);
        public bool QmdReservedM => Bit(887);
        public ReductionFormat Release1ReductionFormat => (ReductionFormat)BitRange(889, 888);
        public bool Release1ReductionEnable => Bit(890);
        public StructureSize Release1StructureSize => (StructureSize)BitRange(895, 895);
        public int Release1Payload => BitRange(927, 896);
        public int ConstantBufferAddrLower(int i) => BitRange(959 + i * 64, 928 + i * 64);
        public int ConstantBufferAddrUpper(int i) => BitRange(967 + i * 64, 960 + i * 64);
        public int ConstantBufferReservedAddr(int i) => BitRange(973 + i * 64, 968 + i * 64);
        public bool ConstantBufferInvalidate(int i) => Bit(974 + i * 64);
        public int ConstantBufferSize(int i) => BitRange(991 + i * 64, 975 + i * 64);
        public int ShaderLocalMemoryLowSize => BitRange(1463, 1440);
        public int QmdReservedN => BitRange(1466, 1464);
        public int BarrierCount => BitRange(1471, 1467);
        public int ShaderLocalMemoryHighSize => BitRange(1495, 1472);
        public int RegisterCount => BitRange(1503, 1496);
        public int ShaderLocalMemoryCrsSize => BitRange(1527, 1504);
        public int SassVersion => BitRange(1535, 1528);
        public int HwOnlyInnerGet => BitRange(1566, 1536);
        public bool HwOnlyRequireSchedulingPcas => Bit(1567);
        public int HwOnlyInnerPut => BitRange(1598, 1568);
        public bool HwOnlyScgType => Bit(1599);
        public int HwOnlySpanListHeadIndex => BitRange(1629, 1600);
        public bool QmdReservedQ => Bit(1630);
        public bool HwOnlySpanListHeadIndexValid => Bit(1631);
        public int HwOnlySkedNextQmdPointer => BitRange(1663, 1632);
        public int QmdSpareE => BitRange(1695, 1664);
        public int QmdSpareF => BitRange(1727, 1696);
        public int QmdSpareG => BitRange(1759, 1728);
        public int QmdSpareH => BitRange(1791, 1760);
        public int QmdSpareI => BitRange(1823, 1792);
        public int QmdSpareJ => BitRange(1855, 1824);
        public int QmdSpareK => BitRange(1887, 1856);
        public int QmdSpareL => BitRange(1919, 1888);
        public int QmdSpareM => BitRange(1951, 1920);
        public int QmdSpareN => BitRange(1983, 1952);
        public int DebugIdUpper => BitRange(2015, 1984);
        public int DebugIdLower => BitRange(2047, 2016);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool Bit(int bit)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if ((uint)bit >= 64 * 32)
            {
                throw new ArgumentOutOfRangeException(nameof(bit));
            }

            return (_words[bit >> 5] & (1 << (bit & 31))) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
<<<<<<< HEAD
        private readonly int BitRange(int upper, int lower)
=======
        private int BitRange(int upper, int lower)
>>>>>>> 1ec71635b (sync with main branch)
        {
            if ((uint)lower >= 64 * 32)
            {
                throw new ArgumentOutOfRangeException(nameof(lower));
            }

            int mask = (int)(uint.MaxValue >> (32 - (upper - lower + 1)));

            return (_words[lower >> 5] >> (lower & 31)) & mask;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
