using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class DeleteExpression : ParentNode
    {
<<<<<<< HEAD
        private readonly bool _isGlobal;
        private readonly bool _isArrayExpression;

        public DeleteExpression(BaseNode child, bool isGlobal, bool isArrayExpression) : base(NodeType.DeleteExpression, child)
        {
            _isGlobal = isGlobal;
=======
        private bool _isGlobal;
        private bool _isArrayExpression;

        public DeleteExpression(BaseNode child, bool isGlobal, bool isArrayExpression) : base(NodeType.DeleteExpression, child)
        {
            _isGlobal          = isGlobal;
>>>>>>> 1ec71635b (sync with main branch)
            _isArrayExpression = isArrayExpression;
        }

        public override void PrintLeft(TextWriter writer)
        {
            if (_isGlobal)
            {
                writer.Write("::");
            }

            writer.Write("delete");

            if (_isArrayExpression)
            {
                writer.Write("[] ");
            }

            Child.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
