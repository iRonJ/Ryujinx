using Ryujinx.Graphics.Shader.IntermediateRepresentation;

namespace Ryujinx.Graphics.Shader.StructuredIr
{
    class GotoStatement
    {
<<<<<<< HEAD
        public AstOperation Goto { get; }
=======
        public AstOperation  Goto  { get; }
>>>>>>> 1ec71635b (sync with main branch)
        public AstAssignment Label { get; }

        public IAstNode Condition => Label.Destination;

        public bool IsLoop { get; set; }

        public bool IsUnconditional => Goto.Inst == Instruction.Branch;

        public GotoStatement(AstOperation branch, AstAssignment label, bool isLoop)
        {
<<<<<<< HEAD
            Goto = branch;
            Label = label;
            IsLoop = isLoop;
        }
    }
}
=======
            Goto   = branch;
            Label  = label;
            IsLoop = isLoop;
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
