using System.Collections.Generic;
using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class CallExpression : NodeArray
    {
<<<<<<< HEAD
        private readonly BaseNode _callee;
=======
        private BaseNode _callee;
>>>>>>> 1ec71635b (sync with main branch)

        public CallExpression(BaseNode callee, List<BaseNode> nodes) : base(nodes, NodeType.CallExpression)
        {
            _callee = callee;
        }

        public override void PrintLeft(TextWriter writer)
        {
            _callee.Print(writer);

            writer.Write("(");
            writer.Write(string.Join<BaseNode>(", ", Nodes.ToArray()));
            writer.Write(")");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
