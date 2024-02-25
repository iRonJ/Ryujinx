namespace ARMeilleure.CodeGen.X86
{
    readonly struct IntrinsicInfo
    {
        public X86Instruction Inst { get; }
<<<<<<< HEAD
        public IntrinsicType Type { get; }
=======
        public IntrinsicType  Type { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public IntrinsicInfo(X86Instruction inst, IntrinsicType type)
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
