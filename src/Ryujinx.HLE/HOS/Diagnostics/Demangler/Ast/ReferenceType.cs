using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class ReferenceType : BaseNode
    {
<<<<<<< HEAD
        private readonly string _reference;
        private readonly BaseNode _child;
=======
        private string   _reference;
        private BaseNode _child;
>>>>>>> 1ec71635b (sync with main branch)

        public ReferenceType(string reference, BaseNode child) : base(NodeType.ReferenceType)
        {
            _reference = reference;
<<<<<<< HEAD
            _child = child;
=======
            _child     = child;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override bool HasRightPart()
        {
            return _child.HasRightPart();
        }

        public override void PrintLeft(TextWriter writer)
        {
            _child.PrintLeft(writer);

            if (_child.IsArray())
            {
                writer.Write(" ");
            }

            if (_child.IsArray() || _child.HasFunctions())
            {
                writer.Write("(");
            }

            writer.Write(_reference);
        }
        public override void PrintRight(TextWriter writer)
        {
            if (_child.IsArray() || _child.HasFunctions())
            {
                writer.Write(")");
            }

            _child.PrintRight(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
