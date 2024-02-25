using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class MemberExpression : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _leftNode;
        private readonly string _kind;
        private readonly BaseNode _rightNode;

        public MemberExpression(BaseNode leftNode, string kind, BaseNode rightNode) : base(NodeType.MemberExpression)
        {
            _leftNode = leftNode;
            _kind = kind;
=======
        private BaseNode _leftNode;
        private string   _kind;
        private BaseNode _rightNode;

        public MemberExpression(BaseNode leftNode, string kind, BaseNode rightNode) : base(NodeType.MemberExpression)
        {
            _leftNode  = leftNode;
            _kind      = kind;
>>>>>>> 1ec71635b (sync with main branch)
            _rightNode = rightNode;
        }

        public override void PrintLeft(TextWriter writer)
        {
            _leftNode.Print(writer);
            writer.Write(_kind);
            _rightNode.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
