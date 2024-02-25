using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class IntegerCastExpression : ParentNode
    {
<<<<<<< HEAD
        private readonly string _number;
=======
        private string _number;
>>>>>>> 1ec71635b (sync with main branch)

        public IntegerCastExpression(BaseNode type, string number) : base(NodeType.IntegerCastExpression, type)
        {
            _number = number;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("(");
            Child.Print(writer);
            writer.Write(")");
            writer.Write(_number);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
