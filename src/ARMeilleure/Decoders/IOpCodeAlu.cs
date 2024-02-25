namespace ARMeilleure.Decoders
{
    interface IOpCodeAlu : IOpCode
    {
        int Rd { get; }
        int Rn { get; }

        DataOp DataOp { get; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
