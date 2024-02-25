using System.IO;

namespace Ryujinx.HLE.HOS.Diagnostics.Demangler.Ast
{
    public class QualifiedName : BaseNode
    {
<<<<<<< HEAD
        private readonly BaseNode _qualifier;
        private readonly BaseNode _name;
=======
        private BaseNode _qualifier;
        private BaseNode _name;
>>>>>>> 1ec71635b (sync with main branch)

        public QualifiedName(BaseNode qualifier, BaseNode name) : base(NodeType.QualifiedName)
        {
            _qualifier = qualifier;
<<<<<<< HEAD
            _name = name;
=======
            _name      = name;
>>>>>>> 1ec71635b (sync with main branch)
        }

        public override void PrintLeft(TextWriter writer)
        {
            _qualifier.Print(writer);
            writer.Write("::");
            _name.Print(writer);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
