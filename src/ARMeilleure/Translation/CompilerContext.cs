using ARMeilleure.IntermediateRepresentation;

namespace ARMeilleure.Translation
{
    readonly struct CompilerContext
    {
        public ControlFlowGraph Cfg { get; }

<<<<<<< HEAD
        public OperandType[] FuncArgTypes { get; }
        public OperandType FuncReturnType { get; }
=======
        public OperandType[] FuncArgTypes   { get; }
        public OperandType   FuncReturnType { get; }
>>>>>>> 1ec71635b (sync with main branch)

        public CompilerOptions Options { get; }

        public CompilerContext(
            ControlFlowGraph cfg,
<<<<<<< HEAD
            OperandType[] funcArgTypes,
            OperandType funcReturnType,
            CompilerOptions options)
        {
            Cfg = cfg;
            FuncArgTypes = funcArgTypes;
            FuncReturnType = funcReturnType;
            Options = options;
        }
    }
}
=======
            OperandType[]    funcArgTypes,
            OperandType      funcReturnType,
            CompilerOptions  options)
        {
            Cfg            = cfg;
            FuncArgTypes   = funcArgTypes;
            FuncReturnType = funcReturnType;
            Options        = options;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
