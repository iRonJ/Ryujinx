using ARMeilleure.IntermediateRepresentation;

namespace ARMeilleure.Decoders
{
    interface IOpCode
    {
        ulong Address { get; }

        InstDescriptor Instruction { get; }

        RegisterSize RegisterSize { get; }

        int GetBitsCount();

        OperandType GetOperandType();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
