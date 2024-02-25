using ARMeilleure.Translation;

namespace ARMeilleure.CodeGen.RegisterAllocators
{
    interface IRegisterAllocator
    {
        AllocationResult RunPass(
            ControlFlowGraph cfg,
            StackAllocator stackAlloc,
            RegisterMasks regMasks);
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
