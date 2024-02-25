namespace ARMeilleure.CodeGen.Unwinding
{
    struct UnwindInfo
    {
        public const int Stride = 4; // Bytes.

        public UnwindPushEntry[] PushEntries { get; }
        public int PrologSize { get; }

        public UnwindInfo(UnwindPushEntry[] pushEntries, int prologSize)
        {
            PushEntries = pushEntries;
            PrologSize = prologSize;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
