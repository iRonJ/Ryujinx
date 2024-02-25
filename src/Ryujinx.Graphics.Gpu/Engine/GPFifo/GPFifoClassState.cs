<<<<<<< HEAD
// This file was auto-generated from NVIDIA official Maxwell definitions.
=======
﻿// This file was auto-generated from NVIDIA official Maxwell definitions.
>>>>>>> 1ec71635b (sync with main branch)

using Ryujinx.Common.Memory;

namespace Ryujinx.Graphics.Gpu.Engine.GPFifo
{
    /// <summary>
    /// Semaphore operation.
    /// </summary>
    enum SemaphoredOperation
    {
        Acquire = 1,
        Release = 2,
        AcqGeq = 4,
        AcqAnd = 8,
<<<<<<< HEAD
        Reduction = 16,
=======
        Reduction = 16
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Semaphore acquire switch enable.
    /// </summary>
    enum SemaphoredAcquireSwitch
    {
        Disabled = 0,
<<<<<<< HEAD
        Enabled = 1,
=======
        Enabled = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Semaphore release interrupt wait enable.
    /// </summary>
    enum SemaphoredReleaseWfi
    {
        En = 0,
<<<<<<< HEAD
        Dis = 1,
=======
        Dis = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Semaphore release structure size.
    /// </summary>
    enum SemaphoredReleaseSize
    {
        SixteenBytes = 0,
<<<<<<< HEAD
        FourBytes = 1,
=======
        FourBytes = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Semaphore reduction operation.
    /// </summary>
    enum SemaphoredReduction
    {
        Min = 0,
        Max = 1,
        Xor = 2,
        And = 3,
        Or = 4,
        Add = 5,
        Inc = 6,
<<<<<<< HEAD
        Dec = 7,
=======
        Dec = 7
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Semaphore format.
    /// </summary>
    enum SemaphoredFormat
    {
        Signed = 0,
<<<<<<< HEAD
        Unsigned = 1,
=======
        Unsigned = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Memory Translation Lookaside Buffer Page Directory Buffer invalidation.
    /// </summary>
    enum MemOpCTlbInvalidatePdb
    {
        One = 0,
<<<<<<< HEAD
        All = 1,
=======
        All = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Memory Translation Lookaside Buffer GPC invalidation enable.
    /// </summary>
    enum MemOpCTlbInvalidateGpc
    {
        Enable = 0,
<<<<<<< HEAD
        Disable = 1,
=======
        Disable = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Memory Translation Lookaside Buffer invalidation target.
    /// </summary>
    enum MemOpCTlbInvalidateTarget
    {
        VidMem = 0,
        SysMemCoherent = 2,
<<<<<<< HEAD
        SysMemNoncoherent = 3,
=======
        SysMemNoncoherent = 3
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Memory operation.
    /// </summary>
    enum MemOpDOperation
    {
        Membar = 5,
        MmuTlbInvalidate = 9,
        L2PeermemInvalidate = 13,
        L2SysmemInvalidate = 14,
        L2CleanComptags = 15,
<<<<<<< HEAD
        L2FlushDirty = 16,
=======
        L2FlushDirty = 16
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Syncpoint operation.
    /// </summary>
    enum SyncpointbOperation
    {
        Wait = 0,
<<<<<<< HEAD
        Incr = 1,
=======
        Incr = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Syncpoint wait switch enable.
    /// </summary>
    enum SyncpointbWaitSwitch
    {
        Dis = 0,
<<<<<<< HEAD
        En = 1,
=======
        En = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Wait for interrupt scope.
    /// </summary>
    enum WfiScope
    {
        CurrentScgType = 0,
<<<<<<< HEAD
        All = 1,
=======
        All = 1
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// Yield operation.
    /// </summary>
    enum YieldOp
    {
        Nop = 0,
        PbdmaTimeslice = 1,
        RunlistTimeslice = 2,
<<<<<<< HEAD
        Tsg = 3,
=======
        Tsg = 3
>>>>>>> 1ec71635b (sync with main branch)
    }

