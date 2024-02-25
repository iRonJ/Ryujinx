using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class ConversionExpression : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _typeNode;
        private readonly BaseNode _expressions;

        public ConversionExpression(BaseNode typeNode, BaseNode expressions) : base(NodeType.ConversionExpression)
        {
            _typeNode = typeNode;
=======
        private BaseNode _typeNode;
        private BaseNode _expressions;

        public ConversionExpression(BaseNode typeNode, BaseNode expressions) : base(NodeType.ConversionExpression)
        {
            _typeNode    = typeNode;
>>>>>>> 1ec71635b (sync with main branch)
            _expressions = expressions;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("(");
            _typeNode.Print(writer);
            writer.Write(")(");
            _expressions.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
