namespace ARMeilleure.Decoders
{
    interface IOpCodeAluRs : IOpCodeAlu
    {
        int Shift { get; }
<<<<<<< HEAD
        int Rm { get; }

        ShiftType ShiftType { get; }
    }
}
=======
        int Rm    { get; }

        ShiftType ShiftType { get; }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