    /// <summary>
    /// General Purpose FIFO class state.
    /// </summary>
    struct GPFifoClassState
    {
<<<<<<< HEAD
#pragma warning disable CS0649 // Field is never assigned to
        public uint SetObject;
        public readonly int SetObjectNvclass => (int)(SetObject & 0xFFFF);
        public readonly int SetObjectEngine => (int)((SetObject >> 16) & 0x1F);
        public uint Illegal;
        public readonly int IllegalHandle => (int)(Illegal);
        public uint Nop;
        public readonly int NopHandle => (int)(Nop);
        public uint Reserved0C;
        public uint Semaphorea;
        public readonly int SemaphoreaOffsetUpper => (int)(Semaphorea & 0xFF);
        public uint Semaphoreb;
        public readonly int SemaphorebOffsetLower => (int)((Semaphoreb >> 2) & 0x3FFFFFFF);
        public uint Semaphorec;
        public readonly int SemaphorecPayload => (int)(Semaphorec);
        public uint Semaphored;
        public readonly SemaphoredOperation SemaphoredOperation => (SemaphoredOperation)(Semaphored & 0x1F);
        public readonly SemaphoredAcquireSwitch SemaphoredAcquireSwitch => (SemaphoredAcquireSwitch)((Semaphored >> 12) & 0x1);
        public readonly SemaphoredReleaseWfi SemaphoredReleaseWfi => (SemaphoredReleaseWfi)((Semaphored >> 20) & 0x1);
        public readonly SemaphoredReleaseSize SemaphoredReleaseSize => (SemaphoredReleaseSize)((Semaphored >> 24) & 0x1);
        public readonly SemaphoredReduction SemaphoredReduction => (SemaphoredReduction)((Semaphored >> 27) & 0xF);
        public readonly SemaphoredFormat SemaphoredFormat => (SemaphoredFormat)((Semaphored >> 31) & 0x1);
        public uint NonStallInterrupt;
        public readonly int NonStallInterruptHandle => (int)(NonStallInterrupt);
        public uint FbFlush;
        public readonly int FbFlushHandle => (int)(FbFlush);
        public uint Reserved28;
        public uint Reserved2C;
        public uint MemOpC;
        public readonly int MemOpCOperandLow => (int)((MemOpC >> 2) & 0x3FFFFFFF);
        public readonly MemOpCTlbInvalidatePdb MemOpCTlbInvalidatePdb => (MemOpCTlbInvalidatePdb)(MemOpC & 0x1);
        public readonly MemOpCTlbInvalidateGpc MemOpCTlbInvalidateGpc => (MemOpCTlbInvalidateGpc)((MemOpC >> 1) & 0x1);
        public readonly MemOpCTlbInvalidateTarget MemOpCTlbInvalidateTarget => (MemOpCTlbInvalidateTarget)((MemOpC >> 10) & 0x3);
        public readonly int MemOpCTlbInvalidateAddrLo => (int)((MemOpC >> 12) & 0xFFFFF);
        public uint MemOpD;
        public readonly int MemOpDOperandHigh => (int)(MemOpD & 0xFF);
        public readonly MemOpDOperation MemOpDOperation => (MemOpDOperation)((MemOpD >> 27) & 0x1F);
        public readonly int MemOpDTlbInvalidateAddrHi => (int)(MemOpD & 0xFF);
=======
#pragma warning disable CS0649
        public uint SetObject;
        public int SetObjectNvclass => (int)((SetObject >> 0) & 0xFFFF);
        public int SetObjectEngine => (int)((SetObject >> 16) & 0x1F);
        public uint Illegal;
        public int IllegalHandle => (int)(Illegal);
        public uint Nop;
        public int NopHandle => (int)(Nop);
        public uint Reserved0C;
        public uint Semaphorea;
        public int SemaphoreaOffsetUpper => (int)((Semaphorea >> 0) & 0xFF);
        public uint Semaphoreb;
        public int SemaphorebOffsetLower => (int)((Semaphoreb >> 2) & 0x3FFFFFFF);
        public uint Semaphorec;
        public int SemaphorecPayload => (int)(Semaphorec);
        public uint Semaphored;
        public SemaphoredOperation SemaphoredOperation => (SemaphoredOperation)((Semaphored >> 0) & 0x1F);
        public SemaphoredAcquireSwitch SemaphoredAcquireSwitch => (SemaphoredAcquireSwitch)((Semaphored >> 12) & 0x1);
        public SemaphoredReleaseWfi SemaphoredReleaseWfi => (SemaphoredReleaseWfi)((Semaphored >> 20) & 0x1);
        public SemaphoredReleaseSize SemaphoredReleaseSize => (SemaphoredReleaseSize)((Semaphored >> 24) & 0x1);
        public SemaphoredReduction SemaphoredReduction => (SemaphoredReduction)((Semaphored >> 27) & 0xF);
        public SemaphoredFormat SemaphoredFormat => (SemaphoredFormat)((Semaphored >> 31) & 0x1);
        public uint NonStallInterrupt;
        public int NonStallInterruptHandle => (int)(NonStallInterrupt);
        public uint FbFlush;
        public int FbFlushHandle => (int)(FbFlush);
        public uint Reserved28;
        public uint Reserved2C;
        public uint MemOpC;
        public int MemOpCOperandLow => (int)((MemOpC >> 2) & 0x3FFFFFFF);
        public MemOpCTlbInvalidatePdb MemOpCTlbInvalidatePdb => (MemOpCTlbInvalidatePdb)((MemOpC >> 0) & 0x1);
        public MemOpCTlbInvalidateGpc MemOpCTlbInvalidateGpc => (MemOpCTlbInvalidateGpc)((MemOpC >> 1) & 0x1);
        public MemOpCTlbInvalidateTarget MemOpCTlbInvalidateTarget => (MemOpCTlbInvalidateTarget)((MemOpC >> 10) & 0x3);
        public int MemOpCTlbInvalidateAddrLo => (int)((MemOpC >> 12) & 0xFFFFF);
        public uint MemOpD;
        public int MemOpDOperandHigh => (int)((MemOpD >> 0) & 0xFF);
        public MemOpDOperation MemOpDOperation => (MemOpDOperation)((MemOpD >> 27) & 0x1F);
        public int MemOpDTlbInvalidateAddrHi => (int)((MemOpD >> 0) & 0xFF);
>>>>>>> 1ec71635b (sync with main branch)
        public uint Reserved38;
        public uint Reserved3C;
        public uint Reserved40;
        public uint Reserved44;
        public uint Reserved48;
        public uint Reserved4C;
        public uint SetReference;
<<<<<<< HEAD
        public readonly int SetReferenceCount => (int)(SetReference);
=======
        public int SetReferenceCount => (int)(SetReference);
>>>>>>> 1ec71635b (sync with main branch)
        public uint Reserved54;
        public uint Reserved58;
        public uint Reserved5C;
        public uint Reserved60;
        public uint Reserved64;
        public uint Reserved68;
        public uint Reserved6C;
        public uint Syncpointa;
<<<<<<< HEAD
        public readonly int SyncpointaPayload => (int)(Syncpointa);
        public uint Syncpointb;
        public readonly SyncpointbOperation SyncpointbOperation => (SyncpointbOperation)(Syncpointb & 0x1);
        public readonly SyncpointbWaitSwitch SyncpointbWaitSwitch => (SyncpointbWaitSwitch)((Syncpointb >> 4) & 0x1);
        public readonly int SyncpointbSyncptIndex => (int)((Syncpointb >> 8) & 0xFFF);
        public uint Wfi;
        public readonly WfiScope WfiScope => (WfiScope)(Wfi & 0x1);
        public uint CrcCheck;
        public readonly int CrcCheckValue => (int)(CrcCheck);
        public uint Yield;
        public readonly YieldOp YieldOp => (YieldOp)(Yield & 0x3);
=======
        public int SyncpointaPayload => (int)(Syncpointa);
        public uint Syncpointb;
        public SyncpointbOperation SyncpointbOperation => (SyncpointbOperation)((Syncpointb >> 0) & 0x1);
        public SyncpointbWaitSwitch SyncpointbWaitSwitch => (SyncpointbWaitSwitch)((Syncpointb >> 4) & 0x1);
        public int SyncpointbSyncptIndex => (int)((Syncpointb >> 8) & 0xFFF);
        public uint Wfi;
        public WfiScope WfiScope => (WfiScope)((Wfi >> 0) & 0x1);
        public uint CrcCheck;
        public int CrcCheckValue => (int)(CrcCheck);
        public uint Yield;
        public YieldOp YieldOp => (YieldOp)((Yield >> 0) & 0x3);
>>>>>>> 1ec71635b (sync with main branch)
        // TODO: Eventually move this to per-engine state.
        public Array31<uint> Reserved84;
        public uint NoOperation;
        public uint SetNotifyA;
        public uint SetNotifyB;
        public uint Notify;
        public uint WaitForIdle;
        public uint LoadMmeInstructionRamPointer;
        public uint LoadMmeInstructionRam;
        public uint LoadMmeStartAddressRamPointer;
        public uint LoadMmeStartAddressRam;
        public uint SetMmeShadowRamControl;
#pragma warning restore CS0649
    }
}
