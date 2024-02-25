using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class PostfixExpression : ParentNode
    {
<<<<<<< HEAD
        private readonly string _operator;
=======
        private string _operator;
>>>>>>> 1ec71635b (sync with main branch)

        public PostfixExpression(BaseNode type, string Operator) : base(NodeType.PostfixExpression, type)
        {
            _operator = Operator;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("(");
            Child.Print(writer);
            writer.Write(")");
            writer.Write(_operator);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
