using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class PrefixExpression : ParentNode
    {
<<<<<<< HEAD
        private readonly string _prefix;
=======
        private string _prefix;
>>>>>>> 1ec71635b (sync with main branch)

        public PrefixExpression(string prefix, BaseNode child) : base(NodeType.PrefixExpression, child)
        {
            _prefix = prefix;
        }

        public override void PrintLeft(TextWriter writer)
        {
            writer.Write(_prefix);
            writer.Write("(");
            Child.Print(writer);
            writer.Write(")");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
