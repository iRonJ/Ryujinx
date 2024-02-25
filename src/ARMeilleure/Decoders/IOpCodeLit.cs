namespace ARMeilleure.Decoders
{
    interface IOpCodeLit : IOpCode
    {
<<<<<<< HEAD
        int Rt { get; }
        long Immediate { get; }
        int Size { get; }
        bool Signed { get; }
        bool Prefetch { get; }
    }
}
=======
        int  Rt        { get; }
        long Immediate { get; }
        int  Size      { get; }
        bool Signed    { get; }
        bool Prefetch  { get; }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
