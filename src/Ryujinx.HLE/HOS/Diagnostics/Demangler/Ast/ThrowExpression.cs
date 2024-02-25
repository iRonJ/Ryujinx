using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class ThrowExpression : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _expression;
=======
        private BaseNode _expression;
>>>>>>> 1ec71635b (sync with main branch)

        public ThrowExpression(BaseNode expression) : base(NodeType.ThrowExpression)
        {
            _expression = expression;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("throw ");
            _expression.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
