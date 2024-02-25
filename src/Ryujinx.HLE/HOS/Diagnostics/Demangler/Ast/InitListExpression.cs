using System.Collections.Generic;
using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class InitListExpression : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _typeNode;
        private readonly List<BaseNode> _nodes;
=======
        private BaseNode       _typeNode;
        private List<BaseNode> _nodes;
>>>>>>> 1ec71635b (sync with main branch)

        public InitListExpression(BaseNode typeNode, List<BaseNode> nodes) : base(NodeType.InitListExpression)
        {
            _typeNode = typeNode;
<<<<<<< HEAD
            _nodes = nodes;
=======
            _nodes    = nodes;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override void PrintLeft(TextWriter writer)
        {
<<<<<<< HEAD
            _typeNode?.Print(writer);
=======
            if (_typeNode != null)
            {
                _typeNode.Print(writer);
            }
>>>>>>> 1ec71635b (sync with main branch)

            writer.Write("{");
            writer.Write(string.Join<BaseNode>(", ", _nodes.ToArray()));
            writer.Write("}");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
