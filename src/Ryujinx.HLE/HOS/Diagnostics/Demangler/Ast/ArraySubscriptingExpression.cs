using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class ArraySubscriptingExpression : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _leftNode;
        private readonly BaseNode _subscript;

        public ArraySubscriptingExpression(BaseNode leftNode, BaseNode subscript) : base(NodeType.ArraySubscriptingExpression)
        {
            _leftNode = leftNode;
=======
        private BaseNode _leftNode;
        private BaseNode _subscript;

        public ArraySubscriptingExpression(BaseNode leftNode, BaseNode subscript) : base(NodeType.ArraySubscriptingExpression)
        {
            _leftNode  = leftNode;
>>>>>>> 1ec71635b (sync with main branch)
            _subscript = subscript;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write("(");
            _leftNode.Print(writer);
            writer.Write(")[");
            _subscript.Print(writer);
<<<<<<< HEAD
            writer.Write("]");
        }
    }
}
=======
            writer.Write("]");            
        }
    }
}
>>>>>>> 1ec71635b (sync with main branch)
