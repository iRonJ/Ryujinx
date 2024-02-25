namespace ARMeilleure.CodeGen.RegisterAllocators
{
    readonly struct AllocationResult
    {
        public int IntUsedRegisters { get; }
        public int VecUsedRegisters { get; }
<<<<<<< HEAD
        public int SpillRegionSize { get; }
=======
        public int SpillRegionSize  { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public AllocationResult(
            int intUsedRegisters,
            int vecUsedRegisters,
            int spillRegionSize)
        {
            IntUsedRegisters = intUsedRegisters;
            VecUsedRegisters = vecUsedRegisters;
<<<<<<< HEAD
            SpillRegionSize = spillRegionSize;
        }
    }
}
=======
            SpillRegionSize  = spillRegionSize;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
