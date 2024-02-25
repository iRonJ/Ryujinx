using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class ConditionalExpression : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _thenNode;
        private readonly BaseNode _elseNode;
        private readonly BaseNode _conditionNode;

        public ConditionalExpression(BaseNode conditionNode, BaseNode thenNode, BaseNode elseNode) : base(NodeType.ConditionalExpression)
        {
            _thenNode = thenNode;
            _conditionNode = conditionNode;
            _elseNode = elseNode;
=======
        private BaseNode _thenNode;
        private BaseNode _elseNode;
        private BaseNode _conditionNode;

        public ConditionalExpression(BaseNode conditionNode, BaseNode thenNode, BaseNode elseNode) : base(NodeType.ConditionalExpression)
        {
            _thenNode      = thenNode;
            _conditionNode = conditionNode;
            _elseNode      = elseNode;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("(");
            _conditionNode.Print(writer);
            writer.Write(") ? (");
            _thenNode.Print(writer);
            writer.Write(") : (");
            _elseNode.Print(writer);
            writer.Write(")");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
