namespace ARMeilleure.CodeGen.Arm64
{
<<<<<<< HEAD
    readonly struct IntrinsicInfo
    {
        public uint Inst { get; }
=======
    struct IntrinsicInfo
    {
        public uint          Inst { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public IntrinsicType Type { get; }

        public IntrinsicInfo(uint inst, IntrinsicType type)
        {
            Inst = inst;
            Type = type;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
