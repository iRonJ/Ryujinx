namespace ARMeilleure.Decoders
{
    interface IOpCode32 : IOpCode
    {
        Condition Cond { get; }

        uint GetPc();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
