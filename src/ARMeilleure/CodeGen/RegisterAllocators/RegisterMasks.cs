using ARMeilleure.IntermediateRepresentation;
using System;

namespace ARMeilleure.CodeGen.RegisterAllocators
{
    readonly struct RegisterMasks
    {
<<<<<<< HEAD
        public int IntAvailableRegisters { get; }
        public int VecAvailableRegisters { get; }
=======
        public int IntAvailableRegisters   { get; }
        public int VecAvailableRegisters   { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public int IntCallerSavedRegisters { get; }
        public int VecCallerSavedRegisters { get; }
        public int IntCalleeSavedRegisters { get; }
        public int VecCalleeSavedRegisters { get; }
        public int RegistersCount { get; }

        public RegisterMasks(
            int intAvailableRegisters,
            int vecAvailableRegisters,
            int intCallerSavedRegisters,
            int vecCallerSavedRegisters,
            int intCalleeSavedRegisters,
            int vecCalleeSavedRegisters,
            int registersCount)
        {
<<<<<<< HEAD
            IntAvailableRegisters = intAvailableRegisters;
            VecAvailableRegisters = vecAvailableRegisters;
=======
            IntAvailableRegisters   = intAvailableRegisters;
            VecAvailableRegisters   = vecAvailableRegisters;
>>>>>>> 1ec71635b (sync with main branch)
            IntCallerSavedRegisters = intCallerSavedRegisters;
            VecCallerSavedRegisters = vecCallerSavedRegisters;
            IntCalleeSavedRegisters = intCalleeSavedRegisters;
            VecCalleeSavedRegisters = vecCalleeSavedRegisters;
<<<<<<< HEAD
            RegistersCount = registersCount;
=======
            RegistersCount          = registersCount;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public int GetAvailableRegisters(RegisterType type)
        {
            if (type == RegisterType.Integer)
            {
                return IntAvailableRegisters;
            }
            else if (type == RegisterType.Vector)
            {
                return VecAvailableRegisters;
            }
            else
            {
                throw new ArgumentException($"Invalid register type \"{type}\".");
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
